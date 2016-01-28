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
		public abstract int początekWysokości { get; }

		Button[] zonkButton = new Button[4];
		CheckBox[] zonkCheckBox = new CheckBox[4];

		public Zonk()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i] = new Button();
				zonkButton[i].Click += new EventHandler(zaznacz);
				zonkButton[i].Location = new Point(0, początekWysokości + i * 25);
				zonkButton[i].Tag = i;
				zonkButton[i].Text = "zonk " + (i + 1).ToString();

				zonkCheckBox[i] = new CheckBox();
				zonkCheckBox[i].Enabled = false;
				zonkCheckBox[i].Size = new Size(15, 15);
				zonkCheckBox[i].Location = new Point(0, początekWysokości + i * 25);

				Global.panelKontroler1.Controls.Add(zonkButton[i]);
				Global.panelGłówny1.Controls.Add(zonkCheckBox[i]);
			}
			zonkButton[3].Text = "boom";

			ukryj();
		}

		private void zaznacz(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;
			int Tag = (int)(przycisk.Tag);
			if (przycisk.BackColor == Color.White)
			{
				przycisk.BackColor = SystemColors.Control;
				przycisk.UseVisualStyleBackColor = true;
				zonkCheckBox[Tag].Checked = false;
			}
			else
			{
				przycisk.BackColor = Color.White;
				zonkCheckBox[Tag].Checked = true;
			}
		}

		public void pokaż()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Show();
				zonkCheckBox[i].Show();
			}
		}
		public void ukryj()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Hide();
				zonkCheckBox[i].Hide();
			}
		}
	}

	class ZonkL : Zonk
	{
		public override int początekWysokości
		{
			get { return 50; }
		}
	}
	class ZonkP : Zonk
	{
		public override int początekWysokości
		{
			get { return 150; }
		}
	}

	class Pytanie1
	{
		int nrPytania;
		string nazwaPytania;
		int punkty = 0;

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
			odpowiedź.usuńOdpowiedź();
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
