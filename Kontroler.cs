﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	public partial class Kontroler : Form, IOperatable
	{
		private const int dodatkowyPanelPozycjaX = 0;
		private const int dodatkowyPanelPozycjaY = 320;
		private const int dodatkowyPanelSzerokość = 210;
		private const int dodatkowyPanelWysokość = 135;
		private const int przełączPytanieButtonPozycjaXPoczątek = 185;
		private const int przełączPytanieButtonOdstępX = 70;
		private const int przełączPytanieButtonPozycjaY = 300;
		private const int przełączPytanieButtonSzerokość = 115;
		private const int przełączPytanieButtonWysokość = 25;
		private const int pokażEkranButtonPozycjaX = 0;
		private const int pokażEkranButtonPozycjaY = 40;
		private const int pokażEkranButtonSzerokość = 115;
		private const int pokażEkranButtonWysokość = 25;
		private const int rundaButtonPozycjaX = 0;
		private const int rundaButtonPozycjaY = 70;
		private const int rundaButtonSzerokość = 115;
		private const int rundaButtonWysokość = 25;
		private const int punktyLabelPozycjaX = 80;
		private const int punktyLabelPozycjaY = 8;
		private const int punktyLabelSzerokość = 25;
		private const int punktyLabelWysokość = 15;
		private const int punktyDrużynaLabelSzerokość = 25;
		private const int punktyDrużynaLabelWysokość = 15;
		private const int ustawCzasButtonPozycjaXPoczątek = 400;
		private const int ustawCzasButtonOdstępX = 25;
		private const int ustawCzasButtonPozycjaY = 300;
		private const int ustawCzasButtonSzerokość = 75;
		private const int ustawCzasButtonWysokość = 25;
		private const int czasLabelPozycjaX = 520;
		private const int czasLabelPozycjaY = 400;
		private const int czasLabelSzerokość = 20;
		private const int czasLabelWysokość = 13;
		private const int czasButtonPozycjaXPoczątek = 400;
		private const int czasButtonOdstępX = 25;
		private const int czasButtonPozycjaY = 350;
		private const int czasButtonSzerokość = 75;
		private const int czasButtonWysokość = 25;
		private const int ukryjOdpowiedziButtonPozycjaX = 300;
		private const int ukryjOdpowiedziButtonPozycjaY = 325;
		private const int ukryjOdpowiedziButtonSzerokość = 75;
		private const int ukryjOdpowiedziButtonWysokość = 25;

		public Kontroler()
		{
			paneleRundy = new List<Panel> { new Panel(), new Panel() };
			foreach (Panel p in paneleRundy)
			{
				p.Dock = DockStyle.Fill;
				p.Margin = new Padding(0);
				p.Visible = false;
			}

			punktyDrużynaLabel = new List<Label> { new Label(), new Label() };
			punktyDrużynaLabel.ForEach(l => l.Size = new Size(punktyDrużynaLabelSzerokość, punktyDrużynaLabelWysokość));
			punktyDrużynaLabel[0].Dock = DockStyle.Left;
			punktyDrużynaLabel[1].Dock = DockStyle.Right;

			ustawCzasButton = new List<Button> { new Button(), new Button(), new Button() };
			for (int i = 0; i < ustawCzasButton.Count; i++)
			{
				Button b = ustawCzasButton[i];
				paneleRundy[1].Controls.Add(b);
				b.Location = new Point(ustawCzasButtonPozycjaXPoczątek + (ustawCzasButtonOdstępX + ustawCzasButtonSzerokość) * i, ustawCzasButtonPozycjaY);
				switch (i)
				{
					case 0:
						b.Tag = "15";
						break;
					case 1:
						b.Tag = "20";
						break;
					case 2:
						b.Tag = "7";
						break;
				}
				b.Text = "ustaw" + (string)(b.Tag);
				b.Size = new Size(ustawCzasButtonSzerokość, ustawCzasButtonWysokość);
				b.Click += new EventHandler(UstawCzas_Click);
			}

			poprzedniePytanie = new Button();
			poprzedniePytanie.Location = new Point(przełączPytanieButtonPozycjaXPoczątek, przełączPytanieButtonPozycjaY);
			poprzedniePytanie.Size = new Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			poprzedniePytanie.Text = "poprzednie pytanie";
			poprzedniePytanie.Visible = false;
			poprzedniePytanie.Click += new EventHandler(PoprzedniePytanie_Click);

			następnePytanie = new Button();
			następnePytanie.Location = new Point(przełączPytanieButtonPozycjaXPoczątek + przełączPytanieButtonOdstępX + przełączPytanieButtonSzerokość, przełączPytanieButtonPozycjaY);
			następnePytanie.Size = new Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			następnePytanie.Text = "zacznij pytania";
			następnePytanie.Click += new EventHandler(NastępnePytanie_Click);

			pokażEkran = new Button();
			pokażEkran.Location = new Point(pokażEkranButtonPozycjaX, pokażEkranButtonPozycjaY);
			pokażEkran.Size = new Size(pokażEkranButtonSzerokość, pokażEkranButtonWysokość);
			pokażEkran.Text = "otwórz ekran główny";
			pokażEkran.Click += new EventHandler(PokażEkran_Click);

			rundaButton = new Button();
			rundaButton.Location = new Point(rundaButtonPozycjaX, rundaButtonPozycjaY);
			rundaButton.Size = new Size(rundaButtonSzerokość, rundaButtonWysokość);
			rundaButton.Tag = 1;
			rundaButton.Text = "przełącz do rundy 1";
			rundaButton.Click += new EventHandler(Runda_Click);

			punktyLabel = new Label();
			punktyLabel.Location = new Point(punktyLabelPozycjaX, punktyLabelPozycjaY);
			punktyLabel.Size = new Size(punktyLabelSzerokość, punktyLabelWysokość);
			punktyLabel.Text = "0";

			start = new Button();
			start.Location = new Point(czasButtonPozycjaXPoczątek, czasButtonPozycjaY);
			start.Size = new Size(czasButtonSzerokość, czasButtonWysokość);
			start.Text = "start";
			start.Click += new EventHandler(StartCzas_Click);

			stop = new Button();
			stop.Location = new Point(czasButtonPozycjaXPoczątek + czasButtonSzerokość + czasButtonOdstępX, czasButtonPozycjaY);
			stop.Size = new Size(czasButtonSzerokość, czasButtonWysokość);
			stop.Text = "pauza";
			stop.Click += new EventHandler(StopCzas_Click);

			czas = new Label();
			czas.Location = new Point(czasLabelPozycjaX, czasLabelPozycjaY);
			czas.Size = new Size(czasLabelSzerokość, czasLabelWysokość);

			ukryjOdpowiedziButton = new Button();
			ukryjOdpowiedziButton.Location = new Point(ukryjOdpowiedziButtonPozycjaX, ukryjOdpowiedziButtonPozycjaY);
			ukryjOdpowiedziButton.Size = new Size(ukryjOdpowiedziButtonSzerokość, ukryjOdpowiedziButtonWysokość);
			ukryjOdpowiedziButton.Text = "ukryj Odpowiedzi";
			ukryjOdpowiedziButton.Click += new EventHandler(UkryjOdpowiedzi_Click);

			dodatkowy = new Panel();
			dodatkowy.BorderStyle = BorderStyle.FixedSingle;
			dodatkowy.Controls.Add(punktyLabel);
			dodatkowy.Controls.Add(rundaButton);
			dodatkowy.Controls.Add(pokażEkran);
			dodatkowy.Location = new Point(dodatkowyPanelPozycjaX, dodatkowyPanelPozycjaY);
			dodatkowy.Size = new Size(dodatkowyPanelSzerokość, dodatkowyPanelWysokość);

			InitializeComponent();

			paneleRundy[0].Controls.Add(poprzedniePytanie);
			paneleRundy[0].Controls.Add(następnePytanie);
			paneleRundy[1].Controls.Add(czas);
			paneleRundy[1].Controls.Add(start);
			paneleRundy[1].Controls.Add(stop);
			paneleRundy[1].Controls.Add(ukryjOdpowiedziButton);
			punktyDrużynaLabel.ForEach(l => dodatkowy.Controls.Add(l));
			Controls.Add(dodatkowy);
			paneleRundy.ForEach(p => Controls.Add(p));
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// TODO jeden plik runda2 - opcjonalny

			try
			{
				StreamReader plik = new StreamReader(Global.plik1);
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (NagłówekPytania(linia) != null)
						{
							Global.pytania1.Add(new Pytanie1(NagłówekPytania(linia)));
						}
						else
						{
							if (Global.pytania1.Count == 0)
								Global.Wyjdź("zacznij plik od numeru pytania");
							try
							{
								Global.pytania1.Last().DodajOdpowiedź(linia);
							}
							catch (ArgumentException exc)
							{
								Global.Wyjdź(String.Format("za dużo odpowiedzi w pytaniu: {0}", exc.Message));
							}
						}
					}
				}
				plik.Close();

				plik = new StreamReader(Global.plik2);
				for (int i = 0; i < 5; i++)
				{
					string linia = plik.ReadLine().Trim();
					Global.pytania2[i] = new Pytanie2(linia, i + 1);
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Global.Wyjdź(String.Format("brakuje pliku {0}", exc.FileName));
			}
			catch (NullReferenceException)
			{
				Global.Wyjdź(String.Format("Wstaw 5 pytań"));
			}

			if (Global.pytania1.Count == 0)
				Global.Wyjdź("brak pytań");

			if (File.Exists(Global.plikOdpowiedzi2))
			{
				StreamReader plik = new StreamReader(Global.plikOdpowiedzi2);
				try
				{
					for (int i = 0; i < 5; i++)
					{
						string linia = plik.ReadLine().Trim();
						int pozycjaOstatniejPrzerwy = linia.LastIndexOfAny(new char[] { ' ', '\t' });
						int pozycjaPrzedostatniejPrzerwy = linia.LastIndexOfAny(new char[] { ' ', '\t' }, pozycjaOstatniejPrzerwy - 1);
						if (pozycjaPrzedostatniejPrzerwy == -1)
							Global.Wyjdź(String.Format("niepoprawna linia: {0}", linia));
						string odpowiedź = linia.Substring(0, pozycjaPrzedostatniejPrzerwy).TrimEnd();
						if (odpowiedź.Length > Global.długośćOdpowiedzi2)
							Global.Wyjdź(String.Format("za długa odpowiedź: {0}. Dopuszczalna szerokość to {1}", odpowiedź, Global.długośćOdpowiedzi2));
						string odpowiedźUpper = odpowiedź.ToUpper(CultureInfo.CurrentUICulture);
						for (int j = 0; j < odpowiedź.Length; j++)
							if (!Global.znaki.ContainsKey(odpowiedźUpper[j]))
								Global.Wyjdź(String.Format("niepoprawny znak '{0}' w {1}", odpowiedź[j], odpowiedź));
						try
						{
							Int32.Parse(linia.Substring(pozycjaPrzedostatniejPrzerwy + 1, pozycjaOstatniejPrzerwy - pozycjaPrzedostatniejPrzerwy - 1));
							Int32.Parse(linia.Substring(pozycjaOstatniejPrzerwy + 1));
						}
						catch (FormatException)
						{
							Global.Wyjdź(String.Format("niepoprawna liczba punktów w {0}", linia));
						}
						string punktyL = linia.Substring(pozycjaPrzedostatniejPrzerwy + 1, pozycjaOstatniejPrzerwy - pozycjaPrzedostatniejPrzerwy - 1);
						string punktyP = linia.Substring(pozycjaOstatniejPrzerwy + 1);
						Global.pytania2[i].pytaniaStrona[1].odpowiedźTextBox.Text = odpowiedź;
						Global.pytania2[i].pytaniaStrona[0].punktyTextBox.Text = punktyL;
						Global.pytania2[i].pytaniaStrona[1].punktyTextBox.Text = punktyP;
					}
				}
				catch (NullReferenceException)
				{
					Global.Wyjdź(String.Format("Wstaw 5 odpowiedzi"));
				}
				plik.Close();
			}
		}

		private static NrINazwaPytania NagłówekPytania(string linia)
		{
			try
			{
				string[] words = linia.Split(new char[] { ' ', '\t' });
				int nrPytania = Int32.Parse(words[0]);
				StringBuilder nazwaPytania = new StringBuilder();
				for (int i = 1; i < words.Length; i++)
					nazwaPytania.Append(words[i]).Append(" ");
				return new NrINazwaPytania(nrPytania, nazwaPytania.ToString().TrimEnd());
			}
			catch (FormatException)
			{
				return null;
			}
		}

		private void Runda_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;

			if ((int)(przycisk.Tag) == 1)
			{
				przycisk.Tag = 2;
				przycisk.Text = "przełącz do rundy 2";

				Global.PokażPanel(0);
				Global.UkryjPanel(1);

				Global.UstawPunktyGłówne(0);

				Pytanie1.PokażPytanie();
			}
			else
			{
				przycisk.Tag = 1;
				przycisk.Text = "przełącz do rundy 1";

				Global.PokażPanel(1);
				Global.UkryjPanel(0);

				Pytanie2.WyświetlPunkty();
			}

			//if (Global.tablicaTło != null)
			//	Global.tablicaTło.Usuń();
		}

		private void NastępnePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Text = "następne pytanie";

			if (Pytanie1.obecnePytanie != -1)
			{
				poprzedniePytanie.Show();
				Pytanie1.UkryjPytanie();
			}

			Pytanie1.obecnePytanie++;
			Pytanie1.PokażPytanie();
			if (Pytanie1.OstatniePytanie())
				następnePytanie.Hide();

			Pytanie1.PokażPrzyciski();
		}
		private void PoprzedniePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Show();

			Pytanie1.UkryjPytanie();
			Pytanie1.obecnePytanie--;
			Pytanie1.PokażPytanie();

			if (Pytanie1.obecnePytanie == 0)
				poprzedniePytanie.Hide();

			Pytanie1.PokażPrzyciski();
		}
		private void PokażEkran_Click(object sender, EventArgs e)
		{
			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			Global.główny.Show();
			Global.główny.WindowState = FormWindowState.Normal;
			Global.główny.Location = drugiEkran.WorkingArea.Location;
			if (tenEkran == drugiEkran)
			{
				Global.główny.FormBorderStyle = FormBorderStyle.Sizable;
				Global.główny.TopMost = false;
			}
			else
			{
				Global.główny.FormBorderStyle = FormBorderStyle.None;
				Global.główny.TopMost = true;
			}
			Global.główny.WindowState = FormWindowState.Maximized;
			pokażEkran.Hide();
		}

		private void UstawCzas_Click(object sender, System.EventArgs e)
		{
			string czasString = (string)(((Button)sender).Tag);
			czas.Text = czasString;
			Global.tablicaPunkty.UstawTekst(czasString, 0, 0, false, 3, ' ');
		}
		private void StartCzas_Click(object sender, EventArgs e)
		{
			if (czas.Text != String.Empty)
				timer1.Start();
		}
		private void StopCzas_Click(object sender, EventArgs e)
		{
			timer1.Stop();
		}
		private void UkryjOdpowiedzi_Click(object sender, EventArgs e)
		{
			Global.PrzełączZaznaczenie(ukryjOdpowiedziButton);
			if (Global.Zaznaczony(ukryjOdpowiedziButton))
			{
				for (int i = 0; i < 5; i++)
					if (Global.pytania2[i].pytaniaStrona[0].Wyświetlony())
						Global.pytania2[i].pytaniaStrona[0].PokażUkryj_Click(new object(), new EventArgs());
			}
			else
			{
				for (int i = 0; i < 5; i++)
					Global.pytania2[i].pytaniaStrona[0].PokażUkryj_Click(new object(), new EventArgs());
			}
		}
		private void Timer1_Tick(object sender, EventArgs e)
		{
			int pozostałyCzas = Int32.Parse(czas.Text);
			pozostałyCzas--;
			czas.Text = pozostałyCzas.ToString();
			Global.tablicaPunkty.UstawTekst(pozostałyCzas.ToString(), 0, 0, false, 3, ' ');
			if (pozostałyCzas == 0)
			{
				timer1.Stop();
				czas.Text = String.Empty;
				Global.tablicaPunkty.UstawTekst(String.Empty, 0, 0, false, 3, ' ');
			}
		}

		public void PokażPanel(int który)
		{
			paneleRundy[który].Show();
		}
		public void UkryjPanel(int który)
		{
			paneleRundy[który].Hide();
		}
		public void UstawPunktyGłówne(int punkty)
		{
			this.punktyLabel.Text = punkty.ToString();
		}
		public void UstawPunktyDrużyny(int która, int punkty)
		{
			punktyDrużynaLabel[która].Text = punkty.ToString();
		}
	}
}
