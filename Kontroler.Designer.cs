using System.Collections.Generic;
using System.Windows.Forms;
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
			this.dodatkowy = new System.Windows.Forms.Panel();
			this.poprzedniePytanie = new System.Windows.Forms.Button();
			this.następnePytanie = new System.Windows.Forms.Button();
			this.pokażEkran = new System.Windows.Forms.Button();
			this.runda = new System.Windows.Forms.Button();
			this.punkty = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.czas = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// dodatkowy
			// 
			this.dodatkowy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dodatkowy.Controls.Add(this.punkty);
			this.dodatkowy.Controls.Add(this.runda);
			this.dodatkowy.Controls.Add(this.pokażEkran);
			this.dodatkowy.Location = new System.Drawing.Point(dodatkowyPanelPozycjaX, dodatkowyPanelPozycjaY);
			this.dodatkowy.Name = "dodatkowy";
			this.dodatkowy.Size = new System.Drawing.Size(dodatkowyPanelSzerokość, dodatkowyPanelWysokość);
			this.dodatkowy.TabIndex = 7;
			// 
			// poprzedniePytanie
			// 
			this.poprzedniePytanie.Location = new System.Drawing.Point(przełączPytanieButtonPozycjaXPoczątek, przełączPytanieButtonPozycjaY);
			this.poprzedniePytanie.Name = "poprzedniePytanie";
			this.poprzedniePytanie.Size = new System.Drawing.Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			this.poprzedniePytanie.TabIndex = 2;
			this.poprzedniePytanie.Text = "poprzednie pytanie";
			this.poprzedniePytanie.UseVisualStyleBackColor = true;
			this.poprzedniePytanie.Visible = false;
			this.poprzedniePytanie.Click += new System.EventHandler(this.poprzedniePytanie_Click);
			// 
			// następnePytanie
			// 
			this.następnePytanie.Location = new System.Drawing.Point(przełączPytanieButtonPozycjaXPoczątek + przełączPytanieButtonOdstępX + przełączPytanieButtonSzerokość, przełączPytanieButtonPozycjaY);
			this.następnePytanie.Name = "następnePytanie";
			this.następnePytanie.Size = new System.Drawing.Size(przełączPytanieButtonSzerokość, przełączPytanieButtonWysokość);
			this.następnePytanie.TabIndex = 2;
			this.następnePytanie.Text = "zacznij pytania";
			this.następnePytanie.UseVisualStyleBackColor = true;
			this.następnePytanie.Click += new System.EventHandler(this.następnePytanie_Click);
			// 
			// pokażEkran
			// 
			this.pokażEkran.Location = new System.Drawing.Point(pokażEkranButtonPozycjaX, pokażEkranButtonPozycjaY);
			this.pokażEkran.Name = "pokażEkran";
			this.pokażEkran.Size = new System.Drawing.Size(pokażEkranButtonSzerokość, pokażEkranButtonWysokość);
			this.pokażEkran.TabIndex = 1;
			this.pokażEkran.Text = "otwórz ekran główny";
			this.pokażEkran.UseVisualStyleBackColor = true;
			this.pokażEkran.Click += new System.EventHandler(this.pokażEkran_Click);
			// 
			// runda
			// 
			this.runda.Location = new System.Drawing.Point(rundaButtonPozycjaX, rundaButtonPozycjaY);
			this.runda.Name = "runda";
			this.runda.Size = new System.Drawing.Size(rundaButtonSzerokość, rundaButtonWysokość);
			this.runda.TabIndex = 6;
			this.runda.Tag = 1;
			this.runda.Text = "przełącz do rundy 1";
			this.runda.UseVisualStyleBackColor = true;
			this.runda.Click += new System.EventHandler(this.runda_Click);
			// 
			// punkty
			// 
			this.punkty.AutoSize = true;
			this.punkty.Location = new System.Drawing.Point(punktyLabelPozycjaX, punktyLabelPozycjaY);
			this.punkty.Name = "punkty";
			this.punkty.Size = new System.Drawing.Size(punktyLabelSzerokość, punktyLabelWysokość);
			this.punkty.TabIndex = 6;
			this.punkty.Text = "0";
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(startButtonPozycjaX, startButtonPozycjaY);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(startButtonSzerokość, startButtonWysokość);
			this.start.TabIndex = 3;
			this.start.Text = "start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.startCzas_Click);
			// 
			// czas
			// 
			this.czas.AutoSize = true;
			this.czas.Location = new System.Drawing.Point(czasLabelPozycjaX, czasLabelPozycjaY);
			this.czas.Name = "czas";
			this.czas.Size = new System.Drawing.Size(czasLabelSzerokość, czasLabelWysokość);
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
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);
		}

		#endregion

		public List<System.Windows.Forms.Panel> panele;
		private List<Label> punktyDrużynaLabel;
		private List<Button> ustawCzasButton;
		public System.Windows.Forms.Panel dodatkowy;
		private System.Windows.Forms.Button poprzedniePytanie;
		private System.Windows.Forms.Button następnePytanie;
		public System.Windows.Forms.Button pokażEkran;
		private System.Windows.Forms.Button runda;
		private System.Windows.Forms.Label punkty;
		private System.Windows.Forms.Label czas;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Timer timer1;
	}
}

