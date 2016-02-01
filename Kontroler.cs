using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
		private const int czasLabelSzerokość = 13;
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
				b.Click += new EventHandler(UstawCzas_Click);
			}

			poprzedniePytanie = new Button();
			poprzedniePytanie.Location = new Point(przełączPytanieButtonPozycjaXPoczątek, przełączPytanieButtonPozycjaY);
			poprzedniePytanie.Size = new Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			poprzedniePytanie.Text = "poprzednie pytanie";
			poprzedniePytanie.Visible = false;
			poprzedniePytanie.Click += new EventHandler(PoprzedniePytanie_Click);

			następnePytanie = new Button();
			następnePytanie.Location = new Point(przełączPytanieButtonPozycjaXPoczątek + przełączPytanieButtonOdstępX + przełączPytanieButtonSzerokość, przełączPytanieButtonPozycjaY);
			następnePytanie.Size = new Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			następnePytanie.Text = "zacznij pytania";
			następnePytanie.Click += new EventHandler(NastępnePytanie_Click);

			pokażEkran = new Button();
			pokażEkran.Location = new Point(pokażEkranButtonPozycjaX, pokażEkranButtonPozycjaY);
			pokażEkran.Size = new Size(pokażEkranButtonSzerokość, pokażEkranButtonWysokość);
			pokażEkran.Text = "otwórz ekran główny";
			pokażEkran.Click += new EventHandler(PokażEkran_Click);

			runda = new Button();
			runda.Location = new Point(rundaButtonPozycjaX, rundaButtonPozycjaY);
			runda.Size = new Size(rundaButtonSzerokość, rundaButtonWysokość);
			runda.Tag = 1;
			runda.Text = "przełącz do rundy 1";
			runda.Click += new EventHandler(Runda_Click);

			punkty = new Label();
			punkty.Location = new Point(punktyLabelPozycjaX, punktyLabelPozycjaY);
			punkty.Size = new Size(punktyLabelSzerokość, punktyLabelWysokość);
			punkty.Text = "0";

			start = new Button();
			start.Location = new Point(startButtonPozycjaX, startButtonPozycjaY);
			start.Size = new Size(startButtonSzerokość, startButtonWysokość);
			start.Text = "start";
			start.Click += new EventHandler(this.StartCzas_Click);
			
			czas = new Label();
			czas.Location = new Point(czasLabelPozycjaX, czasLabelPozycjaY);
			czas.Size = new Size(czasLabelSzerokość, czasLabelWysokość);

			dodatkowy = new Panel();
			dodatkowy.BorderStyle = BorderStyle.FixedSingle;
			dodatkowy.Controls.Add(punkty);
			dodatkowy.Controls.Add(runda);
			dodatkowy.Controls.Add(pokażEkran);
			dodatkowy.Location = new Point(dodatkowyPanelPozycjaX, dodatkowyPanelPozycjaY);
			dodatkowy.Size = new Size(dodatkowyPanelSzerokość, dodatkowyPanelWysokość);

			InitializeComponent();

			panele[0].Controls.Add(poprzedniePytanie);
			panele[0].Controls.Add(następnePytanie);
			panele[1].Controls.Add(czas);
			panele[1].Controls.Add(start);
			panele.ForEach(p => Controls.Add(p));
			punktyDrużynaLabel.ForEach(l => dodatkowy.Controls.Add(l));
			Controls.Add(dodatkowy);
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// TODO usunąć
			//PokażEkran_Click(this, new EventArgs());

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
								Global.Wyjdź("zacznij plik od numeru pytania");
							Global.pytania1.Last().DodajOdpowiedź(linia);
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
				Global.Wyjdź(String.Format("brakuje pliku {0}", exc.FileName));
			}
			catch (NullReferenceException)
			{
				Global.Wyjdź(String.Format("Wstaw 5 pytań"));
			}

			if (Global.pytania1.Count == 0)
				Global.Wyjdź("brak pytań");
		}

		private static NrINazwaPytania nagłówekPytania(string linia)
		{
			try
			{
				string[] words = linia.Split(new char[] { ' ', '\t' });
				int nrPytania = Int32.Parse(words[0]);
				string nazwaPytania = String.Empty;
				for (int i = 1; i < words.Length; i++)
					nazwaPytania += words[i] + " ";
				return new NrINazwaPytania(nrPytania, nazwaPytania.TrimEnd());
			}
			catch (FormatException)
			{
				return null;
			}
		}

		private void Runda_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;

			if ((int)(przycisk.Tag) == 1)
			{
				przycisk.Tag = 2;
				przycisk.Text = "przełącz do rundy 2";

				Global.PokażPanel(0);
				Global.UkryjPanel(1);

				Global.UstawPunktyGłówne(0);

				Pytanie1.PokażPytanie();
			}
			else
			{
				przycisk.Tag = 1;
				przycisk.Text = "przełącz do rundy 1";

				Global.PokażPanel(1);
				Global.UkryjPanel(0);

				Pytanie2.WyświetlPunkty();
			}
		}

		private void NastępnePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Text = "następne pytanie";

			if (Pytanie1.obecnePytanie != -1)
			{
				poprzedniePytanie.Show();
				Pytanie1.UkryjPytanie();
			}

			Pytanie1.PokażPrzyciski();

			Pytanie1.obecnePytanie++;
			Pytanie1.PokażPytanie();
			if (Pytanie1.OstatniePytanie())
				następnePytanie.Hide();
		}
		private void PoprzedniePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Show();

			Pytanie1.UkryjPytanie();
			Pytanie1.obecnePytanie--;
			Pytanie1.PokażPytanie();

			if (Pytanie1.obecnePytanie == 0)
				poprzedniePytanie.Hide();
		}
		private void PokażEkran_Click(object sender, EventArgs e)
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

		private void UstawCzas_Click(object sender, System.EventArgs e)
		{
			string czasString = (string)(((Button)sender).Tag);
			czas.Text = czasString;
			Global.tablicaPunkty.UstawTekst(czasString, 0, 0, false, 3, ' ');
		}
		private void StartCzas_Click(object sender, EventArgs e)
		{
			if (czas.Text != String.Empty)
				timer1.Start();
		}
		private void Timer1_Tick(object sender, EventArgs e)
		{
			int pozostałyCzas = Int32.Parse(czas.Text);
			pozostałyCzas--;
			czas.Text = pozostałyCzas.ToString();
			Global.tablicaPunkty.UstawTekst(pozostałyCzas.ToString(), 0, 0, false, 3, ' ');
			if (pozostałyCzas == 0)
			{
				timer1.Stop();
				czas.Text = String.Empty;
				Global.tablicaPunkty.UstawTekst(String.Empty, 0, 0, false, 3, ' ');
			}
		}

		public void PokażPanel(int który)
		{
			panele[który].Show();
		}
		public void UkryjPanel(int który)
		{
			panele[który].Hide();
		}
		public void UstawPunktyGłówne(int punkty)
		{
			this.punkty.Text = punkty.ToString();
		}
		public void UstawPunktyDrużyny(int która, int punkty)
		{
			punktyDrużynaLabel[która].Text = punkty.ToString();
		}
	}
}
