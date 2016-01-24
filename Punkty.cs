﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace familiada
{
	class Punkty
	{
		public static void wyzerujPunkty()
		{
			Global.główny.punkty.Text = "0";
			Global.kontroler.punkty.Text = "0";
		}

		public static void dodajPunkty(int dodane = 0)
		{
			int punkty = Int32.Parse(Global.główny.punkty.Text) + dodane;
			Global.główny.punkty.Text = punkty.ToString();
			Global.kontroler.punkty.Text = punkty.ToString();
		}

		public static void ustawPunkty(int punkty)
		{
			Global.główny.punkty.Text = punkty.ToString();
			Global.kontroler.punkty.Text = punkty.ToString();
		}
	}
}
