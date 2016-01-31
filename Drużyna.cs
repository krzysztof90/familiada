using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	abstract class Drużyna
	{
		int punkty = 0;
		protected abstract int która { get; }

		public Drużyna()
		{
			wyświetlPunkty();
		}

		public void dodajPunkty(int dodane)
		{
			punkty += dodane;
			wyświetlPunkty();
		}
		public void wyświetlPunkty()
		{
			Global.ustawPunktyDrużyny(która, punkty);
		}
	}

	class DrużynaL : Drużyna
	{
		protected override int która { get { return 0; } }
	}
	class DrużynaP : Drużyna
	{
		protected override int która { get { return 1; } }
	}
}
