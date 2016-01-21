﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	public partial class NotForShow : Form
	{
		static string nazwaPliku = "pytania.txt";

		ForShow główny;

		List<Pytanie> pytania = new List<Pytanie>();
		int obecnePytanie = -1;

		public NotForShow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				StreamReader plik = new StreamReader(nazwaPliku);

				int nrOdpowiedzi = 1;
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != -1)
						{
							pytania.Add(new Pytanie(nrPytania(linia)));
							nrOdpowiedzi = 1;
						}
						else
						{
							if (pytania.Count == 0)
								Functions.exit("zacznij plik od numeru pytania");
							pytania.Last().dodajOdpowiedź(new Odpowiedź(linia, nrOdpowiedzi++));
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Functions.exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			główny = new ForShow();
			główny.Show();
			główny.Location = drugiEkran.WorkingArea.Location;
			//główny.FormBorderStyle = FormBorderStyle.None;
			//główny.WindowState = FormWindowState.Maximized;
			//główny.TopMost = true;

			if (pytania.Count == 0)
				Functions.exit("brak pytań");

		}

		static int nrPytania(string linia)
		{
			int nrPytania = -1;
			try
			{
				nrPytania = Int32.Parse(linia);
			}
			catch (FormatException)
			{ }
			return nrPytania;
		}

		private void następnePytanie_Click(object sender, EventArgs e)
		{
			if (obecnePytanie != pytania.Count - 1)
			{
				if (obecnePytanie != -1)
				{
					pytania[obecnePytanie].usuńCheckBoxy();
					//pytania[obecnePytanie].usuńOdpowiedzi();
				}
				obecnePytanie++;
				pytania[obecnePytanie].dodajCheckBoxy(this);
				pytania[obecnePytanie].pokażNumeryOdpowiedzi(główny);
			}
		}
	}
}
