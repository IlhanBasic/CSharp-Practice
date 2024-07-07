using System;

namespace zadatakNarandze
{
    public class Lista
    {
        public Narandza[,] narandzas;

        public delegate void NarandzaHandler(object source, NarandzaEventArgs args);
        public event NarandzaHandler PokvarilaSe;

        public Lista(int rows, int cols)
        {
            narandzas = new Narandza[rows, cols];
        }

        public void ProcesKvarenja(Narandza narandza)
        {
            // Simulate the process of an orange going bad
            if (narandza.Zdrava)
            {
                narandza.Zdrava = false;
                OnPokvarilaSe(narandza);
            }
        }

        protected virtual void OnPokvarilaSe(Narandza narandza)
        {
            if (PokvarilaSe != null)
            {
                PokvarilaSe(this, new NarandzaEventArgs { Narandza = narandza });
            }
        }
    }

    public class NarandzaEventArgs : EventArgs
    {
        public Narandza Narandza { get; set; }
    }

    
}
