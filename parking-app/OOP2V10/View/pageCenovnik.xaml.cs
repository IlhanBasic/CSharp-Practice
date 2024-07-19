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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP2V10.View
{
    /// <summary>
    /// Interaction logic for Cenovnik.xaml
    /// </summary>
    public partial class pageCenovnik : Page, INotifyPropertyChanged
    {
        private Cenovnik cenovnik;
        public Cenovnik Cenovnik
        {
            get { return cenovnik; }
            set { cenovnik = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Parking_servisEntities parking_ServisEntities = new Parking_servisEntities();
        public pageCenovnik()
        {
            Cenovnik = parking_ServisEntities.Cenovniks.FirstOrDefault();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parking_ServisEntities.SaveChanges();
            MessageBox.Show("Uspesno snimanje podataka");
        }
    }
}
