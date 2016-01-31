using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	abstract class PytanieStrona
	{
		public const int ControlOdstępX = 0;
		public const int odpowiedźTextBoxSzerokość = 100;
		private const int odpowiedźTextBoxWysokość = 20;
		public const int punktyTextBoxSzerokość = 30;
		private const int punktyTextBoxWysokość = 20;
		public const int umieśćButtonSzerokość = 30;
		private const int umieśćButtonWysokość = 30;
		public const int tablicaOdstępX = (Tablica.szerokość / 2 - Global.długośćOdpowiedzi2 - 2) / 3; //2-szerokość punktów; 3-są trzy odstępy
		private const int tablicaPozycjaYPoczątek = 1;

		private static int punkty;
		private int nrPytania;
		private int punktyPytania;

		private TextBox odpowiedźTextBox = new TextBox();
		private TextBox punktyTextBox = new TextBox();
		private Button umieśćButton = new Button();

		protected abstract int Tag { get; }

		protected abstract int odpowiedźTextBoxPozycjaX { get; }
		protected abstract int odpowiedźTextBoxTabIndex { get; }
		protected abstract int punktyTextBoxPozycjaX { get; }
		protected abstract int punktyTextBoxTabIndex { get; }
		protected abstract int umieśćButtonPozycjaX { get; }

		protected abstract int pozycjaOdpowiedziNaTablicy { get; }
		protected abstract int pozycjaPunktówNaTablicy { get; }
		protected abstract bool wyrównanieDoLewej { get; }

		public PytanieStrona(int nrPytania)
		{
			this.nrPytania = nrPytania;

			odpowiedźTextBox.Location = new Point(odpowiedźTextBoxPozycjaX, (Pytanie2.panelWysokość - odpowiedźTextBoxWysokość) / 2);
			odpowiedźTextBox.Size = new Size(odpowiedźTextBoxSzerokość, odpowiedźTextBoxWysokość);
			odpowiedźTextBox.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			odpowiedźTextBox.KeyDown += new KeyEventHandler(odpowiedź_KeyDown);
			odpowiedźTextBox.TabIndex = odpowiedźTextBoxTabIndex;

			punktyTextBox.Location = new Point(punktyTextBoxPozycjaX, (Pytanie2.panelWysokość - punktyTextBoxWysokość) / 2);
			punktyTextBox.Size = new Size(punktyTextBoxSzerokość, punktyTextBoxWysokość);
			punktyTextBox.Text = "0";
			punktyTextBox.Leave += new EventHandler(edytorPunktów_Leave);
			punktyTextBox.KeyDown += new KeyEventHandler(punkty_KeyDown);
			punktyTextBox.TabIndex = punktyTextBoxTabIndex;

			umieśćButton.Location = new Point(umieśćButtonPozycjaX, (Pytanie2.panelWysokość - umieśćButtonWysokość) / 2);
			umieśćButton.Size = new Size(umieśćButtonSzerokość, umieśćButtonWysokość);
			umieśćButton.Text = "umieść";
			umieśćButton.Click += new EventHandler(pokażUkryj_Click);
			umieśćButton.TabStop = false;

			ukryjOdpowiedź();
		}

		public static void wyświetlPunkty()
		{
			Global.ustawPunktyGłówne(punkty);
		}
		public void umieść(Panel panel)
		{
			panel.Controls.Add(this.odpowiedźTextBox);
			panel.Controls.Add(this.punktyTextBox);
			panel.Controls.Add(this.umieśćButton);
		}
		private bool wyświetlony()
		{
			return umieśćButton.BackColor == Color.White;
		}

		private void edytorOdpowiedzi_Leave(object sender, EventArgs e)
		{
			string odpowiedź = odpowiedźTextBox.Text.ToUpper();

			if (odpowiedź.Length > Global.długośćOdpowiedzi2)
			{
				MessageBox.Show(String.Format("Tekst za długi o {0} znaków", odpowiedź.Length - Global.długośćOdpowiedzi2));
				odpowiedźTextBox.Focus();
				return;
			}
			for (int i = 0; i < odpowiedź.Length; i++)
				if (!Global.znaki.ContainsKey(odpowiedź[i]))
				{
					MessageBox.Show(String.Format("niepoprawny znak {0}", odpowiedź[i]));
					odpowiedźTextBox.Focus();
					return;
				}

			if (wyświetlony())
				pokażOdpowiedź();
		}
		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			TextBox textbox = ((TextBox)sender);
			try
			{
				int nowePunkty = Int32.Parse(textbox.Text);
				if (wyświetlony())
				{
					punkty -= punktyPytania;
					punkty += nowePunkty;
					wyświetlPunkty();
				}
				punktyPytania = nowePunkty;
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				textbox.Focus();
				textbox.SelectAll();
			}
		}
		private void odpowiedź_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytaniaStrona[Tag].odpowiedźTextBox.Focus();
			}
		}
		private void punkty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytaniaStrona[Tag].punktyTextBox.Focus();
			}
		}
		private void pokażUkryj_Click(object sender, EventArgs e)
		{
			if (wyświetlony())
			{
				umieśćButton.BackColor = SystemColors.Control;
				umieśćButton.UseVisualStyleBackColor = true;

				ukryjOdpowiedź();
				punkty -= Int32.Parse(punktyTextBox.Text);
			}
			else
			{
				umieśćButton.BackColor = Color.White;

				pokażOdpowiedź();
				punkty += Int32.Parse(punktyTextBox.Text);
			}
			wyświetlPunkty();
		}
		private void pokażOdpowiedź()
		{
			Global.tablica2.ustawTekst(odpowiedźTextBox.Text, pozycjaOdpowiedziNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, wyrównanieDoLewej, Global.długośćOdpowiedzi2, ' ');
			Global.tablica2.ustawTekst(punktyTextBox.Text, pozycjaPunktówNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, false, 2, ' ');
		}
		private void ukryjOdpowiedź()
		{
			Global.tablica2.ustawTekst(String.Empty, pozycjaOdpowiedziNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, wyrównanieDoLewej, Global.długośćOdpowiedzi2, '.');
			Global.tablica2.ustawTekst(String.Empty, pozycjaPunktówNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, false, 2, '|');
		}
	}

	class PytanieL : PytanieStrona
	{
		protected override int Tag { get { return 0; } }

		protected override int odpowiedźTextBoxPozycjaX { get { return Pytanie2.nazwaLabelSzerokość; } }
		protected override int odpowiedźTextBoxTabIndex { get { return 1; } }
		protected override int punktyTextBoxPozycjaX { get { return odpowiedźTextBoxPozycjaX + odpowiedźTextBoxSzerokość + ControlOdstępX; } }
		protected override int punktyTextBoxTabIndex { get { return 2; } }
		protected override int umieśćButtonPozycjaX { get { return punktyTextBoxPozycjaX + punktyTextBoxSzerokość + ControlOdstępX; } }

		protected override int pozycjaOdpowiedziNaTablicy { get { return tablicaOdstępX; } }
		protected override int pozycjaPunktówNaTablicy { get { return pozycjaOdpowiedziNaTablicy + Global.długośćOdpowiedzi2 + tablicaOdstępX; } }
		protected override bool wyrównanieDoLewej { get { return false; } }

		public PytanieL(int nrPytania) : base(nrPytania) { }
	}

	class PytanieP : PytanieStrona
	{
		protected override int Tag { get { return 1; } }

		protected override int odpowiedźTextBoxPozycjaX { get { return punktyTextBoxPozycjaX + punktyTextBoxSzerokość + ControlOdstępX; } }
		protected override int odpowiedźTextBoxTabIndex { get { return 3; } }
		protected override int punktyTextBoxPozycjaX { get { return umieśćButtonPozycjaX + umieśćButtonSzerokość + ControlOdstępX; } }
		protected override int punktyTextBoxTabIndex { get { return 4; } }
		protected override int umieśćButtonPozycjaX { get { return Pytanie2.nazwaLabelSzerokość + odpowiedźTextBoxSzerokość + umieśćButtonSzerokość + punktyTextBoxSzerokość + ControlOdstępX * 3; } }

		protected override int pozycjaOdpowiedziNaTablicy { get { return pozycjaPunktówNaTablicy + 2 + tablicaOdstępX; } }
		protected override int pozycjaPunktówNaTablicy { get { return Tablica.szerokość / 2 + tablicaOdstępX; } }
		protected override bool wyrównanieDoLewej { get { return true; } }

		public PytanieP(int nrPytania) : base(nrPytania) { }
	}

	class Pytanie2
	{
		public const int nazwaLabelSzerokość = 150;
		public const int nazwaLabelWysokość = 14;
		private const int panelPozycjaX = 100;
		private const int panelPozycjaYPoczątek = 50;
		private const int panelOdstępY = 20;
		private const int panelSzerokość = nazwaLabelSzerokość + (PytanieStrona.odpowiedźTextBoxSzerokość + PytanieStrona.punktyTextBoxSzerokość + PytanieStrona.umieśćButtonSzerokość) * 2 + PytanieStrona.ControlOdstępX * 5;
		public const int panelWysokość = 30;

		string nazwaPytania;
		int nrPytania;

		Panel panel = new Panel();

		Label nazwaLabel = new Label();
		public List<PytanieStrona> pytaniaStrona;

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;
			this.nrPytania = nrPytania;
			pytaniaStrona = new List<PytanieStrona> { new PytanieL(nrPytania), new PytanieP(nrPytania) };

			panel.Location = new Point(panelPozycjaX, panelPozycjaYPoczątek + (panelWysokość + panelOdstępY) * (nrPytania - 1));
			panel.Size = new Size(panelSzerokość, panelWysokość);

			nazwaLabel.Location = new Point(0, (panelWysokość - nazwaLabelWysokość) / 2);
			nazwaLabel.Size = new Size(nazwaLabelSzerokość, nazwaLabelWysokość);
			nazwaLabel.Text = nazwaPytania;

			panel.Controls.Add(this.nazwaLabel);
			Global.panelKontroler2.Controls.Add(panel);
			pytaniaStrona.ForEach(p => p.umieść(panel));
		}

		public static void wyświetlPunkty()
		{
			PytanieStrona.wyświetlPunkty();
		}
	}
}
