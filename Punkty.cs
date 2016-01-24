using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace familiada
{
	class Punkty
	{
		public static void ustawPunkty(int punkty=0)
		{
			Global.główny.punkty.Text = punkty.ToString();
			Global.kontroler.punkty.Text = punkty.ToString();
		}
	}
}
