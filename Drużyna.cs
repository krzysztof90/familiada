using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	abstract class DrużynaStrona
	{
		int punkty = 0;
		protected abstract int która { get; }

		public DrużynaStrona()
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

	class DrużynaL : DrużynaStrona
	{
		protected override int która
		{
			get { return 0; }
		}
	}
	class DrużynaP : DrużynaStrona
	{
		protected override int która
		{
			get { return 1; }
		}
	}
}
