using System;
using System.Collections.Generic;
using System.Linq;
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

namespace zadatakNarandze.View
{
    /// <summary>
    /// Interaction logic for pageBaza.xaml
    /// </summary>
    public partial class pageBaza : Page
    {
        Gajba gajba;
        public pageBaza()
        {
            gajba = new Gajba();
            InitializeComponent();
        }
    }
    public class Gajba
    {
        public DateTime DatumKreiranja { get; set; }
        public int BrKolona { get; set; }
        public int BrVrsta { get; set; }
        public int BrPokvarenih { get; set; }
        public int BrZdravih { get; set; }
        public float Procenat { get; set; }
        public List<Narandza> narandzas;
        public Gajba()
        {
            narandzas = new List<Narandza>
            {
                new Narandza{Oznaka="narandza1",Zdrava=true},
                new Narandza{Oznaka="narandza2",Zdrava=true},
                new Narandza{Oznaka="narandza3",Zdrava=false}
            };
            setPokvarene();
            setZdrave();
        }
        private void setPokvarene()
        {
            BrPokvarenih = narandzas.Count(p=>p.Zdrava==false);
        }
        private void setZdrave()
        {
            BrZdravih = narandzas.Count(p => p.Zdrava == true);
        }
        


    }
}
