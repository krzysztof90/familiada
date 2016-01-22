using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace familiada
{
	class Odpowiedź
	{
		public string odpowiedź;
		public int punkty;
		public int nrOdpowiedzi;
		CheckBox checkBox = new CheckBox();
		Panel naGłównym = new Panel();
		Panel naPomocnicznym = new Panel();

		Label nrOdpowiedziLabel = new Label();
		Label odpowiedźLabel = new Label();

		public Odpowiedź(string linia, int nrOdpowiedzi, NotForShow notForShow, ForShow forShow)
		{
			this.nrOdpowiedzi = nrOdpowiedzi;
			int gdziePrzerwa = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (gdziePrzerwa == -1)
				Functions.exit(String.Format("niepoprawna linia: {0}", linia));
			odpowiedź = linia.Substring(0, gdziePrzerwa).TrimEnd();
			try
			{
				punkty = Int32.Parse(linia.Substring(gdziePrzerwa + 1));
			}
			catch (FormatException)
			{
				Functions.exit("niepoprawna liczba punktów");
			}

			naPomocnicznym.Location = new Point(100, nrOdpowiedzi * 30);
			naPomocnicznym.Size = new System.Drawing.Size(200, 30);
			naPomocnicznym.Hide();
			notForShow.Controls.Add(naPomocnicznym);

			checkBox.Location = new Point(0,0);
			checkBox.Text = odpowiedź;
			checkBox.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
			naPomocnicznym.Controls.Add(checkBox);

			naGłównym.Location = new Point(100, nrOdpowiedzi * 30);
			naGłównym.Size = new System.Drawing.Size(200, 30);
			naGłównym.Hide();
			forShow.Controls.Add(naGłównym);

			nrOdpowiedziLabel.AutoSize = true;
			nrOdpowiedziLabel.Location = new Point(0, 0);
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
			naGłównym.Controls.Add(nrOdpowiedziLabel);

			odpowiedźLabel.Location = new Point(30, 0);
			odpowiedźLabel.Text = odpowiedź;
			odpowiedźLabel.Hide();
			naGłównym.Controls.Add(odpowiedźLabel);
		}

		public void zainicjujKontrolkiOdpowiedzi()
		{
			naPomocnicznym.Show();
			naGłównym.Show();
		}
		public void ukryjKontrolkiOdpowiedzi()
		{
			naPomocnicznym.Hide();
			checkBox.Checked = false;
			naGłównym.Hide();
		}
		public void pokażOdpowiedź()
		{
			odpowiedźLabel.Show();
		}
		public void ukryjOdpowiedź()
		{
			odpowiedźLabel.Hide();
		}
		public void usuńOdpowiedź()
		{
			checkBox.Dispose();
			nrOdpowiedziLabel.Dispose();
			odpowiedźLabel.Dispose();
		}
		public bool zaznaczona()
		{
			return checkBox.Checked;
		}

		private void checkBoxCheckedChanged(object sender, EventArgs e)
		{
			if (zaznaczona())
			{
				pokażOdpowiedź();
			}
			else
			{
				ukryjOdpowiedź();
			}
		}
	}
}