﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class NrINazwaPytania
	{
		public int nrPytania;
		public string nazwaPytania;

		public NrINazwaPytania(int nr, string nazwa)
		{
			nrPytania = nr;
			nazwaPytania = nazwa;
		}
	}

	abstract class Zonk
	{
		public abstract int pozycja { get; }

		Button[] zonkButton = new Button[4];

		public Zonk()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i] = new Button();
				zonkButton[i].Click += new EventHandler(zaznacz);
				zonkButton[i].Location = new Point(pozycja, 50 + i * 45);
				zonkButton[i].Size = new Size(27, 45);
				zonkButton[i].Tag = i;
				zonkButton[i].Text = "zonk " + (i + 1).ToString();
				zonkButton[i].Visible = false;

				Global.panelKontroler1.Controls.Add(zonkButton[i]);
			}
			zonkButton[3].Text = "boom";
		}

		private void zaznacz(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;
			int Tag = (int)(przycisk.Tag);
			if (przycisk.BackColor == Color.White)
			{
				przycisk.BackColor = SystemColors.Control;
				przycisk.UseVisualStyleBackColor = true;
				ukryjZonk(Tag);
			}
			else
			{
				przycisk.BackColor = Color.White;
				wyświetlZonk(Tag);
			}
		}
		public void pokaż()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Show();
				if (zonkButton[i].BackColor == Color.White)
					wyświetlZonk(i);
			}
		}
		public void ukryj()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Hide();
				ukryjZonk(i);
			}
		}

		private void wyświetlZonk(int który)
		{
			if (który == 3)
			{
				Global.tablica1.ustawTekst("˹ ˺", pozycja, 3, true, 3, ' ');
				Global.tablica1.ustawTekst("˼ ˻", pozycja, 4, true, 3, ' ');
				Global.tablica1.ustawTekst(" | ", pozycja, 5, true, 3, ' ');
				Global.tablica1.ustawTekst("˺ ˹", pozycja, 6, true, 3, ' ');
				Global.tablica1.ustawTekst("˻ ˼", pozycja, 7, true, 3, ' ');
			}
			else
			{
				Global.tablica1.ustawTekst("┘ˍ└", pozycja, 1 + 3 * który, true, 3, ' ');
				Global.tablica1.ustawTekst(" | ", pozycja, 2 + 3 * który, true, 3, ' ');
				Global.tablica1.ustawTekst("┐ˉ┌", pozycja, 3 + 3 * który, true, 3, ' ');
			}
		}
		private void ukryjZonk(int który)
		{
			if (który == 3)
				for (int rząd = 3; rząd <= 7; rząd++)
					Global.tablica1.ustawTekst(String.Empty, pozycja, rząd, true, 3, ' ');
			else
				for (int rząd = 1 + 3 * który; rząd <= 3 + 3 * który; rząd++)
					Global.tablica1.ustawTekst(String.Empty, pozycja, rząd, true, 3, ' ');
		}
	}

	class ZonkL : Zonk
	{
		public override int pozycja
		{
			get { return 0; }
		}
	}
	class ZonkP : Zonk
	{
		public override int pozycja
		{
			get { return 27; }
		}
	}

	class Pytanie1
	{
		public static int obecnePytanie = -1;
		static Button dodajOdpowiedźButton = new Button();
		List<Button> przypiszButton = new List<Button> { new Button(), new Button() };

		int nrPytania;
		string nazwaPytania;
		public int punkty = 0;
		public Drużyna drużynaZPrzypisanymiPunktami = null;

		Label nazwaPytaniaLabel;

		ZonkL zonkL = new ZonkL();
		ZonkP zonkP = new ZonkP();

		public List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

		static Pytanie1()
		{
			dodajOdpowiedźButton.Click += new EventHandler(dodajOdpowiedź_Click);
			dodajOdpowiedźButton.Location = new Point(457, 95);
			dodajOdpowiedźButton.Size = new Size(135, 23);
			dodajOdpowiedźButton.Text = "dodaj odpowiedź";
			dodajOdpowiedźButton.Visible = false;

			Global.panelKontroler1.Controls.Add(dodajOdpowiedźButton);
		}

		public Pytanie1(NrINazwaPytania pytanie)
		{
			nrPytania = pytanie.nrPytania;
			nazwaPytania = pytanie.nazwaPytania;

			nazwaPytaniaLabel = new Label();
			nazwaPytaniaLabel.Location = new Point(100, 0);
			nazwaPytaniaLabel.Text = nrPytania.ToString() + ". " + nazwaPytania;
			nazwaPytaniaLabel.Hide();

			for (int i = 0; i < 2; i++)
			{
				przypiszButton[i].Size = new System.Drawing.Size(135, 23);
				przypiszButton[i].Visible = false;
				przypiszButton[i].Click += new System.EventHandler(przypisz_Click);
				przypiszButton[i].Location = new System.Drawing.Point(457, 140 + i * 30);
				przypiszButton[i].Tag = i;
				przypiszButton[i].Text = "przypisz punkty" + (i == 0 ? "lewej" : "prawej");
				Global.panelKontroler1.Controls.Add(przypiszButton[i]);
			}

			Global.panelKontroler1.Controls.Add(nazwaPytaniaLabel);
		}

		private void zainicjujKontrolki()
		{
			nazwaPytaniaLabel.Show();
			ustawPunkty(punkty);
			zonkL.pokaż();
			zonkP.pokaż();
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.pokażKontrolkiOdpowiedzi();

			przypiszButton.ForEach(b => b.Show());
		}
		public void dodajIPokażOdpowiedź(string linia)
		{
			dodajOdpowiedź(linia);
			zainicjujKontrolki();
		}
		public void dodajOdpowiedź(string linia)
		{
			odpowiedzi.Add(new Odpowiedź(linia, this));
		}
		public void ukryjOdpowiedzi()
		{
			nazwaPytaniaLabel.Hide();
			Global.ustawPunktyGłówne(0);
			zonkL.ukryj();
			zonkP.ukryj();
			przypiszButton.ForEach(b => b.Hide());
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.ukryjKontrolkiOdpowiedzi();
		}
		public void zamieńOdpowiedzi(int nrPoczątkowej)
		{
			odpowiedzi[nrPoczątkowej - 1].przesuń(nrPoczątkowej + 1, true);
			odpowiedzi[nrPoczątkowej].przesuń(nrPoczątkowej, false);

			Odpowiedź początkowa = odpowiedzi[nrPoczątkowej - 1];
			odpowiedzi[nrPoczątkowej - 1] = odpowiedzi[nrPoczątkowej];
			odpowiedzi[nrPoczątkowej] = początkowa;
		}
		public void usuńOdpowiedź(int nrOdpowiedzi)
		{
			Odpowiedź odpowiedź = odpowiedzi[nrOdpowiedzi - 1];
			odpowiedź.ukryjKontrolkiOdpowiedzi();
			for (int i = nrOdpowiedzi; i < odpowiedzi.Count; i++)
				odpowiedzi[i].przesuń(i, true);

			odpowiedzi.RemoveAt(nrOdpowiedzi - 1);
		}

		public void dodajPunkty(int punkty)
		{
			this.punkty += punkty;
			ustawPunkty(this.punkty);
		}
		public void ustawPunkty(int punkty)
		{
			Global.ustawPunktyGłówne(punkty);
		}

		public static void pokażPytanie()
		{
			if (obecnePytanie != -1)
				zwróćObecnePytanie().zainicjujKontrolki();
		}
		public static void ukryjPytanie()
		{
			if (obecnePytanie != -1)
				zwróćObecnePytanie().ukryjOdpowiedzi();
		}
		public static bool ostatniePytanie()
		{
			return obecnePytanie == Global.pytania1.Count - 1;
		}
		public static void pokażPrzyciski()
		{
			dodajOdpowiedźButton.Show();
		}

		private static Pytanie1 zwróćObecnePytanie()
		{
			return Global.pytania1[obecnePytanie];
		}

		private static void dodajOdpowiedź_Click(object sender, EventArgs e)
		{
			zwróćObecnePytanie().dodajIPokażOdpowiedź(" 0");
		}
		private void przypisz_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;
			int Tag = (int)(przycisk.Tag);
			if (przycisk.BackColor != Color.White)
			{
				if (przypiszButton[Tag == 0 ? 1 : 0].BackColor != Color.White)
				{
					przycisk.BackColor = Color.White;
					zwróćObecnePytanie().drużynaZPrzypisanymiPunktami = Global.drużyny[Tag];

					Global.drużyny[Tag].dodajPunkty(zwróćObecnePytanie().punkty);
				}
			}
			else
			{
				przycisk.BackColor = SystemColors.Control;
				przycisk.UseVisualStyleBackColor = true;
				zwróćObecnePytanie().drużynaZPrzypisanymiPunktami = null;

				Global.drużyny[Tag].dodajPunkty(-zwróćObecnePytanie().punkty);
			}
		}
	}
}
