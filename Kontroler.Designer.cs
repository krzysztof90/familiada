﻿namespace familiada
{
	partial class Kontroler
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
			this.poprzedniePytanie = new System.Windows.Forms.Button();
			this.dodajOdpowiedź = new System.Windows.Forms.Button();
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
			this.pokażEkran.Location = new System.Drawing.Point(352, 12);
			this.pokażEkran.Name = "pokażEkran";
			this.pokażEkran.Size = new System.Drawing.Size(114, 23);
			this.pokażEkran.TabIndex = 1;
			this.pokażEkran.Text = "otwórz ekran główny";
			this.pokażEkran.UseVisualStyleBackColor = true;
			this.pokażEkran.Click += new System.EventHandler(this.pokażEkran_Click);
			// 
			// poprzedniePytanie
			// 
			this.poprzedniePytanie.Location = new System.Drawing.Point(187, 251);
			this.poprzedniePytanie.Name = "poprzedniePytanie";
			this.poprzedniePytanie.Size = new System.Drawing.Size(114, 23);
			this.poprzedniePytanie.TabIndex = 2;
			this.poprzedniePytanie.Text = "poprzedniePytanie";
			this.poprzedniePytanie.UseVisualStyleBackColor = true;
			this.poprzedniePytanie.Visible = false;
			this.poprzedniePytanie.Click += new System.EventHandler(this.poprzedniePytanie_Click);
			// 
			// dodajOdpowiedź
			// 
			this.dodajOdpowiedź.Location = new System.Drawing.Point(457, 110);
			this.dodajOdpowiedź.Name = "dodajOdpowiedź";
			this.dodajOdpowiedź.Size = new System.Drawing.Size(135, 23);
			this.dodajOdpowiedź.TabIndex = 3;
			this.dodajOdpowiedź.Text = "dodaj odpowiedź";
			this.dodajOdpowiedź.UseVisualStyleBackColor = true;
			this.dodajOdpowiedź.Visible = false;
			this.dodajOdpowiedź.Click += new System.EventHandler(this.dodajOdpowiedź_Click);
			// 
			// Kontroler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 293);
			this.Controls.Add(this.dodajOdpowiedź);
			this.Controls.Add(this.poprzedniePytanie);
			this.Controls.Add(this.pokażEkran);
			this.Controls.Add(this.następnePytanie);
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button następnePytanie;
		private System.Windows.Forms.Button poprzedniePytanie;
		public System.Windows.Forms.Button pokażEkran;
		private System.Windows.Forms.Button dodajOdpowiedź;
	}
}

