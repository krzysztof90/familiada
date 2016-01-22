namespace familiada
{
	partial class NotForShow
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
			this.następnePytanie = new System.Windows.Forms.Button();
			this.pokażEkran = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// następnePytanie
			// 
			this.następnePytanie.Location = new System.Drawing.Point(338, 251);
			this.następnePytanie.Name = "następnePytanie";
			this.następnePytanie.Size = new System.Drawing.Size(114, 23);
			this.następnePytanie.TabIndex = 0;
			this.następnePytanie.Text = "następnePytanie";
			this.następnePytanie.UseVisualStyleBackColor = true;
			this.następnePytanie.Click += new System.EventHandler(this.następnePytanie_Click);
			// 
			// pokażEkran
			// 
			this.pokażEkran.Location = new System.Drawing.Point(377, 90);
			this.pokażEkran.Name = "pokażEkran";
			this.pokażEkran.Size = new System.Drawing.Size(114, 23);
			this.pokażEkran.TabIndex = 1;
			this.pokażEkran.Text = "otwórz ekran główny";
			this.pokażEkran.UseVisualStyleBackColor = true;
			this.pokażEkran.Click += new System.EventHandler(this.pokażEkran_Click);
			// 
			// NotForShow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 324);
			this.Controls.Add(this.pokażEkran);
			this.Controls.Add(this.następnePytanie);
			this.Name = "NotForShow";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button następnePytanie;
		private System.Windows.Forms.Button pokażEkran;
	}
}

