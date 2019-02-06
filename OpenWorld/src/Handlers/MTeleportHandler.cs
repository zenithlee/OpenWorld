using Massive;
using Massive.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Handles all Avatar teleport requests
/// </summary>

namespace OpenWorld.Handlers
{
  public class MTeleportHandler
  {

    public MTeleportHandler()
    {
      MMessageBus.TeleportRequestHandler += MMessageBus_TeleportRequestHandler;
    }

    private void MMessageBus_TeleportRequestHandler(object sender, TeleportRequestHandler e)
    {
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, e.Position, e.Rotation);
    }
  }
}
