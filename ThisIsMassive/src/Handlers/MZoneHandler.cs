using Massive;
using Massive.Network;
using Massive2.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisIsMassive.src.Handlers
{
  public class MZoneHandler
  {
    public MZoneHandler()
    {
      Globals.Network.ZoneCreateHandler += Network_ZoneHandler;
    }

    private void Network_ZoneHandler(object sender, Massive2.Events.ZoneEvent e)
    {
      Vector3d vs = new Vector3d(e.Zone.Position.X, e.Zone.Position.Y, e.Zone.Position.Z);
      //MMessageBus.AddBookmark(this, new Massive2.Tools.MBookmark(vs, Quaterniond.Identity, e.Zone.Name));
    }

    //Checks if anyone else has built nearby
    //not a solid test, probably need to double-check on the server.
    public static bool ZoneLocked(Vector3d pos)
    {
      bool result = false;
      //create a copy to avoid locking conflict, as this is a slowish operation
      foreach (MObject m in MScene.ModelRoot.Modules.ToList())
      {
        if (!m.Renderable) continue;

        MSceneObject mo = (MSceneObject)m;
        if (string.IsNullOrEmpty(mo.OwnerID)) continue;
        if (mo.IsAvatar == true) continue;

        if (!mo.OwnerID.Equals(Globals.UserAccount.UserID))
        {
          double dist = Vector3d.Distance(pos, mo.transform.Position);
          if (dist < MStateMachine.BuildThreshold)
          {
            result = true;
            break;
          }
        }
      }

      MStateMachine.ZoneLocked = result;
      return result;
    }
  }
}
