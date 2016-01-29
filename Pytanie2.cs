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
		private bool poprawnePunkty = true;

		public TextBox odpowiedźTextBox = new TextBox();
		protected TextBox punktyTextBox = new TextBox();
		protected Button umieśćButton = new Button();

		public abstract int odpowiedźTextBoxLocationX { get; }
		public abstract int odpowiedźTextBoxTabIndex { get; }
		public abstract int punktyTextBoxLocationX { get; }
		public abstract int punktyTextBoxTabIndex { get; }
		public abstract int umieśćButtonLocationX { get; }

		public abstract int pozycjaOdpowiedziNaTablicy { get; }
		public abstract int pozycjaPunktówNaTablicy { get; }
		public abstract bool wyrównanieDoLewej { get; }

		public abstract void odpowiedź_KeyDown(object sender, KeyEventArgs e);
		public abstract void punkty_KeyDown(object sender, KeyEventArgs e);

		public PytanieStrona(int nrPytania)
		{
			this.nrPytania = nrPytania;

			odpowiedźTextBox.Location = new Point(odpowiedźTextBoxLocationX, 5);
			odpowiedźTextBox.Size = new Size(100, 20);
			odpowiedźTextBox.Leave += new EventHandler(edytor_Leave);
			odpowiedźTextBox.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			odpowiedźTextBox.KeyDown += new KeyEventHandler(odpowiedź_KeyDown);
			odpowiedźTextBox.TabIndex = odpowiedźTextBoxTabIndex;

			punktyTextBox.Location = new Point(punktyTextBoxLocationX, 5);
			punktyTextBox.Size = new Size(30, 20);
			punktyTextBox.Text = "0";
			punktyTextBox.Leave += new EventHandler(edytorPunktów_Leave);
			punktyTextBox.Leave += new EventHandler(edytor_Leave);
			punktyTextBox.KeyDown += new KeyEventHandler(punkty_KeyDown);
			punktyTextBox.TabIndex = punktyTextBoxTabIndex;

			umieśćButton.Location = new Point(umieśćButtonLocationX, 0);
			umieśćButton.Size = new Size(30, 30);
			umieśćButton.Text = "umieść";
			umieśćButton.Click += new EventHandler(pokażUkryj_Click);
			umieśćButton.TabStop = false;

			ukryjOdpowiedź();
		}

		public static void wyświetlPunkty()
		{
			Global.tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
			Global.kontroler.punkty.Text = punkty.ToString();
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
			}
			else
			{
				for (int i = 0; i < odpowiedź.Length; i++)
					if (!Global.znaki.ContainsKey(odpowiedź[i]))
					{
						MessageBox.Show(String.Format("niepoprawny znak {0}", odpowiedź[i]));
						odpowiedźTextBox.Focus();
						return;
					}
			}
		}
		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			TextBox textbox = ((TextBox)sender);
			try
			{
				Int32.Parse(textbox.Text);
				poprawnePunkty = true;
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				textbox.Focus();
				textbox.SelectAll();
				poprawnePunkty = false;
			}
		}
		private void edytor_Leave(object sender, EventArgs e)
		{
			if (poprawnePunkty && wyświetlony())
				pokażUkryj_Click(sender, new EventArgs());
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

				Global.tablica2.ustawTekst(odpowiedźTextBox.Text, pozycjaOdpowiedziNaTablicy, nrPytania + 1, wyrównanieDoLewej, Global.długośćOdpowiedzi2, ' ');
				Global.tablica2.ustawTekst(punktyTextBox.Text, pozycjaPunktówNaTablicy, nrPytania + 1, false, 2, ' ');
				punkty += Int32.Parse(punktyTextBox.Text);
			}
			wyświetlPunkty();
		}
		private void ukryjOdpowiedź()
		{
			Global.tablica2.ustawTekst(String.Empty, pozycjaOdpowiedziNaTablicy, nrPytania + 1, wyrównanieDoLewej, Global.długośćOdpowiedzi2, '.');
			Global.tablica2.ustawTekst(String.Empty, pozycjaPunktówNaTablicy, nrPytania + 1, false, 2, '|');
		}
	}

	class PytanieL : PytanieStrona
	{
		public override int odpowiedźTextBoxLocationX
		{
			get { return 150; }
		}
		public override int odpowiedźTextBoxTabIndex
		{
			get { return 1; }
		}
		public override int punktyTextBoxLocationX
		{
			get { return 250; }
		}
		public override int punktyTextBoxTabIndex
		{
			get { return 2; }
		}
		public override int umieśćButtonLocationX
		{
			get { return 280; }
		}

		public override int pozycjaOdpowiedziNaTablicy
		{
			get { return 1; }
		}
		public override int pozycjaPunktówNaTablicy
		{
			get { return 12; }
		}
		public override bool wyrównanieDoLewej
		{
			get { return false; }
		}

		public override void odpowiedź_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytanieL.odpowiedźTextBox.Focus();
			}
		}
		public override void punkty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytanieL.punktyTextBox.Focus();
			}
		}

		public PytanieL(int nrPytania)
			: base(nrPytania)
		{ }
	}

	class PytanieP : PytanieStrona
	{
		public override int odpowiedźTextBoxLocationX
		{
			get { return 370; }
		}
		public override int odpowiedźTextBoxTabIndex
		{
			get { return 3; }
		}
		public override int punktyTextBoxLocationX
		{
			get { return 340; }
		}
		public override int punktyTextBoxTabIndex
		{
			get { return 4; }
		}
		public override int umieśćButtonLocationX
		{
			get { return 310; }
		}

		public override int pozycjaOdpowiedziNaTablicy
		{
			get { return 19; }
		}
		public override int pozycjaPunktówNaTablicy
		{
			get { return 16; }
		}
		public override bool wyrównanieDoLewej
		{
			get { return true; }
		}

		public override void odpowiedź_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytanieP.odpowiedźTextBox.Focus();
			}
		}
		public override void punkty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (nrPytania != 5)
					Global.pytania2[nrPytania].pytanieP.punktyTextBox.Focus();
			}
		}

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

		public PytanieL pytanieL;
		public PytanieP pytanieP;

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;
			this.nrPytania = nrPytania;

			pytanieL = new PytanieL(nrPytania);
			pytanieP = new PytanieP(nrPytania);

			naKontrolerze.Location = new Point(100, 50 * nrPytania);
			naKontrolerze.Size = new Size(480, 30);
			naKontrolerze.Controls.Add(this.nazwaLabel);
			Global.panelKontroler2.Controls.Add(naKontrolerze);

			nazwaLabel.Location = new Point(5, 8);
			nazwaLabel.Size = new Size(145, 13);
			nazwaLabel.Text = nazwaPytania;

			pytanieL.umieść(naKontrolerze);
			pytanieP.umieść(naKontrolerze);
		}

		public static void wyświetlPunkty()
		{
			PytanieStrona.wyświetlPunkty();
		}
	}
}
