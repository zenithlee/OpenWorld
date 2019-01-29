using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class DFormBase : Form
  {
    Point ClickPoint;
    bool Down = false;
    public DFormBase()
    {
      InitializeComponent();
      BringToFront();      
    }

    public void SetTitle(string sTitle)
    {
      TitleBar.Text = sTitle;
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void TitleBar_MouseDown(object sender, MouseEventArgs e)
    {
      ClickPoint = Control.MousePosition;
      Down = true;
    }

    private void TitleBar_MouseMove(object sender, MouseEventArgs e)
    { 
      if (Down == true)
      {
        Point Delta = Location;
        Delta.Offset(Control.MousePosition.X - ClickPoint.X , Control.MousePosition.Y - ClickPoint.Y);
        Location = Delta;
        Console.WriteLine(Location.X + "," + Delta.X);
        ClickPoint = Control.MousePosition;        
      }
    }

    private void TitleBar_MouseUp(object sender, MouseEventArgs e)
    {
      Down = false;
    }

    private void DFormBase_Shown(object sender, EventArgs e)
    {
      //Owner = Main.GetInstance();
    }

    private void DFormBase_Load(object sender, EventArgs e)
    {
      this.Activate();
    }
  }
}


