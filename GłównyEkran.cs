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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(GłównyEkran));

			TableLayoutPanel cyfryPanel = new TableLayoutPanel();
			Znak[] cyfry = new Znak[3];

			for(int i=0; i<3; i++)
			{
				cyfry[i] = new Znak(30, 2);
				cyfry[i].dodajDo(cyfryPanel, i*2, 0);
			}

			//cyfryPanel.BackColor = Color.Black;
			cyfryPanel.ColumnCount = 5;
			cyfryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			cyfryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.33333F));
			cyfryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			cyfryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.33333F));
			cyfryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			cyfryPanel.Location = new Point(12, 300);
			cyfryPanel.RowCount = 1;
			cyfryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			cyfryPanel.Size = new Size(500, 300);

			panel1.Controls.Add(cyfryPanel);

		}
	}
}
