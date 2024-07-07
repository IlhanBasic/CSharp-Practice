using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatakNarandze
{
    public class Narandza
    {
		private bool zdrava;

		public bool Zdrava
		{
			get { return zdrava; }
			set { zdrava = value; }
		}
		private string oznaka;

		public string Oznaka
		{
			get { return oznaka; }
			set { oznaka = value; }
		}
		private static int id;
		public static int Id
		{
			get { return id; }
			set
			{
				id++;
			}
		}

	}
}
