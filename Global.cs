using System;
using System.Collections.Generic;
using System.Drawing;
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
		
		public static Dictionary<char, Image> znaki = new Dictionary<char, Image>()
			{
				{'a', global::familiada.Properties.Resources.a},
				{'b', global::familiada.Properties.Resources.b},
				{'0', global::familiada.Properties.Resources.b},
				{' ', global::familiada.Properties.Resources.puste},
			};

		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		public static Tablica tablica1 = new Tablica(główny.panel1, 30, 10, global::familiada.Properties.Resources.puste);
		public static Tablica tablica2 = new Tablica(główny.panel2, 30, 10, global::familiada.Properties.Resources.puste);
		public static Tablica tablicaPunkty = new Tablica(główny.panelPunkty, 3, 1, global::familiada.Properties.Resources.puste);

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
