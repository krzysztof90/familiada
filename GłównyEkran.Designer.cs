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
			this.SuspendLayout();
			// 
			// GłównyEkran
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 324);
			this.Name = "GłównyEkran";
			this.Text = "Główny ekran";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GłównyEkran_FormClosing);
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);

		}

		#endregion

	}
}

