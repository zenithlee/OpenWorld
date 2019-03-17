using BulletSharp;
using Massive.Events;
using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Massive
{
  public class MPhysics : MObject
  {
    public bool DebugWorld = false;
    public DiscreteDynamicsWorld World { get; set; }

    public static MPhysics Instance;
    public MPhysicsDebug _DebugDrawer;

    CollisionDispatcher dispatcher;
    DbvtBroadphase broadphase;
    //List<CollisionShape> collisionShapes = new List<CollisionShape>();
    CollisionConfiguration collisionConf;

    public Vector3d DefaultGravity = new Vector3d(0, -9.8, 0);
    public bool UseGravity = true;
    public Vector3d Gravity { get => World.Gravity; set => World.Gravity = value; }

    public BackgroundWorker _backgroundWorker;

    List<MPhysicsObject> AddQueue = new List<MPhysicsObject>();
    List<MPhysicsObject> RemoveQueue = new List<MPhysicsObject>();
    List<MRaycastTask> RaycastsPending = new List<MRaycastTask>();

    BoxShape CollisionTester;
    //MRaycastTask _rayTask;

    public MPhysics()
      : base(EType.PhysicsEngine, "PhysicsEngine")
    {
      Instance = this;
      MMessageBus.GravityStateHandler += MMessageBus_GravityStateHandler;
    }

    private void MMessageBus_GravityStateHandler(object sender, BooleanEvent e)
    {
      UseGravity = e.State;
      SetGravity(DefaultGravity);
    }

    public override void Setup()
    {
      base.Setup();

      if (World != null) return;

      _DebugDrawer = new MPhysicsDebug();

      _backgroundWorker = new BackgroundWorker();
      _backgroundWorker.WorkerSupportsCancellation = true;
      _backgroundWorker.WorkerReportsProgress = true;
      _backgroundWorker.DoWork += _backgroundWorker_DoWork;
      _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
      _backgroundWorker.RunWorkerAsync();

      /*
      collisionConf = new DefaultCollisionConfiguration();
      //try 
      //dispatcher = new CollisionDispatcherMultiThreaded(collisionConf); //crashes
      dispatcher = new CollisionDispatcher(collisionConf);


      broadphase = new DbvtBroadphase();
      ConstraintSolver solver = new MultiBodyConstraintSolver();

      World = new DiscreteDynamicsWorld(dispatcher, broadphase, solver, collisionConf);      
      World.SolverInfo.NumIterations = 20;
      World.DispatchInfo.UseContinuous = true;

      World.Gravity = new Vector3d(0, -9.8, 0);
   

      _DebugDrawer = new MPhysicsDebug();
      World.DebugDrawer = _DebugDrawer;

 


      //CollisionTester = new SphereShape(0.2);
      Vector3d _boxBoundMin, _boxBoundMax;
      _boxBoundMax = new Vector3d(0.1f, 0.1f, 0.1f);
      _boxBoundMin = -_boxBoundMax;
      CollisionTester = new BoxShape(_boxBoundMax);
         */

    }

    private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      MRaycastTask _rayTask = (MRaycastTask)e.UserState;
      if (_rayTask != null)
      {
        _rayTask.Notify();
        _rayTask = null;
      }
    }

    //do all bullet related setup things on the bullet thread
    private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      collisionConf = new DefaultCollisionConfiguration();      
      //try 
      //dispatcher = new CollisionDispatcherMultiThreaded(collisionConf); //crashes
      dispatcher = new CollisionDispatcher(collisionConf);

      broadphase = new DbvtBroadphase();
      //ConstraintSolver solver = new MultiBodyConstraintSolver();
      ConstraintSolver solver = new MultiBodyConstraintSolver();      

      World = new DiscreteDynamicsWorld(dispatcher, broadphase, solver, collisionConf);
      World.SolverInfo.NumIterations = 8;      
      World.DispatchInfo.UseContinuous = true;
      World.DispatchInfo.UseEpa = false;

      World.Gravity = new Vector3d(0, -9.8, 0);

      World.DebugDrawer = _DebugDrawer;

      //CollisionTester = new SphereShape(0.2);
      Vector3d _boxBoundMin, _boxBoundMax;
      _boxBoundMax = new Vector3d(0.1f, 0.1f, 0.1f);
      _boxBoundMin = -_boxBoundMax;
      CollisionTester = new BoxShape(_boxBoundMax);

      DoPhysicsUpdate();
    }

    public void SetGravity(Vector3d g)
    {
      if (UseGravity == true)
      {
        World.Gravity = g;
      }
      else
      {
        World.Gravity = Vector3d.Zero;
      }
    }

    public void RayCastRequest(Vector3d From, Vector3d To, object UserObject, Action<MRaycastTask> d)
    {
      //if (_rayTask != null) return;

      MRaycastTask _rayTask = new MRaycastTask();
      _rayTask.From = From;
      _rayTask.To = To;
      _rayTask.UserObject = UserObject;
      _rayTask.Completion = d;
      RaycastsPending.Add(_rayTask);
    }

    public MRaycastTask RayCast(Vector3d From, Vector3d To)
    {
      MRaycastTask task = new MRaycastTask();
      task.From = From;
      task.To = To;
      Vector3d Result = To;
      ClosestRayResultCallback rc = new ClosestRayResultCallback();
      //rc.CollisionFilterMask = CollisionFilterGroups.StaticFilter;
      rc.ClosestHitFraction = 0.8;
      //AllHitsRayResultCallback       
      rc.RayFromWorld = From;
      rc.RayToWorld = To;

      World.RayTestRef(ref From, ref To, rc);

      if (rc.HasHit)
      {
        task.Result = true;
        task.Hitpoint = rc.HitPointWorld;
        task.Hitnormal = rc.HitNormalWorld;
        return task;
      }

      ClosestConvexResultCallback cc = new ClosestConvexResultCallback();
      //cc.CollisionFilterMask = CollisionFilterGroups.StaticFilter;      
      cc.ClosestHitFraction = 0.21;
      cc.ConvexFromWorld = From;
      cc.ConvexToWorld = To;
      cc.HitPointWorld = From;
      Matrix4d mf = Matrix4d.CreateTranslation(From);
      Matrix4d mt = Matrix4d.CreateTranslation(To);
      World.ConvexSweepTest(CollisionTester, mf, mt, cc);

      if (cc.HasHit == true)
      {
        task.Depth = Vector3d.Distance(From, cc.HitPointWorld);
        if (task.Depth > 0) task.Result = true;
        //task.Result = true;
        task.Hitpoint = cc.HitPointWorld;
        task.Hitnormal = cc.HitNormalWorld;
      }

      return task;
    }

    void DoRayCast(MRaycastTask task)
    {
      ClosestRayResultCallback rc = new ClosestRayResultCallback();
      //rc.CollisionFilterMask = CollisionFilterGroups.StaticFilter;
      rc.ClosestHitFraction = 0.8;
      //AllHitsRayResultCallback 
      if (task == null) return;
      rc.RayFromWorld = task.From;
      rc.RayToWorld = task.To;

      World.RayTestRef(ref task.From, ref task.To, rc);

      if (rc.HasHit)
      {
        task.Depth = Vector3d.Distance(task.From, rc.HitPointWorld);
        if (task.Depth > 0) task.Result = true;
        task.Info = rc.CollisionObject.UserObject;
        task.Hitpoint = rc.HitPointWorld;
        task.Hitnormal = rc.HitNormalWorld;
        return;
      }

      ClosestConvexResultCallback cc = new ClosestConvexResultCallback();
      //cc.CollisionFilterMask = CollisionFilterGroups.StaticFilter;
      cc.ClosestHitFraction = 0.21;
      cc.ConvexFromWorld = task.From;
      cc.ConvexToWorld = task.To;
      cc.HitPointWorld = task.From;
      Matrix4d mf = Matrix4d.CreateTranslation(task.From);
      Matrix4d mt = Matrix4d.CreateTranslation(task.To);
      World.ConvexSweepTest(CollisionTester, mf, mt, cc);

      if (cc.HasHit == true)
      { //task.info = cc.HitCollisionObject.UserObject;
        task.Depth = Vector3d.Distance(task.From, cc.HitPointWorld);
        if (task.Depth > 0) task.Result = true;
        task.Hitpoint = cc.HitPointWorld;
        task.Hitnormal = cc.HitNormalWorld;
        return;
      }

      task.Result = false;
      task.Hitpoint = task.From;
    }

    public static void UpdateAabbs()
    {
      Instance.World.UpdateAabbs();
    }

    public static void Add(MPhysicsObject po)
    {
      if (po != null)
      {
        Instance.AddQueue.Add(po);
      }
    }

    public void Remove(MPhysicsObject po)
    {
      if (po != null)
      {
        RemoveQueue.Add(po);
      }
    }

    public RigidBody Add(float mass, Matrix4d startTransform, CollisionShape shape)
    {
      bool isDynamic = (mass != 0.0f);

      Vector3d localInertia = Vector3d.Zero;
      if (isDynamic)
        shape.CalculateLocalInertia(mass, out localInertia);

      DefaultMotionState myMotionState = new DefaultMotionState(startTransform);

      RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, shape, localInertia);
      RigidBody body = new RigidBody(rbInfo);

      World.AddRigidBody(body);
      return body;
    }

    public void DisposeWorld()
    {
      //remove/dispose constraints
      if (World == null) return;
      if (World.IsDisposed) return;

      RaycastsPending.Clear();
      AddQueue.Clear();
      RemoveQueue.Clear();


      int i;
      for (i = World.NumConstraints - 1; i >= 0; i--)
      {
        TypedConstraint constraint = World.GetConstraint(i);
        if (constraint != null)
        {
          World.RemoveConstraint(constraint);
          constraint.Dispose();
        }
      }

      //remove the rigidbodies from the dynamics world and delete them
      for (i = World.NumCollisionObjects - 1; i >= 0; i--)
      {
        CollisionObject obj = World.CollisionObjectArray[i];
        if (obj == null) continue;
        RigidBody body = obj as RigidBody;
        if (body != null && body.MotionState != null)
        {
          body.MotionState.Dispose();
        }
        World.RemoveCollisionObject(obj);
        obj.Dispose();
      }

      //delete collision shapes
      //foreach (CollisionShape shape in collisionShapes)
      //{
      //        shape.Dispose();
      //}

      //collisionShapes.Clear();
      collisionConf.Dispose();
      collisionConf = null;
      if (dispatcher != null)
      {
        dispatcher.Dispose();
      }
      dispatcher = null;

      World.Dispose();

      broadphase.Dispose();
      broadphase = null;


      World = null;
      Instance = null;
      base.Dispose();
    }

    public override void Render(Matrix4d viewproj, Matrix4d parentmodel)
    {
      base.Render(viewproj, parentmodel);
      if ((World != null) && (DebugWorld == true))
      {
        lock (World.CollisionObjectArray)
        {
          //TODO: unstable
          foreach (CollisionObject co in World.CollisionObjectArray)
          {  
            
            if ( co.UserObject != null)
            {
              MSceneObject mso = (MSceneObject)co.UserObject;
              if ( mso != null)
              {
                if (mso.Type == EType.Terrain) continue; //very heavy, rather skip               
              }
            }
           // if (co.CollisionShape.IsConvex)
            {
             // Console.WriteLine(co.UserObject.ToString());
              World.DebugDrawObject(co.WorldTransform, co.CollisionShape, Color4.AntiqueWhite);
            }
          }
        }
        // World.DebugDrawWorld();

        _DebugDrawer.Render(viewproj, parentmodel);
      }
    }

    public void DoPhysicsUpdate()
    {
      //BackgroundWorker worker = (BackgroundWorker)sender;
      while (!_backgroundWorker.CancellationPending)
      //while (Globals.ApplicationExiting == false)
      {

        if (Globals.ApplicationExiting == true)
        {
          _backgroundWorker.CancelAsync();
          return;
        }

        if (RaycastsPending.Count > 0)
        {
          for (int i = 0; i < RaycastsPending.Count; i++)
          {
            MRaycastTask t = RaycastsPending[0];
            RaycastsPending.RemoveAt(0);
            DoRayCast(t);
            _backgroundWorker.ReportProgress(0, t);
          }
        }

        if (AddQueue.Count > 0)
        {
          MPhysicsObject po = AddQueue[0];
          AddQueue.RemoveAt(0);
          if (!World.CollisionObjectArray.Contains(po._rigidBody))
          {
            World.AddRigidBody(po._rigidBody);
          }
        }

        if (RemoveQueue.Count > 0)
        {
          MPhysicsObject po = RemoveQueue[0];
          RemoveQueue.RemoveAt(0);
          World.RemoveRigidBody(po._rigidBody);
        }

        if (World != null)
        {
          try
          {
            World.StepSimulation(Time.DeltaTime, 10);
          }
          catch (Exception e)
          {
            Console.Error.WriteLine("EXCEPTION: MPhysics StepSimulation : " + e.Message);
          }
        }
        Thread.Sleep(3);
      }
      Thread.Sleep(100);
      DisposeWorld();
    }
  }
}
