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
	public partial class Kontroler : Form
	{
		static int obecnePytanie = -1;

		public Kontroler()
		{

			InitializeComponent();
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// usunąć
			pokażEkran_Click(this, new EventArgs());

			try
			{
				StreamReader plik = new StreamReader(Global.plik1);
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != null)
						{
							Global.pytania1.Add(new Pytanie1(nrPytania(linia)));
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

		static NrINazwaPytania nrPytania(string linia)
		{
			NrINazwaPytania pytanie = null;
			try
			{
				string[] words = linia.Split(new char[] { ' ', '\t' });
				int nrPytania = Int32.Parse(words[0]);
				string nazwaPytania = "";
				for (int i = 1; i < words.Length; i++)
					nazwaPytania += words[i] + " ";
				pytanie = new NrINazwaPytania(nrPytania, nazwaPytania.TrimEnd());
			}
			catch (FormatException)
			{ }
			return pytanie;
		}

		private void następnePytanie_Click(object sender, EventArgs e)
		{
			if (obecnePytanie != -1)
			{
				poprzedniePytanie.Show();
				Global.pytania1[obecnePytanie].ukryjOdpowiedzi();
			}

			pokażOgólneKontrolkiPytania();

			obecnePytanie++;
			Global.pytania1[obecnePytanie].zainicjujKontrolki();
			if (obecnePytanie == Global.pytania1.Count - 1)
				następnePytanie.Hide();
		}

		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Show();

			Global.pytania1[obecnePytanie].ukryjOdpowiedzi();

			obecnePytanie--;
			Global.pytania1[obecnePytanie].zainicjujKontrolki();

			if (obecnePytanie == 0)
				poprzedniePytanie.Hide();
		}

		private void pokażOgólneKontrolkiPytania()
		{
			Global.kontroler.dodajOdpowiedź.Show();

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

		private void dodajOdpowiedź_Click(object sender, EventArgs e)
		{
			Global.pytania1[obecnePytanie].dodajIPokażOdpowiedź(" 0");
		}

		private void runda_Click(object sender, EventArgs e)
		{
			Button przycisk = (Button)sender;

			if ((int)(przycisk.Tag) == 1)
			{
				przycisk.Tag = 2;
				przycisk.Text = "przełącz do rundy 2";

				Global.panelKontroler1.Show();
				Global.panelGłówny1.Show();
				Global.panelKontroler2.Hide();
				Global.panelGłówny2.Hide();

				Punkty.wyzerujPunkty();
				if (obecnePytanie != -1)
				{
					Global.pytania1[obecnePytanie].zainicjujKontrolki();
				}
			}
			else
			{
				przycisk.Tag = 1;
				przycisk.Text = "przełącz do rundy 1";

				Global.panelKontroler2.Show();
				Global.panelGłówny2.Show();
				Global.panelKontroler1.Hide();
				Global.panelGłówny1.Hide();

				Pytanie2.wyświetlPunkty();
			}
		}

	}
}
