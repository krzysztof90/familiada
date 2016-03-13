using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familiada
{
	public partial class Controller : Form, IOperatable
	{
		private const int accessoryPanelXLocation = 0;
		private const int accessoryPanelYLocation = 320;
		private const int accessoryPanelWidth = 210;
		private const int dodatkowyPanelHeight = 135;
		private const int switchQuestionButtonXStart = 185;
		private const int switchQuestionButtonXSpace = 70;
		private const int switchQuestionButtonYLocation = 300;
		private const int switchQuestionButtonWidth = 115;
		private const int switchQuestionButtonHeight = 25;
		private const int showScreenButtonXLocation = 0;
		private const int showScreenButtonYLocation = 40;
		private const int showScreenButtonWidth = 115;
		private const int showScreenButtoeight = 25;
		private const int switchRoundButtonXLocation = 0;
		private const int switchRoundButtonYLocation = 70;
		private const int switchRoundButtonWidth = 115;
		private const int switchRoundButtonHeight = 25;
		private const int pointsLabelXLocation = 80;
		private const int pointsLabelYLocation = 8;
		private const int pointsLabelWidth = 25;
		private const int pointsLabelHeight = 15;
		private const int teamPointsLabelWidth = 25;
		private const int teamPointsLabelHeight = 15;
		private const int setTimeButtonXStart = 400;
		private const int setTimeButtonXSpace = 25;
		private const int setTimeButtonYLocation = 300;
		private const int setTimeButtonWidth = 75;
		private const int setTimeButtonHeight = 25;
		private const int timeLabelXLocation = 520;
		private const int timeLabelYLocation = 400;
		private const int timeLabelWidth = 20;
		private const int timeLabelHeight = 13;
		private const int timButtonXStart = 400;
		private const int timButtonXSpace = 25;
		private const int timButtonYLocation = 350;
		private const int timButtonWidth = 75;
		private const int timButtonHeight = 25;
		private const int hideAnswersButtonXLocation = 300;
		private const int hideAnswersButtonYLocation = 325;
		private const int hideAnswersButtonWidth = 75;
		private const int hideAnswersButtonHeight = 25;

		public Controller()
		{
			roundPanels = new List<Panel> { new Panel(), new Panel() };
			foreach (Panel p in roundPanels)
			{
				p.Dock = DockStyle.Fill;
				p.Margin = new Padding(0);
				p.Visible = false;
			}

			teamPointsLabel = new List<Label> { new Label(), new Label() };
			teamPointsLabel.ForEach(l => l.Size = new Size(teamPointsLabelWidth, teamPointsLabelHeight));
			teamPointsLabel[0].Dock = DockStyle.Left;
			teamPointsLabel[1].Dock = DockStyle.Right;

			setTimeButton = new List<Button> { new Button(), new Button(), new Button() };
			for (int i = 0; i < setTimeButton.Count; i++)
			{
				Button b = setTimeButton[i];
				roundPanels[1].Controls.Add(b);
				b.Location = new Point(setTimeButtonXStart + (setTimeButtonXSpace + setTimeButtonWidth) * i, setTimeButtonYLocation);
				if (i == 0)
					b.Tag = "15";
				else if (i == 1)
					b.Tag = "20";
				else
					b.Tag = "7";
				b.Text = "ustaw" + (string)(b.Tag);
				b.Size = new Size(setTimeButtonWidth, setTimeButtonHeight);
				b.Click += new EventHandler(SetTime_Click);
			}

			previousQuestion = new Button();
			previousQuestion.Location = new Point(switchQuestionButtonXStart, switchQuestionButtonYLocation);
			previousQuestion.Size = new Size(switchQuestionButtonWidth, switchQuestionButtonHeight);
			previousQuestion.Text = "poprzednie pytanie";
			previousQuestion.Visible = false;
			previousQuestion.Click += new EventHandler(PreviousQuestion_Click);

			nextQuestion = new Button();
			nextQuestion.Location = new Point(switchQuestionButtonXStart + switchQuestionButtonXSpace + switchQuestionButtonWidth, switchQuestionButtonYLocation);
			nextQuestion.Size = new Size(switchQuestionButtonWidth, switchQuestionButtonHeight);
			nextQuestion.Text = "zacznij pytania";
			nextQuestion.Click += new EventHandler(NextQuestion_Click);

			showMainScreenButton = new Button();
			showMainScreenButton.Location = new Point(showScreenButtonXLocation, showScreenButtonYLocation);
			showMainScreenButton.Size = new Size(showScreenButtonWidth, showScreenButtoeight);
			showMainScreenButton.Text = "otwórz ekran główny";
			showMainScreenButton.Click += new EventHandler(ShowScreen_Click);

			switchRoundButton = new Button();
			switchRoundButton.Location = new Point(switchRoundButtonXLocation, switchRoundButtonYLocation);
			switchRoundButton.Size = new Size(switchRoundButtonWidth, switchRoundButtonHeight);
			switchRoundButton.Tag = 1;
			switchRoundButton.Text = "przełącz do rundy 1";
			switchRoundButton.Click += new EventHandler(SwitchRound_Click);

			pointsLabel = new Label();
			pointsLabel.Location = new Point(pointsLabelXLocation, pointsLabelYLocation);
			pointsLabel.Size = new Size(pointsLabelWidth, pointsLabelHeight);
			pointsLabel.Text = "0";

			startButton = new Button();
			startButton.Location = new Point(timButtonXStart, timButtonYLocation);
			startButton.Size = new Size(timButtonWidth, timButtonHeight);
			startButton.Text = "start";
			startButton.Click += new EventHandler(StartTime_Click);

			stopButton = new Button();
			stopButton.Location = new Point(timButtonXStart + timButtonWidth + timButtonXSpace, timButtonYLocation);
			stopButton.Size = new Size(timButtonWidth, timButtonHeight);
			stopButton.Text = "pauza";
			stopButton.Click += new EventHandler(StopTime_Click);

			timeLabel = new Label();
			timeLabel.Location = new Point(timeLabelXLocation, timeLabelYLocation);
			timeLabel.Size = new Size(timeLabelWidth, timeLabelHeight);

			hideAnswersButton = new Button();
			hideAnswersButton.Location = new Point(hideAnswersButtonXLocation, hideAnswersButtonYLocation);
			hideAnswersButton.Size = new Size(hideAnswersButtonWidth, hideAnswersButtonHeight);
			hideAnswersButton.Text = "ukryj Odpowiedzi";
			hideAnswersButton.Click += new EventHandler(HideAnswers_Click);

			accessory = new Panel();
			accessory.BorderStyle = BorderStyle.FixedSingle;
			accessory.Controls.Add(pointsLabel);
			accessory.Controls.Add(switchRoundButton);
			accessory.Controls.Add(showMainScreenButton);
			accessory.Location = new Point(accessoryPanelXLocation, accessoryPanelYLocation);
			accessory.Size = new Size(accessoryPanelWidth, dodatkowyPanelHeight);

			InitializeComponent();

			roundPanels[0].Controls.Add(previousQuestion);
			roundPanels[0].Controls.Add(nextQuestion);
			roundPanels[1].Controls.Add(timeLabel);
			roundPanels[1].Controls.Add(startButton);
			roundPanels[1].Controls.Add(stopButton);
			roundPanels[1].Controls.Add(hideAnswersButton);
			teamPointsLabel.ForEach(l => accessory.Controls.Add(l));
			Controls.Add(accessory);
			roundPanels.ForEach(p => Controls.Add(p));
		}

		private void Form_Load(object sender, EventArgs e)
		{
			LoadFromFiles();
		}

		private void LoadFromFiles()
		{
			LoadFromFile1();
			LoadFromFile2();
		}

		private void LoadFromFile1()
		{
			try
			{
				StreamReader file = new StreamReader(Global.file1);
				while (!file.EndOfStream)
				{
					string line = file.ReadLine().Trim();
					if (line.Length != 0)
					{
						Question1NumberAndName header = Question1Header(line);
						if (header != null)
						{
							Global.questions1.Add(new Question1(header));
						}
						else
						{
							if (Global.questions1.Count == 0)
								Global.Exit("zacznij plik od numeru pytania");
							try
							{
								Global.questions1.Last().AddAnswer(line);
							}
							catch (ArgumentException exc)
							{
								Global.Exit(String.Format("za dużo answers w pytaniu: {0}", exc.Message));
							}
						}
					}
				}
				file.Close();
			}
			catch (FileNotFoundException exc)
			{
				Global.Exit(String.Format("brakuje pliku {0}", exc.FileName));
			}

			if (Global.questions1.Count == 0)
				Global.Exit("brak pytań");
		}

		private void LoadFromFile2()
		{
			string[] questions = new string[10];
			Answer2[] answers = new Answer2[10];

			if (File.Exists(Global.file2))
			{
				StreamReader file = new StreamReader(Global.file2);
				int lineNumber = 0;
				while (!file.EndOfStream && lineNumber < 10)
				{
					string linia = file.ReadLine().Trim();
					if (linia != String.Empty)
					{
						questions[lineNumber] = linia;
						answers[lineNumber] = Question2Answer(linia);
						lineNumber++;
					}
				}
				file.Close();

				answers[0] = null;
				int lastAnswer = 0;
				for (int i = 1; i < 10 && QuestionsCount(questions) > 5; i++)
					if (answers[i] != null)
					{
						questions[i] = null;
						lastAnswer = i;
						if (i != 9)
							answers[i + 1] = null;
					}
				for (int i = lastAnswer + 1; i < 10; i++)
					answers[i] = null;
			}

			int questionPosition = 0;
			for (int i = 0; i < 5; i++)
			{
				Global.questions2[i] = new Question2(questions[questionPosition], i + 1);
				if (answers[questionPosition + 1] != null)
				{
					questionPosition++;
					Global.questions2[i].questionsSide[1].answerTextBox.Text = answers[questionPosition].answer;
					Global.questions2[i].questionsSide[0].pointsTextBox.Text = answers[questionPosition].pointsLeft;
					Global.questions2[i].questionsSide[1].pointsTextBox.Text = answers[questionPosition].pointsRight;
				}
				questionPosition++;
			}
		}

		private static Question1NumberAndName Question1Header(string linia)
		{
			try
			{
				string[] words = linia.Split(new char[] { ' ', '\t' });
				int number = Int32.Parse(words[0]);
				StringBuilder name = new StringBuilder();
				for (int i = 1; i < words.Length; i++)
					name.Append(words[i]).Append(" ");
				return new Question1NumberAndName(number, name.ToString().TrimEnd());
			}
			catch (FormatException)
			{
				return null;
			}
		}

		private static Answer2 Question2Answer(string linia)
		{
			int lastSpacePosition = linia.LastIndexOfAny(new char[] { ' ', '\t' });
			if (lastSpacePosition == -1)
				return null;
			int LastButOneSpacePosition = linia.LastIndexOfAny(new char[] { ' ', '\t' }, lastSpacePosition - 1);

			string answer = (LastButOneSpacePosition == -1 ? "" : linia.Substring(0, LastButOneSpacePosition).TrimEnd());
			string pointsLeft = linia.Substring(LastButOneSpacePosition + 1, lastSpacePosition - LastButOneSpacePosition - 1);
			string pointsRight = linia.Substring(lastSpacePosition + 1);
			try
			{
				Int32.Parse(pointsLeft);
				Int32.Parse(pointsRight);
			}
			catch (FormatException)
			{
				return null;
			}

			if (answer.Length > Global.lengthAnswer2)
				Global.Exit(String.Format("za długa odpowiedź: {0}. Dopuszczalna szerokość to {1}", answer, Global.lengthAnswer2));
			string answerUpper = answer.ToUpper(CultureInfo.CurrentUICulture);
			for (int j = 0; j < answer.Length; j++)
				if (!Global.characters.ContainsKey(answerUpper[j]))
					Global.Exit(String.Format("niepoprawny znak '{0}' w {1}", answer[j], answer));
			return new Answer2(answer, pointsLeft, pointsRight);
		}

		private static int QuestionsCount(string[] answers)
		{
			int count = 0;
			foreach (string answer in answers)
				if (answer != null)
					count++;
			return count;
		}

		private void SwitchRound_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if ((int)(button.Tag) == 1)
			{
				button.Tag = 2;
				button.Text = "przełącz do rundy 2";

				Global.ShowPanel(0);
				Global.HidePanel(1);

				Global.SetMainPoints(0);

				Question1.Show();
			}
			else
			{
				button.Tag = 1;
				button.Text = "przełącz do rundy 1";

				Global.ShowPanel(1);
				Global.HidePanel(0);

				Question2.PrintPoints();
			}

			Global.tableBackground.Delete();
		}

		private void NextQuestion_Click(object sender, EventArgs e)
		{
			nextQuestion.Text = "następne pytanie";

			if (Question1.currentQuestionNumber != -1)
			{
				previousQuestion.Show();
				Question1.Hide();
			}

			Question1.currentQuestionNumber++;
			Question1.Show();
			if (Question1.LastQuestion())
				nextQuestion.Hide();

			Question1.ShowButtons();
		}
		private void PreviousQuestion_Click(object sender, EventArgs e)
		{
			nextQuestion.Show();

			Question1.Hide();
			Question1.currentQuestionNumber--;
			Question1.Show();

			if (Question1.currentQuestionNumber == 0)
				previousQuestion.Hide();

			Question1.ShowButtons();
		}
		private void ShowScreen_Click(object sender, EventArgs e)
		{
			Screen thisScreen = Screen.FromControl(this);
			Screen secondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(thisScreen)) ?? thisScreen;
			Global.main.Show();
			Global.main.WindowState = FormWindowState.Normal;
			Global.main.Location = secondScreen.WorkingArea.Location;
			if (thisScreen == secondScreen)
			{
				Global.main.FormBorderStyle = FormBorderStyle.Sizable;
				Global.main.TopMost = false;
			}
			else
			{
				Global.main.FormBorderStyle = FormBorderStyle.None;
				Global.main.TopMost = true;
			}
			Global.main.WindowState = FormWindowState.Maximized;
			showMainScreenButton.Hide();
		}

		private void SetTime_Click(object sender, System.EventArgs e)
		{
			string timeString = (string)(((Button)sender).Tag);
			timeLabel.Text = timeString;
			Global.tablePoints.SetText(timeString, 0, 0, false, 3, ' ');
		}
		private void StartTime_Click(object sender, EventArgs e)
		{
			if (timeLabel.Text != String.Empty)
				timer1.Start();
		}
		private void StopTime_Click(object sender, EventArgs e)
		{
			timer1.Stop();
		}
		private void HideAnswers_Click(object sender, EventArgs e)
		{
			Global.SwitchButtonSelection(hideAnswersButton);
			if (Global.ButtonSelected(hideAnswersButton))
			{
				for (int i = 0; i < 5; i++)
					if (Global.questions2[i].questionsSide[0].Selected())
						Global.questions2[i].questionsSide[0].ShowHide_Click(new object(), new EventArgs());
			}
			else
			{
				for (int i = 0; i < 5; i++)
					Global.questions2[i].questionsSide[0].ShowHide_Click(new object(), new EventArgs());
			}
		}
		private void Timer1_Tick(object sender, EventArgs e)
		{
			int remainingTime = Int32.Parse(timeLabel.Text);
			remainingTime--;
			timeLabel.Text = remainingTime.ToString();
			Global.tablePoints.SetText(remainingTime.ToString(), 0, 0, false, 3, ' ');
			if (remainingTime == 0)
			{
				timer1.Stop();
				timeLabel.Text = String.Empty;
				Global.tablePoints.SetText(String.Empty, 0, 0, false, 3, ' ');
			}
		}

		public void ShowPanel(int which)
		{
			roundPanels[which].Show();
		}
		public void HidePanel(int which)
		{
			roundPanels[which].Hide();
		}
		public void SetMainPoints(int points)
		{
			this.pointsLabel.Text = points.ToString();
		}
		public void SetTeamPoints(int which, int points)
		{
			teamPointsLabel[which].Text = points.ToString();
		}
	}
}
