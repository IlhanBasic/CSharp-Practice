using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BenzinskaStanica
{
    public partial class MainWindow : Window
    {
        private BenzinskaStanica stanica;
        private Pumpa[] pumpe;
        private DispatcherTimer autoputTimer;
        private Random random = new Random();
        private const int KapacitetRezervoara = 50;
        private const int ProgressBarWidth = 200;
        private const int ProgressBarHeight = 20;

        public MainWindow()
        {
            InitializeComponent();
            stanica = new BenzinskaStanica();
            stanica.ZavrsenoSipanje += Stanica_ZavrsenoSipanje;

            pumpe = new Pumpa[4];
            for (int i = 0; i < pumpe.Length; i++)
            {
                pumpe[i] = new Pumpa();
                pumpe[i].ZavrsenoSipanje += Stanica_ZavrsenoSipanje;
            }

            autoputTimer = new DispatcherTimer();
            autoputTimer.Interval = TimeSpan.FromMilliseconds(random.Next(500, 1000));
            autoputTimer.Tick += AutoputTimer_Tick;
            autoputTimer.Start();

            stanica.Otvori();
        }

        private void AutoputTimer_Tick(object sender, EventArgs e)
        {
            Automobil auto = new Automobil(KapacitetRezervoara);
            stanica.DodajAutomobil(auto);
            RefreshQueueDisplay();
            autoputTimer.Interval = TimeSpan.FromMilliseconds(random.Next(500, 1000));
        }

        private void Stanica_ZavrsenoSipanje(object sender, int id)
        {
            Dispatcher.Invoke(() =>
            {
                RefreshQueueDisplay();
                RemoveProgressBar(id);
            });
        }

        private void RefreshQueueDisplay()
        {
            canvas.Children.Clear();
            int y = 10;
            foreach (var auto in stanica.RedCekanja.Where(a => a != null))
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = $"Auto ID: {auto.Id}",
                    Margin = new Thickness(10, y, 0, 0)
                };
                canvas.Children.Add(textBlock);
                y += 20;
            }

            y = 50;
            int x = 10;
            foreach (var pumpa in pumpe)
            {
                if (pumpa.TrenutniAutomobil != null)
                {
                    AddOrUpdateProgressBar(pumpa.TrenutniAutomobil, x, y);
                    pumpa.Start(); // Pokreni pumpu ako ima trenutni automobil
                    y += 50;
                }
            }
        }

        private void AddOrUpdateProgressBar(Automobil auto, int x, int y)
        {
            var existingRectangle = canvas.Children.OfType<Rectangle>()
                .FirstOrDefault(r => r.Tag != null && (int)r.Tag == auto.Id);

            if (existingRectangle == null)
            {
                Rectangle progressBar = new Rectangle
                {
                    Width = ProgressBarWidth,
                    Height = ProgressBarHeight,
                    Fill = Brushes.LightGray,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Tag = auto.Id
                };

                Rectangle progressFill = new Rectangle
                {
                    Width = ProgressBarWidth * (auto.TrenutnaKolicinaGoriva / KapacitetRezervoara),
                    Height = ProgressBarHeight,
                    Fill = Brushes.Green,
                    Tag = auto.Id
                };

                TextBlock textBlock = new TextBlock
                {
                    Text = $"Auto ID: {auto.Id}",
                    Margin = new Thickness(x, y - 20, 0, 0)
                };

                Canvas.SetLeft(progressBar, x);
                Canvas.SetTop(progressBar, y);
                Canvas.SetLeft(progressFill, x);
                Canvas.SetTop(progressFill, y);

                canvas.Children.Add(progressBar);
                canvas.Children.Add(progressFill);
                canvas.Children.Add(textBlock);
            }
            else
            {
                var existingFill = canvas.Children.OfType<Rectangle>()
                    .FirstOrDefault(r => r.Tag != null && (int)r.Tag == auto.Id && r.Fill == Brushes.Green);

                if (existingFill != null)
                {
                    existingFill.Width = ProgressBarWidth * (auto.TrenutnaKolicinaGoriva / KapacitetRezervoara);
                }
            }
        }

        private void RemoveProgressBar(int id)
        {
            var progressBar = canvas.Children.OfType<Rectangle>()
                .FirstOrDefault(r => r.Tag != null && (int)r.Tag == id);
            var progressFill = canvas.Children.OfType<Rectangle>()
                .FirstOrDefault(r => r.Tag != null && (int)r.Tag == id && r.Fill == Brushes.Green);
            var textBlock = canvas.Children.OfType<TextBlock>()
                .FirstOrDefault(tb => tb.Text.Contains($"Auto ID: {id}"));

            if (progressBar != null) canvas.Children.Remove(progressBar);
            if (progressFill != null) canvas.Children.Remove(progressFill);
            if (textBlock != null) canvas.Children.Remove(textBlock);
        }


        public class Automobil
        {
            private static int trenutniMaksId = 0;
            public int Id { get; private set; }
            public int KapacitetRezervoara { get; private set; }
            public double TrenutnaKolicinaGoriva { get; private set; }

            public Automobil(int kapacitetRezervoara)
            {
                Id = ++trenutniMaksId;
                KapacitetRezervoara = kapacitetRezervoara;
                Random rnd = new Random();
                TrenutnaKolicinaGoriva = rnd.Next((int)(0.1 * kapacitetRezervoara), (int)(0.3 * kapacitetRezervoara));
            }

            public void SipajGorivo(double kolicina)
            {
                if (TrenutnaKolicinaGoriva + kolicina > KapacitetRezervoara)
                {
                    TrenutnaKolicinaGoriva = KapacitetRezervoara;
                    throw new InvalidOperationException("Rezervoar je prepunjen.");
                }
                else
                {
                    TrenutnaKolicinaGoriva += kolicina;
                }
            }

            public override string ToString()
            {
                return $"Id: {Id}, Kapacitet: {KapacitetRezervoara}l, Trenutna količina: {TrenutnaKolicinaGoriva}l";
            }
        }

        public class BenzinskaStanica
        {
            public event EventHandler<int> ZavrsenoSipanje;
            private Automobil[] redCekanja = new Automobil[20];
            private int brojAutomobilaURedu = 0;
            private bool otvorena = false;

            public bool Otvorena => otvorena;

            public Automobil[] RedCekanja => redCekanja;

            public void Otvori()
            {
                if (otvorena)
                    throw new InvalidOperationException("Stanica je već otvorena.");

                otvorena = true;
            }

            public void Zatvori()
            {
                if (!otvorena)
                    throw new InvalidOperationException("Stanica je već zatvorena.");

                otvorena = false;
            }

            public void DodajAutomobil(Automobil auto)
            {
                if (!otvorena || brojAutomobilaURedu >= 20)
                    return;

                redCekanja[brojAutomobilaURedu] = auto;
                brojAutomobilaURedu++;
            }

            public void IzvadiAutomobil(int index)
            {
                if (index < 0 || index >= brojAutomobilaURedu)
                    throw new IndexOutOfRangeException("Neispravan indeks automobila.");

                for (int i = index; i < brojAutomobilaURedu - 1; i++)
                {
                    redCekanja[i] = redCekanja[i + 1];
                }

                redCekanja[brojAutomobilaURedu - 1] = null;
                brojAutomobilaURedu--;
            }

            public void DojaviZavrsenoSipanje(int id)
            {
                ZavrsenoSipanje?.Invoke(this, id);
            }
        }

        public class Pumpa
        {
            public event EventHandler<int> ZavrsenoSipanje;
            private const int brzinaSipanja = 100; // simulacija brzine sipanja u milisekundama
            private DispatcherTimer timer;
            private double potrebnaKolicina;

            public Automobil TrenutniAutomobil { get; private set; }

            public Pumpa()
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(brzinaSipanja);
                timer.Tick += Timer_Tick;
            }

            public void Start()
            {
                timer.Start();
            }

            private void Timer_Tick(object sender, EventArgs e)
            {
                if (TrenutniAutomobil == null)
                {
                    return; // Ako nema automobila, ne radi ništa
                }

                if (potrebnaKolicina > 0)
                {
                    TrenutniAutomobil.SipajGorivo(1);
                    potrebnaKolicina--;
                }
                else
                {
                    ZavrsenoSipanje?.Invoke(this, TrenutniAutomobil.Id);
                    TrenutniAutomobil = null;
                    timer.Stop();
                }
            }

            public void SipajGorivo(Automobil auto)
            {
                if (TrenutniAutomobil != null)
                    throw new InvalidOperationException("Pumpa je već zauzeta.");

                TrenutniAutomobil = auto;
                potrebnaKolicina = auto.KapacitetRezervoara - auto.TrenutnaKolicinaGoriva;
                timer.Start();
            }
        }
    }
}
