namespace familiada
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
			this.runda = new System.Windows.Forms.Button();
			this.punkty = new System.Windows.Forms.Label();
			this.dodatkowy = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dodatkowy.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// następnePytanie
			// 
			this.następnePytanie.Location = new System.Drawing.Point(338, 300);
			this.następnePytanie.Name = "następnePytanie";
			this.następnePytanie.Size = new System.Drawing.Size(114, 23);
			this.następnePytanie.TabIndex = 2;
			this.następnePytanie.Text = "następnePytanie";
			this.następnePytanie.UseVisualStyleBackColor = true;
			this.następnePytanie.Click += new System.EventHandler(this.następnePytanie_Click);
			// 
			// pokażEkran
			// 
			this.pokażEkran.Location = new System.Drawing.Point(0, 39);
			this.pokażEkran.Name = "pokażEkran";
			this.pokażEkran.Size = new System.Drawing.Size(114, 23);
			this.pokażEkran.TabIndex = 1;
			this.pokażEkran.Text = "otwórz ekran główny";
			this.pokażEkran.UseVisualStyleBackColor = true;
			this.pokażEkran.Click += new System.EventHandler(this.pokażEkran_Click);
			// 
			// poprzedniePytanie
			// 
			this.poprzedniePytanie.Location = new System.Drawing.Point(187, 300);
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
			this.dodajOdpowiedź.TabIndex = 0;
			this.dodajOdpowiedź.Text = "dodaj odpowiedź";
			this.dodajOdpowiedź.UseVisualStyleBackColor = true;
			this.dodajOdpowiedź.Visible = false;
			this.dodajOdpowiedź.Click += new System.EventHandler(this.dodajOdpowiedź_Click);
			// 
			// runda
			// 
			this.runda.Location = new System.Drawing.Point(0, 68);
			this.runda.Name = "runda";
			this.runda.Size = new System.Drawing.Size(114, 23);
			this.runda.TabIndex = 6;
			this.runda.Tag = 1;
			this.runda.Text = "przełącz do rundy 1";
			this.runda.UseVisualStyleBackColor = true;
			this.runda.Click += new System.EventHandler(this.runda_Click);
			// 
			// punkty
			// 
			this.punkty.AutoSize = true;
			this.punkty.Location = new System.Drawing.Point(80, 8);
			this.punkty.Name = "punkty";
			this.punkty.Size = new System.Drawing.Size(13, 13);
			this.punkty.TabIndex = 6;
			this.punkty.Text = "0";
			// 
			// dodatkowy
			// 
			this.dodatkowy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dodatkowy.Controls.Add(this.punkty);
			this.dodatkowy.Controls.Add(this.runda);
			this.dodatkowy.Controls.Add(this.pokażEkran);
			this.dodatkowy.Location = new System.Drawing.Point(3, 236);
			this.dodatkowy.Name = "dodatkowy";
			this.dodatkowy.Size = new System.Drawing.Size(211, 133);
			this.dodatkowy.TabIndex = 7;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dodajOdpowiedź);
			this.panel1.Controls.Add(this.poprzedniePytanie);
			this.panel1.Controls.Add(this.następnePytanie);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(658, 372);
			this.panel1.TabIndex = 7;
			this.panel1.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(658, 372);
			this.panel2.TabIndex = 8;
			this.panel2.Visible = false;
			// 
			// Kontroler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 372);
			this.Controls.Add(this.dodatkowy);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.Load += new System.EventHandler(this.Form_Load);
			this.dodatkowy.ResumeLayout(false);
			this.dodatkowy.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button następnePytanie;
		private System.Windows.Forms.Button poprzedniePytanie;
		public System.Windows.Forms.Button pokażEkran;
		public System.Windows.Forms.Button dodajOdpowiedź;
		private System.Windows.Forms.Button runda;
		public System.Windows.Forms.Label punkty;
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Panel dodatkowy;
		public System.Windows.Forms.Panel panel2;
	}
}

