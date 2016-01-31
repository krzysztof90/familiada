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

		public void PokażPanel(int który)
		{
			panele[który].Show();
		}
		public void UkryjPanel(int który)
		{
			panele[który].Hide();
		}
		public void UstawPunktyGłówne(int punkty)
		{
			Global.tablicaPunkty.UstawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
		public void UstawPunktyDrużyny(int która, int punkty)
		{
			Global.tablicaPunktyDrużyny[która].UstawTekst(punkty.ToString(), 0, 0, false, 3, ' ');
		}
	}
}
