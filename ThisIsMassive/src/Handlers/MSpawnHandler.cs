using Massive;
using Massive.Network;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MassiveNetwork;

namespace ThisIsMassive.src.Handlers
{
  public class MSpawnHandler
  {
    public MSpawnHandler()
    {
      Globals.Network.SpawnHandler += Network_SpawnHandler;
    }

    MSceneObject SpawnModelFromURL(MServerObject mp)
    {
      Globals.Log(this, "Downloading scene files... please wait...");
      MModelURL mu = MModelURL.Deserialize<MModelURL>(mp.Tag);
      MRemoteModel rmo = Helper.CreateModelURL(MScene.ModelRoot, mu.ModelURL, mu.TextureURL, mp.OwnerID, mp.Name,
        MassiveTools.VectorFromArray(mp.Position), MassiveTools.QuaternionFromArray(mp.Rotation));
      rmo.ReadyEvent += Rmo_ReadyEvent;
      rmo.InstanceID = mp.InstanceID;
      return rmo;
    }

    /**
     * Creates a copy of an object in the TemplateRoot, with new params
     * 
     * */
    private void Network_SpawnHandler(object sender, ObjectSpawnedEvent e)
    {
      DataTable dt = e.SpawnedObject;

      foreach(DataRow dr in dt.Rows)
      {
        MServerObject mso = MServerObject.UnpackFromDataRow(dt.Columns, dr);
        if (mso == null) continue;
        Spawn(mso);
      }      
    }

    void Spawn(MServerObject mp)
    { 
      // Console.WriteLine("SPAWN:" + mp.InstanceID + " : " + mp.Name + " : " + mp.Tag);
      //check if the object is already in the scene
      MSceneObject mo = (MSceneObject)MScene.Root.FindModuleByInstanceID(mp.InstanceID);
      if (mo == null)
      {
        Quaterniond rot = Quaterniond.FromEulerAngles(Globals.LocalUpVector);

        if (mp.TemplateID.Equals(MServerObject.MODELURL))
        {
          mo = SpawnModelFromURL(mp);
        }
        else
        {
          mo = Helper.Spawn(mp.TemplateID, mp.OwnerID, mp.Name, mp.Tag,
          new Vector3d(mp.Position[0], mp.Position[1], mp.Position[2]),
          new Quaterniond(mp.Rotation[0], mp.Rotation[1], mp.Rotation[2], mp.Rotation[3])
         );
        }
      }
      else
      {
        //don't spawn an object that already exists
        return;
      }

      if (mo == null)
      {
        Console.WriteLine("SpawnCheck: Object " + mp.Name + " not found");
        return;
      }

      mo.SetPosition(MassiveTools.VectorFromArray(mp.Position));

      mo.Name = mp.Name;
      mo.InstanceID = mp.InstanceID;
      mo.OwnerID = mp.OwnerID;

      AttachTexture(mo, mp);


      MMessageBus.Created(this, mo);
    }

    void AttachTexture(MSceneObject mo, MServerObject ms)
    {
      MMaterial mat = null;

      if (ms.TextureID != null)
      {
        MObject mmat = MScene.MaterialRoot.FindModuleByName(ms.TextureID);
        if ((mmat != null) && (mmat.Type == MObject.EType.Material))
        {
          mat = (MMaterial)mmat;
        }

        if ((mmat != null) && (mmat.Type == MObject.EType.Texture))
        {
          mat = (MMaterial)mmat.Parent;
        }

        if (mat == null)
        {
          if (MassiveTools.IsURL(ms.TextureID))
          {
            mat = new MMaterial(ms.TextureID);
            MShader DefaultShader = (MShader)MScene.MaterialRoot.FindModuleByName("DefaultShader");
            mat.AddShader(DefaultShader);
            mat.ReplaceTexture(Globals.TexturePool.GetTexture(ms.TextureID));
            MScene.MaterialRoot.Add(mat);
            mo.SetMaterial(mat);
            mo.material.Setup();
          }
          else
          {
            //mat = (MMaterial)MScene.MaterialRoot.FindModuleByName("DefaultMaterial");
          }
        }
        mo.SetMaterial(mat);
      }

      if (mat == null)
      {
        mat = (MMaterial)MScene.MaterialRoot.FindModuleByName("DefaultMaterial");
      }
      mo.SetMaterial(mat);

    }

    private void Rmo_ReadyEvent(object sender, EventArgs e)
    {
      Globals.Log(this, "Complete. Preparing...");
      MRemoteModel rmo = (MRemoteModel)sender;

      MPhysicsObject po = new MPhysicsObject(rmo, "Phyics", 0, MPhysicsObject.EShape.ConcaveMesh, false, Vector3d.One);
      rmo.ReadyEvent -= Rmo_ReadyEvent;
    }
  }
}
