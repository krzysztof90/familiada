using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace familiada
{
	class Punkty
	{
		public static void wyzerujPunkty()
		{
			Global.tablicaPunkty.ustawTekst("0", 0, 0, false, 3, ' ', true);
			Global.kontroler.punkty.Text = "0";
		}

		public static void dodajPunkty(int dodane)
		{
			int punkty = Int32.Parse(Global.tablicaPunkty.zwróćWartość()) + dodane;
			ustawPunkty(punkty);
		}

		public static void ustawPunkty(int punkty)
		{
			Global.tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ', true);
			Global.kontroler.punkty.Text = punkty.ToString();
		}
	}
}
