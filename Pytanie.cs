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
}
