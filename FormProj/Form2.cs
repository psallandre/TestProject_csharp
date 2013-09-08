using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProj
{
	public partial class Form2 : Form
	{
    int cpt;

    System.Timers.Timer timer = new System.Timers.Timer(1000);

		public Form2()
		{
			InitializeComponent();

      timer.AutoReset = true;
      timer.Enabled = true;
      timer.Elapsed += timer_Elapsed;
		}

    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (labelTimer.InvokeRequired) {
        labelTimer.BeginInvoke(new MethodInvoker(() => labelTimer.Text = (cpt+10).ToString()));  //appel asynchrone
        labelTimer.Invoke(new MethodInvoker(() => labelTimer.Text = cpt.ToString()));       //appel synchrone
      }
      else
        labelTimer.Text = cpt.ToString();
      button1.BackColor = Color.Green;
    }

		private void button1_Click(object sender, EventArgs e)
		{
			Test_ScopeGuard(sender as Control);
      cpt++;
      label1.Text = cpt.ToString();
		}

		public void Test_ScopeGuard(Control control)
		{
			using (new CursorApplier(control, Cursors.WaitCursor))
			{
        SomeLongFunc(10);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Test_Events.test();
		}

    private void button3_Click(object sender, EventArgs e)
    {
      button3.BackColor = Color.Red;
      Task task1 = Task.Factory.StartNew(ParameterLessLongAction);
      task1.ContinueWith((t) => button3.BackColor = Color.Green);

      Task<string> task = Task.Factory.StartNew<string>(() => SomeLongFunc(cpt));
      task.ContinueWith((t) => { button3.BackColor = Color.Green; }, TaskScheduler.FromCurrentSynchronizationContext());
      button3.BackColor = Color.Orange;
    }

    private void ParameterLessLongAction()
    {
  		System.Threading.Thread.Sleep(000);
      button3.BackColor = Color.Yellow;
    }


    private string SomeLongFunc(int cpt)
    {
  		System.Threading.Thread.Sleep(2000);
      return DateTime.Now.AddMinutes(cpt).ToString();
    }
	}
}
