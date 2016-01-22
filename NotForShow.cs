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
		public NotForShow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// usunąć
			pokażEkran_Click(this, new EventArgs());

			try
			{
				StreamReader plik = new StreamReader(Statics.nazwaPliku);

				int nrOdpowiedzi = 1;
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != null)
						{
							Statics.pytania.Add(new Pytanie(nrPytania(linia), this));
							nrOdpowiedzi = 1;
						}
						else
						{
							if (Statics.pytania.Count == 0)
								Statics.exit("zacznij plik od numeru pytania");
							Statics.pytania.Last().dodajOdpowiedź(new Odpowiedź(linia, nrOdpowiedzi++));
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				Statics.exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			if (Statics.pytania.Count == 0)
				Statics.exit("brak pytań");

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
			if (Statics.obecnePytanie != Statics.pytania.Count - 1)
			{
				if (Statics.obecnePytanie != -1)
					Statics.pytania[Statics.obecnePytanie].ukryjOdpowiedzi();

				Statics.obecnePytanie++;
				Statics.pytania[Statics.obecnePytanie].zainicjujKontrolki();
			}
		}

		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			if (Statics.obecnePytanie > 0)
			{
				Statics.pytania[Statics.obecnePytanie].ukryjOdpowiedzi();

				Statics.obecnePytanie--;
				Statics.pytania[Statics.obecnePytanie].zainicjujKontrolki();
			}

		}

		private void pokażEkran_Click(object sender, EventArgs e)
		{
			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			Statics.główny.Show();
			Statics.główny.Location = drugiEkran.WorkingArea.Location;
			//główny.FormBorderStyle = FormBorderStyle.None;
			//główny.WindowState = FormWindowState.Maximized;
			//główny.TopMost = true;

			pokażEkran.Hide();
		}

	}
}
