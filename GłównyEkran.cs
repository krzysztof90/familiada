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
	public partial class GłównyEkran : Form
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

		private void Form_Load(object sender, EventArgs e)
		{
			Dictionary<char, Image> znaki = new Dictionary<char, Image>()
			{
				{'a', global::familiada.Properties.Resources.czarny},
				{'b', global::familiada.Properties.Resources.żółty},
				{' ', global::familiada.Properties.Resources.żółty},
			};
			Tablica tablica = new Tablica(panel1, 3, 2, 5, 7, global::familiada.Properties.Resources.czarny, znaki);

			tablica.wstaw('b', 0, 0);
			tablica.wstaw('a', 0, 0);
		}
	}
}
