using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for pageParking.xaml
    /// </summary>
    public partial class pageParking : Page
    {
        Parking_servisEntities parking_ServisEntities = new Parking_servisEntities();
        public ObservableCollection<Parking> Parkings { get; set; } = new ObservableCollection<Parking>();
        public pageParking()
        {
            var list = parking_ServisEntities.Parkings.ToList();
            foreach(var l in list)
                Parkings.Add(l);
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = cb.SelectedItem as Parking;
            TimeSpan razlika = DateTime.Now - selected.Vreme;
            Cenovnik cenovnik = parking_ServisEntities.Cenovniks.First();
            if(razlika.Hours >= 8)
            {
                MessageBox.Show($"Za naplatu {cenovnik.CenaDan}");
            }
            else
            {
                int sati = (razlika.Minutes == 0 && razlika.Seconds == 0) ? razlika.Hours : razlika.Hours + 1;
                MessageBox.Show($"Za naplatu {cenovnik.CenaSat*sati}");
            }
            await SnimanjeUBazi(selected);
        }
        private async Task SnimanjeUBazi(Parking selected)
        {
            await Task.Run(() => {
                Thread.Sleep(10000);
                MessageBox.Show("Evo me posle 10 sekundi");
                }
            );
            parking_ServisEntities.Parkings.Remove(selected);
            await parking_ServisEntities.SaveChangesAsync();
            Parkings.Remove(selected);
        }
    }
}
