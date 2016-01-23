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

		Panel naKontrolerze = new Panel();
		Panel naGłównym = new Panel();

		Button odpowiedźButton = new Button();
		Button punktyLewyButton = new Button();
		Button punktyPrawyButton = new Button();
		Button edycjaButton = new Button();
		TextBox edytor = new TextBox();

		Label nrOdpowiedziLabel = new Label();
		Label odpowiedźLabel = new Label();

		public Odpowiedź(string linia, int nrOdpowiedzi)
		{
			this.nrOdpowiedzi = nrOdpowiedzi;
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
			naKontrolerze.Size = new System.Drawing.Size(300, 30);
			naKontrolerze.Hide();
			Global.kontroler.Controls.Add(naKontrolerze);

			odpowiedźButton.Size = new Size(100, 30);
			odpowiedźButton.Location = new Point(50, 0);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(zaznaczOdznacz_Click);
			naKontrolerze.Controls.Add(odpowiedźButton);

			edytor.AutoSize = false;
			edytor.Size = new Size(100, 30);
			edytor.Location = new Point(50, 0);
			edytor.Text = odpowiedź;
			edytor.Hide();
			edytor.Leave += new EventHandler(edytor_Leave);
			edytor.KeyPress += new KeyPressEventHandler(edytor_KeyPress);
			naKontrolerze.Controls.Add(edytor);

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

			edycjaButton.Size = new Size(30, 30);
			edycjaButton.Location = new Point(220, 0);
			edycjaButton.Text = "edytuj";
			edycjaButton.Click += new EventHandler(edytuj_Click);
			naKontrolerze.Controls.Add(edycjaButton);

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

		private void edytuj_Click(object sender, EventArgs e)
		{
			edytor.Show();
			edytor.BringToFront();
			edytor.Focus();
		}
		private void edytor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				edytor_Leave(sender, new EventArgs());
		}
		private void edytor_Leave(object sender, EventArgs e)
		{
			edytor.Hide();
			odpowiedź = edytor.Text;
			odpowiedźButton.Text = odpowiedź;
			odpowiedźLabel.Text = odpowiedź;
		}
	}
}