using Massive;
using Massive.Events;
using Massive.Network;
using Massive.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.Handlers
{
  public class MAvatarHandler
  {
    public MAvatarHandler()
    {
      MMessageBus.ChangeAvatarRequestHandler += MMessageBus_ChangeAvatarRequestHandler;
      MMessageBus.AvatarMovedEvent += MMessageBus_AvatarMovedEvent;
      MMessageBus.MoveAvatarRequestEventHandler += MMessageBus_MoveAvatarRequestEventHandler;
    }


    //relay move avatar request to server
    private void MMessageBus_MoveAvatarRequestEventHandler(object sender, MoveEvent e)
    {
      Globals.Network.PositionRequest(Globals.UserAccount.UserID, e.Position, e.Rotation);
    }

    private void MMessageBus_AvatarMovedEvent(object sender, MoveEvent e)
    {
      Globals.UserAccount.CurrentPosition = MassiveTools.ArrayFromVector(Globals.Avatar.GetPosition());
    }

    private void MMessageBus_ChangeAvatarRequestHandler(object sender, ChangeAvatarEvent e)
    {
      Globals.UserAccount.AvatarID = e.TemplateID;      
    }

    void CreateAvatar()
    {
      MServerObject m = new MServerObject();

      string sAvatar = "AVATAR03";
      if (!string.IsNullOrEmpty(Globals.UserAccount.AvatarID))
      {
        sAvatar = Globals.UserAccount.AvatarID;
        m.Name = sAvatar;
        m.TemplateID = sAvatar;
        m.TextureID = sAvatar + "M";
      }

      m.InstanceID = Globals.UserAccount.UserID;
      m.OwnerID = m.InstanceID;
      m.Position = Globals.UserAccount.HomePosition;
     // MMessageBus.Spawn
      /*
      Globals.Network.SpawnRequest(Globals.UserAccount.AvatarID, m.TemplateID, Globals.UserAccount.UserID,
        "", MassiveTools.VectorFromArray(m.Position), 
        MassiveTools.QuaternionFromArray(m.Rotation), Globals.UserAccount.UserID,
        0, 100);
        */
      //_spawnHandler.Spawn(m);
      
    }
  }
}
