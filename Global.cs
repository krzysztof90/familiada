using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class Global
	{
		public static string plik1 = "runda1.txt";
		public static string plik2 = "runda2.txt";

		public static Kontroler kontroler = new Kontroler();
		public static GłównyEkran główny = new GłównyEkran();
		
		public static List<Pytanie1> pytania1 = new List<Pytanie1>();
		public static int obecnePytanie = -1;
		public static Pytanie2[] pytania2 = new Pytanie2[5];
		
		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		static public void pokażPytania2()
		{
			foreach (Pytanie2 pytanie in Global.pytania2)
				pytanie.pokażPytanie();
		}
		static public void ukryjPytania2()
		{
			foreach (Pytanie2 pytanie in Global.pytania2)
				pytanie.ukryjPytanie();
		}

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
