using Massive.Network;
using MassiveNetwork;
using MassiveServer.src;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassiveServer
{
  public class MDBAdvocate : MDatabase
  {

    public int GetObjectCount()
    {
      string sQuery = "SELECT COUNT(*) FROM objects;";
      int results = QueryScalar(sQuery);
      return results;
    }

    public bool SetTexture(string UserID, string InstanceID, string TextureID)
    {
      string sQuery = string.Format(
        @"UPDATE objects SET `textureid`='{0}' WHERE `instanceid`='{1}' AND `ownerid`='{2}';",
        TextureID, InstanceID, UserID);
      int results = Query(sQuery);
      return results == 0 ? false : true;
    }

    public int DeleteObject(string InstanceID, string UserID)
    {
      string sQuery = string.Format(
        @"DELETE FROM objects WHERE `instanceid`='{0}' AND `ownerid`='{1}';",
        InstanceID, UserID);
      return Query(sQuery);
    }

    public string DumpUser(string UserID)
    {
      string sQuery = string.Format(
        @"SELECT * FROM objects WHERE `ownerid`='{0}';",
        UserID);
      DataTable dt = QueryReader(sQuery);
      return DataTableToJSON(dt);
    }

    public DataTable GetTable(string sTableName)
    {
      string sQuery = string.Format(
        @"SELECT * FROM {0};", sTableName);
      DataTable dt = QueryReader(sQuery);
      return dt;
    }

    public bool MoveObject(string UserID, string InstanceID, double[] Locus, double[] Rotation)
    {
      string sQuery = string.Format(
        @"UPDATE objects 
          SET `x`={0},`y`={1},`z`={2}, 
          `rx`={3},`ry`={4},`rz`={5},`rw`={6}
          WHERE `instanceid`='{7}' AND `ownerid`='{8}';",
        Locus[0], Locus[1], Locus[2],
        Rotation[0], Rotation[1], Rotation[2], Rotation[3],
        InstanceID, UserID);
      int num = Query(sQuery);
      return num == 0 ? false : true;
    }

    public bool SetProperty(string UserID, string InstanceID, string PropertyTag)
    {
      string sQuery = string.Format(
       @"UPDATE objects SET `tag`='{0}' WHERE `instanceid`='{1}' AND `ownerid`='{2}';",
         PropertyTag, InstanceID, UserID);
      int num = Query(sQuery);
      return num == 0 ? false : true;
    }

    public bool ChangeAvatar(string UserID, string AvatarID)
    {
      int num = 0;
      string sQuery = string.Format(
        @"UPDATE objects SET `templateid`='{0}' WHERE `instanceid`='{1}' AND `ownerid`='{1}';",
        AvatarID, UserID);
      num = Query(sQuery);
      sQuery = string.Format(
        @"UPDATE users SET `avatarid`='{0}' WHERE `userid`='{1}';",
        AvatarID, UserID);
      num += Query(sQuery);
      return num == 0 ? false : true;
    }

    public MServerObject GetObject(string InstanceID)
    {
      MServerObject mso = new MServerObject();
      //if (Objects.ContainsKey(InstanceID)) return Objects[InstanceID];
      string sQuery = string.Format("SELECT 1 FROM `objects` WHERE `instanceid`='{0}'", InstanceID);
      DataTable dt = QueryReader(sQuery);

      DataRow row = dt.Rows[0];
      mso.OwnerID = row.ItemArray[0].ToString();

      return mso;
    }

    public DataTable GetObjectsNear(string UserID, double x, double y, double z)
    {
      List<MServerObject> msl = new List<MServerObject>();

      string sQuery = string.Format("SELECT * FROM `objects`;");
      DataTable dt = QueryReader(sQuery);
      //string sJSON = DataTableToJSON(dt);
      return dt;
    }

    public void RemoveUserFromUniverse(string UserID)
    {
      string sQuery = string.Format(
        @"DELETE FROM objects WHERE `instanceid`='{0}' AND `persist`=0;",
        UserID);
      Query(sQuery);
    }

    public void AddPlayer(MUserAccount m)
    {
      string sQuery = string.Format(
        @"INSERT IGNORE into users (userid, screenname, avatarid, email, password, ip) 
        VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5});",
        m.UserID, m.UserName, m.AvatarID, m.Email, m.Password, m.ClientIP);
      Query(sQuery);

      /*sQuery = string.Format(
        @"INSERT into `objects` (`instanceid`,`ownerid`,`templateid`,`name`,`persist`) 
        VALUES('{0}', '{1}', '{2}', '{3}', 0)
        ON DUPLICATE KEY UPDATE `name`='{3}';",
        m.UserID, m.UserID, m.AvatarID, m.UserName);
      Query(sQuery);*/
    }

    public bool AddToWorld(DataTable dt)
    {
      int n = 0;
      foreach (DataRow dr in dt.Rows)
      {
        string sQuery = string.Format(
         @"INSERT IGNORE into objects (`instanceid`, `ownerid`, `templateid`, `textureid`, `name`, `persist`, x,y,z, rx, ry, rz, rw) 
        VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12});",
         dr[DB.INSTANCEID], dr[DB.OWNERID], dr[DB.TEMPLATEID], dr[DB.TEXTUREID], dr[DB.NAME], dr[DB.PERSIST],
         dr[DB.X], dr[DB.Y], dr[DB.Z], dr[DB.RX], dr[DB.RY], dr[DB.RZ], dr[DB.RZ]
         );
        n += Query(sQuery);
      }
      return n == 0 ? false : true;
    }

    public void UpdatePlayer(MUserAccount m)
    {
      string sQuery = string.Format(
        @"UPDATE users 
          SET screenname = '{0}', avatarid = '{1}', email='{2}', password='{3}' 
          WHERE `userid`='{4}';",
        m.UserName, m.AvatarID, m.Email, m.Password, m.UserID);
      Query(sQuery);
    }

    /// <summary>
    /// Removes all inactive objects from the object table
    /// </summary>
    public void FlushPlayers()
    {
      string sQuery = string.Format(
        @"DELETE from `objects` where `persist`=0;
        "
      );
      Query(sQuery);
    }
  }
}
