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

namespace trkaPlivanje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private int brPlivackihStaza;

        public int BrPlivackihStaza
        {
            get { return brPlivackihStaza; }
            set 
            { 
                brPlivackihStaza = value;
                OnPropertyChanged();
            }
        }
        private String imenaPlivaca;

        public String ImenaPlivaca
        {
            get { return imenaPlivaca; }
            set 
            { 
                imenaPlivaca = value;
                OnPropertyChanged();
            }
        }
        private float duzinaBazena;

        public float DuzinaBazena
        {
            get { return duzinaBazena; }
            set 
            { 
                duzinaBazena = value;
                OnPropertyChanged();
            }
        }
        private int vmax;

        public int Vmax
        {
            get { return vmax; }
            set 
            { 
                
                vmax = value;
                    OnPropertyChanged();
                
                //MessageBox.Show("Molimo unesite brzinu od 1 do 5");
            
            }
        }
        private string[] plivaci;

        public string[] Plivaci
        {
            get { return plivaci; }
            set
            { 
                plivaci = value;
                OnPropertyChanged();
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            BrPlivackihStaza = 0;
            ImenaPlivaca = ""; // postavljeno na prazan niz
            DuzinaBazena = 0;
            Vmax = 0;
            plivaci = new string[0];
        }

        private void btnPotvrda_Click(object sender, RoutedEventArgs e)
        {
            plivaci = ImenaPlivaca.Split(',');
            if (BrPlivackihStaza == 0 || ImenaPlivaca.Length == 0 || Vmax == 0 || DuzinaBazena == 0) // provera da li je ImenaPlivaca prazno
            {
                int result = 0;
                if (BrPlivackihStaza == 0 || !int.TryParse(BrPlivackihStaza.ToString(), out result))
                {
                    MessageBox.Show("Pogresan unos broja plivackih staza");
                }
                else if (plivaci.Length != BrPlivackihStaza) // provera dužine ImenaPlivaca
                {
                    MessageBox.Show("Pogresan unos imena plivaca");
                }
                else if (Vmax <= 0 || Vmax >5)
                {
                    MessageBox.Show("Pogresan unos Vmax");

                }
                else if (DuzinaBazena == 0 || DuzinaBazena > this.ActualHeight)
                {
                    MessageBox.Show("Pogresan unos duzine bazena (visina do 450 px)");
                }

            }
            else
            {
                bazenTrka bt = new bazenTrka(BrPlivackihStaza, Plivaci, DuzinaBazena, Vmax);
                bt.Show();
                this.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
    public class Plivac
    {
        public static int id { get; } = 1;
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private int brzina;

        public int Brzina
        {
            get { return brzina; }
            set { brzina = value; }
        }
        public Plivac(string ime,int brzina)
        {
            this.Ime = ime;
            this.Brzina = brzina;
        }

    }
}
