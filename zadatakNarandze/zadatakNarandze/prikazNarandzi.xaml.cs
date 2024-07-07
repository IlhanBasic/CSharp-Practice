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
using System.Windows.Shapes;
using zadatakNarandze.View;

namespace zadatakNarandze
{
    /// <summary>
    /// Interaction logic for prikazNarandzi.xaml
    /// </summary>
    public partial class prikazNarandzi : Window
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public prikazNarandzi(int _Rows,int _Cols)
        {
            InitializeComponent();
            Cols = _Cols;
            Rows = _Rows;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pageGajbica pg = new pageGajbica(Rows,Cols);
            podloga.Content = pg;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            pageBaza baza = new pageBaza();
            podloga.Content = baza;
        }
    }
}
