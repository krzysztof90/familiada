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
			TableLayoutPanel[] cyfry = new TableLayoutPanel[3];

			for (int i = 0; i < 3; i++)
			{
				cyfry[i] = new TableLayoutPanel();
				cyfry[i].ColumnCount = 5;
				cyfry[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
				cyfry[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
				cyfry[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
				cyfry[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
				cyfry[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
				cyfry[i].Dock = System.Windows.Forms.DockStyle.Fill;
				cyfry[i].RowCount = 7;
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
				cyfry[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));

				for (int kolumna = 0; kolumna < 5; kolumna++)
					for (int rząd = 0; rząd < 7; rząd++)
					{
						PictureBox obraz = new PictureBox();
						((ISupportInitialize)(obraz)).BeginInit();
						cyfry[i].Controls.Add(obraz, kolumna, rząd);
						obraz.Dock = DockStyle.Fill;
						//obraz.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
						obraz.Image = global::familiada.Properties.Resources.żółty;
						((ISupportInitialize)(obraz)).EndInit();
					}

				cyfryPanel.Controls.Add(cyfry[i]);
			}

			cyfryPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			cyfryPanel.ColumnCount = 3;
			cyfryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			cyfryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			cyfryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			cyfryPanel.Location = new System.Drawing.Point(12, 62);
			cyfryPanel.RowCount = 1;
			cyfryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			cyfryPanel.Size = new System.Drawing.Size(190, 100);

			dodatkowy.Controls.Add(cyfryPanel);

		}
	}
}
