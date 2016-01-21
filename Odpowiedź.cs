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

		public Odpowiedź(string linia, int nrOdpowiedzi)
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
		}

		public void dodajCheckBox(NotForShow form)
		{
			checkBox = new CheckBox();
			//checkBox.AutoSize = true;
			checkBox.Location = new Point(100, nrOdpowiedzi * 30);
			//checkBox.Size = new Size(80, 17);
			checkBox.Text = odpowiedź;
			checkBox.CheckedChanged += new EventHandler(checkBoxCheckedChanged);

			form.Controls.Add(checkBox);
		}
		public void usuńCheckBox()
		{
			checkBox.Dispose();
		}
		public void pokażNrPytania(ForShow form)
		{
			nrOdpowiedziLabel = new Label();
			nrOdpowiedziLabel.AutoSize = true;
			nrOdpowiedziLabel.Location = new Point(100, nrOdpowiedzi * 30);
			//nrOdpowiedziLabel.Size = new Size(10, 17);
			nrOdpowiedziLabel.Text = nrOdpowiedzi.ToString();
			form.Controls.Add(nrOdpowiedziLabel);

			// tylko utworzenie
			odpowiedźLabel = new Label();
			//checkBox.AutoSize = true;
			odpowiedźLabel.Location = new Point(120, nrOdpowiedzi * 30);
			//checkBox.Size = new Size(80, 17);
			odpowiedźLabel.Text = odpowiedź;
			odpowiedźLabel.Hide();
			form.Controls.Add(odpowiedźLabel);
		}
		public bool zaznaczona()
		{
			return checkBox.Checked;
		}

		private void checkBoxCheckedChanged(object sender, EventArgs e)
		{
			if (checkBox.Checked)
			{
				odpowiedźLabel.Show();
			}
			else
			{
				odpowiedźLabel.Hide();
			}
		}
	}
}