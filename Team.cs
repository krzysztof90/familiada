using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using familiada.Properties;

namespace familiada
{
	abstract class Team
	{
		private int points = 0;
		protected abstract int which { get; }

		public Team()
		{
			PrintPoints();
		}

		public void AddPoints(int added)
		{
			points += added;
			PrintPoints();
		}
		private void PrintPoints()
		{
			Global.SetTeamPoints(which, points);
		}
	}

	class TeamLeft : Team
	{
		protected override int which { get { return 0; } }
	}
	class TeamRight : Team
	{
		protected override int which { get { return 1; } }
	}
}
