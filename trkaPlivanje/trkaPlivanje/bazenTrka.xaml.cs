using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace trkaPlivanje
{
    /// <summary>
    /// Interaction logic for bazenTrka.xaml
    /// </summary>
    public partial class bazenTrka : Window,INotifyPropertyChanged
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        int BrStaza,Max;
        string[] imenaPlivaca;
        float duzinaBazena;
        Ellipse[] plivaci;
        Plivac[] _plivaci; 
        private Plivac prvi;

        public Plivac Prvi
        {
            get { return prvi; }
            set 
            { 
                prvi = value;
                OnPropertyChanged();
            }
        }
        private Plivac pobednik;

        public Plivac Pobednik
        {
            get { return pobednik; }
            set { pobednik = value; }
        }


        Random r = new Random();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bazenTrka(int BrStaza,string[] imenaPlivaca,float duzinaBazena,int Max)
        {
            InitializeComponent();
            this.BrStaza = BrStaza;
            this.imenaPlivaca = imenaPlivaca;
            this.duzinaBazena = duzinaBazena;
            this.Max = Max;
            plivaci = new Ellipse[BrStaza];
            _plivaci = new Plivac[BrStaza];
            for (int i = 0; i < BrStaza; i++)
            {
                _plivaci[i] = new Plivac(this.imenaPlivaca[i],Max);
                plivaci[i] = new Ellipse();
                plivaci[i].Height = duzinaBazena / BrStaza;
                plivaci[i].Width = 30;
                plivaci[i].Fill = Brushes.Black;
                Canvas.SetTop(plivaci[i], i * plivaci[i].Height);
                Canvas.SetLeft(plivaci[i], 0);
                bazen.Children.Add(plivaci[i]);
            }
            gameTimer.Interval = TimeSpan.FromMilliseconds(30);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            int tempBrzina = 1;
            int index = 0;
            Prvi = _plivaci[0]; 
            foreach (var v in plivaci)
            {
                tempBrzina = r.Next(1, Max);
                Canvas.SetLeft(v, Canvas.GetLeft(v) + (tempBrzina));
                if (Canvas.GetLeft(v) >= bazen.ActualWidth)
                {
                    gameTimer.Stop();
                    Pobednik = _plivaci[index];
                    tbPobeda.Visibility = Visibility.Visible;
                    tbPobeda.Text += Pobednik.Ime;
                    break;
                }
               
                if (Canvas.GetLeft(v) > Canvas.GetLeft(plivaci[Array.IndexOf(_plivaci, Prvi)]))
                {
                    Prvi = _plivaci[index];
                    tbPrvi.Visibility = Visibility.Visible;
                    tbPrvi.Text = "Prvi: " + Prvi.Ime;
                }
                index++;
            }
        }
    }
}
