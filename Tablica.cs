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

		public Tablica(Panel ojciec, int liczbaKolumn, int liczbaRzędów, Image tło)
		{
			this.liczbaKolumn = liczbaKolumn;
			this.liczbaRzędów = liczbaRzędów;

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
					znakPictureBox.Image = Global.znaki[' '];
					panel.Controls.Add(znakPictureBox, kolumna * 2 + 1, rząd * 2 + 1);
				}

			Single rozmiarKolumnyZnaku = 1F * 5;
			Single rozmiarWierszaZnaku = 1F * 7;

			for (int i = 0; i < liczbaKolumn; i++)
			{
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rozmiarKolumnyZnaku));
			}
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
			for (int i = 0; i < liczbaRzędów; i++)
			{
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, rozmiarWierszaZnaku));
			}
			panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));

			panel.Dock = DockStyle.Fill;
			panel.BackgroundImage = tło;
			panel.BackgroundImageLayout = ImageLayout.Stretch;
			panel.Margin = new Padding(0);

			ojciec.Controls.Add(panel);
		}

		/// <summary>
		/// dla za długiego tekstu przy wyrównaniu do lewej urywa z prawej, przy wyrówaniu do prawej urywa z lewej
		/// </summary>
		public void ustawTekst(string tekst, int kolumnaPoczątkowa, int rząd, bool wyrównanieDoLewej, int pojemnośćCałkowita, char wypełnienie, bool ustawJakoTag = false)
		{
			int długośćTekstu = tekst.Length;
			if (wyrównanieDoLewej)
			{
				for (int i = 0; i < długośćTekstu && i < pojemnośćCałkowita; i++)
					znakiPictureBox[kolumnaPoczątkowa + i, rząd].Image = Global.znaki[tekst[i]];
				for (int i = 0; i < pojemnośćCałkowita - długośćTekstu; i++)
					znakiPictureBox[kolumnaPoczątkowa + długośćTekstu + i, rząd].Image = Global.znaki[wypełnienie];
			}
			else
			{
				for (int i = (długośćTekstu > pojemnośćCałkowita ? długośćTekstu - pojemnośćCałkowita : 0); i < długośćTekstu; i++)
					znakiPictureBox[kolumnaPoczątkowa + pojemnośćCałkowita - długośćTekstu + i, rząd].Image = Global.znaki[tekst[i]];
				for (int i = 0; i < pojemnośćCałkowita - długośćTekstu; i++)
					znakiPictureBox[kolumnaPoczątkowa + i, rząd].Image = Global.znaki[wypełnienie];
			}
			if (ustawJakoTag)
				panel.Tag = tekst;
		}
		private void wstaw(char znak, int kolumna, int rząd)
		{
			znakiPictureBox[kolumna, rząd].Image = Global.znaki[znak];
		}
		public string zwróćWartość()
		{
			return (string)(panel.Tag);
		}
	}
}
