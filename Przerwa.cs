using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace familiada
{
	class Przerwa : Znak
	{
		public Przerwa(int liczbaKolumn, int liczbaRzędów)
			: base(liczbaKolumn, liczbaRzędów)
		{
		}

		public override Image obraz()
		{
			return global::familiada.Properties.Resources.czarny;
		}
	}
}
