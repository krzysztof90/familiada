using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace familiada
{
	class Answer2
	{
		public string answer { get; private set; }
		public string pointsLeft { get; private set; }
		public string pointsRight { get; private set; }

		public Answer2(string answer, string pointsLeft, string pointsRight)
		{
			this.answer = answer;
			this.pointsLeft = pointsLeft;
			this.pointsRight = pointsRight;
		}
	}

	abstract class QuestionSide
	{
		public const int controlXSpace = 0;
		public const int answerTextBoxWidth = 100;
		private const int answerTextBoxHeight = 20;
		public const int pointsTextBoxWidth = 30;
		private const int pointsTextBoxHeight = 20;
		public const int placeButtonWidth = 30;
		private const int placeButtonHeight = 30;
		public const int tableXSpace = (Table.width / 2 - Global.lengthAnswer2 - 2) / 3; //2 - mainPoints width; 3 - 3 spaces
		private const int tableYStart = 1;

		private static int mainPoints;
		readonly int number;
		private int questionPoints = 0;

		public TextBox answerTextBox { get; private set; }
		public TextBox pointsTextBox { get; private set; }
		readonly Button placeButton = new Button();

		protected abstract int tag { get; }

		protected abstract int answerTextBoxXLocation { get; }
		protected abstract int answerTextBoxTabIndex { get; }
		protected abstract int pointsTextBoxXLocation { get; }
		protected abstract int pointsTextBoxTabIndex { get; }
		protected abstract int placeButtonXLocation { get; }

		protected abstract int answerPositionTable { get; }
		protected abstract int pointsPositionTable { get; }
		protected abstract bool leftAllign { get; }

		public QuestionSide(int number)
		{
			answerTextBox = new TextBox();
			pointsTextBox = new TextBox();

			this.number = number;

			answerTextBox.Location = new Point(answerTextBoxXLocation, (Question2.panelHeight - answerTextBoxHeight) / 2);
			answerTextBox.Size = new Size(answerTextBoxWidth, answerTextBoxHeight);
			answerTextBox.Leave += new EventHandler(AnswerEditor_Leave);
			answerTextBox.KeyDown += new KeyEventHandler(AnswerEditor_KeyDown);
			answerTextBox.TabIndex = answerTextBoxTabIndex;

			pointsTextBox.Location = new Point(pointsTextBoxXLocation, (Question2.panelHeight - pointsTextBoxHeight) / 2);
			pointsTextBox.Size = new Size(pointsTextBoxWidth, pointsTextBoxHeight);
			pointsTextBox.Text = "0";
			pointsTextBox.Leave += new EventHandler(PointsEditor_Leave);
			pointsTextBox.KeyDown += new KeyEventHandler(PointsEditor_KeyDown);
			pointsTextBox.TabIndex = pointsTextBoxTabIndex;

			placeButton.Location = new Point(placeButtonXLocation, (Question2.panelHeight - placeButtonHeight) / 2);
			placeButton.Size = new Size(placeButtonWidth, placeButtonHeight);
			placeButton.Text = "umieść";
			placeButton.Click += new EventHandler(ShowHide_Click);
			placeButton.TabStop = false;

			HideAnswer();
		}

		private static void AddPoints(int added)
		{
			mainPoints += added;
			PrintPoints();
		}
		public static void PrintPoints()
		{
			Global.SetMainPoints(mainPoints);
		}
		public void Place(Panel panel)
		{
			panel.Controls.Add(answerTextBox);
			panel.Controls.Add(pointsTextBox);
			panel.Controls.Add(placeButton);
		}
		public bool Selected()
		{
			return Global.ButtonSelected(placeButton);
		}

		private void AnswerEditor_Leave(object sender, EventArgs e)
		{
			string answer = answerTextBox.Text.ToUpper();

			if (answer.Length > Global.lengthAnswer2)
			{
				MessageBox.Show(String.Format("Tekst za długi o {0} znaków", answer.Length - Global.lengthAnswer2));
				answerTextBox.Focus();
				return;
			}
			for (int i = 0; i < answer.Length; i++)
				if (!Global.characters.ContainsKey(answer[i]))
				{
					MessageBox.Show(String.Format("niepoprawny znak {0}", answerTextBox.Text[i]));
					answerTextBox.Focus();
					return;
				}

			if (Selected())
				ShowAnswer();
		}
		private void PointsEditor_Leave(object sender, EventArgs e)
		{
			TextBox textbox = ((TextBox)sender);
			try
			{
				int newPoints = Int32.Parse(textbox.Text);
				if (Selected())
				{
					AddPoints(-questionPoints);
					AddPoints(newPoints);
					PrintPoints();
				}
				questionPoints = newPoints;
			}
			catch (FormatException)
			{
				MessageBox.Show("wpisz liczbę");
				textbox.Focus();
				textbox.SelectAll();
			}
		}
		private void AnswerEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down && number != 5)
				Global.questions2[number].questionsSide[tag].answerTextBox.Focus();
		}
		private void PointsEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down && number != 5)
				Global.questions2[number].questionsSide[tag].pointsTextBox.Focus();
		}
		public void ShowHide_Click(object sender, EventArgs e)
		{
			if (Selected())
			{
				Global.UnmarkButtonSelection(placeButton);

				HideAnswer();
				AddPoints(-Int32.Parse(pointsTextBox.Text));
			}
			else
			{
				if (!Global.ButtonSelected(Global.controller.hideAnswersButton))
				{
					Global.MarkButtonSelection(placeButton);

					ShowAnswer();
					AddPoints(Int32.Parse(pointsTextBox.Text));
				}
			}
		}
		private void ShowAnswer()
		{
			Global.table2.SetText(answerTextBox.Text, answerPositionTable, tableYStart - 1 + number, leftAllign, Global.lengthAnswer2, ' ');
			Global.table2.SetText(pointsTextBox.Text, pointsPositionTable, tableYStart - 1 + number, false, 2, ' ');
		}
		private void HideAnswer()
		{
			Global.table2.SetText(String.Empty, answerPositionTable, tableYStart - 1 + number, leftAllign, Global.lengthAnswer2, '.');
			Global.table2.SetText(String.Empty, pointsPositionTable, tableYStart - 1 + number, false, 2, '|');
		}
	}

	class QuestionLeft : QuestionSide
	{
		protected override int tag { get { return 0; } }

		protected override int answerTextBoxXLocation { get { return Question2.nameLabelWidth; } }
		protected override int answerTextBoxTabIndex { get { return 1; } }
		protected override int pointsTextBoxXLocation { get { return answerTextBoxXLocation + answerTextBoxWidth + controlXSpace; } }
		protected override int pointsTextBoxTabIndex { get { return 2; } }
		protected override int placeButtonXLocation { get { return pointsTextBoxXLocation + pointsTextBoxWidth + controlXSpace; } }

		protected override int answerPositionTable { get { return tableXSpace; } }
		protected override int pointsPositionTable { get { return answerPositionTable + Global.lengthAnswer2 + tableXSpace; } }
		protected override bool leftAllign { get { return false; } }

		public QuestionLeft(int number) : base(number) { }
	}

	class QuestionRight : QuestionSide
	{
		protected override int tag { get { return 1; } }

		protected override int answerTextBoxXLocation { get { return pointsTextBoxXLocation + pointsTextBoxWidth + controlXSpace; } }
		protected override int answerTextBoxTabIndex { get { return 3; } }
		protected override int pointsTextBoxXLocation { get { return placeButtonXLocation + placeButtonWidth + controlXSpace; } }
		protected override int pointsTextBoxTabIndex { get { return 4; } }
		protected override int placeButtonXLocation { get { return Question2.nameLabelWidth + answerTextBoxWidth + placeButtonWidth + pointsTextBoxWidth + controlXSpace * 3; } }

		protected override int answerPositionTable { get { return pointsPositionTable + 2 + tableXSpace; } }
		protected override int pointsPositionTable { get { return Table.width / 2 + tableXSpace; } }
		protected override bool leftAllign { get { return true; } }

		public QuestionRight(int number) : base(number) { }
	}

	class Question2
	{
		public const int nameLabelWidth = 200;
		public const int nameLabelHeight = 14;
		private const int panelXLocation = 50;
		private const int panelYStart = 50;
		private const int panelYSpace = 20;
		private const int panelWidth = nameLabelWidth + (QuestionSide.answerTextBoxWidth + QuestionSide.pointsTextBoxWidth + QuestionSide.placeButtonWidth) * 2 + QuestionSide.controlXSpace * 5;
		public const int panelHeight = 30;

		readonly string name;
		readonly int number;

		readonly Panel panel = new Panel();

		readonly Label nameLabel = new Label();
		public List<QuestionSide> questionsSide { get; private set; }

		public Question2(string name, int number)
		{
			this.name = name;
			this.number = number;
			questionsSide = new List<QuestionSide> { new QuestionLeft(number), new QuestionRight(number) };

			panel.Location = new Point(panelXLocation, panelYStart + (panelHeight + panelYSpace) * (number - 1));
			panel.Size = new Size(panelWidth, panelHeight);

			nameLabel.Location = new Point(0, (panelHeight - nameLabelHeight) / 2);
			nameLabel.Size = new Size(nameLabelWidth, nameLabelHeight);
			nameLabel.Text = name;

			panel.Controls.Add(nameLabel);
			questionsSide.ForEach(p => p.Place(panel));
			Global.panelController2.Controls.Add(panel);
		}

		public static void PrintPoints()
		{
			QuestionSide.PrintPoints();
		}
	}
}
