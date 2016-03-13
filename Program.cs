using System;
using System.Windows.Forms;
namespace familiada
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(Global.controller);
		}
	}
}
