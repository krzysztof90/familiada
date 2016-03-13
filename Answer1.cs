using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace familiada
{
	class Answer1
	{
		private const int panelHeight = 30;
		private const int answerButtonAndPointsButtonXSpace = 20;
		private const int answerButtonWidth = 150;
		private const int operationsButtonsXSpace = 0;
		private const int operationsButtonsWidth = 30;

		private const int tableSpaceBetweenAnswerNumberAndAnswer = 1;
		private const int tableAnswerNumberXLocation = 3;
		private const int tableAnswerXLocation = tableAnswerNumberXLocation + 1 + tableSpaceBetweenAnswerNumberAndAnswer;
		private const int tablePointsXLocation = tableAnswerXLocation + 1 + Global.lengthAnswer1;
		public const int tablePointsYStart = 2;

		private string answer;
		private int points;
		private int number;
		readonly Question1 question;

		readonly Panel panel = new Panel();

		readonly Button answerButton = new Button();
		readonly Button pointsButton = new Button();
		readonly Button answerEditionButton = new Button();
		readonly TextBox answerEditionTextBox = new TextBox();
		readonly TextBox pointsEditionTextBox = new TextBox();
		readonly Button up = new Button();
		readonly Button down = new Button();
		readonly Button deleteButton = new Button();

		public Answer1(string line, Question1 question)
		{
			this.question = question;

			number = question.answers.Count + 1;
			if (number > Global.countAnswer1)
				throw new ArgumentException(question.name);

			int spacePosition = line.LastIndexOfAny(new char[] { ' ', '\t' });
			if (spacePosition == -1)
				Global.Exit(String.Format("niepoprawna linia: {0}", line));
			answer = line.Substring(0, spacePosition).TrimEnd();
			if (answer.Length > Global.lengthAnswer1)
				Global.Exit(String.Format("za długa answer: {0}. Dopuszczalna width to {1}", answer, Global.lengthAnswer1));
			string answerUpper = answer.ToUpper(CultureInfo.CurrentUICulture);
			for (int i = 0; i < answer.Length; i++)
				if (!Global.characters.ContainsKey(answerUpper[i]))
					Global.Exit(String.Format("niepoprawny znak '{0}' w {1}", answer[i], answer));
			try
			{
				points = Int32.Parse(line.Substring(spacePosition + 1));
			}
			catch (FormatException)
			{
				Global.Exit(String.Format("niepoprawna liczba punktów w {0}", line));
			}

			panel.Hide();

			answerButton.Location = new Point(0, 0);
			answerButton.Size = new Size(answerButtonWidth, panelHeight);
			answerButton.Text = answer;
			answerButton.Click += new EventHandler(MarkUnmark_Click);

			pointsButton.Location = new Point(answerButton.Right + answerButtonAndPointsButtonXSpace, 0);
			pointsButton.Size = new Size(operationsButtonsWidth, panelHeight);
			pointsButton.Text = points.ToString();
			pointsButton.Click += new EventHandler(EditPoints_Click);

			answerEditionButton.Location = new Point(pointsButton.Right + operationsButtonsXSpace, 0);
			answerEditionButton.Size = new Size(operationsButtonsWidth, panelHeight);
			answerEditionButton.Text = "edytuj";
			answerEditionButton.Click += new EventHandler(AnswerEdit_Click);

			answerEditionTextBox.AutoSize = false;
			answerEditionTextBox.Location = answerButton.Location;
			answerEditionTextBox.Size = answerButton.Size;
			answerEditionTextBox.Text = answer;
			answerEditionTextBox.Hide();
			answerEditionTextBox.Leave += new EventHandler(AnswerEditor_Leave);
			answerEditionTextBox.KeyPress += new KeyPressEventHandler(AnswerEditor_KeyPress);
			answerEditionTextBox.Tag = new EventHandler(AnswerEditor_Leave);

			pointsEditionTextBox.AutoSize = false;
			pointsEditionTextBox.Location = pointsButton.Location;
			pointsEditionTextBox.Size = pointsButton.Size;
			pointsEditionTextBox.Text = points.ToString();
			pointsEditionTextBox.Hide();
			pointsEditionTextBox.Leave += new EventHandler(PointsEditor_Leave);
			pointsEditionTextBox.KeyPress += new KeyPressEventHandler(AnswerEditor_KeyPress);
			pointsEditionTextBox.Tag = new EventHandler(PointsEditor_Leave);

			up.Location = new Point(answerEditionButton.Right + operationsButtonsXSpace, 0);
			up.Size = new Size(operationsButtonsWidth, panelHeight / 2);
			up.Text = "góra";
			up.Click += new EventHandler(Up_Click);

			down.Location = new Point(answerEditionButton.Right + operationsButtonsXSpace, panelHeight / 2);
			down.Size = up.Size;
			down.Text = "dół";
			down.Click += new EventHandler(Down_Click);

			deleteButton.Location = new Point(up.Right + operationsButtonsXSpace, 0);
			deleteButton.Size = new Size(operationsButtonsWidth, 30);
			deleteButton.Text = "usuń";
			deleteButton.Click += new EventHandler(Delete_Click);

			panel.Size = new System.Drawing.Size(deleteButton.Right, panelHeight);

			panel.Controls.Add(answerButton);
			panel.Controls.Add(pointsButton);
			panel.Controls.Add(answerEditionButton);
			panel.Controls.Add(answerEditionTextBox);
			panel.Controls.Add(pointsEditionTextBox);
			panel.Controls.Add(up);
			panel.Controls.Add(down);
			panel.Controls.Add(deleteButton);

			Global.panelController1.Controls.Add(panel);
		}

		public void ShowAnswersControls()
		{
			panel.Location = new Point(100, number * 30 + 30);
			panel.Show();

			PrintAnswerNumber(true, ' ');
			if (Selected())
				Show();
			else
				Hide();
		}
		public void HideAnswersControls()
		{
			panel.Hide();
			PrintAnswerNumber(false, ' ');
			Print(false, ' ');
			PrintPoints(false, ' ');
		}
		private void Show()
		{
			Print(true, '.');
			PrintPoints(true, ' ');
		}
		private void Hide()
		{
			Print(false, '.');
			PrintPoints(false, '|');
		}
		public void Move(int number, bool delete)
		{
			if (delete)
				HideAnswersControls();
			this.number = number;
			ShowAnswersControls();
		}
		private bool Selected()
		{
			return Global.ButtonSelected(answerButton);
		}

		private void MarkUnmark_Click(object sender, EventArgs e)
		{
			Global.SwitchButtonSelection(answerButton);
			if (Selected())
			{
				Show();

				if (question.assignedTeam == null)
					question.AddPoints(points);
			}
			else
			{
				Hide();

				if (question.assignedTeam == null)
					question.AddPoints(-points);
			}
		}
		private void AnswerEdit_Click(object sender, EventArgs e)
		{
			answerEditionTextBox.Show();
			answerEditionTextBox.BringToFront();
			answerEditionTextBox.Focus();
		}
		private void EditPoints_Click(object sender, EventArgs e)
		{
			pointsEditionTextBox.Show();
			pointsEditionTextBox.BringToFront();
			pointsEditionTextBox.Focus();
		}
		private void AnswerEditor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				((EventHandler)(((TextBox)sender).Tag))(sender, new EventArgs());
		}
		private void AnswerEditor_Leave(object sender, EventArgs e)
		{
			answer = answerEditionTextBox.Text.ToUpper();
			answerButton.Text = answerEditionTextBox.Text;

			if (answer.Length > Global.lengthAnswer1)
			{
				MessageBox.Show(String.Format("Tekst za długi o {0} znaków", answer.Length - Global.lengthAnswer1));
				answerEditionTextBox.Focus();
			}
			else
			{
				for (int i = 0; i < answer.Length; i++)
					if (!Global.characters.ContainsKey(answer[i]))
					{
						MessageBox.Show(String.Format("niepoprawny znak {0}", answerEditionTextBox.Text[i]));
						answerEditionTextBox.Focus();
						return;
					}
				if (Selected())
					Print(true, '.');
				answerEditionTextBox.Hide();
				answerButton.Focus();
			}
		}
		private void PointsEditor_Leave(object sender, EventArgs e)
		{
			try
			{
				points = Int32.Parse(pointsEditionTextBox.Text);
				pointsEditionTextBox.Hide();
				pointsButton.Text = points.ToString();
				if (Selected())
					PrintPoints(true, ' ');
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				pointsEditionTextBox.Focus();
				pointsEditionTextBox.SelectAll();
			}
		}
		private void Up_Click(object sender, EventArgs e)
		{
			if (number != 1)
				question.ReplaceAnswers(number - 1);
		}
		private void Down_Click(object sender, EventArgs e)
		{
			if (number != question.answers.Count)
				question.ReplaceAnswers(number);
		}
		private void Delete_Click(object sender, EventArgs e)
		{
			question.DeleteAnswer(number);
			if (question.answers.Count != Global.countAnswer1)
				Question1.addAnswerButton.Show();
		}

		private void PrintAnswerNumber(bool notEmpty, char fill)
		{
			Global.table1.SetText(notEmpty ? number.ToString() : String.Empty, tableAnswerNumberXLocation, tablePointsYStart - 1 + number, false, 1, fill);
		}
		private void Print(bool notEmpty, char fill)
		{
			Global.table1.SetText(notEmpty ? answer : String.Empty, tableAnswerXLocation, tablePointsYStart - 1 + number, true, Global.lengthAnswer1, fill);
		}
		private void PrintPoints(bool notEmpty, char fill)
		{
			Global.table1.SetText(notEmpty ? points.ToString() : String.Empty, tablePointsXLocation, tablePointsYStart - 1 + number, false, 2, fill);
		}
	}
}