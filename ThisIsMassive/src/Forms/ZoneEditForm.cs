using Massive;
using Massive.Events;
using Massive.Network;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThisIsMassive.src.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class ZoneForm : DToolForm
  {
    public Vector3d Position;

    public ZoneForm()
    {
      InitializeComponent();
      SetTitle("_ZONE");
    }

    private void ZoneForm_Shown(object sender, EventArgs e)
    {
      Globals.Network.ZoneCreateHandler += Network_ZoneCreateHandler;
      Globals.Network.ErrorEventHandler += Network_ErrorEventHandler;
    }

    private void Network_ErrorEventHandler(object sender, ErrorEvent e)
    {
      StatusLabel.Invoke((MethodInvoker)delegate
      {
        StatusLabel.ForeColor = Color.DarkRed;
        StatusLabel.Text = e.ErrorMessage;        
      });
    }

    private void Network_ZoneCreateHandler(object sender, ZoneEvent e)
    {
      if (e.Zone.OwnerID.Equals(Globals.UserAccount.UserID))
      {        
        StatusLabel.Invoke((MethodInvoker)delegate
        {
          StatusLabel.ForeColor = Color.DarkGreen;
          StatusLabel.Text = "SUCCESS. Created " + e.Zone.Name;
          timer1.Start();
        });
      }
    }

    public void SetPosition(Vector3d inPos)
    {
      Position = inPos;
      PositionBox.Text = Position.X +"," + Position.Y + "," + Position.Z;
    }

    private void UpdatePropertiesButton_Click(object sender, EventArgs e)
    {      
      Vector3d_Server v = new Vector3d_Server(Position.X, Position.Y, Position.Z);
      MServerZone zone = new MServerZone(Globals.UserAccount.UserID, ZoneNameBox.Text, ZoneGroup.Text, v);      
      Globals.Network.CreateZoneRequest(zone);      
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Globals.Network.ZoneCreateHandler -= Network_ZoneCreateHandler;
      Globals.Network.ErrorEventHandler -= Network_ErrorEventHandler;
      this.Close();
    }


  }
}
