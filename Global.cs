﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	static class Global
	{
		static Global()
		{
			kontroler = new Kontroler();
			panelKontroler1 = kontroler.paneleRundy[0];
			panelKontroler2 = kontroler.paneleRundy[1];
			panelKontrolerDodatkowy = kontroler.dodatkowy;
			główny = new GłównyEkran();
			formy = new List<IOperatable> { kontroler, główny };
			pytania1 = new List<Pytanie1>();
			pytania2 = new Pytanie2[5];

			znaki = new Dictionary<char, Image>
			{
				{'A', Resources.A},
				{'B', Resources.B},
				{'C', Resources.C},
				{'D', Resources.D},
				{'E', Resources.E},
				{'F', Resources.F},
				{'G', Resources.G},
				{'H', Resources.H},
				{'I', Resources.I},
				{'J', Resources.J},
				{'K', Resources.K},
				{'L', Resources.L},
				{'M', Resources.M},
				{'N', Resources.N},
				{'O', Resources.O},
				{'P', Resources.P},
				{'Q', Resources.Q},
				{'R', Resources.R},
				{'S', Resources.S},
				{'T', Resources.T},
				{'U', Resources.U},
				{'V', Resources.V},
				{'W', Resources.W},
				{'X', Resources.X},
				{'Y', Resources.Y},
				{'Z', Resources.Z},
				{'Ą', Resources.Ą},
				{'Ć', Resources.Ć},
				{'Ę', Resources.Ę},
				{'Ł', Resources.Ł},
				{'Ń', Resources.Ń},
				{'Ó', Resources.Ó},
				{'Ś', Resources.Ś},
				{'Ź', Resources.Ź},
				{'Ż', Resources.Ż},
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
				{',', Resources.przecinek},
				{'?', Resources.znakZapytania},
				{'/', Resources.slash},
				{'.', Resources.kropka},
				{' ', Resources.puste},
				{'|', Resources.punktyPuste},
				{'˹', ZwróćZonkDuży(true, true)},
				{'˺', ZwróćZonkDuży(true, false)},
				{'˻', ZwróćZonkDuży(false, true)},
				{'˼', ZwróćZonkDuży(false, false)},
				{'┘', ZwróćZonkMały(true, true)},
				{'└', ZwróćZonkMały(true, false)},
				{'┐', ZwróćZonkMały(false, true)},
				{'┌', ZwróćZonkMały(false, false)},
				{'ˉ', ZwróćZonkMały(true)},
				{'ˍ', ZwróćZonkMały(false)},
			};

			new Tablica(główny.panelRundy, 0, 0, Resources.puste); // TODO dispose po rundyButton.click
			tablica1 = new Tablica(główny.panele[0], Tablica.szerokość, Tablica.wysokość, Resources.puste);
			tablica2 = new Tablica(główny.panele[1], Tablica.szerokość, Tablica.wysokość, Resources.puste);
			tablicaPunkty = new Tablica(główny.panelPunkty, 3, 1, Resources.puste);
			tablicaPunktyDrużyny = new List<Tablica> { new Tablica(główny.panelPunktyL, 3, 1, Resources.puste), new Tablica(główny.panelPunktyP, 3, 1, Resources.puste) };
			drużyny = new List<Drużyna> { new DrużynaL(), new DrużynaP() };
		}

		public const string plik1 = "runda1.txt";
		public const string plik2 = "runda2.txt";
		public const string plikOdpowiedzi2 = "odpowiedzi2.txt";

		public const int długośćOdpowiedzi1 = 24;
		public const int długośćOdpowiedzi2 = 10;
		public const int ilośćOdpowiedzi1 = Tablica.wysokość - Odpowiedź.tablicaPunktyPozycjaYPoczątek;

		public static Kontroler kontroler { get; private set; }
		public static Panel panelKontroler1 { get; private set; }
		public static Panel panelKontroler2 { get; private set; }
		public static Panel panelKontrolerDodatkowy { get; private set; }
		public static GłównyEkran główny { get; private set; }
		private static List<IOperatable> formy;

		public static List<Pytanie1> pytania1 { get; private set; }
		public static Pytanie2[] pytania2 { get; private set; }

		public static Dictionary<char, Image> znaki { get; private set; }

		private static Bitmap ZwróćZonkDuży(bool góra, bool lewo)
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
		private static Bitmap ZwróćZonkMały(bool góra, bool lewo)
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
		private static Bitmap ZwróćZonkMały(bool góra)
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

		static public void PokażPanel(int który)
		{
			formy.ForEach(e => e.PokażPanel(który));
		}
		static public void UkryjPanel(int który)
		{
			formy.ForEach(e => e.UkryjPanel(który));
		}
		static public void UstawPunktyGłówne(int punkty)
		{
			formy.ForEach(e => e.UstawPunktyGłówne(punkty));
		}
		static public void UstawPunktyDrużyny(int która, int punkty)
		{
			formy.ForEach(e => e.UstawPunktyDrużyny(która, punkty));
		}

		static public void OznaczZaznaczenie(Button B)
		{
			B.BackColor = Color.White;
		}
		static public void OdznaczZaznaczenie(Button B)
		{
			B.BackColor = SystemColors.Control;
			B.UseVisualStyleBackColor = true;
		}
		static public bool Zaznaczony(Button B)
		{
			return B.BackColor == Color.White;
		}

		static public void Wyjdź(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
