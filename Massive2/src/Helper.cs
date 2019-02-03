﻿using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

using System.Diagnostics;
using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BulletSharp;

namespace Massive
{
  public static class Helper
  {
    public static void Log(string s)
    {
      Globals.Log(null, s);
    }

    public static MShader GetDefaultShader()
    {
      return (MShader)MScene.MaterialRoot.FindModuleByName("DefaultShader");
    }
    public static MShader GetGUIShader()
    {
      return (MShader)MScene.MaterialRoot.FindModuleByName("DefaultGUIShader");
    }

    public static MObject AddNull(MObject parent, string sName = "NULL")
    {
      MObject mo = new MObject(MObject.EType.Null, sName);
      parent.Add(mo);
      return mo;
    }

    public static MCube CreateCube(MObject parent, string sName)
    {
      return CreateCube(parent, sName, Vector3d.Zero);
    }

    public static MPlane CreatePlane(MObject parent, string sName, Vector3d pos)
    {
      if (parent == null) parent = MScene.ModelRoot;
      MPlane c = new MPlane(sName);
      c.transform.Position = pos;
      c.Setup();
      parent.Add(c);
      c.material = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);
      c.Add(c.material);
      return c;
    }

    public static MCube CreateCube(MObject parent, string sName, Vector3d pos)
    {
      if (parent == null) parent = MScene.ModelRoot;
      MCube c = new MCube(sName);
      c.transform.Position = pos;
      c.Setup();
      parent.Add(c);      
      c.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL));      
      return c;
    }

    public static MSphere CreateSphere(MObject parent, int Recursion, string sName = "Sphere")
    {
      return CreateSphere(parent, Recursion, sName, Vector3d.Zero);
    }
    public static MSphere CreateSphere(MObject parent, int Recursion, string sName, Vector3d pos)
    {
      if (parent == null) parent = MScene.ModelRoot;
      MSphere sphere = new MSphere(sName, Recursion);
      sphere.transform.Position = pos;
      sphere.Setup();
      parent.Add(sphere);
      sphere.material = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);
      sphere.Add(sphere.material);
      return sphere;
    }

    public static MModel CreateModel(MObject parent, string sName, string Filename, Vector3d pos)
    {
      if (parent == null) parent = MScene.ModelRoot;
      MModel m = new MModel(MObject.EType.Model, sName);
      m.transform.Position = pos;
      try
      {
        m.Load(Filename);
      }
      catch (Exception e)
      {

      }
      parent.Add(m);
      return m;
    }

    public static MRemoteModel CreateModelURL(MObject parent, string URL, string TexURL, string OwnerID, string sName,
      Vector3d pos, Quaterniond rot)
    {
      if (parent == null) parent = MScene.ModelRoot;
      MRemoteModel m = new MRemoteModel();
      m.OwnerID = OwnerID;
      m.Name = sName;
      parent.Add(m);
      m.transform.Position = pos;
      m.transform.Rotation = rot;
      //MMaterial mat = new MMaterial(sName+ "_mat");
      //mat.AddShader((MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER));
      //mat.AddTexture(TexturePool.GetTexture(TexURL));
      //m.SetMaterial(mat);
      try
      {
        m.Load(URL);
      }
      catch (Exception e)
      {
        Console.WriteLine("Error createing model:" + URL + "." + e.Message);
      }
      parent.Add(m);
      return m;
    }


    public static MModel SpawnModel(MObject parent, string TemplateID, string OwnerID, string sName, Vector3d pos)
    {
      MModel mo = (MModel)MScene.TemplateRoot.FindModuleByInstanceID(TemplateID);
      //MMesh sm = (MMesh)mo.FindModuleByType(MObject.EType.Mesh);

      MModel m = new MModel(MObject.EType.Model, sName);
      m.OwnerID = OwnerID;
      m.transform.Position = pos;

      for (int i = 0; i < mo.Modules.Count; i++)
      {
        if (mo.Modules[i].Type != MObject.EType.Mesh) continue;

        MMesh mr = (MMesh)mo.Modules[i];

        MMesh mesh = new MMesh(sName);
        mesh.OwnerID = mr.OwnerID;
        m.Add(mesh);
        mesh.VBO = mr.VBO;
        mesh.VAO = mr.VAO;
        mesh.EBO = mr.EBO;
        mesh.Indices = mr.Indices;
        mesh.IndicesLength = mr.IndicesLength;
        mesh.Vertices = mr.Vertices;
        mesh.VerticesLength = mr.VerticesLength;
        mesh.Normals = mr.Normals;
        //mesh.material = mo.material;
        m.material = mo.material;
        parent.Add(m);
      }

      return m;
    }

    public static MInstanceModel SpawnInstanced(MObject parent, string TemplateID, string OwnerID, string sName, Vector3d pos)
    {
      MInstanceModel mo = (MInstanceModel)MScene.TemplateRoot.FindModuleByInstanceID(TemplateID);

      MInstanceModel m = new MInstanceModel(sName, mo.ModelPath, mo.MeshTexture);
      m.OwnerID = OwnerID;
      m.transform.Position = pos;
      mo.CopyTo(m);
      parent.Add(m);

      return m;
    }

    public static MMaterial FindMaterial(string sName)
    {
      MMaterial m = (MMaterial)MScene.MaterialRoot.FindModuleByName(sName);
      return m;
    }

    public static MMaterial CreateMaterial(string sName)
    {
      MMaterial mat = FindMaterial(sName);
      if (mat != null)
      {
        Globals.Log(null, "WARNING: A material with the name " + sName + " already exists");
      }
      mat = new MMaterial(sName);
      MScene.MaterialRoot.Add(mat);
      return mat;
    }

    public static MMaterial AddMaterial(MSceneObject parent, string sName)
    {
      MMaterial mat = FindMaterial(sName);
      if (mat == null)
      {
        Log("WARNING: Material " + sName + " not found");
        return null;
      }
      parent.AddMaterial(mat);
      return mat;
    }

    public static MMaterial AddMaterial(string sName, MShader shader, MTexture tex)
    {
      MMaterial mat = new MMaterial(sName);
      mat.AddShader(shader);
      mat.SetDiffuseTexture(tex);
      MScene.MaterialRoot.Add(mat);
      return mat;
    }

    public static byte[] Hash(string inputString)
    {
      HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
      return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string HashString(string inputString)
    {
      StringBuilder sb = new StringBuilder();
      foreach (byte b in Hash(inputString))
        sb.Append(b.ToString("X2"));

      return sb.ToString();
    }

    public static string GUID()
    {
      Guid g = Guid.NewGuid();
      string sGuid = Convert.ToBase64String(g.ToByteArray());
      sGuid = sGuid.TrimEnd('=');
      sGuid = sGuid.Replace('\\', 'S');
      sGuid = sGuid.Replace('/', 'S');
      sGuid = sGuid.Replace(';', 'Q');
      sGuid = sGuid.Replace('+', 'P');
      return sGuid;
    }

    public static MSceneObject FindNearestObject(Vector3d Pos, string TemplateID)
    {
      double dist = 999999999999999999;
      MSceneObject Closest = null;
      for (int i = 0; i < MScene.Priority1.Modules.Count; i++)
      {
        MObject m = MScene.Priority1.Modules[i];
        if (!m.Renderable) continue;
        MSceneObject mo = (MSceneObject)m;
        if (mo.InstanceID.Equals(Globals.UserAccount.UserID)) continue;
        if (mo != null)
        {
          double dtm = Vector3d.Distance(mo.transform.Position, Pos);
          if (dtm < dist)
          {
            Closest = mo;
            dist = dtm;
          }
        }
      }

      return Closest;
    }


    public static void CheckGLError(MObject mo, string Extra = "")
    {
#if DEBUG
      ErrorCode c = GL.GetError();
      if (c != ErrorCode.NoError)
      {
        StackTrace stackTrace = new StackTrace();
        string sCaller = stackTrace.GetFrame(1).GetMethod().Name;
        sCaller += " @" + stackTrace.GetFrame(1).GetFileLineNumber();

        for ( int i=0; i< stackTrace.FrameCount; i++ )
        {
          StackFrame frame = stackTrace.GetFrame(i);          
          sCaller += " >"+frame.GetMethod().Name;
        }

        //Console.WriteLine(c + " @" + Extra + " OPENGL:" + mo.Name + "(" + sCaller + "): ");
      }
#endif
    }

    public static Vector3d VectorFromString(string s)
    {
      string[] c = s.Split(',');
      Vector3d v = new Vector3d(double.Parse(c[0]), double.Parse(c[1]), double.Parse(c[2]));
      return v;
    }

    public static MShader CreateShader(string sName)
    {
      MShader WallShader = new MShader(sName);
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
      return WallShader;
    }

    public static MSceneObject LoadTemplate(string TemplateID)
    {
      MSceneObject o = Helper.CreateSphere(MScene.TemplateRoot, 2, TemplateID);
      o.TemplateID = TemplateID;
      o.InstanceID = TemplateID;
      MPhysicsObject mpo = new MPhysicsObject(o, TemplateID + "_physics", 1, MPhysicsObject.EShape.Box, true, new Vector3d(1, 1, 1));            
      mpo.SetDamping(0.7, 0.5);
      mpo.SetRestitution(0.5);
      mpo.SetSleep(15);
      mpo.SetAngularFactor(0.0, 0.0, 0.0);
      o.Add(mpo);
      o.Setup();
      //o.OwnerID = m.OwnerID;
      //o.SetPosition(m.transform.Position);
      //o.SetRotation(m.transform.Rotation);
      return o;
    }

    /**
     * Creates a copy of an existing object from the TemplateRoot
     * */
    public static MSceneObject Spawn(string TemplateID,
      string OwnerID,
      string sName,
      string Tag,
      Vector3d Pos, Quaterniond Rot)
    {
      MSceneObject m = (MSceneObject)MScene.TemplateRoot.FindModuleByInstanceID(TemplateID);
      if (m == null)
      {
        m = LoadTemplate(TemplateID);
        if ( m == null )
        {
          return null;
        }        
      }

      MSceneObject t = null;

      MObject TargetRoot = MScene.ModelRoot;
      if (m.IsTransparent)
      {
        TargetRoot = MScene.Priority2;
      }
      else
      {
        TargetRoot = MScene.Priority1;
      }

      if (m.Type == MObject.EType.PrimitiveCube)
      {
        t = CreateCube(TargetRoot, sName, Pos);
      }
      if (m.Type == MObject.EType.PrimitiveSphere)
      {
        t = CreateSphere(TargetRoot, 2, sName, Pos);
      }
      if (m.Type == MObject.EType.Model)
      {
        t = SpawnModel(TargetRoot, TemplateID, OwnerID, sName, Pos);        
      }

      if ( m.Type == MObject.EType.InstanceMesh)
      {
        t = SpawnInstanced(TargetRoot, TemplateID, OwnerID, sName, Pos);
      }

      t.transform.Position = Pos;
      t.transform.Rotation = Rot;

      m.CopyTo(t);
      t.OwnerID = OwnerID;

      t.transform.Position = Pos;
      t.transform.Rotation = Rot;

      t.Tag = m.Tag;

      MClickHandler ch = (MClickHandler)m.FindModuleByType(MObject.EType.ClickHandler);
      if (ch != null)
      {
        MClickHandler ch2 = new MClickHandler();
        ch2.Clicked = ch.Clicked;
        ch2.DoubleClicked = ch.DoubleClicked;
        t.Add(ch2);
      }
      return t;
    }
  }
}
