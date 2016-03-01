using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace familiada
{
	class NrINazwaPytania
	{
		public int nrPytania { get; private set; }
		public string nazwaPytania { get; private set; }

		public NrINazwaPytania(int nr, string nazwa)
		{
			nrPytania = nr;
			nazwaPytania = nazwa;
		}
	}

	abstract class Zonk
	{
		private const int zonkButtonPozycjaYPoczątek = 50;
		private const int zonkButtonOdstępY = 0;
		private const int zonkButtonSzerokość = 25;
		private const int zonkButtonWysokość = 45;
		public abstract int pozycja { get; }

		readonly Button[] zonkButton = new Button[4];

		public Zonk()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i] = new Button();
				zonkButton[i].Click += new EventHandler(Zaznacz);
				zonkButton[i].Location = new Point(pozycja, zonkButtonPozycjaYPoczątek + i * (zonkButtonOdstępY + zonkButtonWysokość));
				zonkButton[i].Size = new Size(zonkButtonSzerokość, zonkButtonWysokość);
				zonkButton[i].Tag = i;
				zonkButton[i].Text = "zonk " + (i + 1).ToString();
				zonkButton[i].Visible = false;

				Global.panelKontroler1.Controls.Add(zonkButton[i]);
			}
			zonkButton[3].Text = "boom";
		}

		private void Zaznacz(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;
			int Tag = (int)(przycisk.Tag);
			if (przycisk.BackColor == Color.White)
			{
				przycisk.BackColor = SystemColors.Control;
				przycisk.UseVisualStyleBackColor = true;
				UkryjZonk(Tag);
			}
			else
			{
				przycisk.BackColor = Color.White;
				WyświetlZonk(Tag);
			}
		}
		public void Pokaż()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Show();
				if (zonkButton[i].BackColor == Color.White)
					WyświetlZonk(i);
			}
		}
		public void Ukryj()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Hide();
				UkryjZonk(i);
			}
		}

		private void WyświetlZonk(int który)
		{
			if (który == 3)
			{
				Global.tablica1.UstawTekst("˹ ˺", pozycja, 3, true, 3, ' ');
				Global.tablica1.UstawTekst("˼ ˻", pozycja, 4, true, 3, ' ');
				Global.tablica1.UstawTekst(" | ", pozycja, 5, true, 3, ' ');
				Global.tablica1.UstawTekst("˺ ˹", pozycja, 6, true, 3, ' ');
				Global.tablica1.UstawTekst("˻ ˼", pozycja, 7, true, 3, ' ');
			}
			else
			{
				Global.tablica1.UstawTekst("┘ˍ└", pozycja, 1 + 3 * który, true, 3, ' ');
				Global.tablica1.UstawTekst(" | ", pozycja, 2 + 3 * który, true, 3, ' ');
				Global.tablica1.UstawTekst("┐ˉ┌", pozycja, 3 + 3 * który, true, 3, ' ');
			}
		}
		private void UkryjZonk(int który)
		{
			if (który == 3)
				for (int rząd = 3; rząd <= 7; rząd++)
					Global.tablica1.UstawTekst(String.Empty, pozycja, rząd, true, 3, ' ');
			else
				for (int rząd = 1 + 3 * który; rząd <= 3 + 3 * który; rząd++)
					Global.tablica1.UstawTekst(String.Empty, pozycja, rząd, true, 3, ' ');
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
		public const int nazwaPytaniaLabelPozycjaX = 100;
		public const int nazwaPytaniaLabelPozycjaY = 0;
		public const int nazwaPytaniaLabelSzerokość = 150;
		public const int nazwaPytaniaLabelWysokość = 15;
		public const int dodajOdpowiedźButtonPozycjaX = 450;
		public const int dodajOdpowiedźButtonPozycjaY = 100;
		public const int dodajOdpowiedźButtonSzerokość = 135;
		public const int dodajOdpowiedźButtonWysokość = 25;
		private const int przypiszButtonPozycjaX = 450;
		private const int przypiszButtonPozycjaYPoczątek = 140;
		private const int przypiszButtonOdstępY = 5;
		private const int przypiszButtonSzerokość = 135;
		private const int przypiszButtonWysokość = 25;

		public static int obecnePytanie { get; set; }
		public static Button dodajOdpowiedźButton = new Button();
		readonly List<Button> przypiszButton = new List<Button> { new Button(), new Button() };

		readonly int nrPytania;
		public readonly string nazwaPytania;
		private int punkty = 0;
		public Drużyna drużynaZPrzypisanymiPunktami { get; set; }

		readonly Label nazwaPytaniaLabel;

		readonly List<Zonk> zonki = new List<Zonk> { new ZonkL(), new ZonkP() };

		public List<Odpowiedź> odpowiedzi { get; private set; }

		static Pytanie1()
		{
			obecnePytanie = -1;

			dodajOdpowiedźButton.Click += new EventHandler(DodajOdpowiedź_Click);
			dodajOdpowiedźButton.Location = new Point(dodajOdpowiedźButtonPozycjaX, dodajOdpowiedźButtonPozycjaY);
			dodajOdpowiedźButton.Size = new Size(dodajOdpowiedźButtonSzerokość, dodajOdpowiedźButtonWysokość);
			dodajOdpowiedźButton.Text = "dodaj odpowiedź";
			dodajOdpowiedźButton.Visible = false;

			Global.panelKontroler1.Controls.Add(dodajOdpowiedźButton);
		}

		public Pytanie1(NrINazwaPytania pytanie)
		{
			drużynaZPrzypisanymiPunktami = null;
			odpowiedzi = new List<Odpowiedź>();

			nrPytania = pytanie.nrPytania;
			nazwaPytania = pytanie.nazwaPytania;

			nazwaPytaniaLabel = new Label();
			nazwaPytaniaLabel.Location = new Point(nazwaPytaniaLabelPozycjaX, nazwaPytaniaLabelPozycjaY);
			nazwaPytaniaLabel.Size = new Size(nazwaPytaniaLabelSzerokość, nazwaPytaniaLabelWysokość);
			nazwaPytaniaLabel.Text = nrPytania.ToString() + ". " + nazwaPytania;
			nazwaPytaniaLabel.Hide();

			for (int i = 0; i < 2; i++)
			{
				przypiszButton[i].Size = new System.Drawing.Size(przypiszButtonSzerokość, przypiszButtonWysokość);
				przypiszButton[i].Visible = false;
				przypiszButton[i].Click += new System.EventHandler(Przypisz_Click);
				przypiszButton[i].Location = new System.Drawing.Point(przypiszButtonPozycjaX, przypiszButtonPozycjaYPoczątek + i * (przypiszButtonWysokość + przypiszButtonOdstępY));
				przypiszButton[i].Tag = i;
				przypiszButton[i].Text = "przypisz punkty " + (i == 0 ? "lewej" : "prawej");
				Global.panelKontroler1.Controls.Add(przypiszButton[i]);
			}

			Global.panelKontroler1.Controls.Add(nazwaPytaniaLabel);
		}

		private void ZainicjujKontrolki()
		{
			nazwaPytaniaLabel.Show();
			UstawPunkty();
			zonki.ForEach(z => z.Pokaż());
			odpowiedzi.ForEach(o => o.PokażKontrolkiOdpowiedzi());
			przypiszButton.ForEach(b => b.Show());
		}
		private void DodajIPokażOdpowiedź(string linia)
		{
			DodajOdpowiedź(linia);
			ZainicjujKontrolki();
		}
		public void DodajOdpowiedź(string linia)
		{
			odpowiedzi.Add(new Odpowiedź(linia, this));
		}
		private void UkryjOdpowiedzi()
		{
			nazwaPytaniaLabel.Hide();
			Global.UstawPunktyGłówne(0);
			zonki.ForEach(z => z.Ukryj());
			odpowiedzi.ForEach(o => o.UkryjKontrolkiOdpowiedzi());
			przypiszButton.ForEach(b => b.Hide());
		}
		public void ZamieńOdpowiedzi(int nrPoczątkowej)
		{
			odpowiedzi[nrPoczątkowej - 1].Przesuń(nrPoczątkowej + 1, true);
			odpowiedzi[nrPoczątkowej].Przesuń(nrPoczątkowej, false);

			Odpowiedź początkowa = odpowiedzi[nrPoczątkowej - 1];
			odpowiedzi[nrPoczątkowej - 1] = odpowiedzi[nrPoczątkowej];
			odpowiedzi[nrPoczątkowej] = początkowa;
		}
		public void UsuńOdpowiedź(int nrOdpowiedzi)
		{
			Odpowiedź odpowiedź = odpowiedzi[nrOdpowiedzi - 1];
			odpowiedź.UkryjKontrolkiOdpowiedzi();
			for (int i = nrOdpowiedzi; i < odpowiedzi.Count; i++)
				odpowiedzi[i].Przesuń(i, true);

			odpowiedzi.RemoveAt(nrOdpowiedzi - 1);
		}

		public void DodajPunkty(int dodane)
		{
			punkty += dodane;
			UstawPunkty();
		}
		private void UstawPunkty()
		{
			Global.UstawPunktyGłówne(punkty);
		}

		public static void PokażPytanie()
		{
			if (obecnePytanie != -1)
				ZwróćObecnePytanie().ZainicjujKontrolki();
		}
		public static void UkryjPytanie()
		{
			if (obecnePytanie != -1)
				ZwróćObecnePytanie().UkryjOdpowiedzi();
		}
		public static bool OstatniePytanie()
		{
			return obecnePytanie == Global.pytania1.Count - 1;
		}
		public static void PokażPrzyciski()
		{
			dodajOdpowiedźButton.Visible = (ZwróćObecnePytanie().odpowiedzi.Count != Global.ilośćOdpowiedzi1);
		}

		private static Pytanie1 ZwróćObecnePytanie()
		{
			return Global.pytania1[obecnePytanie];
		}

		private static void DodajOdpowiedź_Click(object sender, EventArgs e)
		{
			ZwróćObecnePytanie().DodajIPokażOdpowiedź(" 0");
			if (ZwróćObecnePytanie().odpowiedzi.Count == Global.ilośćOdpowiedzi1)
				dodajOdpowiedźButton.Hide();
		}
		private void Przypisz_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;
			int Tag = (int)(przycisk.Tag);
			if (przycisk.BackColor != Color.White)
			{
				if (przypiszButton[Tag == 0 ? 1 : 0].BackColor != Color.White)
				{
					przycisk.BackColor = Color.White;
					ZwróćObecnePytanie().drużynaZPrzypisanymiPunktami = Global.drużyny[Tag];

					Global.drużyny[Tag].DodajPunkty(ZwróćObecnePytanie().punkty);
				}
			}
			else
			{
				przycisk.BackColor = SystemColors.Control;
				przycisk.UseVisualStyleBackColor = true;
				ZwróćObecnePytanie().drużynaZPrzypisanymiPunktami = null;

				Global.drużyny[Tag].DodajPunkty(-ZwróćObecnePytanie().punkty);
			}
		}
	}
}
