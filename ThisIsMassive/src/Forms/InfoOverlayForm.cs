using Massive;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Forms
{
  public partial class InfoOverlayForm : Form
  {

    Vector3d NavigationTarget;

    public InfoOverlayForm()
    {
      InitializeComponent();
      MMessageBus.AvatarMovedEvent += MMessageBus_AvatarMovedEvent;
      MMessageBus.NavigationHandler += MMessageBus_NavigationHandler;
      MMessageBus.ZoneSelectHandler += MMessageBus_ZoneSelectHandler;
    }

    private void MMessageBus_ZoneSelectHandler(object sender, ZoneEvent e)
    {
      NavigationTarget = MassiveTools.Vector3dFromVector3_Server(e.Zone.Position);
    }

    private void MMessageBus_NavigationHandler(object sender, NavigationEvent e)
    {
      NavigationTarget = e.Target;
    }

    private void MMessageBus_AvatarMovedEvent(object sender, MoveEvent e)
    {
      if (MPlanetHandler.CurrentNear == null) return;
      UserInfo.Text = "";      

      Vector3d pos = MPlanetHandler.CurrentNear.GetLonLatOnShere(e.Position);
      UserInfo.Text += string.Format("LonLat: {0:0.0000},{1:0.0000} Alt:{2:0.0}", pos.X, pos.Y, MPlanetHandler.CurrentNear.AvatarDistanceToSurface);

      Vector3d TilePos = MPlanetHandler.CurrentNear.GetTileFromPoint(e.Position);
      UserInfo.Text += "\r\n" + TilePos.ToString();

      GetMetaData(TilePos);

      UserInfo.Text += " > " + Vector3d.Distance(Globals.Avatar.GetPosition(), NavigationTarget);
      Location = Main.ClientLocation;
      Location.Offset(10, Main.RenderClientSize.Height - Height);
    }

    public void UpdateData()
    {
      Location = Main.ClientLocation;
      Location.Offset(10, Height);
    }



    public void GetMetaData(Vector3d Tile)
    {
      if (MPlanetHandler.CurrentNear == null) return;
      if (MPlanetHandler.CurrentNear._terrainHandler == null) return;
      UserInfo.Text += "\r\n" + MPlanetHandler.CurrentNear._terrainHandler.GetTileInfo(Tile);
    }

  }
}
