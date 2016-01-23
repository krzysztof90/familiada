using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace familiada
{
	class Odpowiedź
	{
		public string odpowiedź;
		public int punkty;
		public int nrOdpowiedzi;
		Pytanie pytanie;

		Panel naKontrolerze = new Panel();
		Panel naGłównym = new Panel();

		Button odpowiedźButton = new Button();
		Button punktyLewyButton = new Button();
		Button punktyPrawyButton = new Button();
		Button edycjaOdpowiedziButton = new Button();
		Button edycjaPunktówButton = new Button();
		TextBox edytorOdpowiedzi = new TextBox();
		TextBox edytorPunktów = new TextBox();
		Button doGóry = new Button();
		Button doDołu = new Button();

		Label nrOdpowiedziLabel = new Label();
		Label odpowiedźLabel = new Label();

		public Odpowiedź(string linia, Pytanie pytanie)
		{
			this.pytanie = pytanie;
			nrOdpowiedzi = pytanie.odpowiedzi.Count + 1;
			int gdziePrzerwa = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (gdziePrzerwa == -1)
				Global.exit(String.Format("niepoprawna linia: {0}", linia));
			odpowiedź = linia.Substring(0, gdziePrzerwa).TrimEnd();
			try
			{
				punkty = Int32.Parse(linia.Substring(gdziePrzerwa + 1));
			}
			catch (FormatException)
			{
				Global.exit("niepoprawna liczba punktów");
			}

			naKontrolerze.Location = new Point(100, nrOdpowiedzi * 30);
			naKontrolerze.Size = new System.Drawing.Size(310, 30);
			naKontrolerze.Hide();
			Global.kontroler.Controls.Add(naKontrolerze);

			odpowiedźButton.Size = new Size(100, 30);
			odpowiedźButton.Location = new Point(50, 0);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(zaznaczOdznacz_Click);

			punktyLewyButton.Size = new Size(50, 30);
			punktyLewyButton.Location = new Point(0, 0);
			punktyLewyButton.Text = punkty.ToString();
			punktyLewyButton.Tag = Global.drużynaL;
			punktyLewyButton.Click += new EventHandler(zaznaczDrużynie_Click);
			naKontrolerze.Controls.Add(punktyLewyButton);

			punktyPrawyButton.Size = new Size(50, 30);
			punktyPrawyButton.Location = new Point(150, 0);
			punktyPrawyButton.Text = punkty.ToString();
			punktyPrawyButton.Tag = Global.drużynaP;
			punktyPrawyButton.Click += new EventHandler(zaznaczDrużynie_Click);
			naKontrolerze.Controls.Add(punktyPrawyButton);

			edycjaOdpowiedziButton.Size = new Size(30, 30);
			edycjaOdpowiedziButton.Location = new Point(220, 0);
			edycjaOdpowiedziButton.Text = "edytuj";
			edycjaOdpowiedziButton.Click += new EventHandler(edytujOdpowiedź_Click);
			naKontrolerze.Controls.Add(edycjaOdpowiedziButton);

			edycjaPunktówButton.Size = new Size(30, 30);
			edycjaPunktówButton.Location = new Point(250, 0);
			edycjaPunktówButton.Text = "edytuj punkty";
			edycjaPunktówButton.Click += new EventHandler(edytujPunkty_Click);
			naKontrolerze.Controls.Add(edycjaPunktówButton);
			naKontrolerze.Controls.Add(odpowiedźButton);

			edytorOdpowiedzi.AutoSize = false;
			edytorOdpowiedzi.Size = new Size(100, 30);
			edytorOdpowiedzi.Location = new Point(50, 0);
			edytorOdpowiedzi.Text = odpowiedź;
			edytorOdpowiedzi.Hide();
			edytorOdpowiedzi.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			edytorOdpowiedzi.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorOdpowiedzi.Tag = new EventHandler(edytorOdpowiedzi_Leave);
			naKontrolerze.Controls.Add(edytorOdpowiedzi);

			edytorPunktów.AutoSize = false;
			edytorPunktów.Size = new Size(30, 30);
			edytorPunktów.Location = new Point(250, 0);
			edytorPunktów.Text = punkty.ToString();
			edytorPunktów.Hide();
			edytorPunktów.Leave += new EventHandler(edytorPunktów_Leave);
			edytorPunktów.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorPunktów.Tag = new EventHandler(edytorPunktów_Leave);
			naKontrolerze.Controls.Add(edytorPunktów);

			doGóry.Size = new Size(30, 15);
			doGóry.Location = new Point(280, 0);
			doGóry.Text = "góra";
			doGóry.Tag = nrOdpowiedzi;
			doGóry.Click += new EventHandler(doGóry_Click);
			naKontrolerze.Controls.Add(doGóry);

			doDołu.Size = new Size(30, 15);
			doDołu.Location = new Point(280, 15);
			doDołu.Text = "dół";
			doDołu.Tag = nrOdpowiedzi;
			doDołu.Click += new EventHandler(doDołu_Click);
			naKontrolerze.Controls.Add(doDołu);

			naGłównym.Location = new Point(100, nrOdpowiedzi * 30);
			naGłównym.Size = new System.Drawing.Size(200, 30);
			naGłównym.Hide();
			Global.główny.Controls.Add(naGłównym);

			nrOdpowiedziLabel.AutoSize = true;
			nrOdpowiedziLabel.Location = new Point(0, 0);
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
			naGłównym.Controls.Add(nrOdpowiedziLabel);

			odpowiedźLabel.Location = new Point(30, 0);
			odpowiedźLabel.Text = odpowiedź;
			odpowiedźLabel.Hide();
			naGłównym.Controls.Add(odpowiedźLabel);
		}

		public void zainicjujKontrolkiOdpowiedzi()
		{
			naKontrolerze.Show();
			naGłównym.Show();
		}
		public void ukryjKontrolkiOdpowiedzi()
		{
			naKontrolerze.Hide();
			naGłównym.Hide();
		}
		public void pokażOdpowiedź()
		{
			odpowiedźLabel.Show();
		}
		public void ukryjOdpowiedź()
		{
			odpowiedźLabel.Hide();
		}
		public void usuńOdpowiedź()
		{
			odpowiedźButton.Dispose();
			nrOdpowiedziLabel.Dispose();
			odpowiedźLabel.Dispose();
		}
		public void zaznacz()
		{
			odpowiedźButton.BackColor = Color.White;

			pokażOdpowiedź();
		}
		public void odznacz(bool odejmijPunkty)
		{
			ukryjOdpowiedź();

			if (odejmijPunkty)
			{
				Drużyna drużyna = zaznaczonaDrużyna();
				if (drużyna != null)
					drużyna.dodajPunkty(-punkty);
			}

			odpowiedźButton.BackColor = SystemColors.Control;
			odpowiedźButton.UseVisualStyleBackColor = true;
			punktyPrawyButton.BackColor = SystemColors.Control;
			punktyPrawyButton.UseVisualStyleBackColor = true;
			punktyLewyButton.BackColor = SystemColors.Control;
			punktyLewyButton.UseVisualStyleBackColor = true;
		}
		public bool zaznaczona()
		{
			return odpowiedźButton.BackColor == Color.White;
		}
		private Drużyna zaznaczonaDrużyna()
		{
			if (punktyLewyButton.BackColor == Color.White)
				return (Drużyna)(punktyLewyButton.Tag);
			if (punktyPrawyButton.BackColor == Color.White)
				return (Drużyna)punktyPrawyButton.Tag;
			return null;
		}
		public void zmieńNumer(int numer)
		{
			nrOdpowiedzi = numer;
			naKontrolerze.Location = new Point(100, nrOdpowiedzi * 30);
			naGłównym.Location = new Point(100, nrOdpowiedzi * 30);
			doGóry.Tag = nrOdpowiedzi;
			doDołu.Tag = nrOdpowiedzi;
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
		}

		private void zaznaczOdznacz_Click(object sender, EventArgs e)
		{
			if (!zaznaczona())
			{
				zaznacz();
			}
			else
			{
				odznacz(true);
			}
		}
		private void zaznaczDrużynie_Click(object sender, EventArgs e)
		{
			if (!zaznaczona())
			{
				zaznacz();
				((Button)sender).BackColor = Color.White;

				((Button)sender).BackColor = Color.White;
				((Drużyna)(((Button)sender).Tag)).dodajPunkty(punkty);
			}
		}

		private void edytujOdpowiedź_Click(object sender, EventArgs e)
		{
			edytorOdpowiedzi.Show();
			edytorOdpowiedzi.BringToFront();
			edytorOdpowiedzi.Focus();
		}
		private void edytujPunkty_Click(object sender, EventArgs e)
		{
			edytorPunktów.Show();
			edytorPunktów.BringToFront();
			edytorPunktów.Focus();
		}
		private void edytor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				((EventHandler)(((TextBox)sender).Tag))(sender, new EventArgs());
		}
		private void edytorOdpowiedzi_Leave(object sender, EventArgs e)
		{
			edytorOdpowiedzi.Hide();
			odpowiedź = edytorOdpowiedzi.Text;
			odpowiedźButton.Text = odpowiedź;
			odpowiedźLabel.Text = odpowiedź;
		}
		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			try
			{
				punkty = Int32.Parse(edytorPunktów.Text);
				edytorPunktów.Hide();
				punktyLewyButton.Text = punkty.ToString();
				punktyPrawyButton.Text = punkty.ToString();
				//punktyLabel.Text = odpowiedź;
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				edytorPunktów.SelectAll();
			}
		}
		private void doGóry_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != 1)
				pytanie.zamieńOdpowiedzi(((int)(((Button)sender).Tag))-1);
		}
		private void doDołu_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != pytanie.odpowiedzi.Count)
				pytanie.zamieńOdpowiedzi((int)(((Button)sender).Tag));
		}
	}
}