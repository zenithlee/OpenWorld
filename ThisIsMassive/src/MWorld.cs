using Massive;
using Massive.Network;
using Massive.Events;
using Massive.Tools;
using MassiveUniverse;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.src.Handlers;
using ThisIsMassive.Widgets;
using System.IO;

namespace ThisIsMassive.src
{
  class MWorld
  {
    List<MSceneObject> Objects = new List<MSceneObject>();

    public MSceneObject Selected;
    MSound UISound;
    MNavigationPointer Navi;

    MLightHandler _lightHandler;
    MServerDataHandler _ServerDataHandler;

    bool Dirty = false;

    public object ZoneHandler { get; private set; }

    public MWorld()
    {
      //AddWall();     

      MMessageBus.CreateObjectRequestHandler += MMessageBus_SpawnObjectRequestHandler;
      MMessageBus.MoveRequestEventHandler += MMessageBus_MoveObjectRequestEventHandler;
      MMessageBus.MoveAvatarRequestEventHandler += MMessageBus_MoveAvatarRequestEventHandler;
      MMessageBus.RotateEventHandler += MMessageBus_RotateEventHandler;
      MMessageBus.SelectEventHandler += MMessageBus_SelectEventHandler;
      MMessageBus.FocusEventHandler += MMessageBus_FocusEventHandler;

      MMessageBus.ObjectCreatedHandler += Network_ObjectSpawned;
      MMessageBus.DeleteObjectRequestHandler += MMessageBus_DeleteObjectRequestHandler;
      MMessageBus.TextureRequestHandler += MMessageBus_TextureRequestHandler;
      //MMessageBus.UpdateHandler += MMessageBus_UpdateHandler;
      MMessageBus.ChangeAvatarRequestHandler += MMessageBus_ChangeAvatarRequestHandler;
      MMessageBus.AvatarChangedHandler += MMessageBus_AvatarChangedHandler;
      MMessageBus.ObjectMovedEvent += ObjectPositionChanged;
      MMessageBus.ObjectDeletedEvent += ObjectDeletedHandler;

      Globals.Network.LoggedInHandler += Network_LoggedInHandler;
      Globals.Network.LoggedOutHandler += Network_LoggedOutHandler;
      Globals.Network.TeleportHandler += Network_TeleportHandler;
      //Globals.Network.ObjectSpawned += Network_ObjectSpawned;
      //Globals.Network.DeletedHandler += Network_DeletedHandler;      

      Globals.Network.TextureHandler += Network_TextureHandler;
    }

    private void Network_TeleportHandler(object sender, MoveEvent e)
    {
      throw new NotImplementedException();
    }

    public void Setup()
    {
      SetupTemplates();
      Navi = new MNavigationPointer();
      Navi.Setup();
      //MScene.UtilityRoot.Add(Navi);
      _lightHandler = new MLightHandler();
      _ServerDataHandler = new MServerDataHandler();
    }

    //should be called after world is loaded
    public void AddAvatar()
    {
      MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
    }

    private void MMessageBus_ChangeAvatarRequestHandler(object sender, ChangeAvatarEvent e)
    {
      if (string.IsNullOrEmpty(Globals.UserAccount.AvatarID))
      {
        Globals.UserAccount.AvatarID = BuildParts.AVATAR01;
      }
      if (Globals.Avatar == null) return;
      //Vector3d pos = new Vector3d(Globals.UserAccount.HomePosition[0], Globals.UserAccount.HomePosition[1], Globals.UserAccount.HomePosition[2]); ;
      //if (Globals.Avatar.Target != null)
      //{
        //pos = Globals.Avatar.Target.transform.Position;
      //}

      //Globals.Network.DeleteRequest(Globals.UserAccount.UserID);

      //TODO: these may not happen sequentially, create a change avatar request
      //Quaterniond rot = Extensions.LookAt(pos, pos + Globals.LocalUpVector, Vector3d.UnitY)
       //* Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0);

      //Globals.Network.SpawnRequest(Globals.UserAccount.AvatarID, Globals.UserAccount.AvatarID + "T", Globals.UserAccount.UserName, "",
      //pos, rot, Globals.UserAccount.UserID, MServerObject.DYNAMICSTORAGE, 2);
      Globals.Network.ChangeAvatarRequest(Globals.UserAccount.UserID, e.TemplateID);
    }

