using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Massive.Network;
using OpenTK;
using Massive;
using Massive.Services;

namespace OpenWorld.src.Controls
{
  public partial class NavBarControl : UserControl
  {
    public NavBarControl()
    {
      InitializeComponent();
    }

    private void HomeButton_Click(object sender, EventArgs e)
    {
      MServerZone zone = MZoneService.Find("Earth");
      //Vector3d pos = MassiveTools.Vector3dFromVector3_Server(zone.Position);

      //cape town
      Vector3d pos = new Vector3d(12717657178.1831, 146353256847.389, -7581837054.42208);
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, pos, Quaterniond.Identity);
    }
  }
}
