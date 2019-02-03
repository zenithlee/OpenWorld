using Massive;
using Massive.Network;
using Massive.Tools;
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

    void Spawn(MServerObject m)
    {
      MSceneObject mo = (MSceneObject)MScene.Root.FindModuleByInstanceID(m.InstanceID);
      if (mo != null) return;      
        //if ((m.Name == Globals.UserAccount.UserID) && ( m.OwnerID == Globals.UserAccount.UserID)){
        mo = Helper.Spawn(m.TemplateID, m.OwnerID, m.Name, m.Tag,           
          MassiveTools.VectorFromArray( m.Position), 
          MassiveTools.QuaternionFromArray(m.Rotation));
      mo.InstanceID = m.InstanceID;
      if ( mo.Name == Globals.UserAccount.UserID)
      {
        Globals.Avatar.SetSceneObject(mo);
      }
      //}
      //Helper.CreateCube(MScene.ModelRoot, dt)
    }    
  }
}