    private void MMessageBus_AvatarChangedHandler(object sender, ChangeAvatarEvent e)
    {
      //delete the existing avatar      
      Vector3d pos = MassiveTools.VectorFromArray(Globals.UserAccount.HomePosition);
      DeleteObject(e.UserID);
      //MMessageBus.CreateObjectRequest(this, e.TemplateID);
      
      Globals.Network.SpawnRequest(e.TemplateID, e.TemplateID + "T", e.TemplateID, "", 
        pos, 
        Globals.Avatar.GetRotation(), e.UserID, 0, 2);
    }

    private void Network_LoggedOutHandler(object sender, LoggedOutEvent e)
    {
      DeleteObject(e.UserID);
    }

    private void Network_LoggedInHandler(object sender, ChangeDetailsEvent e)
    {

    }

    private void MMessageBus_TextureRequestHandler(object sender, TextureRequestEvent e)
    {
      if (Selected == null) return;
      //TextureID can be a local resource ID or a URL
      Globals.Network.TextureRequest(Selected.InstanceID, e.TextureID);
    }

    private void Network_TextureHandler(object sender, TextureEvent e)
    {
      MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(e.InstanceID);

      if (MassiveTools.IsURL(e.TextureID))
      {
        MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName(e.TextureID);
        if (mat == null)
        {
          mat = new MMaterial(e.TextureID);
          MShader WallShader = (MShader)MScene.MaterialRoot.FindModuleByName("WallShader");
          MTexture tex = Globals.TexturePool.GetTexture(e.TextureID);
          mat.AddShader(WallShader);
          mat.SetDiffuseTexture(tex);
          MScene.MaterialRoot.Add(mat);
          //mo.material.Setup();

        }
        mo.SetMaterial(mat);
      }
      else
      {
        MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName(e.TextureID);
        if (mo != null)
        {
          mo.SetMaterial(mat);
        }
        else
        {
          Console.WriteLine("Object " + e.InstanceID + " was null");
        }

      }

      //Console.WriteLine("Texture:" + e.TextureID + " for :" + mo.InstanceID);
    }

    private void MMessageBus_RotateEventHandler(object sender, RotationRequestEvent e)
    {
      if (Selected == null) return;

      Globals.Network.PositionRequest(Selected.InstanceID, Selected.transform.Position, Selected.transform.Rotation * e.Rotation);
    }

    /**
     * From UI build panel
     * */
    private void MMessageBus_MoveObjectRequestEventHandler(object sender, MoveEvent e)
    {
      if (Selected == null) return;
      Globals.Network.PositionRequest(Selected.InstanceID, e.Position, Selected.transform.Rotation);
    }

    private void MMessageBus_MoveAvatarRequestEventHandler(object sender, MoveEvent e)
    {      
      Globals.Network.PositionRequest(Globals.UserAccount.UserID, e.Position, e.Rotation);
    }

    private void ObjectPositionChanged(object sender, MoveEvent e)
    {
      if (!e.InstanceID.Equals(Globals.UserAccount.UserID))
      {
        if (MScene.ModelRoot == null) return;
        MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(e.InstanceID);
        if (mo != null)
        {
          //
          //MNetworkObject mn = (MNetworkObject)mo.FindModuleByType(MObject.EType.NetworkObject);
          //if (mn == null)
          {
            //if (e.Rotation != Quaterniond.Identity)
            //{
//              mo.SetRotation(e.Rotation);
  //          }
            MMoveSync ms = (MMoveSync)mo.FindModuleByType(MObject.EType.MoveSync);
            if (ms == null)
            {
              ms = new MMoveSync(mo, e.Position, e.Rotation);
              mo.Add(ms);
            }
            else
            {
              ms.SetTarget(e.Position, e.Rotation);
            }
          }
        }
      }
      else
      {
        MMessageBus.AvatarMoved(this, e.InstanceID, e.Position, e.Rotation);
      }
    }

    void DeleteObject(string InstanceID)
    {
      MObject mo = MScene.Root.FindModuleByInstanceID(InstanceID);
      if (mo == null) return;

      MScene.SelectionRoot.Remove(mo);
      MPointLight pl = (MPointLight)mo.FindModuleByType(MObject.EType.PointLight);
      if (pl != null)
      {
        MScene.LightRoot.Remove(pl);
        pl.Dispose();
      }
      MScene.ModelRoot.Remove(mo);
      MScene.Priority1.Remove(mo);
      MScene.Priority2.Remove(mo);

      MPhysicsObject po = (MPhysicsObject)mo.FindModuleByType(MObject.EType.PhysicsObject);
      MScene.Physics.Remove(po);

      //TODO: don't dispose shared textures
      //mo.Dispose();

      Selected = null;
    }

