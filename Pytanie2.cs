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

		protected Label odpowiedźLabel = new Label();
		protected Label punktyLabel = new Label();

		public abstract int odpowiedźTextBoxLocationX { get; }
		public abstract int odpowiedźTextBoxTabIndex { get; }
		public abstract int punktyTextBoxLocationX { get; }
		public abstract int punktyTextBoxTabIndex { get; }
		public abstract int umieśćButtonLocationX { get; }
		public abstract int odpowiedźLabelLocationX { get; }
		public abstract int punktyLabelLocationX { get; }

		public abstract void odpowiedź_KeyDown(object sender, KeyEventArgs e);
		public abstract void punkty_KeyDown(object sender, KeyEventArgs e);

		public PytanieStrona()
		{
			odpowiedźTextBox.Location = new Point(odpowiedźTextBoxLocationX, 5);
			odpowiedźTextBox.Size = new Size(100, 20);
			odpowiedźTextBox.Leave += new EventHandler(edytor_Leave);
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

			odpowiedźLabel.Location = new Point(odpowiedźLabelLocationX, 5);
			odpowiedźLabel.Size = new Size(100, 20);

			punktyLabel.Location = new Point(punktyLabelLocationX, 5);
			punktyLabel.Size = new Size(30, 20);
		}
		public static void wyświetlPunkty()
		{
			Punkty.ustawPunkty(punkty);
		}
		public void umieść(Panel naKontrolerze, Panel naGłównym, int nrPytania)
		{
			this.nrPytania = nrPytania;

			naKontrolerze.Controls.Add(this.odpowiedźTextBox);
			naKontrolerze.Controls.Add(this.punktyTextBox);
			naKontrolerze.Controls.Add(this.umieśćButton);

			naGłównym.Controls.Add(this.odpowiedźLabel);
			naGłównym.Controls.Add(this.punktyLabel);
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
		public bool wyświetlony()
		{
			return umieśćButton.BackColor == Color.White;
		}
		private void pokażUkryj_Click(object sender, EventArgs e)
		{
			if (wyświetlony())
			{
				umieśćButton.BackColor = SystemColors.Control;
				umieśćButton.UseVisualStyleBackColor = true;

				odpowiedźLabel.Text = "";
				punktyLabel.Text = "";
				punkty -= Int32.Parse(punktyTextBox.Text);
			}
			else
			{
				umieśćButton.BackColor = Color.White;

				odpowiedźLabel.Text = odpowiedźTextBox.Text;
				punktyLabel.Text = punktyTextBox.Text;
				punkty += Int32.Parse(punktyTextBox.Text);
			}
			wyświetlPunkty();
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
		public override int odpowiedźLabelLocationX
		{
			get { return 150; }
		}
		public override int punktyLabelLocationX
		{
			get { return 250; }
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
		public override int odpowiedźLabelLocationX
		{
			get { return 310; }
		}
		public override int punktyLabelLocationX
		{
			get { return 280; }
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
	}

	class Pytanie2
	{
		string nazwaPytania;
		int nrPytania;

		Panel naKontrolerze = new Panel();
		Panel naGłównym = new Panel();

		Label nazwaLabel = new Label();

		public PytanieL pytanieL = new PytanieL();
		public PytanieP pytanieP = new PytanieP();

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;
			this.nrPytania = nrPytania;

			naKontrolerze.Location = new Point(100, 50 * nrPytania);
			naKontrolerze.Size = new Size(480, 30);
			naKontrolerze.Controls.Add(this.nazwaLabel);
			Global.panelKontroler2.Controls.Add(naKontrolerze);

			nazwaLabel.Location = new Point(5, 8);
			nazwaLabel.Size = new Size(145, 13);
			nazwaLabel.Text = nazwaPytania;

			naGłównym.Location = new Point(30, 50 * nrPytania);
			naGłównym.Size = new Size(420, 30);
			Global.panelGłówny2.Controls.Add(naGłównym);

			pytanieL.umieść(naKontrolerze, naGłównym, nrPytania);
			pytanieP.umieść(naKontrolerze, naGłównym, nrPytania);
		}

		//public static void przenieśFocus()
		//{

		//}
		public static void wyświetlPunkty()
		{
			PytanieStrona.wyświetlPunkty();
		}
	}
}
