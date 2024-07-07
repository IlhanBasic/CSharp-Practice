using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace igraJurke
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        DispatcherTimer gameTimer = new DispatcherTimer();
        int xSmer = 1, ySmer = 1;
        float xBrzina = 3f, yBrzina = 3f, xPomeraj = 0, yPomeraj = 300f;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Set DataContext here
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            xPomeraj = r.Next(0, (int)this.ActualWidth);

            // Add MouseDown event for kuglica
            kuglica.MouseDown += Kuglica_MouseDown;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Rect rkugla = new Rect(Canvas.GetLeft(kugla), Canvas.GetTop(kugla), kugla.Width, kugla.Height);
            Rect rkuglica = new Rect(Canvas.GetLeft(kuglica), Canvas.GetTop(kuglica), kuglica.Width, kuglica.Height);

            if (rkuglica.IntersectsWith(rkugla))
            {
                // If kuglica reaches kugla
                Score++;
                xBrzina++;
                yBrzina++;
                SpawnKuglica();
            }
            else if (Canvas.GetLeft(kuglica) >= this.ActualWidth || Canvas.GetTop(kuglica) >= this.ActualHeight)
            {
                SpawnKuglica();
            }

            Canvas.SetLeft(kuglica, Canvas.GetLeft(kuglica) + (xSmer * xBrzina));
            Canvas.SetTop(kuglica, Canvas.GetTop(kuglica) + (ySmer * yBrzina));
        }

        private void Kuglica_MouseDown(object sender, MouseButtonEventArgs e)
        {
            xSmer *= -1;
            ySmer *= -1;
            xBrzina++;
            yBrzina++;
            SpawnKuglica();
        }

        private void SpawnKuglica()
        {
            Canvas.SetLeft(kuglica, r.Next(0, (int)(this.ActualWidth - kuglica.Width)) / 2);
            Canvas.SetTop(kuglica, r.Next(0, (int)(this.ActualHeight - kuglica.Height)));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            xSmer = 1; ySmer = 1; Score = 0; xBrzina = 30f; yBrzina = 30f; xPomeraj = 0; yPomeraj = 300f;
            gameTimer.Start();
            SpawnKuglica();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Stop();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
