using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	public partial class NotForShow : Form
	{
		static string nazwaPliku = "pytania.txt";

		ForShow główny = new ForShow();

		List<Pytanie> pytania = new List<Pytanie>();
		int obecnePytanie = -1;

		public NotForShow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				StreamReader plik = new StreamReader(nazwaPliku);

				int nrOdpowiedzi = 1;
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != null)
						{
							pytania.Add(new Pytanie(nrPytania(linia), this));
							nrOdpowiedzi = 1;
						}
						else
						{
							if (pytania.Count == 0)
								Functions.exit("zacznij plik od numeru pytania");
							pytania.Last().dodajOdpowiedź(new Odpowiedź(linia, nrOdpowiedzi++, this, główny));
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Functions.exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			if (pytania.Count == 0)
				Functions.exit("brak pytań");

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
			if (obecnePytanie != pytania.Count - 1)
			{
				if (obecnePytanie != -1)
				{
					pytania[obecnePytanie].ukryjOdpowiedzi();
				}
				obecnePytanie++;
				pytania[obecnePytanie].zainicjujKontrolki();
			}
		}

		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			if (obecnePytanie > 0)
			{
				//if (obecnePytanie != -1)
				{
					pytania[obecnePytanie].ukryjOdpowiedzi();
				}
				obecnePytanie--;
				pytania[obecnePytanie].zainicjujKontrolki();
			}

		}

		private void pokażEkran_Click(object sender, EventArgs e)
		{
			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			główny.Show();
			główny.Location = drugiEkran.WorkingArea.Location;
			//główny.FormBorderStyle = FormBorderStyle.None;
			//główny.WindowState = FormWindowState.Maximized;
			//główny.TopMost = true;
		}

	}
}
