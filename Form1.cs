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
	public partial class Form1 : Form
	{
		static string nazwaPliku = "pytania.txt";

		class Odpowiedź
		{
			string odpowiedź;
			int punkty;

			public Odpowiedź(string linia)
			{
				int gdziePrzerwa = linia.LastIndexOfAny(new char[]{' ','\t'});
				if (gdziePrzerwa == -1)
					exit(String.Format("niepoprawna linia: {0}", linia));
				odpowiedź = linia.Substring(0, gdziePrzerwa).TrimEnd();
				punkty = Int32.Parse(linia.Substring(gdziePrzerwa+1));
			}
		}

		class Pytanie
		{
			int nrPytania;
			List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

			public Pytanie(int nr)
			{
				nrPytania = nr;
			}

			public void dodajOdpowiedź(Odpowiedź odpowiedź)
			{
				odpowiedzi.Add(odpowiedź);
			}
		}

		static int nrPytania(string linia)
		{
			int nrPytania=-1;
			try
			{
				nrPytania=Int32.Parse(linia);
			}
			catch (FormatException)
			{}
			return nrPytania;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				StreamReader plik = new StreamReader(nazwaPliku);

				List<Pytanie> pytania = new List<Pytanie>();
				int obecnePytanie = -1;
				while (!plik.EndOfStream)
				{
					string linia = plik.ReadLine().Trim();
					if (linia.Length != 0)
					{
						if (nrPytania(linia) != -1)
						{
							obecnePytanie++;
							pytania.Add(new Pytanie(nrPytania(linia)));
						}
						else
						{
							if (obecnePytanie == -1)
								exit("zacznij plik od numeru pytania");
							pytania[obecnePytanie].dodajOdpowiedź(new Odpowiedź(linia));
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				exit(String.Format("brakuje pliku {0}", exc.FileName));
			}
		}

		static void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
