using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	interface IOperatable
	{
		void pokażPanel(int który);
		void ukryjPanel(int który);
		void ustawPunktyGłówne(int punkty);
		void ustawPunktyDrużyny(int która, int punkty);
		void pokażKontrolkiOdpowiedzi1(int numer, string odpowiedź, int punkty, Panel panel, bool zaznaczona);
		void ukryjKontrolkiOdpowiedzi1(int numer, Panel panel);
	}
}
