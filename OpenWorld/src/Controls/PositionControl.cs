using Massive;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OpenWorld.src.Controls
{
  public partial class PositionControl : UserControl
  {
    public PositionControl()
    {
      InitializeComponent();
      Globals.Network.PositionChangeHandler += Network_PositionChangeHandler;
      Globals.Network.TeleportHandler += Network_TeleportHandler;
    }

    private void Network_PositionChangeHandler(object sender, Massive.Events.MoveEvent e)
    {
      SetPosition(e.Position);
    }

    private void Network_TeleportHandler(object sender, Massive.Events.MoveEvent e)
    {
      SetPosition(e.Position);
    }

    void SetPosition(Vector3d pos)
    {
      Invoke(new MethodInvoker(delegate ()
      {
        PositionBox.Text = pos.ToString();
      }));      
    }   
  }
}
