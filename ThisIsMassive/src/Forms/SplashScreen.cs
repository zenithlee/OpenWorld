using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Forms
{
  public partial class SplashScreen : Form
  {
    public SplashScreen()
    {
      InitializeComponent();     
    }

    private void SplashScreen_Shown(object sender, EventArgs e)
    {
      timer1.Interval = 10000;
      timer1.Start();
    }

    public void DoClose()
    {
      Invoke((MethodInvoker)delegate
      {
        timer1.Interval = 100;
        timer1.Start();
      });
      
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Close();
    }

   
  }
}
