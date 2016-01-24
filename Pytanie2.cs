using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	class Pytanie2
	{
		string nazwaPytania;

		Panel naKontrolerze = new Panel();
		Panel naGłównym= new Panel();

		Label nazwaLabel= new Label();
		TextBox odpowiedźLTextBox= new TextBox();
		TextBox odpowiedźPTextBox= new TextBox();
		TextBox punktyLTextBox= new TextBox();
		TextBox punktyPTextBox = new TextBox();

		Label odpowiedźLLabel= new Label();
		Label odpowiedźPLabel = new Label();
		Label punktyLLabel = new Label();
		Label punktyPLabel = new Label();

		public Pytanie2(string nazwa, int nrPytania)
		{
			nazwaPytania = nazwa;

			naKontrolerze.Location = new System.Drawing.Point(100, 50 * nrPytania);
			naKontrolerze.Size = new System.Drawing.Size(420, 30);
			naKontrolerze.Controls.Add(this.nazwaLabel);
			naKontrolerze.Controls.Add(this.odpowiedźLTextBox);
			naKontrolerze.Controls.Add(this.odpowiedźPTextBox);
			naKontrolerze.Controls.Add(this.punktyLTextBox);
			naKontrolerze.Controls.Add(this.punktyPTextBox);
			Global.kontroler.Controls.Add(naKontrolerze);

			nazwaLabel.Location = new System.Drawing.Point(5, 8);
			nazwaLabel.Size = new System.Drawing.Size(145, 13);
			nazwaLabel.Text = nazwaPytania;

			odpowiedźLTextBox.Location = new System.Drawing.Point(150, 5);
			odpowiedźLTextBox.Size = new System.Drawing.Size(100, 20);

			odpowiedźPTextBox.Location = new System.Drawing.Point(310, 5);
			odpowiedźPTextBox.Size = new System.Drawing.Size(100, 20);

			punktyLTextBox.Location = new System.Drawing.Point(250, 5);
			punktyLTextBox.Size = new System.Drawing.Size(30, 20);

			punktyPTextBox.Location = new System.Drawing.Point(280, 5);
			punktyPTextBox.Size = new System.Drawing.Size(30, 20);


			naGłównym.Location = new System.Drawing.Point(30, 50 * nrPytania);
			naGłównym.Size = new System.Drawing.Size(420, 30);
			naGłównym.Controls.Add(this.odpowiedźLLabel);
			naGłównym.Controls.Add(this.odpowiedźPLabel);
			naGłównym.Controls.Add(this.punktyLLabel);
			naGłównym.Controls.Add(this.punktyPLabel);
			Global.główny.Controls.Add(naGłównym);

			odpowiedźLLabel.Location = new System.Drawing.Point(150, 5);
			odpowiedźLLabel.Size = new System.Drawing.Size(100, 20);

			odpowiedźPLabel.Location = new System.Drawing.Point(310, 5);
			odpowiedźPLabel.Size = new System.Drawing.Size(100, 20);

			punktyLLabel.Location = new System.Drawing.Point(250, 5);
			punktyLLabel.Size = new System.Drawing.Size(30, 20);

			punktyPLabel.Location = new System.Drawing.Point(280, 5);
			punktyPLabel.Size = new System.Drawing.Size(30, 20);

			ukryjPytanie();
		}

		public void pokażPytanie()
		{
			naKontrolerze.Show();
		}
		public void ukryjPytanie()
		{
			naKontrolerze.Hide();
			naGłównym.Hide();
		}
	}
}
