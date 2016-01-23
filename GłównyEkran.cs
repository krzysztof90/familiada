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

		private void GłównyEkran_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			Global.kontroler.pokażEkran.Show();
		}

		//protected override void WndProc(ref Message m)
		//{
		//	const int WM_DISPLAYCHANGE = 0x007e;

		//	// Listen for operating system messages. 
		//	switch (m.Msg)
		//	{
		//		case WM_DISPLAYCHANGE:
					
		//	//Global.kontroler.Location = tenEkran.WorkingArea.Location;
		//			//MessageBox.Show("screen change");
		//			// The WParam value is the new bit depth
		//			//int width = m.LParam;
		//			//int height =m.LParam;
		//			break;
		//	}
		//	base.WndProc(ref m);
		//}
	}
}
