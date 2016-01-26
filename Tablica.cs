using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	class Tablica
	{
		int liczbaKolumn;
		int liczbaRzędów;

		TableLayoutPanel panel = new TableLayoutPanel();
		Znak[,] znaki;

		public Tablica(int liczbaKolumn, int liczbaRzędów, int pikseleWKolumnie, int pikseleWRzędzie)
		{
			this.liczbaKolumn = liczbaKolumn;
			this.liczbaRzędów = liczbaRzędów;

			panel.ColumnCount = liczbaKolumn * 2 + 1;
			panel.RowCount = liczbaRzędów * 2 + 1;

			Single rozmiarKolumnyPrzerwy=100F/(pikseleWKolumnie*liczbaKolumn+(liczbaKolumn+1));
			Single rozmiarKolumnyZnaku=rozmiarKolumnyPrzerwy*pikseleWKolumnie;
			Single rozmiarWierszaPrzerwy = 100F / (pikseleWRzędzie * liczbaRzędów + (liczbaRzędów + 1));
			Single rozmiarWierszaZnaku = rozmiarWierszaPrzerwy * pikseleWRzędzie;

			for (int i = 0; i < liczbaKolumn; i++)
			{
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyPrzerwy));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyZnaku));
			}
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyPrzerwy));
			panel.ColumnCount++;
			for (int i = 0; i < liczbaRzędów; i++)
			{
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaPrzerwy));
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaZnaku));
			}
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaPrzerwy));
			panel.RowCount++;
			panel.Dock = DockStyle.Fill;
			panel.Margin = new Padding(0);

			znaki = new Znak[liczbaKolumn, liczbaRzędów];

			//przerwa
			for (int kolumna = 0; kolumna < liczbaKolumn; kolumna++)
			{
				for (int rząd = 0; rząd < liczbaRzędów; rząd++)
				{
					//przerwa

					Znak znak = znaki[kolumna, rząd];
					znak = new Znak(pikseleWKolumnie, pikseleWRzędzie);
					znak.dodajDo(panel, kolumna * 2 + 1, rząd * 2 + 1);

				}
					//przerwa
			}
					//przerwa

			//panel.BackColor = Color.Black;
			//panel.Dock
			panel.Location = new Point(12, 300);
			panel.Size = new Size(500, 300);

		}
		public void dodajDo(Panel panel)
		{
			panel.Controls.Add(this.panel);
		}
	}
}
