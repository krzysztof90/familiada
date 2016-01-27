using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class Znak
	{
		int liczbaKolumn;
		int liczbaRzędów;

		TableLayoutPanel panel = new TableLayoutPanel();
		PictureBox[,] piksele;

		public Znak(int liczbaKolumn, int liczbaRzędów)
		{
			this.liczbaKolumn = liczbaKolumn;
			this.liczbaRzędów = liczbaRzędów;

			panel.ColumnCount = liczbaKolumn; //+1 ? zamiast tego niżej
			panel.RowCount = liczbaRzędów;

			for (int i = 0; i < liczbaKolumn; i++)
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / liczbaKolumn));
			//panel.ColumnCount++; //naprawia wyświetlanie ostatniej kolumny za dużej?
			for (int i = 0; i < liczbaRzędów; i++)
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / liczbaRzędów));
			//panel.RowCount++;
			panel.Dock = DockStyle.Fill;
			panel.Margin = new Padding(0);

			piksele = new PictureBox[liczbaKolumn, liczbaRzędów];
			for (int kolumna = 0; kolumna < liczbaKolumn; kolumna++)
				for (int rząd = 0; rząd < liczbaRzędów; rząd++)
				{
					PictureBox piksel = piksele[kolumna, rząd];
					piksel = new PictureBox();
					//((ISupportInitialize)(piksel)).BeginInit();
					panel.Controls.Add(piksel, kolumna, rząd);
					piksel.Dock = DockStyle.Fill;
					piksel.Image = obraz();
					piksel.SizeMode = PictureBoxSizeMode.StretchImage;
					piksel.Margin = new Padding(0);
					//((ISupportInitialize)(piksel)).EndInit();
				}
		}

		public virtual Image obraz()
		{
			return global::familiada.Properties.Resources.żółty;
		}

		public void dodajDo(TableLayoutPanel panel, int kolumna, int rząd)
		{
			panel.Controls.Add(this.panel, kolumna, rząd);
		}
	}
}
