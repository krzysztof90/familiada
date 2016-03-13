using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace familiada
{
	class Table
	{
		public const int width = 30;
		public const int height = 10;

		readonly int columnCount;
		readonly int rowCount;

		readonly TableLayoutPanel panel = new TableLayoutPanel();
		readonly PictureBox[,] characters;

		public Table(Panel parent, int columnCount, int rowCount, Image background)
		{
			this.columnCount = columnCount;
			this.rowCount = rowCount;

			panel.ColumnCount = columnCount * 2 + 1;
			panel.RowCount = rowCount * 2 + 1;

			characters = new PictureBox[columnCount, rowCount];
			for (int column = 0; column < columnCount; column++)
				for (int row = 0; row < rowCount; row++)
				{
					characters[column, row] = new PictureBox();
					PictureBox chracter = characters[column, row];
					chracter.Dock = DockStyle.Fill;
					chracter.SizeMode = PictureBoxSizeMode.StretchImage;
					chracter.Margin = new Padding(0);
					chracter.Image = Global.characters[' '];
					panel.Controls.Add(chracter, column * 2 + 1, row * 2 + 1);
				}

			Single characterWidth = 1F * 5;
			Single characterHeight = 1F * 7;

			for (int i = 0; i < columnCount; i++)
			{
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, characterWidth));
			}
			panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
			for (int i = 0; i < rowCount; i++)
			{
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
				panel.RowStyles.Add(new RowStyle(SizeType.Percent, characterHeight));
			}
			panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));

			panel.Dock = DockStyle.Fill;
			panel.BackgroundImage = background;
			panel.BackgroundImageLayout = ImageLayout.Stretch;
			panel.Margin = new Padding(0);

			parent.Controls.Add(panel);
		}

		/// <summary>
		/// dla za długiego tekstu przy wyrównaniu do lewej urywa z prawej, przy wyrówaniu do prawej urywa z lewej
		/// </summary>
		public void SetText(string text, int startColumn, int row, bool leftAllign, int capacity, char fill)
		{
			string textUpper = text.ToUpper(CultureInfo.CurrentUICulture);
			int textLength = textUpper.Length;
			if (leftAllign)
			{
				for (int i = 0; i < textLength && i < capacity; i++)
					characters[startColumn + i, row].Image = Global.characters[textUpper[i]];
				for (int i = 0; i < capacity - textLength; i++)
					characters[startColumn + textLength + i, row].Image = Global.characters[fill];
			}
			else
			{
				for (int i = (textLength > capacity ? textLength - capacity : 0); i < textLength; i++)
					characters[startColumn + capacity - textLength + i, row].Image = Global.characters[textUpper[i]];
				for (int i = 0; i < capacity - textLength; i++)
					characters[startColumn + i, row].Image = Global.characters[fill];
			}
		}
		private void Insert(char character, int column, int row)
		{
			characters[column, row].Image = Global.characters[character];
		}
		public void Delete()
		{
			panel.Dispose();
			foreach(PictureBox character in characters)
				character.Dispose();
		}
	}
}
