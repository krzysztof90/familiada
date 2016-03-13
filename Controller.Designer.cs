using System.Collections.Generic;
using System.Windows.Forms;
namespace familiada
{
	partial class Controller
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// Kontroler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 454);
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public List<System.Windows.Forms.Panel> roundPanels;
		private List<Label> teamPointsLabel;
		private List<Button> setTimeButton;
		public System.Windows.Forms.Panel accessory;
		private System.Windows.Forms.Button previousQuestion;
		private System.Windows.Forms.Button nextQuestion;
		public System.Windows.Forms.Button showMainScreenButton;
		private System.Windows.Forms.Button switchRoundButton;
		private System.Windows.Forms.Label pointsLabel;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Button hideAnswersButton;
	}
}

