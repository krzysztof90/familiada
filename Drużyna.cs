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

		Label punktyDrużynaLabel = new Label();
		public Tablica tablicaPunkty;

		public abstract DockStyle punktyKontrolerLabelDockStyle { get; }
		public abstract Panel ojciec { get; }

		public DrużynaStrona()
		{
			punktyDrużynaLabel.Dock = punktyKontrolerLabelDockStyle;
			Global.panelKontrolerDodatkowy.Controls.Add(punktyDrużynaLabel);

			tablicaPunkty = new Tablica(ojciec, 3, 1, Resources.puste);

			wyświetlPunkty();
		}

		public void dodajPunkty(int dodane)
		{
			punkty += dodane;
			wyświetlPunkty();
		}
		public void wyświetlPunkty()
		{
			tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
			
			punktyDrużynaLabel.Text = punkty.ToString();
		}
	}

	class DrużynaL : DrużynaStrona
	{
		public DrużynaL() : base() { }

		public override DockStyle punktyKontrolerLabelDockStyle
		{
			get { return DockStyle.Left; }
		}
		public override Panel ojciec
		{
			get { return Global.główny.panelPunktyL; }
		}
	}

	class DrużynaP : DrużynaStrona
	{
		public DrużynaP() : base() { }

		public override DockStyle punktyKontrolerLabelDockStyle
		{
			get { return DockStyle.Right; }
		}
		public override Panel ojciec
		{
			get { return Global.główny.panelPunktyP; }
		}
	}
}
