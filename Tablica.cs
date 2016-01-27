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
		PictureBox[,] znakiPictureBox;
		Dictionary<char, Image> znakiObrazy;

		public Tablica(Panel ojciec, int liczbaKolumn, int liczbaRzędów, int pikseleWKolumnie, int pikseleWRzędzie, Image tło, Dictionary<char, Image> znaki)
		{
			this.liczbaKolumn = liczbaKolumn;
			this.liczbaRzędów = liczbaRzędów;
			this.znakiObrazy = znaki;

			panel.ColumnCount = liczbaKolumn * 2 + 1;
			panel.RowCount = liczbaRzędów * 2 + 1;

			znakiPictureBox = new PictureBox[liczbaKolumn, liczbaRzędów];
			for (int kolumna = 0; kolumna < liczbaKolumn; kolumna++)
				for (int rząd = 0; rząd < liczbaRzędów; rząd++)
				{
					znakiPictureBox[kolumna, rząd] = new PictureBox();
					PictureBox znakPictureBox = znakiPictureBox[kolumna, rząd];
					znakPictureBox.Dock = DockStyle.Fill;
					znakPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					znakPictureBox.Margin = new Padding(0);
					znakPictureBox.Image = znakiObrazy[' '];
					panel.Controls.Add(znakPictureBox, kolumna * 2 + 1, rząd * 2 + 1);
				}

			Single rozmiarKolumnyPrzerwy = 100F / (pikseleWKolumnie * liczbaKolumn + (liczbaKolumn + 1));
			Single rozmiarKolumnyZnaku = rozmiarKolumnyPrzerwy * pikseleWKolumnie;
			Single rozmiarWierszaPrzerwy = 100F / (pikseleWRzędzie * liczbaRzędów + (liczbaRzędów + 1));
			Single rozmiarWierszaZnaku = rozmiarWierszaPrzerwy * pikseleWRzędzie;

			for (int i = 0; i < liczbaKolumn; i++)
			{
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyPrzerwy));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyZnaku));
			}
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyPrzerwy));
			for (int i = 0; i < liczbaRzędów; i++)
			{
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaPrzerwy));
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaZnaku));
			}
			panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaPrzerwy));

			panel.Dock = DockStyle.Fill;
			panel.BackgroundImage = tło;
			panel.BackgroundImageLayout = ImageLayout.Stretch;
			panel.Margin = new Padding(0);

			ojciec.Controls.Add(panel);
		}

		public void wstaw(char znak, int kolumna, int rząd)
		{
			znakiPictureBox[kolumna, rząd].Image = znakiObrazy[znak];
		}
	}
}
