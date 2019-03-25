﻿using Massive.Events;
using Massive.Graphics.Character;
using Massive2.Graphics.Character;
using OpenTK;
using System;

namespace Massive
{
  public class MAvatar : MObject
  {
    public MSceneObject Target;

    public Quaterniond TargetRotation;

    public MPhysicsObject _physics;
    public double height = 1.2;

    public double Throttle = 0;

    public enum eMoveMode { Walking, Flying };
    eMoveMode MoveMode = eMoveMode.Walking;

    public enum eMoveState { Idle, Walk, Run, Jump, Fight1, Fight2 };
    eMoveState MoveState = eMoveState.Idle;
    public float CurrentSpeed = 0;    

    IControllerContext Controller;

    public MAvatar(string name)
      : base(EType.Player, "UserAvatar")
    {
      Controller = new MWalkController(this);
    }

    public eMoveMode GetMoveMode()
    {
      return MoveMode;
    }

    public void SetMoveMode(eMoveMode m)
    {
      MoveMode = m;
      if (_physics != null)
      {
        if (MoveMode == eMoveMode.Walking)
        {
          Controller = new MWalkController(this);
          //MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, "AVATAR02");
          _physics.SetAngularFactor(1.0, 1.0, 1.0);
          _physics.SetDamping(0.95, 0.5);
        }
        else
        {
          Controller = new MFlyBirdController(this);
          // LoadTargetModel(@"Models\vehicles\swallow01.fbx");
          //MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, "AVATAR03");
          _physics.SetAngularFactor(0.7, 0.7, 0.7);
          _physics.SetDamping(0.21, 0.9);
        }
      }
    }

    public bool Owns(MObject mo)
    {
      if (string.IsNullOrEmpty(Globals.UserAccount.UserID)) return false;
      if (mo == null) return false;
      if (string.IsNullOrEmpty(mo.OwnerID)) return false;
      if (Globals.UserAccount.UserID.Equals(mo.OwnerID)) return true;
      return false;
    }

    public void SetSceneObject(MSceneObject so)
    {
      Target = so;
      _physics = null;
      if (Target != null)
      {
        _physics = (MPhysicsObject)Target.FindModuleByType(EType.PhysicsObject);
      }
    }

    public Vector3d GetPosition()
    {
      if (Target == null) return Vector3d.Zero;
      if (_physics == null) return Target.transform.Position;
      return _physics.GetPosition();
    }

    public Quaterniond GetRotation()
    {
      if (Target == null) return Quaterniond.Identity;
      if (_physics == null) return Target.transform.Rotation;
      return _physics.GetRotation();
    }

    public Quaterniond GetTargetRotation()
    {
      return TargetRotation;
    }

    public void SetPosition(Vector3d pos)
    {
      if (_physics == null)
      {
        if (Target != null)
        {
          Target.transform.Position = pos;
        }
        return;
      }
      _physics.SetPosition(pos);
    }

    public void SetRotation(Quaterniond rot)
    {
      if (_physics == null) return;
      TargetRotation = rot;
      // _physics.SetRotation(rot);
    }

    public void InputH(double h)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      Vector3d vo = MScene.Camera.transform.Right() * h;
      _physics._rigidBody.ApplyCentralImpulse(vo);
    }

