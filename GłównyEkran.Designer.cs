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
			this.SuspendLayout();
			// 
			// punkty
			// 
			this.punkty.AutoSize = true;
			this.punkty.Location = new System.Drawing.Point(197, 13);
			this.punkty.Name = "punkty";
			this.punkty.Size = new System.Drawing.Size(0, 13);
			this.punkty.TabIndex = 0;
			this.punkty.Text = "0";
			// 
			// GłównyEkran
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 324);
			this.Controls.Add(this.punkty);
			this.Name = "GłównyEkran";
			this.Text = "Główny ekran";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GłównyEkran_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public Label punkty;

	}
}

