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

		List<Pytanie> pytania = new List<Pytanie>();
		int obecnePytanie = -1;

		ForShow główny;

		class Odpowiedź
		{
			public string odpowiedź;
			public int punkty;
			public int nrOdpowiedzi;
			CheckBox checkBox;
			Label nrOdpowiedziLabel;
			Label odpowiedźLabel;

			public Odpowiedź(string linia, int nrOdpowiedzi)
			{
				this.nrOdpowiedzi = nrOdpowiedzi;
				int gdziePrzerwa = linia.LastIndexOfAny(new char[] { ' ', '\t' });
				if (gdziePrzerwa == -1)
					exit(String.Format("niepoprawna linia: {0}", linia));
				odpowiedź = linia.Substring(0, gdziePrzerwa).TrimEnd();
				try
				{
					punkty = Int32.Parse(linia.Substring(gdziePrzerwa + 1));
				}
				catch (FormatException)
				{
					exit("niepoprawna liczba punktów");
				}
			}

			public void dodajCheckBox(NotForShow form)
			{
				checkBox = new CheckBox();
				//checkBox.AutoSize = true;
				checkBox.Location = new Point(100, nrOdpowiedzi * 30);
				//checkBox.Size = new Size(80, 17);
				checkBox.Text = odpowiedź;
				checkBox.CheckedChanged += new EventHandler(checkBoxCheckedChanged);

				form.Controls.Add(checkBox);
			}
			public void usuńCheckBox()
			{
				checkBox.Dispose();
			}
			public void pokażNrPytania(ForShow form)
			{
				nrOdpowiedziLabel = new Label();
				nrOdpowiedziLabel.AutoSize = true;
				nrOdpowiedziLabel.Location = new Point(100, nrOdpowiedzi * 30);
				//nrOdpowiedziLabel.Size = new Size(10, 17);
				nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
				form.Controls.Add(nrOdpowiedziLabel);

				// tylko utworzenie
				odpowiedźLabel = new Label();
				//checkBox.AutoSize = true;
				odpowiedźLabel.Location = new Point(120, nrOdpowiedzi * 30);
				//checkBox.Size = new Size(80, 17);
				odpowiedźLabel.Text = odpowiedź;
				odpowiedźLabel.Hide();
				form.Controls.Add(odpowiedźLabel);
			}
			public bool zaznaczona()
			{
				return checkBox.Checked;
			}

			private void checkBoxCheckedChanged(object sender, EventArgs e)
			{
				if (checkBox.Checked)
				{
					odpowiedźLabel.Show();
				}
				else
				{
					odpowiedźLabel.Hide();
				}
			}
		}

		class Pytanie
		{
			int nrPytania;
			public List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

			public Pytanie(int nr)
			{
				nrPytania = nr;
			}

			public void dodajOdpowiedź(Odpowiedź odpowiedź)
			{
				odpowiedzi.Add(odpowiedź);
			}
			public void dodajCheckBoxy(NotForShow form)
			{
				foreach (Odpowiedź odpowiedź in odpowiedzi)
					odpowiedź.dodajCheckBox(form);
			}
			public void usuńCheckBoxy()
			{
				foreach (Odpowiedź odpowiedź in odpowiedzi)
					odpowiedź.usuńCheckBox();
			}
			public void pokażNumeryOdpowiedzi(ForShow form)
			{
				foreach (Odpowiedź odpowiedź in odpowiedzi)
					odpowiedź.pokażNrPytania(form);
			}
			public bool zaznaczoneWszystkie()
			{
				foreach (Odpowiedź odpowiedź in odpowiedzi)
					if (!odpowiedź.zaznaczona())
						return false;
				return true;
			}
		}

		static int nrPytania(string linia)
		{
			int nrPytania = -1;
			try
			{
				nrPytania = Int32.Parse(linia);
			}
			catch (FormatException)
			{ }
			return nrPytania;
		}

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
						if (nrPytania(linia) != -1)
						{
							pytania.Add(new Pytanie(nrPytania(linia)));
							nrOdpowiedzi = 1;
						}
						else
						{
							if (pytania.Count == 0)
								exit("zacznij plik od numeru pytania");
							pytania.Last().dodajOdpowiedź(new Odpowiedź(linia, nrOdpowiedzi++));
						}
					}
				}
				plik.Close();
			}
			catch (FileNotFoundException exc)
			{
				exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			główny = new ForShow();
			główny.Show();
			główny.Location = drugiEkran.WorkingArea.Location;
			główny.FormBorderStyle = FormBorderStyle.None;
			główny.WindowState = FormWindowState.Maximized;
			główny.TopMost = true;

			if (pytania.Count == 0)
				exit("brak pytań");

		}

		static void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}

		private void następnePytanie_Click(object sender, EventArgs e)
		{
			if (obecnePytanie == -1 || pytania[obecnePytanie].zaznaczoneWszystkie())
			{
				if (obecnePytanie != -1)
				{
					pytania[obecnePytanie].usuńCheckBoxy();
					//pytania[obecnePytanie].usuńOdpowiedzi();
				}

				if (obecnePytanie != pytania.Count - 1)
				{
					obecnePytanie++;
					pytania[obecnePytanie].dodajCheckBoxy(this);
					pytania[obecnePytanie].pokażNumeryOdpowiedzi(główny);
				}
			}
		}
	}
}
