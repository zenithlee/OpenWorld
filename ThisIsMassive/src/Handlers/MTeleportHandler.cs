using Massive;
using Massive.Events;
using Massive.Tools;
using MassiveUniverse;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisIsMassive.src.Handlers
{
  public class MTeleportHandler
  {
    //Dictionary<string, MBookmark> Locations = new Dictionary<string, MBookmark>();

    public MTeleportHandler()
    {
      MMessageBus.TeleportRequestHandler += MMessageBus_TeleportRequestHandler;
      Globals.Network.TeleportHandler += Network_TeleportHandler;
    }

    //only for our avatar
    private void MMessageBus_TeleportRequestHandler(object sender, TeleportRequestHandler e)
    {
      if (Globals.Avatar.Target != null)
      {
        Globals.Network.TeleportRequest(Globals.UserAccount.UserID, e.Position, e.Rotation);
        //Globals.Network.SpawnRequest(Globals.UserAccount.AvatarID, Globals.UserAccount.AvatarID + "T", Globals.UserAccount.UserName,
        //          (string)Globals.Avatar.Target.Tag, e.Position, e.Rotation, Globals.UserAccount.UserID, 0, 2);
      }
    }

    private void Network_TeleportHandler(object sender, MoveEvent e)
    {
      MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(e.InstanceID);
      if (mo == null) return;


      //create a nice transition for ourselves, but other players can just move

      if (e.InstanceID.Equals(Globals.UserAccount.UserID))
      {
        /*
       MTeleportOneShot oldmt = (MTeleportOneShot)mo.FindModuleByType(MObject.EType.Teleport);
      if (oldmt != null)
      {
        mo.Remove(oldmt);
      }
        MTeleportOneShot mt = new MTeleportOneShot(mo, e.Position, e.Rotation);
        if (e.InstanceID.Equals(Globals.UserAccount.UserID))
        {
          if (MKeyboardHandler.ControlDown) mt.Speed = 0.1;
          if (MKeyboardHandler.ShiftDown) mt.Speed = 0.01;
        }
        mt.TeleportCompleteHandler += TeleportComplete;
        mo.Add(mt);
        */
        //if (Dirty == true)
        Globals.Avatar.SetPosition(e.Position);
        MPlanetHandler._Instance.Update();
        Globals.Avatar.SetRotation(Globals.LocalUpRotation()
          * Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0));

        if (Globals.Avatar.GetMoveMode() == MAvatar.eMoveMode.Walking)
        {
          MScene.Camera.TargetOffset = Globals.LocalUpVector * -2;
        }

      }
      else
      {
        mo.SetPosition(e.Position);
        Vector3d LocalUp = MPlanetHandler.GetUpAt(e.Position);
        Quaterniond rota = Extensions.LookAt(mo.transform.Position, mo.transform.Position + LocalUp, Vector3d.UnitY)
               * Quaterniond.FromEulerAngles(0, 0, -90 * Math.PI / 180.0);
        mo.SetRotation(rota);
      }

      TeleportComplete(e.InstanceID, e.Position, e.Rotation);
    }

    void TeleportComplete(string InstanceID, Vector3d Pos, Quaterniond Rot)
    {
      MMessageBus.TeleportComplete(this, InstanceID, Pos, Rot);
    }

    public void TeleportComplete(object sender, MoveEvent e)
    {
      MTeleportOneShot tp = (MTeleportOneShot)sender;
      MSceneObject parent = (MSceneObject)tp.Parent;
      tp.TeleportCompleteHandler -= TeleportComplete;

      parent.SetPosition(e.Position);
      Quaterniond rota = Extensions.LookAt(parent.transform.Position, parent.transform.Position + Globals.LocalUpVector, Vector3d.UnitY)
             * Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0);
      parent.SetRotation(rota);
      MPhysicsObject po = (MPhysicsObject)parent.FindModuleByType(MObject.EType.PhysicsObject);
      po.StopAllMotion();

      if (e.InstanceID.Equals(Globals.UserAccount.UserID))
      {
        if (Globals.Avatar.Target != null)
        {
          MLight light = (MLight)MScene.UtilityRoot.FindModuleByType(MObject.EType.DirectionalLight);
          //light.transform.Position = Globals.Avatar.GetPosition() + Globals.LocalUpRotation;
          light.transform.Position = Globals.Avatar.GetPosition() + Globals.Avatar.Forward() * 15
            + Globals.Avatar.Up() * 10;
          light.LookAt(Globals.Avatar.GetPosition());



        }
      }
    }
  }
}
