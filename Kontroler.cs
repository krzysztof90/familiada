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
	public partial class Kontroler : Form
	{
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
				StreamReader plik = new StreamReader(Global.nazwaPliku);

				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != null)
						{
							Global.pytania.Add(new Pytanie(nrPytania(linia)));
						}
						else
						{
							if (Global.pytania.Count == 0)
								Global.exit("zacznij plik od numeru pytania");
							Global.pytania.Last().dodajOdpowiedź(linia);
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Global.exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			if (Global.pytania.Count == 0)
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
			if (Global.obecnePytanie != -1)
			{
				poprzedniePytanie.Show();
				Global.pytania[Global.obecnePytanie].ukryjOdpowiedzi();
			}

			Global.obecnePytanie++;
			Global.pytania[Global.obecnePytanie].zainicjujKontrolki();
			if (Global.obecnePytanie == Global.pytania.Count - 1)
				następnePytanie.Hide();
		}

		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			następnePytanie.Show();

			Global.pytania[Global.obecnePytanie].ukryjOdpowiedzi();

			Global.obecnePytanie--;
			Global.pytania[Global.obecnePytanie].zainicjujKontrolki();

			if (Global.obecnePytanie == 0)
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

		private void dodajOdpowiedź_Click(object sender, EventArgs e)
		{
			Global.pytania[Global.obecnePytanie].dodajIPokażOdpowiedź(" 0");
		}

		private void runda1_Click(object sender, EventArgs e)
		{
			//TODO usunięcie elementów z drugiej

			runda2.Show();
			runda1.Hide();
			if (Global.obecnePytanie != Global.pytania.Count - 1)
				następnePytanie.Show();
			if (Global.obecnePytanie > 0)
				poprzedniePytanie.Show();
			if (Global.obecnePytanie != -1)
			{
				Global.pytania[Global.obecnePytanie].zainicjujKontrolki();
			}
		}

		private void runda2_Click(object sender, EventArgs e)
		{
			runda1.Show();
			runda2.Hide();
			następnePytanie.Hide();
			poprzedniePytanie.Hide();

			if (Global.obecnePytanie != -1)
				Global.pytania[Global.obecnePytanie].ukryjOdpowiedzi();


		}

	}
}
