﻿using System;
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
		static Global()
		{
			kontroler = new Kontroler();
			panelKontroler1 = kontroler.panele[0];
			panelKontroler2 = kontroler.panele[1];
			panelKontrolerDodatkowy = kontroler.dodatkowy;
			główny = new GłównyEkran();
			formy = new List<IOperatable> { kontroler, główny };
			pytania1 = new List<Pytanie1>();
			pytania2 = new Pytanie2[5];

			znaki = new Dictionary<char, Image>()
			{
				{'A', Resources.a},
				{'B', Resources.b},
				{'C', Resources.b},
				{'D', Resources.b},
				{'E', Resources.b},
				{'F', Resources.b},
				{'G', Resources.b},
				{'H', Resources.b},
				{'I', Resources.b},
				{'J', Resources.b},
				{'K', Resources.b},
				{'L', Resources.b},
				{'M', Resources.b},
				{'N', Resources.b},
				{'O', Resources.b},
				{'P', Resources.b},
				{'R', Resources.b},
				{'S', Resources.b},
				{'T', Resources.b},
				{'U', Resources.b},
				{'W', Resources.b},
				{'Y', Resources.b},
				{'Z', Resources.b},
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

			tablica1 = new Tablica(główny.panele[0], 30, 10, Resources.puste);
			tablica2 = new Tablica(główny.panele[1], 30, 10, Resources.puste);
			tablicaPunkty = new Tablica(główny.panelPunkty, 3, 1, Resources.puste);
			tablicaPunktyDrużyny = new List<Tablica> { new Tablica(główny.panelPunktyL, 3, 1, Resources.puste), new Tablica(główny.panelPunktyP, 3, 1, Resources.puste) };
			drużyny = new List<Drużyna> { new DrużynaL(), new DrużynaP() };
		}

		public const string plik1 = "runda1.txt";
		public const string plik2 = "runda2.txt";

		public const int długośćOdpowiedzi1 = 17;
		public const int długośćOdpowiedzi2 = 10;

		public static Kontroler kontroler { get; private set; }
		public static Panel panelKontroler1 { get; private set; }
		public static Panel panelKontroler2 { get; private set; }
		public static Panel panelKontrolerDodatkowy { get; private set; }
		public static GłównyEkran główny { get; private set; }
		private static List<IOperatable> formy;

		public static List<Pytanie1> pytania1 { get; private set; }
		public static Pytanie2[] pytania2 { get; private set; }

		public static Dictionary<char, Image> znaki { get; private set; }

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
				if (lewo)
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
				if (lewo)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				else
					Zonk.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
			return Zonk;
		}
		private static Bitmap zonkMały(bool góra)
		{
			Bitmap Zonk = (Bitmap)(Resources.zonkMałyG.Clone());
			if (góra)
				Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
			return Zonk;
		}

		public static Tablica tablica1 { get; private set; }
		public static Tablica tablica2 { get; private set; }
		public static Tablica tablicaPunkty { get; private set; }
		public static List<Tablica> tablicaPunktyDrużyny { get; private set; }

		public static List<Drużyna> drużyny { get; private set; }

		static public void pokażPanel(int który)
		{
			formy.ForEach(e => e.pokażPanel(który));
		}
		static public void ukryjPanel(int który)
		{
			formy.ForEach(e => e.ukryjPanel(który));
		}
		static public void ustawPunktyGłówne(int punkty)
		{
			formy.ForEach(e => e.ustawPunktyGłówne(punkty));
		}
		static public void ustawPunktyDrużyny(int która, int punkty)
		{
			formy.ForEach(e => e.ustawPunktyDrużyny(która, punkty));
		}

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
