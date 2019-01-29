using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThisIsMassive.src.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class CButtonBar : UserControl
  {
    public CButtonBar()
    {
      InitializeComponent();
    }

    private void AssetsButton_Click(object sender, EventArgs e)
    {
      //AssetsForm af = new AssetsForm();
      //af.Show(this);
      TableForm td = new TableForm("objects", "All Objects");
      td.Show(this);
    }
    private void SocialButton_Click(object sender, EventArgs e)
    {
      //MStateMachine.ChangeState(MStateMachine.eStates.Building);
      ChatForm cf = new ChatForm();
      cf.Show();
    }

    private void BuildModeButton_Click(object sender, EventArgs e)
    {
      //MStateMachine.ChangeState(MStateMachine.eStates.Building);
      BuildForm bf = new BuildForm();
      bf.Show();
      //bf.SetSelected(MyWorld.Selected);
      bf.Location = new Point(0, 0);
    }

    private void Zones_Click(object sender, EventArgs e)
    {
      ZoneExploreForm zf = new ZoneExploreForm();
      zf.Show();
    }

    private void Market_Click(object sender, EventArgs e)
    {
      TableForm tf = new TableForm("market", "The Market");
      tf.Show(this);
    }

    private void AdminTools_Click(object sender, EventArgs e)
    {
      AdminTools at = new AdminTools();
      at.Show(this);
    }
  }
}
