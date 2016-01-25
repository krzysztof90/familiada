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
			this.punkty = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dodatkowy = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// punkty
			// 
			this.punkty.AutoSize = true;
			this.punkty.Location = new System.Drawing.Point(77, 0);
			this.punkty.Name = "punkty";
			this.punkty.Size = new System.Drawing.Size(13, 13);
			this.punkty.TabIndex = 0;
			this.punkty.Text = "0";
			// 
			// dodatkowy
			// 
			this.dodatkowy.Controls.Add(this.punkty);
			this.dodatkowy.Location = new System.Drawing.Point(0, 0);
			this.dodatkowy.Name = "dodatkowy";
			this.dodatkowy.Size = new System.Drawing.Size(211, 20);
			this.dodatkowy.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(517, 324);
			this.panel1.TabIndex = 1;
			this.panel1.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(517, 324);
			this.panel2.TabIndex = 2;
			this.panel2.Visible = false;
			// 
			// GłównyEkran
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 324);
			this.Controls.Add(this.dodatkowy);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "GłównyEkran";
			this.Text = "Główny ekran";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GłównyEkran_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		public Label punkty;
		public Panel panel1;
		public Panel panel2;
		public Panel dodatkowy;

	}
}

