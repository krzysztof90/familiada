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

		public void pokażPanel1()
		{
			panel1.Show();
		}
		public void ukryjPanel1()
		{
			panel1.Hide();
		}
		public void pokażPanel2()
		{
			panel2.Show();
		}
		public void ukryjPanel2()
		{
			panel2.Hide();
		}
		public void ustawPunktyGłówne(int punkty)
		{
			Global.tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
	}
}
