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
using vojska.View;

namespace vojska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Vod _Vod { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _Vod = new Vod(); // Inicijalizacija Vod kolekcije
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dodajVojnika dv = new dodajVojnika(_Vod); // Prosledi instancu Vod
            mainContent.Content = dv;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            pageListaVojnika plv = new pageListaVojnika(_Vod); // Prosledi instancu Vod
            mainContent.Content = plv;
        }
    }
    public class VojnikEventHandlerArgs : EventArgs
    {
        public Vojnik _Vojnik { get; set; }
    }
    public class Vojnik
    {
        private static int trenutniId = 0;
        public int Id { get;private set; }
        public event EventHandler unapredjenjeVojnika;
        public void UnaprediVojnika()
        {
            if (cinVojnika==Cin.mladjiVodnik)
            {
                MessageBox.Show("Mladji vodnik se ne moze unaprediti");
            }else if (cinVojnika==Cin.desetar)
            {
                MessageBox.Show("Desetar se ne moze dalje unaprediti");
            }
            else
            {
                MessageBox.Show($"Vojnik {Ime} sa starim cinom {cinVojnika} je sada unapredjen u {Cin.desetar}");
                cinVojnika = Cin.desetar;
                unapredjenjeVojnika?.Invoke(this, new VojnikEventHandlerArgs { _Vojnik =  this});
            }
        }
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public Cin cinVojnika { get; set; }
        public enum Cin
        {
            razvodnik,
            desetar,
            mladjiVodnik
        }
        public override string ToString()
        {
            return $"Ime:{Ime},Prezime: {Prezime},Datum rodjenja: {Datum}, Cin vojnika: {cinVojnika}";
        }
        public Vojnik()
        {
            Id = ++trenutniId;
        }
    }
    public class Vod
    {
        public List<Vojnik> Vojniks { get; set; }

        public Vod()
        {
            Vojniks = new List<Vojnik>();
        }

        public void DodajVojnika(Vojnik v)
        {
            Vojniks.Add(v);
        }
    }
}
