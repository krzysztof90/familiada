using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	class Drużyna
	{
		int punkty=0;

		Label punktyGłównyLabel = new Label();
		Label punktyPomocniczyLabel = new Label();

		public Drużyna(bool left)
		{
			DockStyle Dock = left ? DockStyle.Left : DockStyle.Right;

			punktyGłównyLabel.Dock = Dock;
			Global.główny.Controls.Add(punktyGłównyLabel);

			punktyPomocniczyLabel.Dock = Dock;
			Global.kontroler.Controls.Add(punktyPomocniczyLabel);

			dodajPunkty();
		}

		public void dodajPunkty(int dodane=0)
		{
			punkty += dodane;
			punktyGłównyLabel.Text = punkty.ToString();
			punktyPomocniczyLabel.Text = punkty.ToString();

		}
	}
}