    private void ObjectDeletedHandler(object sender, DeleteEvent e)
    {
      DeleteObject(e.InstanceID);
    }

    private void MMessageBus_DeleteObjectRequestHandler(object sender, DeleteRequestEvent e)
    {
      MSceneObject mo = e.TargetObject;
      if ((mo == null) && (Selected != null))
      {
        mo = Selected;
      }

      if (mo != null)
      {
        Globals.Network.DeleteRequest(mo.InstanceID);
      }
    }


    void SetAsAvatar(MSceneObject mo)
    {
      MMessageBus.Status(this, "Set as Avatar " + mo.InstanceID);
      Selected = null;
      if (Globals.Avatar.Target != null)
      {
        //MScene.Priority2.Remove(Globals.Avatar.Target);
      }
      Globals.Avatar.SetSceneObject(mo);
      mo.Visible = true;
      mo.Add(UISound);
      //mo.SetRotation(MPlanetHandler.FwdDir(mo.transform.Position));

      MMessageBus.AvatarSetup(this);
    }

    // don't call directly, call via MessageBus
    void Select(MSceneObject mo)
    {
      if (Selected != null)
      {
        Selected.Selected = false;
        MScene.SelectionRoot.Remove(Selected);
      }

      Selected = mo;
      if ((Selected != null) && (Globals.UserAccount.UserID.Equals(mo.OwnerID)))
      {
        MScene.SelectionRoot.Add(Selected);
        Selected.Selected = true;
      }
      MScene.Root.OnSelected(mo);
    }

    private void MMessageBus_SpawnObjectRequestHandler(object sender, CreateObjectRequestEvent e)
    {
      Vector3d Offset = Globals.LocalUpVector;
      if (e.ServerObject.TemplateID.Equals(BuildParts.FOUNDATION01))
      {
        Offset = -Globals.LocalUpVector;
      }

      Vector3d pos = Vector3d.Zero;
      Quaterniond rot = Quaterniond.Identity;

      if (e.ServerObject.TemplateID.Equals(BuildParts.DUPLICATE))
      {
        if (Selected != null)
        {
          e.ServerObject.TemplateID = Selected.TemplateID;
          pos = Selected.transform.Position;
          rot = Selected.transform.Rotation;

          MTexture tex = (MTexture)Selected.FindModuleByType(MObject.EType.Texture);
          if (tex != null)
          {
            e.ServerObject.TextureID = tex.Filename;
          }
        }
      }
      else
      {
        pos = Globals.Avatar.Target.transform.Position
          + Globals.Avatar.Target.transform.Forward() * 4 + Offset;
        pos.X = Math.Round(pos.X);
        pos.Y = Math.Round(pos.Y);
        pos.Z = Math.Round(pos.Z);


        //try to find a foundation to orient to
       // MSceneObject mo = Helper.FindNearestObject(Globals.Avatar.GetPosition(), BuildParts.FOUNDATION01);
        //if ( mo == null )
       // {
          rot = Globals.LocalUpRotation();
       // }
        //else
       // {
          //rot = mo.transform.Rotation;
        //}
        
        Vector3d rounded = new Vector3d(pos);
        rounded.X = Math.Round(pos.X);
        rounded.Y = Math.Round(pos.Y);
        rounded.Z = Math.Round(pos.Z);
      }
      
      if (string.IsNullOrEmpty(e.ServerObject.Tag))
      {
        MSceneObject mTemplate = (MSceneObject)MScene.TemplateRoot.FindModuleByInstanceID(e.ServerObject.TemplateID);
        if (mTemplate != null)
        {
          e.ServerObject.Tag = (string)mTemplate.Tag;
          if (string.IsNullOrEmpty(e.ServerObject.TextureID))
          {
            MMaterial mat = (MMaterial)mTemplate.FindModuleByType(MObject.EType.Material);
            if (mat != null)
            {
              e.ServerObject.TextureID = mat.Name;
            }
          }
        }
      }

      Globals.Network.SpawnRequest(e.ServerObject.TemplateID, e.ServerObject.TextureID, e.ServerObject.TemplateID, e.ServerObject.Tag, pos, rot);
    }

