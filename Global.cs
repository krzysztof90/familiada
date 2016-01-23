using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	class Global
	{
		public static string nazwaPliku = "pytania.txt";

		public static Kontroler pomocniczy = new Kontroler();
		public static GłównyEkran główny = new GłównyEkran();
		
		public static List<Pytanie> pytania = new List<Pytanie>();
		public static int obecnePytanie = -1;
		
		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
