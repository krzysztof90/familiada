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
			punktyGłównyLabel.Text = "0";
			Global.główny.Controls.Add(punktyGłównyLabel);

			//int szerokość = Global.główny.Width;
			//MessageBox.Show(szerokość.ToString());

			punktyPomocniczyLabel.Dock = Dock;
			punktyPomocniczyLabel.Text = "0";
			Global.pomocniczy.Controls.Add(punktyPomocniczyLabel);
		}
	}
}
