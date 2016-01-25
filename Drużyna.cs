﻿using System;
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
		Label punktyGłównyLabel = new Label();

		public Drużyna(bool left)
		{
			DockStyle Dock = left ? DockStyle.Left : DockStyle.Right;

			punktyKontrolerLabel.Dock = Dock;
			Global.panelKontrolerDodatkowy.Controls.Add(punktyKontrolerLabel);

			punktyGłównyLabel.Dock = Dock;
			Global.panelGłównyDodatkowy.Controls.Add(punktyGłównyLabel);

			dodajPunkty();
		}

		public void dodajPunkty(int dodane = 0)
		{
			punkty += dodane;
			punktyGłównyLabel.Text = punkty.ToString();
			punktyKontrolerLabel.Text = punkty.ToString();
		}
	}
}
