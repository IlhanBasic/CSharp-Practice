using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace zadatakNarandze.View
{
    /// <summary>
    /// Interaction logic for pageGajbica.xaml
    /// </summary>
    public partial class pageGajbica : Page
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        private Ellipse[,] ellipses;
        private Lista lista;

        public pageGajbica(int _Cols, int _Rows)
        {
            InitializeComponent();
            Rows = _Rows;
            Cols = _Cols;
            lista = new Lista(Rows, Cols); // Assuming Lista has a constructor that takes Rows and Cols
            PrikazMatrice();
        }

        public void PrikazMatrice()
        {
            AktivnaPodloga.Children.Clear();
            ellipses = new Ellipse[Rows, Cols];
            double ellipseWidth = AktivnaPodloga.ActualWidth / Cols;
            double ellipseHeight = AktivnaPodloga.ActualHeight / Rows;

            Random r = new Random();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    bool zdravaNezdrava = r.Next(2) == 0;
                    lista.narandzas[i, j] = new Narandza
                    {
                        Oznaka = $"narandza {i}-{j}",
                        Zdrava = zdravaNezdrava
                    };

                    ellipses[i, j] = new Ellipse
                    {
                        Width = ellipseWidth,
                        Height = ellipseHeight,
                        Visibility = Visibility.Visible,
                        Fill = lista.narandzas[i, j].Zdrava ? Brushes.Orange : Brushes.Black
                    };

                    Canvas.SetTop(ellipses[i, j], i * ellipseHeight);
                    Canvas.SetLeft(ellipses[i, j], j * ellipseWidth);
                    AktivnaPodloga.Children.Add(ellipses[i, j]);
                }
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            PrikazMatrice();
        }

        private void btnPokvari_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (ellipses[i, j].Fill == Brushes.Black)
                    {
                        if (i + 1 < Rows)
                            ellipses[i + 1, j].Fill = Brushes.Black;
                        if (i - 1 > 0)
                            ellipses[i - 1, j].Fill = Brushes.Black;
                        if (j + 1 < Cols)
                            ellipses[i, j + 1].Fill = Brushes.Black;
                        if (j - 1 > 0)
                            ellipses[i, j - 1].Fill = Brushes.Black;

                    }
                }
            }
        }


        private void btnSnimi_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
