using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace familiada
{
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
		public void zainicjujKontrolki()
		{
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.zainicjujKontrolkiOdpowiedzi();
		}
		public void pokażOdpowiedzi()
		{
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.pokażOdpowiedź();
		}
		public void usuńOdpowiedzi()
		{
			foreach (Odpowiedź odpowiedź in odpowiedzi)
				odpowiedź.usuńOdpowiedź();
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
