using System;
using System.Collections.Generic;
using System.Drawing;
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
		readonly int nrPytania;
		private int punktyPytania = 0;

		readonly TextBox odpowiedźTextBox = new TextBox();
		readonly TextBox punktyTextBox = new TextBox();
		readonly Button umieśćButton = new Button();

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
			odpowiedźTextBox.Leave += new EventHandler(EdytorOdpowiedzi_Leave);
			odpowiedźTextBox.KeyDown += new KeyEventHandler(Odpowiedź_KeyDown);
			odpowiedźTextBox.TabIndex = odpowiedźTextBoxTabIndex;

			punktyTextBox.Location = new Point(punktyTextBoxPozycjaX, (Pytanie2.panelWysokość - punktyTextBoxWysokość) / 2);
			punktyTextBox.Size = new Size(punktyTextBoxSzerokość, punktyTextBoxWysokość);
			punktyTextBox.Text = "0";
			punktyTextBox.Leave += new EventHandler(EdytorPunktów_Leave);
			punktyTextBox.KeyDown += new KeyEventHandler(Punkty_KeyDown);
			punktyTextBox.TabIndex = punktyTextBoxTabIndex;

			umieśćButton.Location = new Point(umieśćButtonPozycjaX, (Pytanie2.panelWysokość - umieśćButtonWysokość) / 2);
			umieśćButton.Size = new Size(umieśćButtonSzerokość, umieśćButtonWysokość);
			umieśćButton.Text = "umieść";
			umieśćButton.Click += new EventHandler(PokażUkryj_Click);
			umieśćButton.TabStop = false;

			UkryjOdpowiedź();
		}

		private static void DodajPunkty(int dodane)
		{
			punkty += dodane;
			WyświetlPunkty();
		}
		public static void WyświetlPunkty()
		{
			Global.UstawPunktyGłówne(punkty);
		}
		public void Umieść(Panel panel)
		{
			panel.Controls.Add(odpowiedźTextBox);
			panel.Controls.Add(punktyTextBox);
			panel.Controls.Add(umieśćButton);
		}
		private bool Wyświetlony()
		{
			return umieśćButton.BackColor == Color.White;
		}

		private void EdytorOdpowiedzi_Leave(object sender, EventArgs e)
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

			if (Wyświetlony())
				PokażOdpowiedź();
		}
		private void EdytorPunktów_Leave(object sender, EventArgs e)
		{
			TextBox textbox = ((TextBox)sender);
			try
			{
				int nowePunkty = Int32.Parse(textbox.Text);
				if (Wyświetlony())
				{
					DodajPunkty(-punktyPytania);
					DodajPunkty(nowePunkty);
					WyświetlPunkty();
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
		private void Odpowiedź_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down && nrPytania != 5)
				Global.pytania2[nrPytania].pytaniaStrona[Tag].odpowiedźTextBox.Focus();
		}
		private void Punkty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down && nrPytania != 5)
				Global.pytania2[nrPytania].pytaniaStrona[Tag].punktyTextBox.Focus();
		}
		private void PokażUkryj_Click(object sender, EventArgs e)
		{
			if (Wyświetlony())
			{
				umieśćButton.BackColor = SystemColors.Control;
				umieśćButton.UseVisualStyleBackColor = true;

				UkryjOdpowiedź();
				DodajPunkty(-Int32.Parse(punktyTextBox.Text));
			}
			else
			{
				umieśćButton.BackColor = Color.White;

				PokażOdpowiedź();
				DodajPunkty(Int32.Parse(punktyTextBox.Text));
			}
		}
		private void PokażOdpowiedź()
		{
			Global.tablica2.UstawTekst(odpowiedźTextBox.Text, pozycjaOdpowiedziNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, wyrównanieDoLewej, Global.długośćOdpowiedzi2, ' ');
			Global.tablica2.UstawTekst(punktyTextBox.Text, pozycjaPunktówNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, false, 2, ' ');
		}
		private void UkryjOdpowiedź()
		{
			Global.tablica2.UstawTekst(String.Empty, pozycjaOdpowiedziNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, wyrównanieDoLewej, Global.długośćOdpowiedzi2, '.');
			Global.tablica2.UstawTekst(String.Empty, pozycjaPunktówNaTablicy, tablicaPozycjaYPoczątek - 1 + nrPytania, false, 2, '|');
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

		readonly string nazwaPytania;
		readonly int nrPytania;

		readonly Panel panel = new Panel();

		readonly Label nazwaLabel = new Label();
		public List<PytanieStrona> pytaniaStrona { get; private set; }

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

			panel.Controls.Add(nazwaLabel);
			pytaniaStrona.ForEach(p => p.Umieść(panel));
			Global.panelKontroler2.Controls.Add(panel);
		}

		public static void WyświetlPunkty()
		{
			PytanieStrona.WyświetlPunkty();
		}
	}
}
