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
		CheckBox checkBox;
		Label nrOdpowiedziLabel;
		Label odpowiedźLabel;

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

			checkBox = new CheckBox();
			checkBox.Location = new Point(100, nrOdpowiedzi * 30);
			//checkBox.Size = new Size(80, 17);
			checkBox.Text = odpowiedź;
			checkBox.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
			checkBox.Hide();
			notForShow.Controls.Add(checkBox);

			nrOdpowiedziLabel = new Label();
			nrOdpowiedziLabel.AutoSize = true;
			nrOdpowiedziLabel.Location = new Point(100, nrOdpowiedzi * 30);
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
			nrOdpowiedziLabel.Hide();
			forShow.Controls.Add(nrOdpowiedziLabel);

			odpowiedźLabel = new Label();
			odpowiedźLabel.Location = new Point(120, nrOdpowiedzi * 30);
			odpowiedźLabel.Text = odpowiedź;
			odpowiedźLabel.Hide();
			forShow.Controls.Add(odpowiedźLabel);
		}

		public void zainicjujKontrolkiOdpowiedzi()
		{
			checkBox.Show();
			nrOdpowiedziLabel.Show();
		}
		public void ukryjKontrolkiOdpowiedzi()
		{
			checkBox.Hide();
			checkBox.Checked = false;
			nrOdpowiedziLabel.Hide();
			ukryjOdpowiedź();
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