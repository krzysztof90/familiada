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
		Button usuńButton = new Button();

		Label nrOdpowiedziLabel = new Label();
		Label odpowiedźLabel = new Label();
		Label punktyLabel = new Label();

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

			naKontrolerze.Location = new Point(100, nrOdpowiedzi * 30+30);
			naKontrolerze.Size = new System.Drawing.Size(340, 30);
			naKontrolerze.Hide();
			Global.kontroler.Controls.Add(naKontrolerze);

			odpowiedźButton.Location = new Point(50, 0);
			odpowiedźButton.Size = new Size(100, 30);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(zaznaczOdznacz_Click);
			naKontrolerze.Controls.Add(odpowiedźButton);

			punktyLewyButton.Location = new Point(0, 0);
			punktyLewyButton.Size = new Size(50, 30);
			punktyLewyButton.Text = punkty.ToString();
			punktyLewyButton.Tag = Global.drużynaL;
			punktyLewyButton.Click += new EventHandler(zaznaczDrużynie_Click);
			naKontrolerze.Controls.Add(punktyLewyButton);

			punktyPrawyButton.Location = new Point(150, 0);
			punktyPrawyButton.Size = new Size(50, 30);
			punktyPrawyButton.Text = punkty.ToString();
			punktyPrawyButton.Tag = Global.drużynaP;
			punktyPrawyButton.Click += new EventHandler(zaznaczDrużynie_Click);
			naKontrolerze.Controls.Add(punktyPrawyButton);

			edycjaOdpowiedziButton.Location = new Point(220, 0);
			edycjaOdpowiedziButton.Size = new Size(30, 30);
			edycjaOdpowiedziButton.Text = "edytuj";
			edycjaOdpowiedziButton.Click += new EventHandler(edytujOdpowiedź_Click);
			naKontrolerze.Controls.Add(edycjaOdpowiedziButton);

			edycjaPunktówButton.Location = new Point(250, 0);
			edycjaPunktówButton.Size = new Size(30, 30);
			edycjaPunktówButton.Text = "edytuj punkty";
			edycjaPunktówButton.Click += new EventHandler(edytujPunkty_Click);
			naKontrolerze.Controls.Add(edycjaPunktówButton);

			edytorOdpowiedzi.AutoSize = false;
			edytorOdpowiedzi.Location = new Point(50, 0);
			edytorOdpowiedzi.Size = new Size(100, 30);
			edytorOdpowiedzi.Text = odpowiedź;
			edytorOdpowiedzi.Hide();
			edytorOdpowiedzi.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			edytorOdpowiedzi.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorOdpowiedzi.Tag = new EventHandler(edytorOdpowiedzi_Leave);
			naKontrolerze.Controls.Add(edytorOdpowiedzi);

			edytorPunktów.AutoSize = false;
			edytorPunktów.Location = new Point(250, 0);
			edytorPunktów.Size = new Size(30, 30);
			edytorPunktów.Text = punkty.ToString();
			edytorPunktów.Hide();
			edytorPunktów.Leave += new EventHandler(edytorPunktów_Leave);
			edytorPunktów.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorPunktów.Tag = new EventHandler(edytorPunktów_Leave);
			naKontrolerze.Controls.Add(edytorPunktów);

			doGóry.Location = new Point(280, 0);
			doGóry.Size = new Size(30, 15);
			doGóry.Text = "góra";
			doGóry.Tag = nrOdpowiedzi;
			doGóry.Click += new EventHandler(doGóry_Click);
			naKontrolerze.Controls.Add(doGóry);

			doDołu.Location = new Point(280, 15);
			doDołu.Size = new Size(30, 15);
			doDołu.Text = "dół";
			doDołu.Tag = nrOdpowiedzi;
			doDołu.Click += new EventHandler(doDołu_Click);
			naKontrolerze.Controls.Add(doDołu);

			usuńButton.Location = new Point(310, 0);
			usuńButton.Size = new Size(30, 30);
			usuńButton.Text = "usuń";
			usuńButton.Click += new EventHandler(usuń_Click);
			naKontrolerze.Controls.Add(usuńButton);


			naGłównym.Location = new Point(100, nrOdpowiedzi * 30);
			naGłównym.Size = new Size(210, 30);
			naGłównym.Hide();
			Global.główny.Controls.Add(naGłównym);

			nrOdpowiedziLabel.Location = new Point(0, 0);
			nrOdpowiedziLabel.Size = new Size(30, 30);
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
			naGłównym.Controls.Add(nrOdpowiedziLabel);

			odpowiedźLabel.Location = new Point(30, 0);
			odpowiedźLabel.Size = new Size(150, 30);
			odpowiedźLabel.Text = odpowiedź;
			odpowiedźLabel.Hide();
			naGłównym.Controls.Add(odpowiedźLabel);

			punktyLabel.Location = new Point(180, 0);
			punktyLabel.Size = new Size(30, 30);
			punktyLabel.Text = punkty.ToString();
			punktyLabel.Hide();
			naGłównym.Controls.Add(punktyLabel);
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
			punktyLabel.Show();
		}
		public void ukryjOdpowiedź()
		{
			odpowiedźLabel.Hide();
			punktyLabel.Hide();
		}
		public void usuńOdpowiedź()
		{
			naKontrolerze.Dispose();
			naGłównym.Dispose();
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
				pytanie.dodajPunkty(-punkty);

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
			naKontrolerze.Location = new Point(100, nrOdpowiedzi * 30+30);
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
				pytanie.dodajPunkty(punkty);

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
				punktyLabel.Text = punkty.ToString();
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
				pytanie.zamieńOdpowiedzi(nrOdpowiedzi-1);
		}
		private void doDołu_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != pytanie.odpowiedzi.Count)
				pytanie.zamieńOdpowiedzi(nrOdpowiedzi);
		}
		private void usuń_Click(object sender, EventArgs e)
		{
			pytanie.usuń(nrOdpowiedzi);
		}
	}
}