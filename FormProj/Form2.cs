using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormProj
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Test_ScopeGuard(sender as Control);
		}

		public static void Test_ScopeGuard(Control control)
		{
			using (new CursorApplier(control, Cursors.WaitCursor))
			{
				// some work here
				System.Threading.Thread.Sleep(2000);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Test_Events.test();
		}
	}
}
