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
		public static Panel panelKontroler1 = kontroler.panel1;
		public static Panel panelKontroler2 = kontroler.panel2;
		public static Panel panelKontrolerDodatkowy = kontroler.dodatkowy;
		public static GłównyEkran główny = new GłównyEkran();
		public static Panel panelGłówny1 = główny.panel1;
		public static Panel panelGłówny2 = główny.panel2;
		public static Panel panelGłównyDodatkowy = główny.dodatkowy;
		
		public static List<Pytanie1> pytania1 = new List<Pytanie1>();
		public static Pytanie2[] pytania2 = new Pytanie2[5];
		
		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
