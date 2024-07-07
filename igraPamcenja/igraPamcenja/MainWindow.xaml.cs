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
using System.Windows.Threading;

namespace igraPamcenja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        private DateTime startTime;
        private Button[,] dugmad;
        Button btnPrvo;
        Button btnDrugo;
        Button btnPogodak;
        Button[] parDugmadi;
        bool promenjenoPrvo = false;
        bool promenjenoDrugo = false;
        private TimeSpan stoperica;

        public TimeSpan Stoperica
        {
            get { return stoperica; }
            set
            {
                stoperica = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainWindow()
        {
            InitializeComponent();
            napraviPodlogu();
            btnPogodak = new Button();
            btnPrvo = new Button();
            btnDrugo = new Button();
            parDugmadi = new Button[2];
            parDugmadi[0] = btnPrvo;
            parDugmadi[1] = btnDrugo;
            startTime = DateTime.Now;
            gameTimer.Interval = TimeSpan.FromMilliseconds(500);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            Stoperica = TimeSpan.FromSeconds(Math.Floor(elapsed.TotalSeconds));
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            napraviPodlogu();
        }
        public void napraviPodlogu()
        {
            podloga.Children.Clear();
            dugmad = new Button[4, 5];
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    dugmad[i, j] = new Button();
                    dugmad[i, j].Width = podloga.ActualWidth / 5;
                    dugmad[i, j].Height = podloga.ActualHeight / 4;
                    dugmad[i, j].FontSize = 20;
                    dugmad[i, j].Content = $"?";
                    dugmad[i, j].Background = Brushes.White;
                    dugmad[i, j].Click += btnPogodi_Click;
                    dugmad[i, j].Tag = r.Next(1, 10);
                    Canvas.SetTop(dugmad[i, j], i * dugmad[i, j].Height);
                    Canvas.SetLeft(dugmad[i, j], j * dugmad[i, j].Width);
                    podloga.Children.Add(dugmad[i, j]);
                }
            }
        }

        private void btnPogodi_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Start();
            Button btn = sender as Button;
            btn.Content = $"{btn.Tag}";

            if (promenjenoPrvo && promenjenoDrugo)
            {
                // If two cards are already open, reset their state
                parDugmadi[0].Content = "?";
                parDugmadi[1].Content = "?";
                promenjenoPrvo = false;
                promenjenoDrugo = false;
            }

            // Check if the clicked card is already open
            if (btn != parDugmadi[0] && btn != parDugmadi[1])
            {
                // If not, proceed with opening the card
                if (!promenjenoPrvo)
                {
                    parDugmadi[0] = btn;
                    promenjenoPrvo = true;
                }
                else if (!promenjenoDrugo)
                {
                    parDugmadi[1] = btn;
                    promenjenoDrugo = true;
                }
            }

            if (promenjenoPrvo && promenjenoDrugo && parDugmadi[0].Tag == parDugmadi[1].Tag && btn.Tag==btnPogodak.Tag)
            {
                // If the cards match, change their background to green and keep their content
                btn.Background = Brushes.Green;
                parDugmadi[1].Background = Brushes.Green;
                gameTimer.Stop();
                parDugmadi[0].IsEnabled = false;
                parDugmadi[1].IsEnabled = false;
            }
            
        }





        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            startTime = DateTime.Now;
            gameTimer.Start();
            napraviPodlogu();
            btnDrugo = new Button();
            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Stop();
            napraviPodlogu();
            btnDrugo = new Button();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
    }
}