    public void InputRollH(double h)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      _physics._rigidBody.ApplyTorque(GetRotation() * new Vector3d(0, 0, h));
    }

    public void InputPitchV(double h)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      _physics._rigidBody.ApplyTorque(_physics.GetRotation() * new Vector3d(h, 0, 0));
    }

    public void InputYawH(double h)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      //_physics._rigidBody.ApplyTorque(_physics.GetRotation() * new Vector3d(0, h, 0));
      TargetRotation = _physics.GetRotation() * Quaterniond.FromEulerAngles(0, h, 0);
    }

    public void Walk(double v)
    {
      MoveState = eMoveState.Walk;
      InputV(v);
    }

    public void Run(double v)
    {
      MoveState = eMoveState.Run;
      InputV(v);
    }

    public void Turn(double v)
    {
      MoveState = eMoveState.Walk;
      InputYawH(v);
    }

    public void RunTurn(double v)
    {
      MoveState = eMoveState.Run;
      InputYawH(v);
    }

    int Counter = 0;
    public void InputV(double v)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      // ph.Thrust.Z = v * 2;
      Vector3d vo = -MScene.Camera.transform.Forward() * v; //OPENGL camera has inverse z      
      _physics._rigidBody.ApplyCentralImpulse(vo);
      //_physics._rigidBody.ApplyTorque(vo);

      //if we're moving forward and our feet are near an obstacle, add an upward boost to step over it
      if (v > 0)
      {
        Vector3d ap = GetPosition();
        Vector3d pos = ap + Forward() * 0.5;
        MPhysics.Instance.RayCastRequest(pos, pos + Forward() - Up() * height, this, (result) =>
          {
            if (result.Result == true)
            {
              //Console.WriteLine("HIT " + Counter + " " + result.Depth);
              Counter++;
              if (result.Depth < 0.9)
              {
                //InputB1(70);
              }
            }
          });
      }
    }

    public void Reset()
    {
      _physics._rigidBody.LinearVelocity = Vector3d.Zero;
      _physics._rigidBody.AngularVelocity = Vector3d.Zero;
      SetRotation(Globals.LocalUpRotation());
      _physics.SetRotation(Globals.LocalUpRotation());
    }

    public void MouseWheel(double b)
    {
      Controller.MouseWheel(b);
    }

    public void Jump(double b)
    {
      if (_physics == null) return;
      _physics.SetActive(true);

      Controller.Jump(b);
    }

    public void InputB1(double b)
    {
      if (_physics == null) return;
      _physics.SetActive(true);
      Vector3d vo = Vector3d.Zero;

      if (MoveMode == eMoveMode.Walking)
      {
        vo = Globals.LocalUpVector * b; //jetpack
      }
      if (MoveMode == eMoveMode.Flying)
      {
        vo = GetRotation()
         * new Vector3d(0, 0, b); //boost
      }
      _physics._rigidBody.ApplyCentralForce(vo);
    }

    public void Brake(double b)
    {
      _physics.SetActive(true);
      Controller.Brake(b);
    }

    public Vector3d Up()
    {
      if (_physics == null)
      {
        return Globals.LocalUpVector;
        //new Vector3d(0, 1, 0);
      }

      Vector3d vo = _physics._rigidBody.WorldTransform.ExtractRotation() * new Vector3d(0, 1, 0);
      return vo;
    }

    public Vector3d Forward()
    {
      if (_physics == null) return new Vector3d(0, 0, 1);
      Vector3d vo = _physics._rigidBody.WorldTransform.ExtractRotation() * new Vector3d(0, 0, 1);
      return vo.Normalized();
    }

    public Vector3d Right()
    {
      if (_physics == null) return new Vector3d(1, 0, 0);
      Vector3d vo = _physics._rigidBody.WorldTransform.ExtractRotation() * new Vector3d(1, 0, 0);
      return vo.Normalized();
    }

    //assuming  walking player
    public void RotateBy(double deltax, double deltay)
    {
      if (Target != null)
      {
        Quaterniond ir = _physics._rigidBody.CenterOfMassTransform.ExtractRotation();
        //Quaterniond d = Quaterniond.FromAxisAngle(Globals.GlobalUpVector, deltax);
        //Quaterniond d = Quaterniond.FromAxisAngle(Vector3d.UnitY, deltax);

        Quaterniond d = new Quaterniond(0, deltax, 0);
        Quaterniond dy = new Quaterniond(0, 0, deltay);
        _physics.SetRotation(d * ir * dy);
        //ph.SetRotation(d * ir);
      }
    }

    public void Hide()
    {
      if (Target != null)
      {
        Target.Visible = false;
      }
    }

    public void Show()
    {
      if (Target != null)
      {
        Target.Visible = true;
      }
    }

    void CalcAerodynamics()
    {
      double sideslip = Vector3d.Dot(Right(), _physics._rigidBody.LinearVelocity);
      _physics._rigidBody.ApplyCentralImpulse(Right() * -sideslip * 0.5);

      double forwaddyn = Vector3d.Dot(Forward(), _physics._rigidBody.LinearVelocity);
      //Console.WriteLine("fwd:" + forwaddyn);
      //Console.WriteLine("LV:" + _physics._rigidBody.LinearVelocity.Length);
      if (MPhysics.Instance.UseGravity == true)
      {
        if (Math.Abs(forwaddyn) < 0.5)
        {
          double lift = Vector3d.Dot(Up(), -Globals.LocalGravity) * Globals.LocalGravity.Length * Throttle;
          _physics._rigidBody.ApplyCentralForce(Up() * lift);
        }

        if (Throttle == 1)
        {
          _physics._rigidBody.ApplyCentralForce(-Globals.LocalGravity * 8);
        }
      }
    }

    void SyncAnimationToState()
    {
      MAnimatedModel ma = (MAnimatedModel)Target;

      if (CurrentSpeed == 0)
      {
        MoveState = eMoveState.Idle;
      }
      switch (MoveState)
      {
        case eMoveState.Idle:
          ma._animationController.PlayAnimation("idle", CurrentSpeed);
          break;
        case eMoveState.Walk:
          ma._animationController.PlayAnimation("walk", CurrentSpeed);
          break;
        case eMoveState.Run:
          ma._animationController.PlayAnimation("run", CurrentSpeed);
          break;
      }
    }

    public override void Update()
    {
      base.Update();
      if (Target == null) return;

      if (Target is MAnimatedModel)
      {
        CurrentSpeed = (float)_physics._rigidBody.LinearVelocity.Length;
        // Console.WriteLine("MAvatar.Update:"+CurrentSpeed);
        SyncAnimationToState();
      }

      if (MoveMode == eMoveMode.Walking)
      {
        if (_physics != null)
        {
          //Quaterniond rot = Quaterniond.Slerp(GetRotation(), TargetRotation, Time.DeltaTime * 15);
          Quaterniond rot = Quaterniond.Slerp(GetRotation(), TargetRotation, 0.2);
          _physics.SetRotation(rot);
          //_physics.SetRotation(TargetRotation);
        }
      }
      if (MoveMode == eMoveMode.Flying)
      {
        CalcAerodynamics();
      }
    }

  }
}
