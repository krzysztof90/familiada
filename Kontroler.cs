using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	public partial class Kontroler : Form, IOperatable
	{
		private const int dodatkowyPanelPozycjaX = 0;
		private const int dodatkowyPanelPozycjaY = 320;
		private const int dodatkowyPanelSzerokość = 210;
		private const int dodatkowyPanelWysokość = 135;
		private const int przełączPytanieButtonPozycjaXPoczątek = 185;
		private const int przełączPytanieButtonOdstępX = 70;
		private const int przełączPytanieButtonPozycjaY = 300;
		private const int przełączPytanieButtonSzerokość = 115;
		private const int przełączPytanieButtonWysokość = 25;
		private const int pokażEkranButtonPozycjaX = 0;
		private const int pokażEkranButtonPozycjaY = 40;
		private const int pokażEkranButtonSzerokość = 115;
		private const int pokażEkranButtonWysokość = 25;
		private const int rundaButtonPozycjaX = 0;
		private const int rundaButtonPozycjaY = 70;
		private const int rundaButtonSzerokość = 115;
		private const int rundaButtonWysokość = 25;
		private const int punktyLabelPozycjaX = 80;
		private const int punktyLabelPozycjaY = 8;
		private const int punktyLabelSzerokość = 13;
		private const int punktyLabelWysokość = 13;
		private const int punktyDrużynaLabelSzerokość = 25;
		private const int punktyDrużynaLabelWysokość = 15;
		private const int ustawCzasButtonPozycjaXPoczątek = 400;
		private const int ustawCzasButtonOdstępX = 25;
		private const int ustawCzasButtonPozycjaY = 300;
		private const int ustawCzasButtonSzerokość = 75;
		private const int ustawCzasButtonWysokość = 25;
		private const int czasLabelPozycjaX = 520;
		private const int czasLabelPozycjaY = 400;
		private const int czasLabelSzerokość = 0;
		private const int czasLabelWysokość = 13;
		private const int startButtonPozycjaX = 470;
		private const int startButtonPozycjaY = 350;
		private const int startButtonSzerokość = 75;
		private const int startButtonWysokość = 25;

		public Kontroler()
		{
			panele = new List<Panel> { new Panel(), new Panel() };
			foreach (Panel p in panele)
			{
				p.Dock = DockStyle.Fill;
				p.Margin = new Padding(0);
				p.Visible = false;
			}

			punktyDrużynaLabel = new List<Label> { new Label(), new Label() };
			punktyDrużynaLabel.ForEach(l => l.Size = new Size(punktyDrużynaLabelSzerokość, punktyDrużynaLabelWysokość));
			punktyDrużynaLabel[0].Dock = DockStyle.Left;
			punktyDrużynaLabel[1].Dock = DockStyle.Right;

			ustawCzasButton = new List<Button> { new Button(), new Button() };
			for (int i = 0; i < ustawCzasButton.Count; i++)
			{
				Button b = ustawCzasButton[i];
				panele[1].Controls.Add(b);
				b.Location = new Point(ustawCzasButtonPozycjaXPoczątek + (ustawCzasButtonOdstępX+ustawCzasButtonSzerokość) * i, ustawCzasButtonPozycjaY);
				b.Tag = i == 0 ? "15" : "20";
				b.Text = "ustaw" + (string)(b.Tag);
				b.Size = new Size(ustawCzasButtonSzerokość, ustawCzasButtonWysokość);
				b.Click += new EventHandler(ustawCzas_Click);
			}

			InitializeComponent();

			panele[0].Controls.Add(poprzedniePytanie);
			panele[0].Controls.Add(następnePytanie);
			panele[1].Controls.Add(czas);
			panele[1].Controls.Add(start);
			panele.ForEach(p => Controls.Add(p));
			punktyDrużynaLabel.ForEach(l => dodatkowy.Controls.Add(l));
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// TODO usunąć
			pokażEkran_Click(this, new EventArgs());

			try
			{
				StreamReader plik = new StreamReader(Global.plik1);
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nagłówekPytania(linia) != null)
						{
							Global.pytania1.Add(new Pytanie1(nagłówekPytania(linia)));
						}
						else
						{
							if (Global.pytania1.Count == 0)
								Global.exit("zacznij plik od numeru pytania");
							Global.pytania1.Last().dodajOdpowiedź(linia);
						}
					}
				}
				plik.Close();

				plik = new StreamReader(Global.plik2);
				for (int i = 0; i < 5; i++)
				{
					string linia = plik.ReadLine().Trim();
					Global.pytania2[i] = new Pytanie2(linia, i + 1);
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Global.exit(String.Format("brakuje pliku {0}", exc.FileName));
			}
			catch (NullReferenceException)
			{
				Global.exit(String.Format("wstaw 5 pytań"));
			}

			if (Global.pytania1.Count == 0)
				Global.exit("brak pytań");
		}

		private static NrINazwaPytania nagłówekPytania(string linia)
		{
			NrINazwaPytania pytanie = null;
			try
			{
				string[] words = linia.Split(new char[] { ' ', '\t' });
				int nrPytania = Int32.Parse(words[0]);
				string nazwaPytania = String.Empty;
				for (int i = 1; i < words.Length; i++)
					nazwaPytania += words[i] + " ";
				pytanie = new NrINazwaPytania(nrPytania, nazwaPytania.TrimEnd());
			}
			catch (FormatException)
			{ }
			return pytanie;
		}

		private void runda_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;

			if ((int)(przycisk.Tag) == 1)
			{
				przycisk.Tag = 2;
				przycisk.Text = "przełącz do rundy 2";

				Global.pokażPanel(0);
				Global.ukryjPanel(1);

				Global.ustawPunktyGłówne(0);

				Pytanie1.pokażPytanie();
			}
			else
			{
				przycisk.Tag = 1;
				przycisk.Text = "przełącz do rundy 1";

				Global.pokażPanel(1);
				Global.ukryjPanel(0);

				Pytanie2.wyświetlPunkty();
			}
		}

		private void następnePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Text = "następne pytanie";

			if (Pytanie1.obecnePytanie != -1)
			{
				poprzedniePytanie.Show();
				Pytanie1.ukryjPytanie();
			}

			Pytanie1.pokażPrzyciski();

			Pytanie1.obecnePytanie++;
			Pytanie1.pokażPytanie();
			if (Pytanie1.ostatniePytanie())
				następnePytanie.Hide();
		}
		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Show();

			Pytanie1.ukryjPytanie();
			Pytanie1.obecnePytanie--;
			Pytanie1.pokażPytanie();

			if (Pytanie1.obecnePytanie == 0)
				poprzedniePytanie.Hide();
		}
		private void pokażEkran_Click(object sender, EventArgs e)
		{
			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			Global.główny.Show();
			Global.główny.WindowState = FormWindowState.Normal;
			Global.główny.Location = drugiEkran.WorkingArea.Location;
			if (tenEkran == drugiEkran)
			{
				Global.główny.FormBorderStyle = FormBorderStyle.Sizable;
				Global.główny.TopMost = false;
			}
			else
			{
				Global.główny.FormBorderStyle = FormBorderStyle.None;
				Global.główny.TopMost = true;
			}
			Global.główny.WindowState = FormWindowState.Maximized;
			pokażEkran.Hide();
		}

		private void ustawCzas_Click(object sender, System.EventArgs e)
		{
			string czasString = (string)(((Button)sender).Tag);
			czas.Text = czasString;
			Global.tablicaPunkty.ustawTekst(czasString, 0, 0, false, 3, ' ');
		}
		private void startCzas_Click(object sender, EventArgs e)
		{
			if (czas.Text != String.Empty)
				timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			int pozostałyCzas = Int32.Parse(czas.Text);
			pozostałyCzas--;
			czas.Text = pozostałyCzas.ToString();
			Global.tablicaPunkty.ustawTekst(pozostałyCzas.ToString(), 0, 0, false, 3, ' ');
			if (pozostałyCzas == 0)
			{
				timer1.Stop();
				czas.Text = String.Empty;
				Global.tablicaPunkty.ustawTekst(String.Empty, 0, 0, false, 3, ' ');
			}
		}

		public void pokażPanel(int który)
		{
			panele[który].Show();
		}
		public void ukryjPanel(int który)
		{
			panele[który].Hide();
		}
		public void ustawPunktyGłówne(int punkty)
		{
			this.punkty.Text = punkty.ToString();
		}
		public void ustawPunktyDrużyny(int która, int punkty)
		{
			punktyDrużynaLabel[która].Text = punkty.ToString();
		}
	}
}
