using Massive;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Massive.MObject;

/// <summary>
/// Controls a camera, animation, prevents clipping, etc
/// </summary>

namespace OpenWorld.Handlers
{
  public class MCameraHandler
  {
    MCamera _camera;

    double MaxSpeed = 0.002;
    double Speed = 1;
    Vector3d PreviousPosition = Vector3d.Zero;
    Vector3d PreviousTarget = Vector3d.Zero;
    double MaxNetworkThrottle = 0.5;
    double Throttle = 0;
    Vector3d CurrentPosition;
    bool ThirdPerson = true;
    MPhysicsObject po;

    Vector3d TargetPosition;
    Vector3d TargetUp;    

    //MSceneObject Target;

    public MCameraHandler()
    {
      _camera = MScene.Camera;

      Globals.Network.TeleportHandler += Network_TeleportHandler;
      MMessageBus.UpdateHandler += MMessageBus_UpdateHandler;

      //po = new MPhysicsObject(_camera, "CamPhysball", 0, MPhysicsObject.EShape.Sphere, false, new Vector3d(0.1,0.1,0.1));
      // MMessageBus.TeleportedEventHandler += MMessageBus_TeleportEventHandler;
      //MMessageBus.UpdateHandler += MMessageBus_UpdateHandler;

      // Target = Helper.CreateSphere(null, "CamTarget");
      // Target.transform.Position = new OpenTK.Vector3d(0, 1.1, 9);
    }

    private void MMessageBus_UpdateHandler(object sender, UpdateEvent e)
    {
      Update();
    }

    private void Network_TeleportHandler(object sender, MoveEvent e)
    {
      MScene.Camera.TargetOffset = Vector3d.Zero;
    }

    //private void MMessageBus_TeleportEventHandler(object sender, Events.MoveEvent e)
    // {
    //_camera.Move(new Vector3d(e.Delta.X, 0, e.Delta.Z));
    // Speed = e.Locus;
    //}
    void CheckIfCloseToWall(Vector3d AP)
    {
      Vector3d result = Vector3d.Zero;
      MScene.Physics.RayCastRequest(AP, AP + Globals.Avatar.Forward() * 2.5, this, (RayResult) =>
      {
        if (RayResult.Result)
        {
          double d = Vector3d.Distance(result, AP);
          //MScene.Camera.NearPlane = d/6.0;
          MScene.Camera.NearPlane = 0.01;
          //MScene.Camera.FarPlane = 1000;
          MScene.Closeup = 1;
          // Console.WriteLine("Hit:" + (d.ToString()));
          //MMessageBus.NavigationEnable(this, false);
        }
        else
        {
          MScene.Camera.NearPlane = 1;
          //MScene.Camera.FarPlane = 1000000000;
          MScene.Closeup = 0;
          //MMessageBus.NavigationEnable(this, true);
        }
      });

    }

    public void UpdateMovement()
    {
      double dist = Vector3d.Distance(MScene.Camera.transform.Position, TargetPosition);
      dist = MathHelper.Clamp(dist, 1, 10);
      //MScene.Camera.transform.Position = Vector3d.Lerp(MScene.Camera.transform.Position, TargetPosition, Time.DeltaTime * Speed * dist);
      MScene.Camera.transform.Position = TargetPosition;
      MScene.Camera.UpVector = Vector3d.Lerp(MScene.Camera.UpVector, TargetUp, Time.DeltaTime * Speed * 2);
    }

    public void Update()
    {
      Throttle += Time.DeltaTime;

      if (Globals.Avatar.Target != null)
      {

        Vector3d AP = Globals.Avatar.GetPosition();

        MBoundingBox box = Globals.Avatar.Target.BoundingBox;
        //Console.WriteLine(box);
        double rad = box.Size().Length;

        // CheckIfCloseToWall(AP + Globals.Avatar.Forward() * 0.1);        
       
        TargetUp = Globals.Avatar.Up();

        if (Globals.Avatar.GetMoveMode() == MAvatar.eMoveMode.Walking)
        {
          TargetPosition = AP + Globals.Avatar.Up() * Settings.OffsetThirdPerson.Y
                 - Globals.Avatar.Forward() * Settings.OffsetThirdPerson.Z;          

          MScene.Camera.Target.transform.Position = AP + Globals.Avatar.Forward() * 10
            + MScene.Camera.TargetOffset;
        }
        else
        {
          TargetPosition = AP + Globals.Avatar.Up() * Settings.OffsetThirdPerson.Y
                 - Globals.Avatar.Forward() * Settings.OffsetThirdPerson.Z;          

          MScene.Camera.Target.transform.Position = AP + Globals.Avatar.Forward() * 10;
        }

        double dist = Vector3d.Distance(PreviousPosition, MScene.Camera.transform.Position);
        double td = Math.Abs(Vector3d.Distance(PreviousTarget, MScene.Camera.Target.transform.Position));

        if (((dist > 0.25) || (td > 1))
          && (Throttle > MaxNetworkThrottle))
        {
          MMessageBus.MoveAvatarRequest(this, Globals.UserAccount.UserID, AP, Globals.Avatar.GetRotation());
          Throttle = 0;
          PreviousPosition = MScene.Camera.transform.Position;
          PreviousTarget = MScene.Camera.Target.transform.Position;
        }
      }

      UpdateMovement();
    }

  }
}
