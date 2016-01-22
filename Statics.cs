using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familiada
{
	class Statics
	{
		public static string nazwaPliku = "pytania.txt";

		public static NotForShow pomocniczy = new NotForShow();
		public static ForShow główny = new ForShow();
		
		public static List<Pytanie> pytania = new List<Pytanie>();
		public static int obecnePytanie = -1;
		
		public static Drużyna drużynaL = new Drużyna();
		public static Drużyna drużynaP = new Drużyna();

		static public void exit(string message)
		{
			MessageBox.Show(message);
			Environment.Exit(0);
		}
	}
}
