using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	public partial class GłównyEkran : Form
	{

		public GłównyEkran()
		{
			InitializeComponent();
		}

		private void Form_Load(object sender, EventArgs e)
		{
			Screen tenEkran = Screen.FromControl(this);
			Screen drugiEkran = Screen.AllScreens.FirstOrDefault(s => !s.Equals(tenEkran)) ?? tenEkran;
			this.Location = drugiEkran.WorkingArea.Location;
			//this.FormBorderStyle = FormBorderStyle.None;
			//this.WindowState = FormWindowState.Maximized;
			//this.TopMost = true;
		}

		private void GłównyEkran_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			Global.kontroler.pokażEkran.Show();
		}

	}
}
