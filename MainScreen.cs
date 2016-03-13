using System.Collections.Generic;
using System.Windows.Forms;

namespace familiada
{
	public partial class MainScreen : Form, IOperatable
	{
		public MainScreen()
		{
			panels = new List<Panel> { new Panel(), new Panel() };
			foreach (Panel p in panels)
			{
				p.Dock = DockStyle.Fill;
				p.Margin = new Padding(0);
				p.Visible = false;
			}

			InitializeComponent();

			panels.ForEach(p => roundPanel.Controls.Add(p));
		}

		private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			Global.controller.showMainScreenButton.Show();
		}

		public void ShowPanel(int which)
		{
			panels[which].Show();
		}
		public void HidePanel(int which)
		{
			panels[which].Hide();
		}
		public void SetMainPoints(int points)
		{
			Global.tablePoints.SetText(points.ToString(), 0, 0, false, 3, ' ');
		}
		public void SetTeamPoints(int which, int points)
		{
			Global.tableTeamPoints[which].SetText(points.ToString(), 0, 0, false, 3, ' ');
		}
	}
}