    private void Network_ObjectSpawned(object sender, CreateEvent e)
    {
      MSceneObject mo = (MSceneObject)e.CreatedObject;
      if (mo.InstanceID.Equals(Globals.UserAccount.UserID))
      {
        SetAsAvatar(mo);
      }
      else
      {
        if (mo.IsAvatar == false)
        {
          if (mo.OwnerID.Equals(Globals.UserAccount.UserID))
          {
            MMessageBus.Select(this, mo);
          }
        }
        else
        {
          mo.SetRotation(Globals.LocalUpRotation() * Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0));
        }
      }
    }

    private void MMessageBus_FocusEventHandler(object sender, FocusEvent e)
    {
      if (Selected != null)
      {
        if (e.FocusObject == null)

          MScene.Camera.Target.transform.Position = Selected.transform.Position;
      }
      else
      {
        MScene.Camera.Target.transform.Position = e.FocusObject.transform.Position;
      }
    }

    private void MMessageBus_SelectEventHandler(object sender, SelectEvent e)
    {
      UISound.Play(MScene.audioListener);
      Select(e.Selected);
    }

    void SetupTemplates()
    {
      MShader WallShader = new MShader("WallShader");
      WallShader.Load("Shaders\\default_v.glsl",
        "Shaders\\default_f.glsl",
        "Shaders\\Terrain\\eval.glsl",
        "Shaders\\Terrain\\control.glsl"
        );
      WallShader.Bind();
      WallShader.SetInt("material.diffuse", MShader.LOCATION_DIFFUSE);
      WallShader.SetInt("material.specular", MShader.LOCATION_SPECULAR);
      WallShader.SetInt("material.multitex", MShader.LOCATION_MULTITEX);
      WallShader.SetInt("material.normalmap", MShader.LOCATION_NORMALMAP);
      WallShader.SetInt("material.shadowMap", MShader.LOCATION_SHADOWMAP);

      MMaterial WhiteT = new MMaterial("WHITEM");
      WhiteT.AddShader(WallShader);
      WhiteT.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\white.jpg"));
      MScene.MaterialRoot.Add(WhiteT);

      MMaterial WallMat = new MMaterial("TEXTURE01T");
      WallMat.AddShader(WallShader);
      WallMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\wall01.jpg"));
      MScene.MaterialRoot.Add(WallMat);

      MMaterial Wall2Mat = new MMaterial("TEXTURE02T");
      Wall2Mat.AddShader(WallShader);
      Wall2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\wall02.jpg"));
      MScene.MaterialRoot.Add(Wall2Mat);

      MMaterial FloorMat = new MMaterial("TEXTURE03T");
      FloorMat.AddShader(WallShader);
      FloorMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\worktops001.jpg"));
      MScene.MaterialRoot.Add(FloorMat);

      MMaterial Floor2Mat = new MMaterial("FLOOR02T");
      Floor2Mat.AddShader(WallShader);
      Floor2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\floor02.jpg"));
      MScene.MaterialRoot.Add(Floor2Mat);

      MMaterial Floor3Mat = new MMaterial("FLOOR03T");
      Floor3Mat.AddShader(WallShader);
      Floor3Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\floor03.jpg"));
      MScene.MaterialRoot.Add(Floor3Mat);

      MMaterial Floor4Mat = new MMaterial("FLOOR04T");
      Floor4Mat.AddShader(WallShader);
      Floor4Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\floor04.jpg"));
      MScene.MaterialRoot.Add(Floor4Mat);

      MMaterial Terrain01M = new MMaterial("TERRAIN01M");
      Terrain01M.AddShader(WallShader);
      Terrain01M.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\terrain\\grass01.jpg"));
      MScene.MaterialRoot.Add(Terrain01M);

      MMaterial CeilingMat = new MMaterial("CEILING01T");
      CeilingMat.AddShader(WallShader);
      CeilingMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\floor01.jpg"));
      MScene.MaterialRoot.Add(CeilingMat);         

      MMaterial Door01Mat = new MMaterial("DOOR01T");
      Door01Mat.AddShader(WallShader);
      Door01Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\door01.jpg"));
      MScene.MaterialRoot.Add(Door01Mat);

      MMaterial Door02Mat = new MMaterial("DOOR02T");
      Door02Mat.AddShader(WallShader);
      Door02Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\door02.jpg"));
      MScene.MaterialRoot.Add(Door02Mat);

      MMaterial Door03Mat = new MMaterial("DOOR03T");
      Door03Mat.AddShader(WallShader);
      Door03Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\door03.jpg"));
      MScene.MaterialRoot.Add(Door03Mat);

      //////////// PRIMITIVES //////////////////
      MModel cube01 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.CUBE01, @"Models\cube01.3ds", new Vector3d(0, 0, 0));
      cube01.InstanceID = BuildParts.CUBE01;
      cube01.TemplateID = BuildParts.CUBE01;
      cube01.transform.Scale = new Vector3d(1, 1, 1);
      cube01.SetMaterial(WhiteT);
      MPhysicsObject poc = new MPhysicsObject(cube01, "CUBE01", 0f, MPhysicsObject.EShape.Box, true, cube01.transform.Scale * 0.5);


