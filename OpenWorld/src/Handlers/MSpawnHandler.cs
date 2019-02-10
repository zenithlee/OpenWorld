using Massive;
using Massive.Events;
using Massive.Network;
using Massive.Tools;
using OpenTK;
using OpenWorld.Widgets;
using OpernWorld.Widgets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.Handlers
{
  public class MSpawnHandler
  {
    public MSpawnHandler()
    {
      Globals.Network.SpawnHandler += Network_SpawnHandler;
    }

    private void Network_SpawnHandler(object sender, Massive.Events.ObjectSpawnedEvent e)
    {
      DataTable dt = e.SpawnedObject;

      foreach (DataRow dr in dt.Rows)
      {
        MServerObject mso = MServerObject.UnpackFromDataRow(dt.Columns, dr);
        if (mso == null) continue;
        Spawn(mso);
      }
    }

    static MPhysicsObject.EShape GetShape(string sShape)
    {
      switch (sShape)
      {
        case "Capsule": return MPhysicsObject.EShape.Capsule;
        case "Sphere": return MPhysicsObject.EShape.Sphere;
        case "Box": return MPhysicsObject.EShape.Box;
        case "ConcaveMesh": return MPhysicsObject.EShape.ConcaveMesh;
        case "ConvexHull": return MPhysicsObject.EShape.ConvexHull;
        case "HACD": return MPhysicsObject.EShape.HACD;
        default: return MPhysicsObject.EShape.Sphere;
      }
    }

    public static MSceneObject LoadTemplate(string TemplateID)
    {
      MBuildingBlock bb = MBuildParts.GetBlock(TemplateID);
      if (bb == null) return null;

      MSceneObject o = null;
      if (bb.Type == MBuildParts.MModel)
      {
        o = Helper.CreateModel(MScene.TemplateRoot, TemplateID, bb.Model, Vector3d.Zero);
        o.TemplateID = TemplateID;
        o.InstanceID = TemplateID;
        o.IsTransparent = bb.IsTransparent;

        MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName(bb.MaterialID);
        o.SetMaterial(mat);

        Vector3d size = MassiveTools.VectorFromArray(bb.Size);

        MPhysicsObject.EShape shape = GetShape(bb.PhysicsShape);

        MPhysicsObject mpo = new MPhysicsObject(o, TemplateID + "_physics", bb.Weight, shape,
          true, size);
        mpo.SetDamping(0.7, 0.5);
        mpo.SetRestitution(0.5);
        mpo.SetSleep(15);
        mpo.SetFriction(0);
        mpo.SetAngularFactor(0.0, 0.0, 0.0);
        o.Setup();
      }

      if (bb.SubModule == "MDoor")
      {
        MDoor door = new MDoor(o);
        o.Add(door);
      }

      if (bb.SubModule == "MLinker")
      {
        MLinker link = new MLinker();
        o.Add(link);
        MClickHandler mc = new MClickHandler();
        mc.DoubleClicked = MLinkerWidget.Mc_DoubleClick;
        mc.RightClicked = MLinkerWidget.Mc_RightClick;
        o.Add(mc);
        o.Tag = "LINKER01|URL:";
      }

      if (bb.SubModule == "MTeleporter")
      {
        MClickHandler mc = new MClickHandler();
        mc.DoubleClicked = MTeleporterWidget.Mc_DoubleClick;
        mc.RightClicked = MTeleporterWidget.Mc_RightClick;
        o.Add(mc);
        o.Tag = "TELEPORTER01|XYZ:";
      }

      if (bb.SubModule == "MPicture")
      {
        MClickHandler mc = new MClickHandler();
        mc.DoubleClicked = MPictureWidget.Mc_DoubleClick;
        mc.RightClicked = MPictureWidget.Mc_RightClick;
        o.Add(mc);
        o.Tag = "PICTURE01|This Picture|Description";
      }

      return o;
    }

    /// <summary>
    /// Prepares an object for inclusion in the scene graph
    /// If the template does not exist, it is created first
    /// </summary>
    /// <param name="m"></param>
    public void Spawn(MServerObject m)
    {
      MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(m.InstanceID);
      if (mo != null) return;
      MSceneObject mt = (MSceneObject)MScene.TemplateRoot.FindModuleByName(m.TemplateID);
      if (mt == null)
      {
        LoadTemplate(m.TemplateID);
      }

      //if ((m.Name == Globals.UserAccount.UserID) && ( m.OwnerID == Globals.UserAccount.UserID)){
      mo = Helper.Spawn(m.TemplateID, m.OwnerID, m.Name, m.Tag,
          MassiveTools.VectorFromArray(m.Position),
          MassiveTools.QuaternionFromArray(m.Rotation));
      if (mo == null)
      {
        Console.WriteLine("MSpawnHandler: Template not found:" + m.TemplateID);
      }
      else
      {
        mo.InstanceID = m.InstanceID;
        mo.SetRotation(MassiveTools.QuaternionFromArray(m.Rotation));
        if (mo.InstanceID == Globals.UserAccount.UserID)
        {
          Globals.Avatar.SetSceneObject(mo);
        }
        SetMaterial(mo, m.TextureID);
      }

      if (mo.OwnerID == Globals.UserAccount.UserID)
      {
        MMessageBus.Select(this, new SelectEvent(mo));
      }

    }

    void SetMaterial(MSceneObject mo, string sMaterialID)
    {
      //MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(e.InstanceID);
      MObject o = MScene.MaterialRoot.FindModuleByName(sMaterialID);
      MMaterial mat = null;
      
      if (o != null && o.Type == MObject.EType.Material)
      {
        mat = (MMaterial)o;
        if (mat != null)
        {
          mo.SetMaterial(mat);
          mat.MaterialID = sMaterialID;
        }
      }

      if (MassiveTools.IsURL(sMaterialID))
      {
        mat = (MMaterial)new MMaterial("URLShader");
        MShader DefaultShader = (MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER);
        mat.AddShader(DefaultShader);
        mat.ReplaceTexture(Globals.TexturePool.GetTexture(sMaterialID));
        MScene.MaterialRoot.Add(mat);
        mo.SetMaterial(mat);
        mo.material.Setup();
      }
    }
  }
}
