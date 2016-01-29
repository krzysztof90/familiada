using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	class Global
	{
		public static string plik1 = "runda1.txt";
		public static string plik2 = "runda2.txt";

		public static int długośćOdpowiedzi1 = 17;
		public static int długośćOdpowiedzi2 = 10;

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
				{'a', Resources.a},
				{'b', Resources.b},
				{'c', Resources.b},
				{'d', Resources.b},
				{'e', Resources.b},
				{'f', Resources.b},
				{'g', Resources.b},
				{'h', Resources.b},
				{'i', Resources.b},
				{'j', Resources.b},
				{'k', Resources.b},
				{'l', Resources.b},
				{'m', Resources.b},
				{'n', Resources.b},
				{'o', Resources.b},
				{'p', Resources.b},
				{'r', Resources.b},
				{'s', Resources.b},
				{'t', Resources.b},
				{'u', Resources.b},
				{'w', Resources.b},
				{'y', Resources.b},
				{'z', Resources.b},
				{'0', Resources.c0},
				{'1', Resources.c1},
				{'2', Resources.c2},
				{'3', Resources.c3},
				{'4', Resources.c4},
				{'5', Resources.c5},
				{'6', Resources.c6},
				{'7', Resources.c7},
				{'8', Resources.c8},
				{'9', Resources.c9},
				{'-', Resources.minus},
				{'.', Resources.kropka},
				{' ', Resources.puste},
				{'|', Resources.punktyPuste},
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
			Bitmap Zonk = (Bitmap)(Resources.zonkDużyGL.Clone());
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
			Bitmap Zonk = (Bitmap)(Resources.zonkMałyGL.Clone());
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
			Bitmap Zonk = (Bitmap)(Resources.zonkMałyG.Clone());
			if(góra)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				return Zonk;
		}

		public static Drużyna drużynaL = new Drużyna(true);
		public static Drużyna drużynaP = new Drużyna(false);

		public static Tablica tablica1 = new Tablica(panelGłówny1, 30, 10, Resources.puste);
		public static Tablica tablica2 = new Tablica(panelGłówny2, 30, 10, Resources.puste);
		public static Tablica tablicaPunkty = new Tablica(główny.panelPunkty, 3, 1, Resources.puste);

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
