using System;
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
		int nrPytania;
		string nazwaPytania;
		public int punkty = 0;
		public string druzynaZPrzypisanymiPunktami = null;

		Label nazwaPytaniaLabel;

		ZonkL zonkL = new ZonkL();
		ZonkP zonkP = new ZonkP();

		public List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

		public Pytanie1(NrINazwaPytania pytanie)
		{
			nrPytania = pytanie.nrPytania;
			nazwaPytania = pytanie.nazwaPytania;

			nazwaPytaniaLabel = new Label();
			nazwaPytaniaLabel.Location = new Point(100, 0);
			nazwaPytaniaLabel.Text = nrPytania.ToString() + ". " + nazwaPytania;
			nazwaPytaniaLabel.Hide();

			Global.panelKontroler1.Controls.Add(nazwaPytaniaLabel);
		}

		public void zainicjujKontrolki()
		{
			nazwaPytaniaLabel.Show();
			ustawPunkty(punkty);
			zonkL.pokaż();
			zonkP.pokaż();
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.pokażKontrolkiOdpowiedzi();

			Global.kontroler.przypiszL.BackColor = SystemColors.Control;
			Global.kontroler.przypiszL.UseVisualStyleBackColor = true;
			Global.kontroler.przypiszP.BackColor = SystemColors.Control;
			Global.kontroler.przypiszP.UseVisualStyleBackColor = true;
			if (druzynaZPrzypisanymiPunktami != null)
			{
				if (druzynaZPrzypisanymiPunktami == "L")
					Global.kontroler.przypiszL.BackColor = Color.White;
				else
					Global.kontroler.przypiszP.BackColor = Color.White;
			}
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
			Punkty.wyzerujPunkty();
			zonkL.ukryj();
			zonkP.ukryj();
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
			Punkty.dodajPunkty(punkty);
		}
		public void ustawPunkty(int punkty)
		{
			Punkty.ustawPunkty(punkty);
		}
	}
}
