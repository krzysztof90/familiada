using System.Collections.Generic;
using System.Windows.Forms;
namespace familiada
{
	partial class GłównyEkran
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelPodstawa = new System.Windows.Forms.TableLayoutPanel();
			this.panelRundy = new System.Windows.Forms.Panel();
			this.panelPodstawaLewy = new System.Windows.Forms.TableLayoutPanel();
			this.panelPunktyL = new System.Windows.Forms.Panel();
			this.panelPodstawaPrawy = new System.Windows.Forms.TableLayoutPanel();
			this.panelPunktyP = new System.Windows.Forms.Panel();
			this.panelPodstawaGóra = new System.Windows.Forms.TableLayoutPanel();
			this.panelPunkty = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panelPodstawa
			// 
			this.panelPodstawa.ColumnCount = 3;
			this.panelPodstawa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
			this.panelPodstawa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.panelPodstawa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
			this.panelPodstawa.Controls.Add(this.panelRundy, 1, 1);
			this.panelPodstawa.Controls.Add(this.panelPodstawaLewy, 0, 1);
			this.panelPodstawa.Controls.Add(this.panelPodstawaPrawy, 2, 1);
			this.panelPodstawa.Controls.Add(this.panelPodstawaGóra, 1, 0);
			this.panelPodstawa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPodstawa.Location = new System.Drawing.Point(0, 0);
			this.panelPodstawa.Name = "panelPodstawa";
			this.panelPodstawa.RowCount = 2;
			this.panelPodstawa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.panelPodstawa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.panelPodstawa.Size = new System.Drawing.Size(795, 476);
			this.panelPodstawa.TabIndex = 0;
			// 
			// panelRundy
			// 
			this.panelRundy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRundy.Location = new System.Drawing.Point(126, 109);
			this.panelRundy.Margin = new System.Windows.Forms.Padding(0);
			this.panelRundy.Name = "panelRundy";
			this.panelRundy.Size = new System.Drawing.Size(542, 367);
			this.panelRundy.TabIndex = 3;
			// 
			// panelPodstawaLewy
			// 
			this.panelPodstawaLewy.ColumnCount = 1;
			this.panelPodstawaLewy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelPodstawaLewy.Controls.Add(this.panelPunktyL, 0, 1);
			this.panelPodstawaLewy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPodstawaLewy.Location = new System.Drawing.Point(0, 109);
			this.panelPodstawaLewy.Margin = new System.Windows.Forms.Padding(0);
			this.panelPodstawaLewy.Name = "panelPodstawaLewy";
			this.panelPodstawaLewy.RowCount = 3;
			this.panelPodstawaLewy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
			this.panelPodstawaLewy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.panelPodstawaLewy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
			this.panelPodstawaLewy.Size = new System.Drawing.Size(126, 367);
			this.panelPodstawaLewy.TabIndex = 4;
			// 
			// panelPunktyL
			// 
			this.panelPunktyL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPunktyL.Location = new System.Drawing.Point(0, 128);
			this.panelPunktyL.Margin = new System.Windows.Forms.Padding(0);
			this.panelPunktyL.Name = "panelPunktyL";
			this.panelPunktyL.Size = new System.Drawing.Size(126, 110);
			this.panelPunktyL.TabIndex = 0;
			// 
			// panelPodstawaPrawy
			// 
			this.panelPodstawaPrawy.ColumnCount = 1;
			this.panelPodstawaPrawy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelPodstawaPrawy.Controls.Add(this.panelPunktyP, 0, 1);
			this.panelPodstawaPrawy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPodstawaPrawy.Location = new System.Drawing.Point(668, 109);
			this.panelPodstawaPrawy.Margin = new System.Windows.Forms.Padding(0);
			this.panelPodstawaPrawy.Name = "panelPodstawaPrawy";
			this.panelPodstawaPrawy.RowCount = 3;
			this.panelPodstawaPrawy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
			this.panelPodstawaPrawy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.panelPodstawaPrawy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
			this.panelPodstawaPrawy.Size = new System.Drawing.Size(127, 367);
			this.panelPodstawaPrawy.TabIndex = 5;
			// 
			// panelPunktyP
			// 
			this.panelPunktyP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPunktyP.Location = new System.Drawing.Point(0, 128);
			this.panelPunktyP.Margin = new System.Windows.Forms.Padding(0);
			this.panelPunktyP.Name = "panelPunktyP";
			this.panelPunktyP.Size = new System.Drawing.Size(127, 110);
			this.panelPunktyP.TabIndex = 0;
			// 
			// panelPodstawaGóra
			// 
			this.panelPodstawaGóra.ColumnCount = 3;
			this.panelPodstawaGóra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
			this.panelPodstawaGóra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
			this.panelPodstawaGóra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
			this.panelPodstawaGóra.Controls.Add(this.panelPunkty, 1, 0);
			this.panelPodstawaGóra.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPodstawaGóra.Location = new System.Drawing.Point(126, 0);
			this.panelPodstawaGóra.Margin = new System.Windows.Forms.Padding(0);
			this.panelPodstawaGóra.Name = "panelPodstawaGóra";
			this.panelPodstawaGóra.RowCount = 1;
			this.panelPodstawaGóra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelPodstawaGóra.Size = new System.Drawing.Size(542, 109);
			this.panelPodstawaGóra.TabIndex = 6;
			// 
			// panelPunkty
			// 
			this.panelPunkty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPunkty.Location = new System.Drawing.Point(207, 0);
			this.panelPunkty.Margin = new System.Windows.Forms.Padding(0);
			this.panelPunkty.Name = "panelPunkty";
			this.panelPunkty.Size = new System.Drawing.Size(126, 109);
			this.panelPunkty.TabIndex = 0;
			// 
			// GłównyEkran
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 476);
			this.Controls.Add(this.panelPodstawa);
			this.Name = "GłównyEkran";
			this.Text = "Główny ekran";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GłównyEkran_FormClosing);
			this.ResumeLayout(false);
		}

		#endregion

		public List<System.Windows.Forms.Panel> panel;
		private TableLayoutPanel panelPodstawa;
		private Panel panelRundy;
		private TableLayoutPanel panelPodstawaLewy;
		private TableLayoutPanel panelPodstawaPrawy;
		private TableLayoutPanel panelPodstawaGóra;
		public Panel panelPunktyL;
		public Panel panelPunktyP;
		public Panel panelPunkty;

	}
}

