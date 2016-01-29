using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	public partial class GłównyEkran : Form, IOperatable
	{
		public GłównyEkran()
		{
			InitializeComponent();
		}

		private void GłównyEkran_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			Global.kontroler.pokażEkran.Show();
		}

		public void pokażPanel(int który)
		{
			panel[który].Show();
		}
		public void ukryjPanel(int który)
		{
			panel[który].Hide();
		}
		public void ustawPunktyGłówne(int punkty)
		{
			Global.tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
		public void ustawPunktyDrużyny(int która, int punkty)
		{
			Global.tablicaPunktyDrużyny[która].ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
	}
}
