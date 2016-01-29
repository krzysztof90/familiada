using System.Collections.Generic;
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
			this.components = new System.ComponentModel.Container();
			this.następnePytanie = new System.Windows.Forms.Button();
			this.pokażEkran = new System.Windows.Forms.Button();
			this.poprzedniePytanie = new System.Windows.Forms.Button();
			this.runda = new System.Windows.Forms.Button();
			this.punkty = new System.Windows.Forms.Label();
			this.dodatkowy = new System.Windows.Forms.Panel();
			this.panel = new List<System.Windows.Forms.Panel> { new System.Windows.Forms.Panel(), new System.Windows.Forms.Panel() };
			this.start = new System.Windows.Forms.Button();
			this.ustawCzas20 = new System.Windows.Forms.Button();
			this.ustawCzas15 = new System.Windows.Forms.Button();
			this.czas = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.dodatkowy.SuspendLayout();
			panel.ForEach(p => p.SuspendLayout());
			this.SuspendLayout();
			// 
			// następnePytanie
			// 
			this.następnePytanie.Location = new System.Drawing.Point(338, 300);
			this.następnePytanie.Name = "następnePytanie";
			this.następnePytanie.Size = new System.Drawing.Size(114, 23);
			this.następnePytanie.TabIndex = 2;
			this.następnePytanie.Text = "zacznij pytania";
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
			this.poprzedniePytanie.Text = "poprzednie pytanie";
			this.poprzedniePytanie.UseVisualStyleBackColor = true;
			this.poprzedniePytanie.Visible = false;
			this.poprzedniePytanie.Click += new System.EventHandler(this.poprzedniePytanie_Click);
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
			this.dodatkowy.Location = new System.Drawing.Point(3, 320);
			this.dodatkowy.Name = "dodatkowy";
			this.dodatkowy.Size = new System.Drawing.Size(211, 133);
			this.dodatkowy.TabIndex = 7;
			// 
			// panel1
			// 

			this.panel[0].Controls.Add(this.poprzedniePytanie);
			this.panel[0].Controls.Add(this.następnePytanie);

			this.panel.ForEach(p => p.Dock = System.Windows.Forms.DockStyle.Fill);
			this.panel.ForEach(p => p.Margin = new System.Windows.Forms.Padding(0));
			this.panel.ForEach(p => p.Visible = false);
			// 
			// panel2
			// 
			this.panel[1].Controls.Add(this.ustawCzas15);
			this.panel[1].Controls.Add(this.czas);
			this.panel[1].Controls.Add(this.start);
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(474, 345);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(75, 23);
			this.start.TabIndex = 3;
			this.start.Text = "start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.startCzas_Click);
			// 
			// ustawCzas20
			// 
			this.ustawCzas20.Location = new System.Drawing.Point(571, 300);
			this.ustawCzas20.Name = "ustawCzas20";
			this.ustawCzas20.Size = new System.Drawing.Size(75, 23);
			this.ustawCzas20.TabIndex = 4;
			this.ustawCzas20.Tag = "20";
			this.ustawCzas20.Text = "ustaw 20";
			this.ustawCzas20.UseVisualStyleBackColor = true;
			this.ustawCzas20.Click += new System.EventHandler(this.ustawCzas_Click);
			// 
			// ustawCzas15
			// 
			this.ustawCzas15.Location = new System.Drawing.Point(474, 300);
			this.ustawCzas15.Name = "ustawCzas15";
			this.ustawCzas15.Size = new System.Drawing.Size(75, 23);
			this.ustawCzas15.TabIndex = 3;
			this.ustawCzas15.Tag = "15";
			this.ustawCzas15.Text = "ustaw 15";
			this.ustawCzas15.UseVisualStyleBackColor = true;
			this.ustawCzas15.Click += new System.EventHandler(this.ustawCzas_Click);
			// 
			// czas
			// 
			this.czas.AutoSize = true;
			this.czas.Location = new System.Drawing.Point(523, 398);
			this.czas.Name = "czas";
			this.czas.Size = new System.Drawing.Size(0, 13);
			this.czas.TabIndex = 3;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Kontroler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 454);
			this.Controls.Add(this.dodatkowy);
			this.panel.ForEach(p => this.Controls.Add(p));
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.Load += new System.EventHandler(this.Form_Load);
			this.dodatkowy.ResumeLayout(false);
			this.dodatkowy.PerformLayout();
			this.panel.ForEach(p => p.ResumeLayout());
			this.panel.ForEach(p => p.PerformLayout());
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button następnePytanie;
		private System.Windows.Forms.Button poprzedniePytanie;
		public System.Windows.Forms.Button pokażEkran;
		private System.Windows.Forms.Button runda;
		public System.Windows.Forms.Label punkty;
		public List<System.Windows.Forms.Panel> panel;
		public System.Windows.Forms.Panel dodatkowy;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Label czas;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button ustawCzas20;
		private System.Windows.Forms.Button ustawCzas15;
	}
}

