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

		public static int długośćOdpowiedzi = 15;

		public static Kontroler kontroler = new Kontroler();
		public static Panel panelKontroler1 = kontroler.panel1;
		public static Panel panelKontroler2 = kontroler.panel2;
		public static Panel panelKontrolerDodatkowy = kontroler.dodatkowy;
		public static GłównyEkran główny = new GłównyEkran();
		public static Panel panelGłówny1 = główny.panel1;
		public static Panel panelGłówny2 = główny.panel2;

		public static List<Pytanie1> pytania1 = new List<Pytanie1>();
		public static Pytanie2[] pytania2 = new Pytanie2[5];

		public static Dictionary<char, Image> znaki = new Dictionary<char, Image>()
			{
				{'a', global::familiada.Properties.Resources.a},
				{'b', global::familiada.Properties.Resources.b},
				{'o', global::familiada.Properties.Resources.b},
				{'d', global::familiada.Properties.Resources.b},
				{'p', global::familiada.Properties.Resources.b},
				{'0', global::familiada.Properties.Resources.c0},
				{'1', global::familiada.Properties.Resources.c1},
				{'2', global::familiada.Properties.Resources.c2},
				{'3', global::familiada.Properties.Resources.c3},
				{'4', global::familiada.Properties.Resources.c4},
				{'5', global::familiada.Properties.Resources.c5},
				{'6', global::familiada.Properties.Resources.c6},
				{'7', global::familiada.Properties.Resources.c7},
				{'8', global::familiada.Properties.Resources.c8},
				{'9', global::familiada.Properties.Resources.c9},
				{'-', global::familiada.Properties.Resources.minus},
				{'.', global::familiada.Properties.Resources.kropka},
				{' ', global::familiada.Properties.Resources.puste},
				{'|', global::familiada.Properties.Resources.punktyPuste},
				{'˹', zonkDuży(true, true)},
				{'˺', zonkDuży(true, false)},
				{'˻', zonkDuży(false, true)},
				{'˼', zonkDuży(false, false)},
				{'┘', zonkMały(true, true)},
				{'└', zonkMały(true, false)},
				{'┐', zonkMały(false, true)},
				{'┌', zonkMały(false, false)},
				{'ˉ', zonkMały(true)},
				{'ˍ', zonkMały(false)},
			};

		private static Bitmap zonkDuży(bool góra, bool lewo)
		{
			Bitmap Zonk = (Bitmap)(global::familiada.Properties.Resources.zonkDużyGL.Clone());
			if (góra)
			{
				if (!lewo)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			else
			{
				if(lewo)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				else
					Zonk.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
				return Zonk;
		}
		private static Bitmap zonkMały(bool góra, bool lewo)
		{
			Bitmap Zonk = (Bitmap)(global::familiada.Properties.Resources.zonkMałyGL.Clone());
			if (góra)
			{
				if (!lewo)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			else
			{
				if(lewo)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				else
					Zonk.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
				return Zonk;
		}
		private static Bitmap zonkMały(bool góra)
		{
			Bitmap Zonk = (Bitmap)(global::familiada.Properties.Resources.zonkMałyG.Clone());
			if(góra)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				return Zonk;
		}

		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		public static Tablica tablica1 = new Tablica(panelGłówny1, 30, 10, global::familiada.Properties.Resources.puste);
		public static Tablica tablica2 = new Tablica(panelGłówny2, 30, 10, global::familiada.Properties.Resources.puste);
		public static Tablica tablicaPunkty = new Tablica(główny.panelPunkty, 3, 1, global::familiada.Properties.Resources.puste);

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
