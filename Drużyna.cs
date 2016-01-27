using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class Drużyna
	{
		int punkty = 0;

		Label punktyKontrolerLabel = new Label();
		public Tablica tablicaPunkty;

		public Drużyna(bool left)
		{
			punktyKontrolerLabel.Dock = left ? DockStyle.Left : DockStyle.Right;
			Global.panelKontrolerDodatkowy.Controls.Add(punktyKontrolerLabel);

			tablicaPunkty = new Tablica(left ? Global.główny.panelPunktyL : Global.główny.panelPunktyP, 3, 1, global::familiada.Properties.Resources.puste);

			wyświetlPunkty();
		}

		public void dodajPunkty(int dodane)
		{
			punkty += dodane;
			wyświetlPunkty();
		}
		public void wyświetlPunkty()
		{
			tablicaPunkty.ustawTekst(punkty.ToString(),0,0);
			punktyKontrolerLabel.Text = punkty.ToString();
		}
	}
}
