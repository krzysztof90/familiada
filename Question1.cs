using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace familiada
{
	class Question1NumberAndName
	{
		public int number { get; private set; }
		public string name { get; private set; }

		public Question1NumberAndName(int number, string name)
		{
			this.number = number;
			this.name = name;
		}
	}

	abstract class Zonk
	{
		private const int zonkButtonYStart = 50;
		private const int zonkButtonYSpace = 0;
		private const int zonkButtonWidth = 25;
		private const int zonkButtonHeight = 45;
		public abstract int position { get; }

		readonly Button[] zonkButton = new Button[4];

		public Zonk()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i] = new Button();
				zonkButton[i].Click += new EventHandler(Mark);
				zonkButton[i].Location = new Point(position, zonkButtonYStart + i * (zonkButtonYSpace + zonkButtonHeight));
				zonkButton[i].Size = new Size(zonkButtonWidth, zonkButtonHeight);
				zonkButton[i].Tag = i;
				zonkButton[i].Text = "zonk " + (i + 1).ToString();
				zonkButton[i].Visible = false;

				Global.panelController1.Controls.Add(zonkButton[i]);
			}
			zonkButton[3].Text = "boom";
		}

		private void Mark(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int tag = (int)(button.Tag);

			Global.SwitchButtonSelection(button);
			if (Global.ButtonSelected(button))
				ShowZonk(tag);
			else
				HideZonk(tag);
		}
		public void Show()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Show();
				if (Global.ButtonSelected(zonkButton[i]))
					ShowZonk(i);
			}
		}
		public void Hide()
		{
			for (int i = 0; i < 4; i++)
			{
				zonkButton[i].Hide();
				HideZonk(i);
			}
		}

		private void ShowZonk(int which)
		{
			if (which == 3)
			{
				Global.table1.SetText("˹ ˺", position, 3, true, 3, ' ');
				Global.table1.SetText("˼ ˻", position, 4, true, 3, ' ');
				Global.table1.SetText(" | ", position, 5, true, 3, ' ');
				Global.table1.SetText("˺ ˹", position, 6, true, 3, ' ');
				Global.table1.SetText("˻ ˼", position, 7, true, 3, ' ');
			}
			else
			{
				Global.table1.SetText("┘ˍ└", position, 1 + 3 * which, true, 3, ' ');
				Global.table1.SetText(" | ", position, 2 + 3 * which, true, 3, ' ');
				Global.table1.SetText("┐ˉ┌", position, 3 + 3 * which, true, 3, ' ');
			}
		}
		private void HideZonk(int which)
		{
			if (which == 3)
				for (int row = 3; row <= 7; row++)
					Global.table1.SetText(String.Empty, position, row, true, 3, ' ');
			else
				for (int row = 1 + 3 * which; row <= 3 + 3 * which; row++)
					Global.table1.SetText(String.Empty, position, row, true, 3, ' ');
		}
	}

	class ZonkLeft : Zonk
	{
		public override int position
		{
			get { return 0; }
		}
	}
	class ZonkRight : Zonk
	{
		public override int position
		{
			get { return 27; }
		}
	}

	class Question1
	{
		public const int questionNameLabelXLocation = 100;
		public const int questionNameLabelYLocation = 0;
		public const int questionNameLabelWidth = 150;
		public const int questionNameLabelHeight = 15;
		public const int addAnswerButtonXLocation = 450;
		public const int addAnswerButtonYLocation = 100;
		public const int addAnswerButtonWidth = 135;
		public const int addAnswerButtonHeight = 25;
		private const int assignButtonXLocation = 450;
		private const int assignButtonYStart = 140;
		private const int assignButtonYSpace = 5;
		private const int assignButtonWidth = 135;
		private const int assignButtonHeight = 25;

		public static int currentQuestionNumber { get; set; }
		private static Question1 currentQuestion
		{
			get
			{
				return Global.questions1[currentQuestionNumber];
			}
		}
		public static Button addAnswerButton { get; private set; }
		readonly List<Button> assignButton = new List<Button> { new Button(), new Button() };

		readonly int number;
		public string name { get; set; }
		private int points = 0;
		public Team assignedTeam { get; set; }

		readonly Label questionNameLabel;

		readonly List<Zonk> zonks = new List<Zonk> { new ZonkLeft(), new ZonkRight() };

		public List<Answer1> answers { get; private set; }

		static Question1()
		{
			addAnswerButton = new Button();
			currentQuestionNumber = -1;

			addAnswerButton.Click += new EventHandler(AddAnswer_Click);
			addAnswerButton.Location = new Point(addAnswerButtonXLocation, addAnswerButtonYLocation);
			addAnswerButton.Size = new Size(addAnswerButtonWidth, addAnswerButtonHeight);
			addAnswerButton.Text = "dodaj odpowiedź";
			addAnswerButton.Visible = false;

			Global.panelController1.Controls.Add(addAnswerButton);
		}

		public Question1(Question1NumberAndName question)
		{
			assignedTeam = null;
			answers = new List<Answer1>();

			number = question.number;
			name = question.name;

			questionNameLabel = new Label();
			questionNameLabel.Location = new Point(questionNameLabelXLocation, questionNameLabelYLocation);
			questionNameLabel.Size = new Size(questionNameLabelWidth, questionNameLabelHeight);
			questionNameLabel.Text = number.ToString() + ". " + name;
			questionNameLabel.Hide();

			for (int i = 0; i < 2; i++)
			{
				assignButton[i].Size = new Size(assignButtonWidth, assignButtonHeight);
				assignButton[i].Visible = false;
				assignButton[i].Click += new EventHandler(Assign_Click);
				assignButton[i].Location = new Point(assignButtonXLocation, assignButtonYStart + i * (assignButtonHeight + assignButtonYSpace));
				assignButton[i].Tag = i;
				assignButton[i].Text = "przypisz punkty " + (i == 0 ? "lewej" : "prawej");
				Global.panelController1.Controls.Add(assignButton[i]);
			}

			Global.panelController1.Controls.Add(questionNameLabel);
		}

		private void InitializeControls()
		{
			questionNameLabel.Show();
			SetPoints();
			zonks.ForEach(z => z.Show());
			answers.ForEach(o => o.ShowAnswersControls());
			assignButton.ForEach(b => b.Show());
		}
		private void AddAndShowAnswer(string line)
		{
			AddAnswer(line);
			InitializeControls();
		}
		public void AddAnswer(string line)
		{
			answers.Add(new Answer1(line, this));
		}
		private void HideAnswers()
		{
			questionNameLabel.Hide();
			Global.SetMainPoints(0);
			zonks.ForEach(z => z.Hide());
			answers.ForEach(o => o.HideAnswersControls());
			assignButton.ForEach(b => b.Hide());
		}
		public void ReplaceAnswers(int firstAnswerNumber)
		{
			answers[firstAnswerNumber - 1].Move(firstAnswerNumber + 1, true);
			answers[firstAnswerNumber].Move(firstAnswerNumber, false);

			Answer1 firstAnswer = answers[firstAnswerNumber - 1];
			answers[firstAnswerNumber - 1] = answers[firstAnswerNumber];
			answers[firstAnswerNumber] = firstAnswer;
		}
		public void DeleteAnswer(int which)
		{
			Answer1 answer = answers[which - 1];
			answer.HideAnswersControls();
			for (int i = which; i < answers.Count; i++)
				answers[i].Move(i, true);

			answers.RemoveAt(which - 1);
		}

		public void AddPoints(int added)
		{
			points += added;
			SetPoints();
		}
		private void SetPoints()
		{
			Global.SetMainPoints(points);
		}

		public static void Show()
		{
			if (currentQuestionNumber != -1)
				currentQuestion.InitializeControls();
		}
		public static void Hide()
		{
			if (currentQuestionNumber != -1)
				currentQuestion.HideAnswers();
		}
		public static bool LastQuestion()
		{
			return currentQuestionNumber == Global.questions1.Count - 1;
		}
		public static void ShowButtons()
		{
			addAnswerButton.Visible = (currentQuestion.answers.Count != Global.countAnswer1);
		}

		private static void AddAnswer_Click(object sender, EventArgs e)
		{
			currentQuestion.AddAndShowAnswer(" 0");
			if (currentQuestion.answers.Count == Global.countAnswer1)
				addAnswerButton.Hide();
		}
		private void Assign_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int tag = (int)(button.Tag);
			if (Global.ButtonSelected(button))
			{
				Global.UnmarkButtonSelection(button);
				currentQuestion.assignedTeam = null;

				Global.teams[tag].AddPoints(-currentQuestion.points);
			}
			else
			{
				if (!Global.ButtonSelected(assignButton[tag == 0 ? 1 : 0])) //opposed
				{
					Global.MarkButtonSelection(button);
					currentQuestion.assignedTeam = Global.teams[tag];

					Global.teams[tag].AddPoints(currentQuestion.points);
				}
			}
		}
	}
}
