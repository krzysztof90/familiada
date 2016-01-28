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

		public Odpowiedź(string linia, Pytanie1 pytanie)
		{
			this.pytanie = pytanie;

			nrOdpowiedzi = pytanie.odpowiedzi.Count + 1;

			int pozycjaPrzerwy = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (pozycjaPrzerwy == -1)
				Global.exit(String.Format("niepoprawna linia: {0}", linia));
			odpowiedź = linia.Substring(0, pozycjaPrzerwy).TrimEnd();
			if (odpowiedź.Length > Global.długośćOdpowiedzi)
				Global.exit(String.Format("za długa odpowiedź: {0}", odpowiedź));
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

			naKontrolerze.Size = new System.Drawing.Size(340, 30);
			naKontrolerze.Hide();

			odpowiedźButton.Location = new Point(50, 0);
			odpowiedźButton.Size = new Size(100, 30);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(zaznaczOdznacz_Click);

			punktyLewyButton.Location = new Point(0, 0);
			punktyLewyButton.Size = new Size(50, 30);
			punktyLewyButton.Text = punkty.ToString();
			punktyLewyButton.Tag = Global.drużynaL;
			punktyLewyButton.Click += new EventHandler(zaznaczDrużynie_Click);

			punktyPrawyButton.Location = new Point(150, 0);
			punktyPrawyButton.Size = new Size(50, 30);
			punktyPrawyButton.Text = punkty.ToString();
			punktyPrawyButton.Tag = Global.drużynaP;
			punktyPrawyButton.Click += new EventHandler(zaznaczDrużynie_Click);

			edycjaOdpowiedziButton.Location = new Point(220, 0);
			edycjaOdpowiedziButton.Size = new Size(30, 30);
			edycjaOdpowiedziButton.Text = "edytuj";
			edycjaOdpowiedziButton.Click += new EventHandler(edytujOdpowiedź_Click);

			edycjaPunktówButton.Location = new Point(250, 0);
			edycjaPunktówButton.Size = new Size(30, 30);
			edycjaPunktówButton.Text = "edytuj punkty";
			edycjaPunktówButton.Click += new EventHandler(edytujPunkty_Click);

			edytorOdpowiedzi.AutoSize = false;
			edytorOdpowiedzi.Location = new Point(50, 0);
			edytorOdpowiedzi.Size = new Size(100, 30);
			edytorOdpowiedzi.Text = odpowiedź;
			edytorOdpowiedzi.Hide();
			edytorOdpowiedzi.Leave += new EventHandler(edytorOdpowiedzi_Leave);
			edytorOdpowiedzi.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorOdpowiedzi.Tag = new EventHandler(edytorOdpowiedzi_Leave);

			edytorPunktów.AutoSize = false;
			edytorPunktów.Location = new Point(250, 0);
			edytorPunktów.Size = new Size(30, 30);
			edytorPunktów.Text = punkty.ToString();
			edytorPunktów.Hide();
			edytorPunktów.Leave += new EventHandler(edytorPunktów_Leave);
			edytorPunktów.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			edytorPunktów.Tag = new EventHandler(edytorPunktów_Leave);

			doGóry.Location = new Point(280, 0);
			doGóry.Size = new Size(30, 15);
			doGóry.Text = "góra";
			doGóry.Click += new EventHandler(doGóry_Click);

			doDołu.Location = new Point(280, 15);
			doDołu.Size = new Size(30, 15);
			doDołu.Text = "dół";
			doDołu.Click += new EventHandler(doDołu_Click);

			usuńButton.Location = new Point(310, 0);
			usuńButton.Size = new Size(30, 30);
			usuńButton.Text = "usuń";
			usuńButton.Click += new EventHandler(usuń_Click);

			//naGłównym.Hide();

			naKontrolerze.Controls.Add(odpowiedźButton);
			naKontrolerze.Controls.Add(punktyLewyButton);
			naKontrolerze.Controls.Add(punktyPrawyButton);
			naKontrolerze.Controls.Add(edycjaOdpowiedziButton);
			naKontrolerze.Controls.Add(edycjaPunktówButton);
			naKontrolerze.Controls.Add(edytorOdpowiedzi);
			naKontrolerze.Controls.Add(edytorPunktów);
			naKontrolerze.Controls.Add(doGóry);
			naKontrolerze.Controls.Add(doDołu);
			naKontrolerze.Controls.Add(usuńButton);

			Global.panelKontroler1.Controls.Add(naKontrolerze);
			//Global.panelGłówny1.Controls.Add(naGłównym);
		}

		public void pokażKontrolkiOdpowiedzi()
		{
			naKontrolerze.Location = new Point(100, nrOdpowiedzi * 30 + 30);
			naKontrolerze.Show();

			Global.tablica1.ustawTekst(nrOdpowiedzi.ToString(), 0, nrOdpowiedzi, false, 2, ' ');
			if (zaznaczona())
			{
				Global.tablica1.ustawTekst(odpowiedź, 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, '.');
				Global.tablica1.ustawTekst(punkty.ToString(), 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, false, 2, ' ');
			}
			else
			{
				Global.tablica1.ustawTekst("", 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, '.');
				Global.tablica1.ustawTekst("", 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, true, 2, '|');
			}
		}
		public void ukryjKontrolkiOdpowiedzi()
		{
			naKontrolerze.Hide();
			Global.tablica1.ustawTekst("", 0, nrOdpowiedzi, false, 2, ' ');
			Global.tablica1.ustawTekst("", 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, ' ');
			Global.tablica1.ustawTekst("", 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, true, 2, ' ');
		}
		public void pokażOdpowiedź()
		{
			Global.tablica1.ustawTekst(odpowiedź, 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, '.');
			Global.tablica1.ustawTekst(punkty.ToString(), 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, false, 2, ' ');
		}
		public void ukryjOdpowiedź()
		{
			Global.tablica1.ustawTekst("", 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, '.');
			Global.tablica1.ustawTekst("", 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, true, 2, '|');
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

		private Drużyna zaznaczonaDrużyna()
		{
			if (punktyLewyButton.BackColor == Color.White)
				return (Drużyna)(punktyLewyButton.Tag);
			if (punktyPrawyButton.BackColor == Color.White)
				return (Drużyna)punktyPrawyButton.Tag;
			return null;
		}

		private void zaznaczOdznacz_Click(object sender, EventArgs e)
		{
			if (!zaznaczona())
			{
				odpowiedźButton.BackColor = Color.White;

				pokażOdpowiedź();
			}
			else
			{
				Drużyna drużyna = zaznaczonaDrużyna();
				if (drużyna != null)
				{
					drużyna.dodajPunkty(-punkty);
					pytanie.dodajPunkty(-punkty);
				}

				odpowiedźButton.BackColor = SystemColors.Control;
				odpowiedźButton.UseVisualStyleBackColor = true;
				punktyPrawyButton.BackColor = SystemColors.Control;
				punktyPrawyButton.UseVisualStyleBackColor = true;
				punktyLewyButton.BackColor = SystemColors.Control;
				punktyLewyButton.UseVisualStyleBackColor = true;

				ukryjOdpowiedź();
			}
		}
		private void zaznaczDrużynie_Click(object sender, EventArgs e)
		{
			if (!zaznaczona())
			{
				zaznaczOdznacz_Click(sender, new EventArgs());

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
			odpowiedź = edytorOdpowiedzi.Text;
			odpowiedźButton.Text = odpowiedź;

			if (odpowiedź.Length > Global.długośćOdpowiedzi)
			{
				MessageBox.Show("za długi tekst");
				edytorOdpowiedzi.Focus();
			}
			else
			{
				char? niepoprawnyZnak = null;
				for (int i = 0; i < odpowiedź.Length; i++)
					if (!Global.znaki.ContainsKey(odpowiedź[i]))
					{
						niepoprawnyZnak = odpowiedź[i];
						break;
					}
				if (niepoprawnyZnak != null)
					MessageBox.Show(String.Format("niepoprawny znak {0}", niepoprawnyZnak));
				else
				{
					if (zaznaczona())
						Global.tablica1.ustawTekst(odpowiedź, 2, nrOdpowiedzi, true, Global.długośćOdpowiedzi, '.');
					edytorOdpowiedzi.Hide();
				}
			}
		}
		private void edytorPunktów_Leave(object sender, EventArgs e)
		{
			try
			{
				punkty = Int32.Parse(edytorPunktów.Text);
				edytorPunktów.Hide();
				punktyLewyButton.Text = punkty.ToString();
				punktyPrawyButton.Text = punkty.ToString();
				if (zaznaczona())
					Global.tablica1.ustawTekst(punkty.ToString(), 3 + Global.długośćOdpowiedzi, nrOdpowiedzi, false, 2, ' ');
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
	}
}