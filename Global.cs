using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	static class Global
	{
		static Global()
		{
			controller = new Controller();
			panelController1 = controller.roundPanels[0];
			panelController2 = controller.roundPanels[1];
			panelControllerAccessory = controller.accessory;
			main = new MainScreen();
			forms = new List<IOperatable> { controller, main };
			questions1 = new List<Question1>();
			questions2 = new Question2[5];

			characters = new Dictionary<char, Image>
			{
				{'A', Resources.A},
				{'Ą', Resources.Ą},
				{'B', Resources.B},
				{'C', Resources.C},
				{'Ć', Resources.Ć},
				{'D', Resources.D},
				{'E', Resources.E},
				{'Ę', Resources.Ę},
				{'F', Resources.F},
				{'G', Resources.G},
				{'H', Resources.H},
				{'I', Resources.I},
				{'J', Resources.J},
				{'K', Resources.K},
				{'L', Resources.L},
				{'Ł', Resources.Ł},
				{'M', Resources.M},
				{'N', Resources.N},
				{'Ń', Resources.Ń},
				{'O', Resources.O},
				{'Ó', Resources.Ó},
				{'P', Resources.P},
				{'Q', Resources.Q},
				{'R', Resources.R},
				{'S', Resources.S},
				{'Ś', Resources.Ś},
				{'T', Resources.T},
				{'U', Resources.U},
				{'V', Resources.V},
				{'W', Resources.W},
				{'X', Resources.X},
				{'Y', Resources.Y},
				{'Z', Resources.Z},
				{'Ź', Resources.Ź},
				{'Ż', Resources.Ż},
				{'0', Resources.c0},
				{'1', Resources.c1},
				{'2', Resources.c2},
				{'3', Resources.c3},
				{'4', Resources.c4},
				{'5', Resources.c5},
				{'6', Resources.c6},
				{'7', Resources.c7},
				{'8', Resources.c8},
				{'9', Resources.c9},
				{'-', Resources.minus},
				{',', Resources.przecinek},
				{'?', Resources.znakZapytania},
				{'/', Resources.slash},
				{'.', Resources.kropka},
				{' ', Resources.puste},
				{'|', Resources.punktyPuste},
				{'˹', GetZonkBig(true, true)},
				{'˺', GetZonkBig(true, false)},
				{'˻', GetZonkBig(false, true)},
				{'˼', GetZonkBig(false, false)},
				{'┘', GetZonkSmall(true, true)},
				{'└', GetZonkSmall(true, false)},
				{'┐', GetZonkSmall(false, true)},
				{'┌', GetZonkSmall(false, false)},
				{'ˉ', GetZonkSmall(true)},
				{'ˍ', GetZonkSmall(false)},
			};

			tableBackground = new Table(main.roundPanel, 0, 0, Resources.puste);
			table1 = new Table(main.panels[0], Table.width, Table.height, Resources.puste);
			table2 = new Table(main.panels[1], Table.width, Table.height, Resources.puste);
			tablePoints = new Table(main.pointsPanel, 3, 1, Resources.puste);
			tableTeamPoints = new List<Table> { new Table(main.pointsLeftPanel, 3, 1, Resources.puste), new Table(main.pointsRightPanel, 3, 1, Resources.puste) };
			teams = new List<Team> { new TeamLeft(), new TeamRight() };
		}

		public const string file1 = "runda1.txt";
		public const string file2 = "runda2.txt";

		public const int lengthAnswer1 = 19;
		public const int lengthAnswer2 = 10;
		public const int countAnswer1 = Table.height - Answer1.tablePointsYStart;

		public static Controller controller { get; private set; }
		public static Panel panelController1 { get; private set; }
		public static Panel panelController2 { get; private set; }
		public static Panel panelControllerAccessory { get; private set; }
		public static MainScreen main { get; private set; }
		private static List<IOperatable> forms;

		public static List<Question1> questions1 { get; private set; }
		public static Question2[] questions2 { get; private set; }

		public static Dictionary<char, Image> characters { get; private set; }

		private static Bitmap GetZonkBig(bool up, bool left)
		{
			Bitmap Zonk = (Bitmap)(Resources.zonkDużyGL.Clone());
			if (up)
			{
				if (!left)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			else
			{
				if (left)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				else
					Zonk.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
			return Zonk;
		}
		private static Bitmap GetZonkSmall(bool up, bool left)
		{
			Bitmap Zonk = (Bitmap)(Resources.zonkMałyGL.Clone());
			if (up)
			{
				if (!left)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			else
			{
				if (left)
					Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
				else
					Zonk.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
			return Zonk;
		}
		private static Bitmap GetZonkSmall(bool up)
		{
			Bitmap Zonk = (Bitmap)(Resources.zonkMałyG.Clone());
			if (up)
				Zonk.RotateFlip(RotateFlipType.RotateNoneFlipY);
			return Zonk;
		}

		public static Table tableBackground { get; private set; }
		public static Table table1 { get; private set; }
		public static Table table2 { get; private set; }
		public static Table tablePoints { get; private set; }
		public static List<Table> tableTeamPoints { get; private set; }

		public static List<Team> teams { get; private set; }

		static public void ShowPanel(int which)
		{
			forms.ForEach(e => e.ShowPanel(which));
		}
		static public void HidePanel(int which)
		{
			forms.ForEach(e => e.HidePanel(which));
		}
		static public void SetMainPoints(int points)
		{
			forms.ForEach(e => e.SetMainPoints(points));
		}
		static public void SetTeamPoints(int which, int points)
		{
			forms.ForEach(e => e.SetTeamPoints(which, points));
		}

		static public void MarkButtonSelection(Button B)
		{
			B.BackColor = Color.White;
		}
		static public void UnmarkButtonSelection(Button B)
		{
			B.BackColor = SystemColors.Control;
			B.UseVisualStyleBackColor = true;
		}
		static public void SwitchButtonSelection(Button B)
		{
			if (ButtonSelected(B))
				UnmarkButtonSelection(B);
			else
				MarkButtonSelection(B);
		}
		static public bool ButtonSelected(Button B)
		{
			return B.BackColor == Color.White;
		}

		static public void Exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
