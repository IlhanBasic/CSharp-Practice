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

namespace vojska.View
{
    /// <summary>
    /// Interaction logic for dodajVojnika.xaml
    /// </summary>
    public partial class dodajVojnika : Page, INotifyPropertyChanged
    {
        private Vojnik _vojnik;
        private Vod _vod; // Čuva referencu na Vod instancu

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Vojnik _Vojnik
        {
            get { return _vojnik; }
            set
            {
                _vojnik = value;
                OnPropertyChanged();
            }
        }

        public dodajVojnika(Vod vod)
        {
            InitializeComponent();
            _Vojnik = new Vojnik();
            _vod = vod; // Inicijalizacija Vod instance
        }

        private void Validacija(Vojnik v)
        {
            if (string.IsNullOrEmpty(v.Ime) || string.IsNullOrEmpty(v.Prezime) ||
                v.Ime.Any(char.IsDigit) || v.Prezime.Any(char.IsDigit) ||
                !IsValidDateTime(v.Datum.ToString("MM/dd/yyyy")))
            {
                MessageBox.Show("Morate uneti ispravne podatke o vojniku");
            }
            else
            {
                _vod.DodajVojnika(v); // Dodavanje vojnika u postojeću Vod kolekciju
                MessageBox.Show("Vojnik uspesno dodat");
            }
        }

        public bool IsValidDateTime(string input)
        {
            DateTime result;
            return DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Validacija(_Vojnik);
        }
    }

}
