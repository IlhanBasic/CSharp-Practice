using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vojska.View
{
    /// <summary>
    /// Interaction logic for pageListaVojnika.xaml
    /// </summary>
    public partial class pageListaVojnika : Page, INotifyPropertyChanged { 


        private ObservableCollection<Vojnik> vojnici;
        public ObservableCollection<Vojnik> Vojnici 
        {
            get {  return vojnici; }
            set
            {
                vojnici = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Vojnik> temp { get; set; }
        public pageListaVojnika(Vod vojska)
        {
            Vojnici = new ObservableCollection<Vojnik>();
            temp = new ObservableCollection<Vojnik>();
            if (vojska.Vojniks != null)
            {
                foreach (var voj in vojska.Vojniks)
                {
                    Vojnici.Add(voj);
                }
                foreach (var voj in vojska.Vojniks)
                {
                    temp.Add(voj);
                }
            }

            InitializeComponent();
            DataContext = this; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag != null)
            {
                int id = int.Parse(btn.Tag.ToString());
                var vojnik = Vojnici.FirstOrDefault(p => p.Id == id);
                if (vojnik != null)
                {
                    vojnik.UnaprediVojnika();
                    Refresh();
                }
            }
        }

        private void Refresh()
        {
            Vojnici = new ObservableCollection<Vojnik>(temp);
        }
        private void cinovi_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas can = (Canvas)sender;
            Vojnik vojnik = (Vojnik)can.DataContext;

            if (vojnik != null)
            {
                int numberOfRectangles = 1;

                switch (vojnik.cinVojnika.ToString().ToLower())
                {
                    case "mladjiVodnik":
                        numberOfRectangles = 1;
                        break;
                    case "razvodnik":
                        numberOfRectangles = 2;
                        break;
                    case "desetar":
                        numberOfRectangles = 3;
                        break;
                    default:
                        break;
                }


                for (int i = 0; i < numberOfRectangles; i++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Height = 20;
                    rec.Width = 20;
                    rec.Fill = Brushes.Black;

                    Canvas.SetTop(rec, 0); 
                    Canvas.SetLeft(rec, i * 25);

                    can.Children.Add(rec);
                }
            }
        }
    }

}
