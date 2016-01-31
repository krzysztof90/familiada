using System.Collections.Generic;
using System.Windows.Forms;
namespace familiada
{
	public partial class GłównyEkran : Form, IOperatable
	{
		public GłównyEkran()
		{
			panele = new List<Panel> { new Panel(), new Panel() };
			foreach (Panel p in panele)
			{
				p.Dock = DockStyle.Fill;
				p.Margin = new Padding(0);
				p.Visible = false;
			}

			InitializeComponent();

			panele.ForEach(p => panelRundy.Controls.Add(p));
		}

		private void GłównyEkran_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;

			Global.kontroler.pokażEkran.Show();
		}

		public void pokażPanel(int który)
		{
			panele[który].Show();
		}
		public void ukryjPanel(int który)
		{
			panele[który].Hide();
		}
		public void ustawPunktyGłówne(int punkty)
		{
			Global.tablicaPunkty.ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
		public void ustawPunktyDrużyny(int która, int punkty)
		{
			Global.tablicaPunktyDrużyny[która].ustawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
	}
}