      MModel wedge01 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.WEDGE01, @"Models\wedge01.3ds", new Vector3d(0, 0, 0));
      wedge01.InstanceID = BuildParts.WEDGE01;
      wedge01.TemplateID = BuildParts.WEDGE01;
      wedge01.transform.Scale = new Vector3d(0.5, 0.5, 0.5);
      wedge01.SetMaterial(WhiteT);
      MPhysicsObject powedge = new MPhysicsObject(wedge01, "WEDGE01", 0f, MPhysicsObject.EShape.ConvexHull, true, wedge01.transform.Scale);
      powedge.SetRestitution(1);


      MSphere Sphere01 = Helper.CreateSphere(MScene.TemplateRoot, 2, BuildParts.SPHERE01, Vector3d.Zero);
      Sphere01.transform.Scale = new Vector3d(1, 1, 1);
      Sphere01.InstanceID = BuildParts.SPHERE01;
      Sphere01.TemplateID = BuildParts.SPHERE01;
      Sphere01.CastsShadow = false;
      MMaterial mlight = (MMaterial)MScene.MaterialRoot.FindModuleByName("WHITEM");
      mlight.IsSky = 1;
      mlight.Opacity = 0.5;
      Sphere01.SetMaterial(mlight);
      MPointLight mps = new MPointLight("PointLight");
      Sphere01.Add(mps);
      MPhysicsObject pp3 = new MPhysicsObject(Sphere01, "PICPO", 0.1f, MPhysicsObject.EShape.Sphere, true, Sphere01.transform.Scale);
      pp3.SetRestitution(0.95);
      pp3.SetDamping(0.01, 0.1);

      
      /////////////// BUILDING PARTS ///////////////////////


      /////////////////////// TELEPORT ///////////////////////
      MModel Teleporter = Helper.CreateModel(MScene.TemplateRoot, BuildParts.TELEPORT01, @"Models\teleport01.3ds", Vector3d.Zero);
      //MCube floor01 = Helper.CreateCube(MScene.TemplateRoot, BuildParts.FLOOR01);
      Teleporter.InstanceID = BuildParts.TELEPORT01;
      Teleporter.TemplateID = BuildParts.TELEPORT01;
      Teleporter.transform.Scale = new Vector3d(1, 1.0, 1);
      Teleporter.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName("FLOOR03T"));
      Teleporter.Tag = "TELEPORT|mars|Hello";
      MPhysicsObject poft = new MPhysicsObject(Teleporter, "FLOOPO", 0f, MPhysicsObject.EShape.Box, true, Teleporter.transform.Scale);
      MClickHandler mc = new MClickHandler();
      mc.DoubleClicked = MTeleporterWidget.Mc_DoubleClick;
      Teleporter.Add(mc);
      //floor01.Setup();

      MMaterial DefaultMat = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);

      MModel mWall01 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.WALL01, @"Models\wall01.3ds", Vector3d.Zero);
      mWall01.InstanceID = BuildParts.WALL01;
      mWall01.TemplateID = BuildParts.WALL01;
      mWall01.SetMaterial(DefaultMat);
      MPhysicsObject pow = new MPhysicsObject(mWall01, "WALLPO", 0f, MPhysicsObject.EShape.Box, true, new Vector3d(1, 1.5, 0.1));
      

      MModel mWall03 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.WALL03, @"Models\wall03.3ds", Vector3d.Zero);
      mWall03.InstanceID = BuildParts.WALL03;
      mWall03.TemplateID = BuildParts.WALL03;
      mWall03.SetMaterial(DefaultMat);
      MPhysicsObject pow3 = new MPhysicsObject(mWall03, "WALLPO3", 0f, MPhysicsObject.EShape.Box, true, new Vector3d(3, 1.5, 0.1));
      

      MModel mWindow01 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.WINDOW01, @"Models\window01.3ds", Vector3d.Zero);
      mWindow01.InstanceID = BuildParts.WINDOW01;
      mWindow01.TemplateID = BuildParts.WINDOW01;
      mWindow01.SetMaterial(DefaultMat);
      MPhysicsObject poww = new MPhysicsObject(mWindow01, "WALLPO", 0f, MPhysicsObject.EShape.Box, true, new Vector3d(1, 1.5, 0.1));
      
      // m.Setup();

      MModel mCeiling = Helper.CreateModel(MScene.TemplateRoot, BuildParts.CEILING01, @"Models\ceiling01.3ds", Vector3d.Zero);
      mCeiling.InstanceID = BuildParts.CEILING01;
      mCeiling.TemplateID = BuildParts.CEILING01;
      mCeiling.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName("CEILING01T"));
      MPhysicsObject poc1 = new MPhysicsObject(mCeiling, "CEILPO", 0f, MPhysicsObject.EShape.Box, true, new Vector3d(1, 0.1, 1));
      //mCeiling.Setup();

     
      // pp2.SetRestitution(0.1);

     

      //helper object to show where the main light is located
      MSphere LightSphere = Helper.CreateSphere(MScene.ModelRoot, 1, "LightSphere");
      LightSphere.transform.Scale = new Vector3d(0.1, 0.1, 0.1);
      MMaterial lgihtmat = (MMaterial)MScene.MaterialRoot.FindModuleByName("WHITEM");
      LightSphere.SetMaterial(lgihtmat);
      LightSphere.CastsShadow = false;

      BuildParts.CreateTemplates();

      UISound = new MSound();
      UISound.Volume = 0.1f;
      MScene.UtilityRoot.Add(UISound);
      //UISound.Loop = true;
      UISound.Load(Path.Combine(Globals.AssetsPath, "Audio\\click.wav"));

      MScene.Fog.Enabled = true;

      //MPointLight pl = new MPointLight("PointLight");
      //pl.transform.Position = new Vector3d(-2.74, 0.70, -8.21);
      //MScene.LightRoot.Add(pl);      
      SetupAvatars();
    }

    void SetupAvatars()
    {
      MShader WallShader = (MShader)MScene.MaterialRoot.FindModuleByName("WallShader");

      MMaterial AvatarMat = new MMaterial("AVATAR01T");
      AvatarMat.AddShader(WallShader);
      AvatarMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar01.jpg"));
      MScene.MaterialRoot.Add(AvatarMat);

      MMaterial Avatar2Mat = new MMaterial("AVATAR02T");
      Avatar2Mat.AddShader(WallShader);
      Avatar2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar02.jpg"));
      MScene.MaterialRoot.Add(Avatar2Mat);

      MMaterial Avatar3Mat = new MMaterial("AVATAR03T");
      Avatar3Mat.AddShader(WallShader);
      Avatar3Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar02.jpg"));
      MScene.MaterialRoot.Add(Avatar3Mat);

      //MBoneModel bm = new MBoneModel();
      //bm.Setup();

      

    }

    public void AddModel(string sFile)
    {
      MModel m = new MModel();
      m.OwnerID = Globals.UserAccount.UserID;
      m.Load(sFile);

      m.transform.Position += new Vector3d(0, 1, 0);
      MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName("FLOOR01");
      m.SetMaterial(mat);
      MScene.ModelRoot.Add(m);
    }   

    public void UpdatePositionTick()
    {
      {
        if (Globals.Avatar.Target != null)
        {
          //_Avatar.transform.Position = MScene.Camera.transform.Position + new Vector3d(0, 2, 0);
          //Globals.Network.PositionRequest(Globals.Avatar.Target.InstanceID, Globals.Avatar.Target.transform.Position, Globals.Avatar.Target.transform.Rotation);
        }
        Dirty = false;
      }
    }
  }
}
