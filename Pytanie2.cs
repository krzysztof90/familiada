using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	class Odpowiedź2
	{

	}

	class Pytanie2
	{
		static int punkty;
		
		string nazwaPytania;
		int nrPytania;

		Panel naKontrolerze = new Panel();
		Panel naGłównym = new Panel();

		Label nazwaLabel = new Label();
		TextBox odpowiedźLTextBox = new TextBox();
		TextBox odpowiedźPTextBox = new TextBox();
		TextBox punktyLTextBox = new TextBox();
		TextBox punktyPTextBox = new TextBox();
		Button umieśćL = new Button();
		Button umieśćP = new Button();

		Label odpowiedźLLabel = new Label();
		Label odpowiedźPLabel = new Label();
		Label punktyLLabel = new Label();
		Label punktyPLabel = new Label();

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;
			this.nrPytania = nrPytania;

			naKontrolerze.Location = new System.Drawing.Point(100, 50 * nrPytania);
			naKontrolerze.Size = new System.Drawing.Size(480, 30);
			naKontrolerze.Controls.Add(this.nazwaLabel);
			naKontrolerze.Controls.Add(this.odpowiedźLTextBox);
			naKontrolerze.Controls.Add(this.odpowiedźPTextBox);
			naKontrolerze.Controls.Add(this.punktyLTextBox);
			naKontrolerze.Controls.Add(this.punktyPTextBox);
			naKontrolerze.Controls.Add(this.umieśćL);
			naKontrolerze.Controls.Add(this.umieśćP);
			Global.kontroler.Controls.Add(naKontrolerze);

			nazwaLabel.Location = new System.Drawing.Point(5, 8);
			nazwaLabel.Size = new System.Drawing.Size(145, 13);
			nazwaLabel.Text = nazwaPytania;

			odpowiedźLTextBox.Location = new System.Drawing.Point(150, 5);
			odpowiedźLTextBox.Size = new System.Drawing.Size(100, 20);
			odpowiedźLTextBox.Leave += new EventHandler(edytorL_Leave);
			odpowiedźLTextBox.TabIndex = 1;

			odpowiedźPTextBox.Location = new System.Drawing.Point(370, 5);
			odpowiedźPTextBox.Size = new System.Drawing.Size(100, 20);
			odpowiedźPTextBox.Leave += new EventHandler(edytorP_Leave);
			odpowiedźPTextBox.TabIndex = 3;
			//odpowiedźPTextBox.TabStop = false;

			punktyLTextBox.Location = new System.Drawing.Point(250, 5);
			punktyLTextBox.Size = new System.Drawing.Size(30, 20);
			punktyLTextBox.Text = "0";
			punktyLTextBox.Leave += new EventHandler(edytorPunktów_Leave);
			punktyLTextBox.Leave += new EventHandler(edytorL_Leave);
			punktyLTextBox.KeyDown += new KeyEventHandler(punktyL_KeyDown);
			punktyLTextBox.TabIndex = 2;

			punktyPTextBox.Location = new System.Drawing.Point(340, 5);
			punktyPTextBox.Size = new System.Drawing.Size(30, 20);
			punktyPTextBox.Text = "0";
			punktyPTextBox.Leave += new EventHandler(edytorPunktów_Leave);
			punktyPTextBox.Leave += new EventHandler(edytorP_Leave);
			punktyPTextBox.KeyDown += new KeyEventHandler(punktyP_KeyDown);
			punktyPTextBox.TabIndex = 4;

			umieśćL.Location = new Point(280, 0);
			umieśćL.Size = new Size(30, 30);
			umieśćL.Text = "umieść";
			umieśćL.Click += new EventHandler(pokażUkryjL_Click);
			umieśćL.TabStop = false;

			umieśćP.Location = new Point(310, 0);
			umieśćP.Size = new Size(30, 30);
			umieśćP.Text = "umieść";
			umieśćP.Click += new EventHandler(pokażUkryjP_Click);
			umieśćP.TabStop = false;


			naGłównym.Location = new System.Drawing.Point(30, 50 * nrPytania);
			naGłównym.Size = new System.Drawing.Size(420, 30);
			naGłównym.Controls.Add(this.odpowiedźLLabel);
			naGłównym.Controls.Add(this.odpowiedźPLabel);
			naGłównym.Controls.Add(this.punktyLLabel);
			naGłównym.Controls.Add(this.punktyPLabel);
			Global.główny.Controls.Add(naGłównym);

			odpowiedźLLabel.Location = new System.Drawing.Point(150, 5);
			odpowiedźLLabel.Size = new System.Drawing.Size(100, 20);

			odpowiedźPLabel.Location = new System.Drawing.Point(310, 5);
			odpowiedźPLabel.Size = new System.Drawing.Size(100, 20);

			punktyLLabel.Location = new System.Drawing.Point(250, 5);
			punktyLLabel.Size = new System.Drawing.Size(30, 20);

			punktyPLabel.Location = new System.Drawing.Point(280, 5);
			punktyPLabel.Size = new System.Drawing.Size(30, 20);

			ukryjPytanie();
		}

		public void pokażPytanie()
		{
			naKontrolerze.Show();
			naGłównym.Show();
		}
		public void ukryjPytanie()
		{
			naKontrolerze.Hide();
			naGłównym.Hide();
		}
		public bool wyświetlonyL()
		{
			return umieśćL.BackColor == Color.White;
		}
		public bool wyświetlonyP()
		{
			return umieśćP.BackColor == Color.White;
		}
		public static void wyświetlPunkty()
		{
			Punkty.ustawPunkty(punkty);
		}

		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			TextBox textbox = ((TextBox)sender);
			try
			{
				Int32.Parse(textbox.Text);
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				textbox.Focus();
				textbox.SelectAll();
			}
		}
		private void edytorL_Leave(object sender, EventArgs e)
		{
			if (wyświetlonyL())
				pokażUkryjL_Click(sender, new EventArgs());
		}
		private void edytorP_Leave(object sender, EventArgs e)
		{
			if (wyświetlonyP())
				pokażUkryjP_Click(sender, new EventArgs());
		}
		private void pokażUkryjL_Click(object sender, EventArgs e)
		{
			if (wyświetlonyL())
			{
				umieśćL.BackColor = SystemColors.Control;
				umieśćL.UseVisualStyleBackColor = true;

				odpowiedźLLabel.Text = "";
				punktyLLabel.Text = "";
				punkty -= Int32.Parse(punktyLTextBox.Text);
				wyświetlPunkty();
			}
			else
			{
				umieśćL.BackColor = Color.White;

				odpowiedźLLabel.Text = odpowiedźLTextBox.Text;
				punktyLLabel.Text = punktyLTextBox.Text;
				punkty += Int32.Parse(punktyLTextBox.Text);
				wyświetlPunkty();
			}
		}
		private void pokażUkryjP_Click(object sender, EventArgs e)
		{
			if (wyświetlonyP())
			{
				umieśćP.BackColor = SystemColors.Control;
				umieśćP.UseVisualStyleBackColor = true;

				odpowiedźPLabel.Text = "";
				punktyPLabel.Text = "";
				punkty -= Int32.Parse(punktyPTextBox.Text);
				wyświetlPunkty();
			}
			else
			{
				umieśćP.BackColor = Color.White;

				odpowiedźPLabel.Text = odpowiedźPTextBox.Text;
				punktyPLabel.Text = punktyPTextBox.Text;
				Punkty.dodajPunkty(Int32.Parse(punktyPTextBox.Text));
				punkty += Int32.Parse(punktyPTextBox.Text);
				wyświetlPunkty();
			}
		}
		private void punktyL_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if(nrPytania!=5)
				Global.pytania2[nrPytania].odpowiedźLTextBox.Focus();
				else
				Global.pytania2[0].odpowiedźPTextBox.Focus();

			}
		}
		private void punktyP_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if(nrPytania!=5)
				Global.pytania2[nrPytania].odpowiedźPTextBox.Focus();
			}
		}
	}
}
