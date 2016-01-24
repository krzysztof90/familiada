using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class NrINazwaPytania
	{
		public int nrPytania;
		public string nazwaPytania;

		public NrINazwaPytania(int nr, string nazwa)
		{
			nrPytania = nr;
			nazwaPytania = nazwa;
		}
	}

	class Pytanie
	{
		int nrPytania;
		string nazwaPytania;
		int punkty = 0;

		Label nazwaPytaniaLabel;
		Label punktyNaKontrolerzeLabel;
		Label punktyNaGłównymLabel;

		public List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

		public Pytanie(NrINazwaPytania pytanie)
		{
			nrPytania = pytanie.nrPytania;
			nazwaPytania = pytanie.nazwaPytania;

			nazwaPytaniaLabel = new Label();
			nazwaPytaniaLabel.Location = new Point(100,0);
			nazwaPytaniaLabel.Text = nazwaPytania;
			nazwaPytaniaLabel.Hide();
			Global.kontroler.Controls.Add(nazwaPytaniaLabel);

			punktyNaKontrolerzeLabel = new Label();
			punktyNaKontrolerzeLabel.Location = new Point(100, 30);
			punktyNaKontrolerzeLabel.Hide();
			Global.kontroler.Controls.Add(punktyNaKontrolerzeLabel);

			punktyNaGłównymLabel = new Label();
			punktyNaGłównymLabel.Location = new Point(200, 0);
			punktyNaGłównymLabel.Hide();
			Global.główny.Controls.Add(punktyNaGłównymLabel);

			dodajPunkty();
		}

		public void dodajIPokażOdpowiedź(string linia)
		{
			dodajOdpowiedź(linia);
			zainicjujKontrolki();
		}
		public void dodajOdpowiedź(string linia)
		{
			odpowiedzi.Add(new Odpowiedź(linia, this));
		}
		public void zainicjujKontrolki()
		{
			nazwaPytaniaLabel.Show();
			punktyNaKontrolerzeLabel.Show();
			punktyNaGłównymLabel.Show();
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.zainicjujKontrolkiOdpowiedzi();
		}
		public void pokażOdpowiedzi()
		{
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.pokażOdpowiedź();
		}
		public void ukryjOdpowiedzi()
		{
			nazwaPytaniaLabel.Hide();
			punktyNaKontrolerzeLabel.Hide();
			punktyNaGłównymLabel.Hide();
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.ukryjKontrolkiOdpowiedzi();
		}
		public bool zaznaczoneWszystkie()
		{
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				if (!odpowiedź.zaznaczona())
					return false;
			return true;
		}
		public void zamieńOdpowiedzi(int nrPoczątkowej)
		{
			odpowiedzi[nrPoczątkowej - 1].zmieńNumer(nrPoczątkowej + 1);
			odpowiedzi[nrPoczątkowej].zmieńNumer(nrPoczątkowej);

			Odpowiedź początkowa = odpowiedzi[nrPoczątkowej - 1];
			odpowiedzi[nrPoczątkowej - 1] = odpowiedzi[nrPoczątkowej];
			odpowiedzi[nrPoczątkowej] = początkowa;
		}
		public void usuń(int nrOdpowiedzi)
		{
			Odpowiedź odpowiedź = odpowiedzi[nrOdpowiedzi - 1];
			odpowiedź.usuńOdpowiedź();
			for (int i = nrOdpowiedzi; i < odpowiedzi.Count; i++)
				odpowiedzi[i].zmieńNumer(i);

			odpowiedzi.RemoveAt(nrOdpowiedzi - 1);
		}
		public void dodajPunkty(int dodane = 0)
		{
			punkty += dodane;
			punktyNaKontrolerzeLabel.Text = punkty.ToString();
			punktyNaGłównymLabel.Text = punkty.ToString();
		}
	}
}
