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
		protected static int punkty;
		protected int nrPytania;
		private int punktyPytania;

		public TextBox odpowiedźTextBox = new TextBox();
		protected TextBox punktyTextBox = new TextBox();
		protected Button umieśćButton = new Button();

		public abstract int Tag { get; }

		public abstract int odpowiedźTextBoxPozycjaX { get; }
		public abstract int odpowiedźTextBoxTabIndex { get; }
		public abstract int punktyTextBoxPozycjaX { get; }
		public abstract int punktyTextBoxTabIndex { get; }
		public abstract int umieśćButtonPozycjaX { get; }

		public abstract int pozycjaOdpowiedziNaTablicy { get; }
		public abstract int pozycjaPunktówNaTablicy { get; }
		public abstract bool wyrównanieDoLewej { get; }

		public PytanieStrona(int nrPytania)
		{
			this.nrPytania = nrPytania;

			odpowiedźTextBox.Location = new Point(odpowiedźTextBoxPozycjaX, 5);
			odpowiedźTextBox.Size = new Size(100, 20);
			odpowiedźTextBox.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			odpowiedźTextBox.KeyDown += new KeyEventHandler(odpowiedź_KeyDown);
			odpowiedźTextBox.TabIndex = odpowiedźTextBoxTabIndex;

			punktyTextBox.Location = new Point(punktyTextBoxPozycjaX, 5);
			punktyTextBox.Size = new Size(30, 20);
			punktyTextBox.Text = "0";
			punktyTextBox.Leave += new EventHandler(edytorPunktów_Leave);
			punktyTextBox.KeyDown += new KeyEventHandler(punkty_KeyDown);
			punktyTextBox.TabIndex = punktyTextBoxTabIndex;

			umieśćButton.Location = new Point(umieśćButtonPozycjaX, 0);
			umieśćButton.Size = new Size(30, 30);
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
		public bool wyświetlony()
		{
			return umieśćButton.BackColor == Color.White;
		}

		private void edytorOdpowiedzi_Leave(object sender, EventArgs e)
		{
			string odpowiedź = odpowiedźTextBox.Text;

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
			Global.tablica2.ustawTekst(odpowiedźTextBox.Text, pozycjaOdpowiedziNaTablicy, nrPytania + 1, wyrównanieDoLewej, Global.długośćOdpowiedzi2, ' ');
			Global.tablica2.ustawTekst(punktyTextBox.Text, pozycjaPunktówNaTablicy, nrPytania + 1, false, 2, ' ');
		}
		private void ukryjOdpowiedź()
		{
			Global.tablica2.ustawTekst(String.Empty, pozycjaOdpowiedziNaTablicy, nrPytania + 1, wyrównanieDoLewej, Global.długośćOdpowiedzi2, '.');
			Global.tablica2.ustawTekst(String.Empty, pozycjaPunktówNaTablicy, nrPytania + 1, false, 2, '|');
		}
	}

	class PytanieL : PytanieStrona
	{
		public override int Tag { get { return 0; } }

		public override int odpowiedźTextBoxPozycjaX { get { return 150; } }
		public override int odpowiedźTextBoxTabIndex { get { return 1; } }
		public override int punktyTextBoxPozycjaX { get { return 250; } }
		public override int punktyTextBoxTabIndex { get { return 2; } }
		public override int umieśćButtonPozycjaX { get { return 280; } }

		public override int pozycjaOdpowiedziNaTablicy { get { return 1; } }
		public override int pozycjaPunktówNaTablicy { get { return 12; } }
		public override bool wyrównanieDoLewej { get { return false; } }

		public PytanieL(int nrPytania)
			: base(nrPytania)
		{ }
	}

	class PytanieP : PytanieStrona
	{
		public override int Tag { get { return 1; } }

		public override int odpowiedźTextBoxPozycjaX { get { return 370; } }
		public override int odpowiedźTextBoxTabIndex { get { return 3; } }
		public override int punktyTextBoxPozycjaX { get { return 340; } }
		public override int punktyTextBoxTabIndex { get { return 4; } }
		public override int umieśćButtonPozycjaX { get { return 310; } }

		public override int pozycjaOdpowiedziNaTablicy { get { return 19; } }
		public override int pozycjaPunktówNaTablicy { get { return 16; } }
		public override bool wyrównanieDoLewej { get { return true; } }

		public PytanieP(int nrPytania)
			: base(nrPytania)
		{ }
	}

	class Pytanie2
	{
		string nazwaPytania;
		int nrPytania;

		Panel naKontrolerze = new Panel();

		Label nazwaLabel = new Label();
		public List<PytanieStrona> pytaniaStrona;

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;
			this.nrPytania = nrPytania;
			pytaniaStrona = new List<PytanieStrona> { new PytanieL(nrPytania), new PytanieP(nrPytania) };

			naKontrolerze.Location = new Point(100, 50 * nrPytania);
			naKontrolerze.Size = new Size(480, 30);

			nazwaLabel.Location = new Point(5, 8);
			nazwaLabel.Size = new Size(145, 13);
			nazwaLabel.Text = nazwaPytania;

			naKontrolerze.Controls.Add(this.nazwaLabel);
			Global.panelKontroler2.Controls.Add(naKontrolerze);
			pytaniaStrona.ForEach(p => p.umieść(naKontrolerze));
		}

		public static void wyświetlPunkty()
		{
			PytanieStrona.wyświetlPunkty();
		}
	}
}
