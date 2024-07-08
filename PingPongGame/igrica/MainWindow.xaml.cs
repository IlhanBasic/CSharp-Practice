using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace igrica
{
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        int Xsmer = 1, Ysmer = 1;
        int pomerajIgraca = 10, score1 = 0, score2 = 0;

        float Xbrzina = 4f, Ybrzina = 4f, Xpomeraj = 0, Ypomeraj = 300f;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            Random r = new Random();
            Xpomeraj = r.Next((int)igrac1.Width, (int)this.Width);

            this.KeyDown += new KeyEventHandler(podloga_KeyDown);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Rect rpak = new Rect(Canvas.GetLeft(pak), Canvas.GetTop(pak), pak.Width, pak.Height);


            Rect rpl1 = new Rect(Canvas.GetLeft(igrac1), Canvas.GetTop(igrac1), igrac1.Width, igrac1.Height);
            Rect rpl2 = new Rect(Canvas.GetLeft(igrac2), Canvas.GetTop(igrac2), igrac2.Width, igrac2.Height);

            if (Canvas.GetTop(pak) <= 0 || Canvas.GetTop(pak) + pak.Height >= this.ActualHeight- controlPanel.ActualHeight)
            {
                Ysmer *= -1;
                Ybrzina++;
            }


            if (rpl1.IntersectsWith(rpak))
            {

                Xsmer *= -1;
                Xbrzina += 1.5f;
                score1++;
            }


            else if (rpl2.IntersectsWith(rpak))
            {

                Xsmer *= -1;
                Xbrzina += 1.5f;
                score2++;
            }

            else if (Canvas.GetLeft(pak) <= igrac1.Width - 20 && !rpl1.IntersectsWith(rpak))
            {

                gameTimer.Stop();
                MessageBox.Show($"Rezultati {score1} , {score2}");

            }
            else if (Canvas.GetLeft(pak) + pak.Width >= Canvas.GetLeft(igrac2) && !rpl2.IntersectsWith(rpak))
            {
                gameTimer.Stop();
                MessageBox.Show($"Rezultati {score1} , {score2}");
            }


            Canvas.SetLeft(pak, Canvas.GetLeft(pak) + (Xsmer * Xbrzina));
            Canvas.SetTop(pak, Canvas.GetTop(pak) + (Ysmer * Ybrzina));
        }

        private void podloga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && Canvas.GetTop(igrac2) > 0)
            {
                Canvas.SetTop(igrac2, Canvas.GetTop(igrac2) - pomerajIgraca);
            }
            else if (e.Key == Key.Down && Canvas.GetTop(igrac2) < this.ActualHeight - igrac2.Height)
            {
                Canvas.SetTop(igrac2, Canvas.GetTop(igrac2) + pomerajIgraca);
            }

            if (e.Key == Key.W && Canvas.GetTop(igrac1) > 0)
            {
                Canvas.SetTop(igrac1, Canvas.GetTop(igrac1) - pomerajIgraca);
            }
            else if (e.Key == Key.S && Canvas.GetTop(igrac1) < this.ActualHeight - igrac1.Height)
            {
                Canvas.SetTop(igrac1, Canvas.GetTop(igrac1) + pomerajIgraca);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Pokreće tajmer
            gameTimer.Start();
            // Onemogućava dugme "Start"
            btnStart.IsEnabled = false;
            // Omogućava dugme "Stop"
            btnStop.IsEnabled = true;
            Xbrzina = 4f; Ybrzina = 4f; Xpomeraj = 0; Ypomeraj = 300f;
            // Postavljanje loptice u sredinu ekrana po X osi
            double centerX = (this.Width - pak.Width) / 2;
            Canvas.SetLeft(pak, centerX);

            // Postavljanje loptice na početak po Y osi (možeš prilagoditi ako je potrebno)
            Canvas.SetTop(pak, 0);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gameTimer.Stop();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }


    }
}