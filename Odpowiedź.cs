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
		Pytanie1 pytanie;

		Panel panel = new Panel();

		Button odpowiedźButton = new Button();
		Button punktyButton = new Button();
		Button edycjaOdpowiedziButton = new Button();
		TextBox edytorOdpowiedzi = new TextBox();
		TextBox edytorPunktów = new TextBox();
		Button doGóry = new Button();
		Button doDołu = new Button();
		Button usuńButton = new Button();

		public Odpowiedź(string linia, Pytanie1 pytanie)
		{
			this.pytanie = pytanie;

			nrOdpowiedzi = pytanie.odpowiedzi.Count + 1;

			int pozycjaPrzerwy = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (pozycjaPrzerwy == -1)
				Global.exit(String.Format("niepoprawna linia: {0}", linia));
			odpowiedź = linia.Substring(0, pozycjaPrzerwy).TrimEnd();
			if (odpowiedź.Length > Global.długośćOdpowiedzi1)
				Global.exit(String.Format("za długa odpowiedź: {0}. Dopuszczalna długość to {1}", odpowiedź, Global.długośćOdpowiedzi1));
			for (int i = 0; i < odpowiedź.Length; i++)
				if (!Global.znaki.ContainsKey(odpowiedź[i]))
					Global.exit(String.Format("niepoprawny znak '{0}' w {1}", odpowiedź[i], odpowiedź));
			try
			{
				punkty = Int32.Parse(linia.Substring(pozycjaPrzerwy + 1));
			}
			catch (FormatException)
			{
				Global.exit("niepoprawna liczba punktów");
			}

			panel.Size = new System.Drawing.Size(290, 30);
			panel.Hide();

			odpowiedźButton.Location = new Point(50, 0);
			odpowiedźButton.Size = new Size(100, 30);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(zaznaczOdznacz_Click);

			punktyButton.Location = new Point(170, 0);
			punktyButton.Size = new Size(30, 30);
			punktyButton.Text = punkty.ToString();
			punktyButton.Click += new EventHandler(edytujPunkty_Click);

			edycjaOdpowiedziButton.Location = new Point(200, 0);
			edycjaOdpowiedziButton.Size = new Size(30, 30);
			edycjaOdpowiedziButton.Text = "edytuj";
			edycjaOdpowiedziButton.Click += new EventHandler(edytujOdpowiedź_Click);

			edytorOdpowiedzi.AutoSize = false;
			edytorOdpowiedzi.Location = new Point(50, 0);
			edytorOdpowiedzi.Size = new Size(100, 30);
			edytorOdpowiedzi.Text = odpowiedź;
			edytorOdpowiedzi.Hide();
			edytorOdpowiedzi.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			edytorOdpowiedzi.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorOdpowiedzi.Tag = new EventHandler(edytorOdpowiedzi_Leave);

			edytorPunktów.AutoSize = false;
			edytorPunktów.Location = new Point(170, 0);
			edytorPunktów.Size = new Size(30, 30);
			edytorPunktów.Text = punkty.ToString();
			edytorPunktów.Hide();
			edytorPunktów.Leave += new EventHandler(edytorPunktów_Leave);
			edytorPunktów.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorPunktów.Tag = new EventHandler(edytorPunktów_Leave);

			doGóry.Location = new Point(230, 0);
			doGóry.Size = new Size(30, 15);
			doGóry.Text = "góra";
			doGóry.Click += new EventHandler(doGóry_Click);

			doDołu.Location = new Point(230, 15);
			doDołu.Size = new Size(30, 15);
			doDołu.Text = "dół";
			doDołu.Click += new EventHandler(doDołu_Click);

			usuńButton.Location = new Point(260, 0);
			usuńButton.Size = new Size(30, 30);
			usuńButton.Text = "usuń";
			usuńButton.Click += new EventHandler(usuń_Click);

			panel.Controls.Add(odpowiedźButton);
			panel.Controls.Add(punktyButton);
			panel.Controls.Add(edycjaOdpowiedziButton);
			panel.Controls.Add(edytorOdpowiedzi);
			panel.Controls.Add(edytorPunktów);
			panel.Controls.Add(doGóry);
			panel.Controls.Add(doDołu);
			panel.Controls.Add(usuńButton);

			Global.panelKontroler1.Controls.Add(panel);
		}

		public void pokażKontrolkiOdpowiedzi()
		{
			panel.Location = new Point(100, nrOdpowiedzi * 30 + 30);
			panel.Show();

			wyświetlNrOdpowiedzi(true, ' ');
			if (zaznaczona())
				pokażOdpowiedź();
			else
				ukryjOdpowiedź();
		}
		public void ukryjKontrolkiOdpowiedzi()
		{
			panel.Hide();
			wyświetlNrOdpowiedzi(false, ' ');
			wyświetlOdpowiedź(false, ' ');
			wyświetlPunkty(false, ' ');
		}
		public void pokażOdpowiedź()
		{
			wyświetlOdpowiedź(true, '.');
			wyświetlPunkty(true, ' ');
		}
		public void ukryjOdpowiedź()
		{
			wyświetlOdpowiedź(false, '.');
			wyświetlPunkty(false, '|');
		}
		public void przesuń(int numer, bool usuń)
		{
			if (usuń)
				ukryjKontrolkiOdpowiedzi();
			nrOdpowiedzi = numer;
			pokażKontrolkiOdpowiedzi();
		}
		public bool zaznaczona()
		{
			return odpowiedźButton.BackColor == Color.White;
		}

		private void zaznaczOdznacz_Click(object sender, EventArgs e)
		{
			if (!zaznaczona())
			{
				odpowiedźButton.BackColor = Color.White;

				pokażOdpowiedź();

				if (pytanie.druzynaZPrzypisanymiPunktami == null)
					pytanie.dodajPunkty(punkty);
			}
			else
			{
				odpowiedźButton.BackColor = SystemColors.Control;
				odpowiedźButton.UseVisualStyleBackColor = true;

				ukryjOdpowiedź();

				if (pytanie.druzynaZPrzypisanymiPunktami == null)
					pytanie.dodajPunkty(-punkty);
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
			odpowiedź = edytorOdpowiedzi.Text;
			odpowiedźButton.Text = odpowiedź;

			if (odpowiedź.Length > Global.długośćOdpowiedzi1)
			{
				MessageBox.Show(String.Format("Tekst za długi o {0} znaków", odpowiedź.Length-Global.długośćOdpowiedzi1));
				edytorOdpowiedzi.Focus();
			}
			else
			{
				for (int i = 0; i < odpowiedź.Length; i++)
					if (!Global.znaki.ContainsKey(odpowiedź[i]))
					{
						MessageBox.Show(String.Format("niepoprawny znak {0}", odpowiedź[i]));
						edytorOdpowiedzi.Focus();
						return;
					}
				if (zaznaczona())
					wyświetlOdpowiedź(true, '.');
				edytorOdpowiedzi.Hide();
			}
		}
		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			try
			{
				punkty = Int32.Parse(edytorPunktów.Text);
				edytorPunktów.Hide();
				punktyButton.Text = punkty.ToString();
				if (zaznaczona())
					wyświetlPunkty(true, ' ');
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				edytorPunktów.Focus();
				edytorPunktów.SelectAll();
			}
		}
		private void doGóry_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != 1)
				pytanie.zamieńOdpowiedzi(nrOdpowiedzi - 1);
		}
		private void doDołu_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != pytanie.odpowiedzi.Count)
				pytanie.zamieńOdpowiedzi(nrOdpowiedzi);
		}
		private void usuń_Click(object sender, EventArgs e)
		{
			pytanie.usuńOdpowiedź(nrOdpowiedzi);
		}

		private void wyświetlNrOdpowiedzi(bool niePuste, char wypełnienie)
		{
			Global.tablica1.ustawTekst(niePuste ? nrOdpowiedzi.ToString() : String.Empty, 4, nrOdpowiedzi, false, 2, wypełnienie);
		}
		private void wyświetlOdpowiedź(bool niePuste, char wypełnienie)
		{
			Global.tablica1.ustawTekst(niePuste ? odpowiedź : String.Empty, 6, nrOdpowiedzi, true, Global.długośćOdpowiedzi1, wypełnienie);
		}
		private void wyświetlPunkty(bool niePuste, char wypełnienie)
		{
			Global.tablica1.ustawTekst(niePuste ? punkty.ToString() : String.Empty, 24, nrOdpowiedzi, false, 2, wypełnienie);
		}
	}
}