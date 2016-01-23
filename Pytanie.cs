using System;
using System.Collections.Generic;
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
		Label nazwaPytaniaLabel;
		public List<Odpowiedź> odpowiedzi = new List<Odpowiedź>();

		Button dodajNowąOdpowiedź;

		public Pytanie(NrINazwaPytania pytanie)
		{
			nrPytania = pytanie.nrPytania;
			nazwaPytania = pytanie.nazwaPytania;

			nazwaPytaniaLabel = new Label();
			nazwaPytaniaLabel.Text = nazwaPytania;
			nazwaPytaniaLabel.Hide();
			Global.kontroler.Controls.Add(nazwaPytaniaLabel);
		}

		public void dodajOdpowiedź(Odpowiedź odpowiedź)
		{
			odpowiedzi.Add(odpowiedź);
		}
		public void zainicjujKontrolki()
		{
			nazwaPytaniaLabel.Show();
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
	}
}
