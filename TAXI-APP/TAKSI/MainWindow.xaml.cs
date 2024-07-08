using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TAKSI
{
    public struct Taxi
    {
        public string TaxiIme { get; set; }
        public string TipVozila { get; set; }
        public double CenaKm { get; set; }
        public string Dostupnost { get; set; }
        public override string ToString()
        {
            return $"{TipVozila},{TaxiIme}, {CenaKm}, {Dostupnost}";
        }
    }
    public partial class MainWindow : Window
    {
        private List<Taxi> taxis = new List<Taxi>();

        public MainWindow()
        {
            InitializeComponent();
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            try
            {
                string[] lines = File.ReadAllLines("ulazna.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string[] nameParts = parts[0].Split(':');
                        string taxiName = nameParts[1].Trim();

                        string[] typeParts = parts[1].Split(':');
                        string vehicleType = typeParts[1].Trim();

                        string[] priceParts = parts[2].Split(':');
                        double pricePerKm = double.Parse(priceParts[1]);

                        string[] availabilityParts = parts[3].Split(':');
                        string availability = availabilityParts[1].Trim();
                        if (availability == "-")
                        {
                            availability = "SLOBODAN";
                        }
                        if (availability == "+")
                        {
                            availability = "ZAUZET";
                        }

                        Taxi taxi = new Taxi
                        {
                            TaxiIme = taxiName,
                            TipVozila = vehicleType,
                            CenaKm = pricePerKm,
                            Dostupnost = availability
                        };
                        taxis.Add(taxi);
                    }
                }
                listaTaxi.ItemsSource = null;
                listaTaxi.ItemsSource = taxis;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom učitavanja taksija: " + ex.Message);
            }
        }



        private void btnPotvrda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                maksimalni.Text = string.Empty;
                ukupnaZarada.Text = string.Empty;
                ukVozila.Text = string.Empty;
                double money;
                if (!double.TryParse(unosNovca.Text, out money) || money <= 0)
                {
                    MessageBox.Show("Unesite ispravan iznos novca.");
                    return;
                }

                string vehicleType = ((ComboBoxItem)cbType.SelectedItem)?.Content.ToString();

                if (string.IsNullOrWhiteSpace(vehicleType))
                {
                    MessageBox.Show("Molimo odaberite vrstu vozila.");
                    return;
                }

                using (StreamWriter w = new StreamWriter("izlazna.txt"))
                {
                    foreach (var taxi in taxis)
                    {
                        w.WriteLine($"{taxi.TipVozila}, {taxi.TaxiIme}, {taxi.CenaKm}, {taxi.Dostupnost}");
                    }

                    var max = taxis
                        .Where(t => t.Dostupnost == "SLOBODAN")
                        .OrderByDescending(t => kilometraza(money, t.CenaKm))
                        .FirstOrDefault();

                    w.WriteLine($"Najvecu potencijalnu zaradu ostvarice: {max.TipVozila}, {max.TaxiIme}, {max.CenaKm}, {max.Dostupnost}");

                    double totalEarnings = taxis
                    .Where(t => t.Dostupnost == "ZAUZET")
                    .Sum(t => money * 0.1);


                    w.WriteLine($"Ukupna zarada od zauzetih taksija: {totalEarnings}");

                    int freeTaxisCount = taxis.Count(t => t.Dostupnost == "SLOBODAN" && t.TipVozila.ToUpper() == vehicleType.ToUpper());
                    w.WriteLine($"Broj slobodnih taksija tipa {vehicleType}: {freeTaxisCount}");
                    maksimalni.Text = $"Najveca zarada: {max.TaxiIme}";
                    ukupnaZarada.Text = $"Ukupna zarada kompanije:{totalEarnings}";
                    ukVozila.Text = $"Broj slobodnih {vehicleType}: {freeTaxisCount}";
                    prikaz.Visibility = Visibility.Visible;
                    var tabela = taxis
                    .Where(t => t.Dostupnost == "SLOBODAN" && t.TipVozila.ToUpper() == vehicleType.ToUpper())
                    .ToList();
                    if (tabela.Count > 0)
                    {
                        listaTaxi.ItemsSource = tabela;
                    }
                    else
                    {
                        MessageBox.Show("Nema dostupnih taksi vozila za taj tip!");
                    }
                }

                unosNovca.Text = string.Empty;
                cbType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom obrade: " + ex.Message);
            }
        }


        public double kilometraza(double novac, double cena)
        {
            if (novac < cena || cena == 0)
            {
                return 0;
            }
            return novac / cena;
        }
    }


}
