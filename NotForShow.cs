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
	// URUCHOMIĆ PROGRAM DOPIERO PO PODŁĄCZENIU DRUGIEGO EKRANU

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
				StreamReader plik = new StreamReader(Global.nazwaPliku);

				int nrOdpowiedzi = 1;
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != null)
						{
							Global.pytania.Add(new Pytanie(nrPytania(linia), this));
							nrOdpowiedzi = 1;
						}
						else
						{
							if (Global.pytania.Count == 0)
								Global.exit("zacznij plik od numeru pytania");
							Global.pytania.Last().dodajOdpowiedź(new Odpowiedź(linia, nrOdpowiedzi++));
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
			if (Global.obecnePytanie != Global.pytania.Count - 1)
			{
				if (Global.obecnePytanie != -1)
					Global.pytania[Global.obecnePytanie].ukryjOdpowiedzi();

				Global.obecnePytanie++;
				Global.pytania[Global.obecnePytanie].zainicjujKontrolki();
			}
		}

		private void poprzedniePytanie_Click(object sender, EventArgs e)
		{
			if (Global.obecnePytanie > 0)
			{
				Global.pytania[Global.obecnePytanie].ukryjOdpowiedzi();

				Global.obecnePytanie--;
				Global.pytania[Global.obecnePytanie].zainicjujKontrolki();
			}

		}

		private void pokażEkran_Click(object sender, EventArgs e)
		{
			Global.główny.Show();
			pokażEkran.Hide();
		}

	}
}
