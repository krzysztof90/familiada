using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace familiada
{
	class Odpowiedź
	{
		private const int panelWysokość = 30;
		private const int odpowiedźButtoniPunktyButtonOdstępX = 20;
		private const int operacjeButtonOdstępX = 0;
		private const int odpowiedźButtonSzerokość = 150;
		private const int operacjeButtonSzerokość = 30;

		private const int tablicaOdstępNumerOdpowiedziOdpowiedź = 1;
		private const int tablicaNumerOdpowiedziPozycjaX = 3;
		private const int tablicaOdpowiedźPozycjaX = tablicaNumerOdpowiedziPozycjaX + 1 + tablicaOdstępNumerOdpowiedziOdpowiedź;
		private const int tablicaPunktyPozycjaX = tablicaOdpowiedźPozycjaX + 1 + Global.długośćOdpowiedzi1;
		public const int tablicaPunktyPozycjaYPoczątek = 2;

		private string odpowiedź;
		private int punkty;
		private int nrOdpowiedzi;
		readonly Pytanie1 pytanie;

		readonly Panel panel = new Panel();

		readonly Button odpowiedźButton = new Button();
		readonly Button punktyButton = new Button();
		readonly Button edycjaOdpowiedziButton = new Button();
		readonly TextBox edytorOdpowiedzi = new TextBox();
		readonly TextBox edytorPunktów = new TextBox();
		readonly Button doGóry = new Button();
		readonly Button doDołu = new Button();
		readonly Button usuńButton = new Button();

		public Odpowiedź(string linia, Pytanie1 pytanie)
		{
			this.pytanie = pytanie;

			nrOdpowiedzi = pytanie.odpowiedzi.Count + 1;
			if (nrOdpowiedzi > Global.ilośćOdpowiedzi1)
				throw new ArgumentException(pytanie.nazwaPytania);

			int pozycjaPrzerwy = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (pozycjaPrzerwy == -1)
				Global.Wyjdź(String.Format("niepoprawna linia: {0}", linia));
			odpowiedź = linia.Substring(0, pozycjaPrzerwy).TrimEnd();
			if (odpowiedź.Length > Global.długośćOdpowiedzi1)
				Global.Wyjdź(String.Format("za długa odpowiedź: {0}. Dopuszczalna szerokość to {1}", odpowiedź, Global.długośćOdpowiedzi1));
			string odpowiedźUpper = odpowiedź.ToUpper(CultureInfo.CurrentUICulture);
			for (int i = 0; i < odpowiedź.Length; i++)
				if (!Global.znaki.ContainsKey(odpowiedźUpper[i]))
					Global.Wyjdź(String.Format("niepoprawny znak '{0}' w {1}", odpowiedź[i], odpowiedź));
			try
			{
				punkty = Int32.Parse(linia.Substring(pozycjaPrzerwy + 1));
			}
			catch (FormatException)
			{
				Global.Wyjdź(String.Format("niepoprawna liczba punktów w {0}", linia));
			}

			panel.Hide();

			odpowiedźButton.Location = new Point(0, 0);
			odpowiedźButton.Size = new Size(odpowiedźButtonSzerokość, panelWysokość);
			odpowiedźButton.Text = odpowiedź;
			odpowiedźButton.Click += new EventHandler(ZaznaczOdznacz_Click);

			punktyButton.Location = new Point(odpowiedźButton.Right + odpowiedźButtoniPunktyButtonOdstępX, 0);
			punktyButton.Size = new Size(operacjeButtonSzerokość, panelWysokość);
			punktyButton.Text = punkty.ToString();
			punktyButton.Click += new EventHandler(EdytujPunkty_Click);

			edycjaOdpowiedziButton.Location = new Point(punktyButton.Right + operacjeButtonOdstępX, 0);
			edycjaOdpowiedziButton.Size = new Size(operacjeButtonSzerokość, panelWysokość);
			edycjaOdpowiedziButton.Text = "edytuj";
			edycjaOdpowiedziButton.Click += new EventHandler(EdytujOdpowiedź_Click);

			edytorOdpowiedzi.AutoSize = false;
			edytorOdpowiedzi.Location = odpowiedźButton.Location;
			edytorOdpowiedzi.Size = odpowiedźButton.Size;
			edytorOdpowiedzi.Text = odpowiedź;
			edytorOdpowiedzi.Hide();
			edytorOdpowiedzi.Leave += new EventHandler(EdytorOdpowiedzi_Leave);
			edytorOdpowiedzi.KeyPress += new KeyPressEventHandler(Edytor_KeyPress);
			edytorOdpowiedzi.Tag = new EventHandler(EdytorOdpowiedzi_Leave);

			edytorPunktów.AutoSize = false;
			edytorPunktów.Location = punktyButton.Location;
			edytorPunktów.Size = punktyButton.Size;
			edytorPunktów.Text = punkty.ToString();
			edytorPunktów.Hide();
			edytorPunktów.Leave += new EventHandler(EdytorPunktów_Leave);
			edytorPunktów.KeyPress += new KeyPressEventHandler(Edytor_KeyPress);
			edytorPunktów.Tag = new EventHandler(EdytorPunktów_Leave);

			doGóry.Location = new Point(edycjaOdpowiedziButton.Right + operacjeButtonOdstępX, 0);
			doGóry.Size = new Size(operacjeButtonSzerokość, panelWysokość / 2);
			doGóry.Text = "góra";
			doGóry.Click += new EventHandler(DoGóry_Click);

			doDołu.Location = new Point(edycjaOdpowiedziButton.Right + operacjeButtonOdstępX, panelWysokość / 2);
			doDołu.Size = doGóry.Size;
			doDołu.Text = "dół";
			doDołu.Click += new EventHandler(DoDołu_Click);

			usuńButton.Location = new Point(doGóry.Right + operacjeButtonOdstępX, 0);
			usuńButton.Size = new Size(operacjeButtonSzerokość, 30);
			usuńButton.Text = "usuń";
			usuńButton.Click += new EventHandler(Usuń_Click);

			panel.Size = new System.Drawing.Size(usuńButton.Right, panelWysokość);

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

		public void PokażKontrolkiOdpowiedzi()
		{
			panel.Location = new Point(100, nrOdpowiedzi * 30 + 30);
			panel.Show();

			WyświetlNrOdpowiedzi(true, ' ');
			if (Zaznaczona())
				PokażOdpowiedź();
			else
				UkryjOdpowiedź();
		}
		public void UkryjKontrolkiOdpowiedzi()
		{
			panel.Hide();
			WyświetlNrOdpowiedzi(false, ' ');
			WyświetlOdpowiedź(false, ' ');
			WyświetlPunkty(false, ' ');
		}
		private void PokażOdpowiedź()
		{
			WyświetlOdpowiedź(true, '.');
			WyświetlPunkty(true, ' ');
		}
		private void UkryjOdpowiedź()
		{
			WyświetlOdpowiedź(false, '.');
			WyświetlPunkty(false, '|');
		}
		public void Przesuń(int numer, bool usuń)
		{
			if (usuń)
				UkryjKontrolkiOdpowiedzi();
			nrOdpowiedzi = numer;
			PokażKontrolkiOdpowiedzi();
		}
		private bool Zaznaczona()
		{
			return Global.Zaznaczony(odpowiedźButton);
		}

		private void ZaznaczOdznacz_Click(object sender, EventArgs e)
		{
			Global.PrzełączZaznaczenie(odpowiedźButton);
			if (Zaznaczona())
			{
				PokażOdpowiedź();

				if (pytanie.drużynaZPrzypisanymiPunktami == null)
					pytanie.DodajPunkty(punkty);
			}
			else
			{
				UkryjOdpowiedź();

				if (pytanie.drużynaZPrzypisanymiPunktami == null)
					pytanie.DodajPunkty(-punkty);
			}
		}
		private void EdytujOdpowiedź_Click(object sender, EventArgs e)
		{
			edytorOdpowiedzi.Show();
			edytorOdpowiedzi.BringToFront();
			edytorOdpowiedzi.Focus();
		}
		private void EdytujPunkty_Click(object sender, EventArgs e)
		{
			edytorPunktów.Show();
			edytorPunktów.BringToFront();
			edytorPunktów.Focus();
		}
		private void Edytor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				((EventHandler)(((TextBox)sender).Tag))(sender, new EventArgs());
		}
		private void EdytorOdpowiedzi_Leave(object sender, EventArgs e)
		{
			odpowiedź = edytorOdpowiedzi.Text.ToUpper();
			odpowiedźButton.Text = edytorOdpowiedzi.Text;

			if (odpowiedź.Length > Global.długośćOdpowiedzi1)
			{
				MessageBox.Show(String.Format("Tekst za długi o {0} znaków", odpowiedź.Length - Global.długośćOdpowiedzi1));
				edytorOdpowiedzi.Focus();
			}
			else
			{
				for (int i = 0; i < odpowiedź.Length; i++)
					if (!Global.znaki.ContainsKey(odpowiedź[i]))
					{
						MessageBox.Show(String.Format("niepoprawny znak {0}", edytorOdpowiedzi.Text[i]));
						edytorOdpowiedzi.Focus();
						return;
					}
				if (Zaznaczona())
					WyświetlOdpowiedź(true, '.');
				edytorOdpowiedzi.Hide();
				odpowiedźButton.Focus();
			}
		}
		private void EdytorPunktów_Leave(object sender, EventArgs e)
		{
			try
			{
				punkty = Int32.Parse(edytorPunktów.Text);
				edytorPunktów.Hide();
				punktyButton.Text = punkty.ToString();
				if (Zaznaczona())
					WyświetlPunkty(true, ' ');
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				edytorPunktów.Focus();
				edytorPunktów.SelectAll();
			}
		}
		private void DoGóry_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != 1)
				pytanie.ZamieńOdpowiedzi(nrOdpowiedzi - 1);
		}
		private void DoDołu_Click(object sender, EventArgs e)
		{
			if (nrOdpowiedzi != pytanie.odpowiedzi.Count)
				pytanie.ZamieńOdpowiedzi(nrOdpowiedzi);
		}
		private void Usuń_Click(object sender, EventArgs e)
		{
			pytanie.UsuńOdpowiedź(nrOdpowiedzi);
			if (pytanie.odpowiedzi.Count != Global.ilośćOdpowiedzi1)
				Pytanie1.dodajOdpowiedźButton.Show();
		}

		private void WyświetlNrOdpowiedzi(bool niePuste, char wypełnienie)
		{
			Global.tablica1.UstawTekst(niePuste ? nrOdpowiedzi.ToString() : String.Empty, tablicaNumerOdpowiedziPozycjaX, tablicaPunktyPozycjaYPoczątek - 1 + nrOdpowiedzi, false, 1, wypełnienie);
		}
		private void WyświetlOdpowiedź(bool niePuste, char wypełnienie)
		{
			Global.tablica1.UstawTekst(niePuste ? odpowiedź : String.Empty, tablicaOdpowiedźPozycjaX, tablicaPunktyPozycjaYPoczątek - 1 + nrOdpowiedzi, true, Global.długośćOdpowiedzi1, wypełnienie);
		}
		private void WyświetlPunkty(bool niePuste, char wypełnienie)
		{
			Global.tablica1.UstawTekst(niePuste ? punkty.ToString() : String.Empty, tablicaPunktyPozycjaX, tablicaPunktyPozycjaYPoczątek - 1 + nrOdpowiedzi, false, 2, wypełnienie);
		}
	}
}