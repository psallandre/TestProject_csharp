using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormProj
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
			Application.SetCompatibleTextRenderingDefault(false);

			var f2 = new Form2();
			f2.Show();

			Test_EF test = new Test_EF();

			Application.Run(new Form1());
		}
	}
}
