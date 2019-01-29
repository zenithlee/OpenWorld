using Massive;
using Massive.Events;
using Massive.GIS;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Forms
{
  public partial class DebugWindow : Form
  {
    MScene _Scene;
    MObject Selected;

    public DebugWindow()
    {
      InitializeComponent();
    }

    private void DebugWindow_Shown(object sender, EventArgs e)
    {
      Globals.Network.InfoDumpHandler += Network_InfoEventHandler;
      MMessageBus.SelectEventHandler += MMessageBus_SelectEventHandler;
#if DEBUG
      Globals.Network.MergeResultHandler += Network_MergeResultHandler;
      TestButton.Enabled = true;
#else
      //MergeButton.Visible = false;
      //MergeButton.Enabled = false;
      TestButton.Enabled = false;
#endif
      Text = "_DEBUG TOOLS";
      TopLevel = true;
    }

    private void MMessageBus_SelectEventHandler(object sender, SelectEvent e)
    {
      Selected = e.Selected;
    }

    public void SetScene(MScene scene)
    {
      _Scene = scene;
    }

    private void Network_MergeResultHandler(object sender, InfoEvent e)
    {
      Status.Invoke((MethodInvoker)delegate
      {
        Status.Text = e.Message;
      });
    }

    private void Network_InfoEventHandler(object sender, InfoEvent e)
    {
      ItemInfo.Invoke((MethodInvoker)delegate
      {
        ItemInfo.AppendText(e.Data.ToString());
      });

    }

    private void GetGraph_Click(object sender, EventArgs e)
    {
      GraphView.Nodes.Clear();
      TreeNode Parent = new TreeNode("Graph");

      GraphView.Nodes.Add(Parent);
      GetNode(MScene.Root, Parent);
      Parent.Expand();
      //Parent.Expand();
      //Parent.ExpandAll();
    }

    void GetNode(MObject m, TreeNode parent)
    {
      TreeNode lvi = new TreeNode(m.Name);
      parent.Nodes.Add(lvi);
      lvi.Tag = m;
      if (Globals.Avatar.Owns(m))
      {
        lvi.BackColor = Color.CornflowerBlue;
      }
      foreach (MObject mo in m.Modules)
      {
        GetNode(mo, lvi);
      }

      if (m.Name.Equals("ModelRoot"))
      {
        lvi.Expand();
      }

      if (m.Name.Equals("Priority1"))
      {
        lvi.Expand();
      }

      if (m.Name.Equals("Root"))
      {
        lvi.Expand();
      }
    }

    private void GraphView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode tn = GraphView.SelectedNode;
      MObject mo = (MObject)tn.Tag;
      if (mo == null)
      {
        return;
      }
      ItemInfo.Text = mo.Name + "\n";
      ItemInfo.AppendText("Type:" + mo.Type.ToString() + "\n");
      ItemInfo.AppendText("IID:" + mo.InstanceID + "\n");
      ItemInfo.AppendText("OID:" + mo.OwnerID + "\n");
      ItemInfo.AppendText("ERROR:" + mo.Error + "\n");

      if (mo.Renderable)
      {
        MSceneObject mso = (MSceneObject)mo;
        ItemInfo.AppendText("PickIndex:" + mso.Index + "\n");
        ItemInfo.AppendText("POS:" + mso.transform.Position.ToString() + "\n");
        ItemInfo.AppendText("CastsShadow:" + mso.CastsShadow + "\n");
        ItemInfo.AppendText("DistanceFromAvatar:" + mso.DistanceFromAvatar + "\n");
        ItemInfo.AppendText("DistanceThreshold:" + mso.DistanceThreshold + "\n");

        MMessageBus.Select(this, mso);
      }
      else
      {
        Selected = mo;
      }

      if (mo.Type == MObject.EType.Texture)
      {
        MTexture tex = (MTexture)mo;
        ItemInfo.AppendText(tex.Filename + "\n");
        ItemInfo.AppendText(tex.CacheFilename + "\n");
        ItemInfo.AppendText(tex.DoAssign + "\n");
      }

      if (mo.Type == MObject.EType.Model)
      {
        MModel mm = (MModel)mo;
        if (mm.Filename != null)
        {
          ItemInfo.AppendText(mm.Filename);
        }
      }

      if (mo.Type == MObject.EType.Sound)
      {
        MSound s = (MSound)mo;
        ItemInfo.AppendText(s.Filename + "\n");
        //ItemInfo.AppendText("SoundBO:" + s.SoundBO.ToString() + "\n");
        //ItemInfo.AppendText("DeltaPos:" + s.DeltaPos + "\n");
      }
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      Globals.Network.InfoDumpHandler -= Network_InfoEventHandler;
#if DEBUG
      Globals.Network.MergeResultHandler -= Network_MergeResultHandler;
#endif
      Close();
    }

    private void GetMyData_Click(object sender, EventArgs e)
    {
      Globals.Network.InfoDumpRequest(Globals.UserAccount.UserID);
    }

    private void MergeMyData_Click(object sender, EventArgs e)
    {

    }
    /*
    private void LightIntensityScroll_Scroll(object sender, ScrollEventArgs e)
    {
      MLight light = (MLight)MScene.UtilityRoot.FindModuleByType(MObject.EType.DirectionalLight);
      if (light != null)
      {
        float rel = 1 - LightIntensityScroll.Value / (float)LightIntensityScroll.Maximum;
        light.Ambient = Vector3.One * rel;
      }
    }
    */

    private void EditShader_Click(object sender, EventArgs e)
    {
      if (GraphView.SelectedNode == null) return;
      MObject mo = (MObject)GraphView.SelectedNode.Tag;
      if (mo == null) return;

      ShaderEditor se = new ShaderEditor();

      MShader shader;
      if (mo.Type == MObject.EType.Shader)
      {
        shader = (MShader)mo;
        se.SetObject(shader);
      }
      shader = (MShader)mo.FindModuleByType(MObject.EType.Shader);
      if (shader == null) return;
      se.SetObject(shader);

      se.Show();

    }
    /*
    private void LightTweaker_Scroll(object sender, ScrollEventArgs e)
    {
      MLight light = (MLight)MScene.UtilityRoot.FindModuleByType(MObject.EType.DirectionalLight);
      if (light != null)
      {
        float rel = 1 - (float)LightTweaker.Value / (float)LightTweaker.Maximum;
        light.FarPlane = 1000 * rel;

      }
    }
    */
    private void DebugWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      Globals.Network.InfoDumpHandler -= Network_InfoEventHandler;
#if DEBUG
      Globals.Network.MergeResultHandler -= Network_MergeResultHandler;
#endif
    }

    private void TestButton_Click(object sender, EventArgs e)
    {
      MMaterial Whitem = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);

      MAstroBody body = MPlanetHandler.CurrentNear;
      Vector3d ap = Globals.Avatar.GetPosition();
      Vector3d lonlat = body.GetLonLatOnShere(ap);
      Vector3d Tile = body.GetTileFromPoint(ap);

      //      MSceneObject mo = (MSceneObject)body.Tag;
      //mo.Visible = false;


      MTerrainBoundary b = body.GetTileBoundaryLonLat((int)Tile.X, (int)Tile.Y, (int)Tile.Z);

      MSphere sp = Helper.CreateSphere(MScene.ModelRoot, 3, "Sphere");
      sp.transform.Position = b.TL;
      sp.transform.Scale = new Vector3d(10, 1000, 10);
      sp.DistanceThreshold = 1000000000000;
      sp.SetMaterial(Whitem);

      sp = Helper.CreateSphere(MScene.ModelRoot, 3, "Sphere");
      sp.transform.Position = b.TR;
      sp.transform.Scale = new Vector3d(10, 1000, 10);
      sp.DistanceThreshold = 1000000000000;
      sp.SetMaterial(Whitem);

      sp = Helper.CreateSphere(MScene.ModelRoot, 3, "Sphere");
      sp.transform.Position = b.BL;
      sp.transform.Scale = new Vector3d(10, 1000, 10);
      sp.DistanceThreshold = 1000000000000;
      sp.SetMaterial(Whitem);

      sp = Helper.CreateSphere(MScene.ModelRoot, 3, "Sphere");
      sp.transform.Position = b.BR;
      sp.transform.Scale = new Vector3d(10, 1000, 10);
      sp.DistanceThreshold = 1000000000000;
      sp.SetMaterial(Whitem);


      Console.WriteLine(b.ToString());
      Console.WriteLine(body.GetNearestPointOnSurface(ap));
      Console.WriteLine(ap);
      Console.WriteLine(Vector3d.Distance(ap, sp.transform.Position));

      MMessageBus.NavigationEnable(this, true);
      MMessageBus.Navigate(this, sp.transform.Position);

      //MScene.ModelRoot.Debug();


      /*MRemoteModel rem = new MRemoteModel();
      rem.Load(@"https://bigfun.co.za/fu/static/models/pyramid_giza/pyramid_giza.3ds");
      MScene.ModelRoot.Add(rem);
      rem.OwnerID = Globals.UserAccount.UserID;
      rem.transform.Position = Globals.Avatar.GetPosition();
      MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);
      rem.SetMaterial(mat);
      mat.AddTexture(TexturePool.GetTexture("https://bigfun.co.za/fu/static/models/pyramid_giza/texture.jpg"));
      */

      /*

      MModelURL mu = new MModelURL("https://bigfun.co.za/fu/static/models/pyramid_giza/pyramid_giza.3ds"
      ,"https://bigfun.co.za/fu/static/models/pyramid_giza/texture.jpg");

    Globals.Network.SpawnRequest(MServerObject.MODELURL, mu.TextureURL, "Pyramid at Giza", mu.Serialize(),
           Globals.Avatar.GetPosition()+ Globals.Avatar.Forward(), Globals.Avatar.GetRotation());

      */

      /*
      MModelURL mu = new MModelURL("https://bigfun.co.za/fu/static/models/12_2257_2458.obj",
                                 "https://bigfun.co.za/fu/static/models/12_2257_2458_sat.jpg");

      Globals.Network.SpawnRequest(MServerObject.MODELURL, mu.TextureURL, "TerrainTest", mu.Serialize(),
           Globals.Avatar.GetPosition() + Globals.Avatar.Forward(), Globals.Avatar.GetRotation(), "", 1, 9000);


      /*
      string sPath = Path.Combine(Globals.AppDataPath, @"Cache\3833094878FA6D416D2B8DAADE9DA775.obj");
      MModel model = Helper.CreateModel(MScene.ModelRoot, "Terrain", sPath, Globals.Avatar.GetPosition() + Globals.Avatar.Forward());
      MMaterial mat = new MMaterial("TerrainMat");
      mat.AddShader((MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER));
      MTexture tex = new MTexture("TerrainTex");
      tex.Load("https://bigfun.co.za/fu/static/models/12_2257_2458_sat.jpg");
      tex.Setup();
      mat.ReplaceTexture(tex);
      model.SetMaterial(mat);
      model.transform.Rotation = Globals.Avatar.GetRotation();
      MScene.MaterialRoot.Add(mat);
      model.OwnerID = Globals.UserAccount.UserID;

      MPhysicsObject po = new MPhysicsObject(model, "TerrainPhyysics", 0, MPhysicsObject.EShape.ConcaveMesh, false, Vector3d.One);
      */

      //Globals.Network.GetZones();

      //MPhysics.Realign();

      /*
      //MMessageBus.CreateObjectRequest(this, BuildParts.TELEPORT01, "mars");
      //new TeleporterConfigForm().Show();
      MAstroBody CurrentBody = MPlanetInitializer.Bodies.Find(x => "Earth" == x.Name);
      MSceneObject mo = (MSceneObject)CurrentBody.Tag;
      mo.transform.Scale += new Vector3d(10000.0);
      MMessageBus.Status(this, mo.transform.Scale.ToString());

      MScene.ModelRoot.Debug();
      */
    }

    private void DisableRender_Click(object sender, EventArgs e)
    {
      MMessageBus.ToggleRenderer();
    }

    private void DepthDebug_Click(object sender, EventArgs e)
    {
      _Scene.light.DebugDepth = !_Scene.light.DebugDepth;
    }

    private void DebugPhysics_Click(object sender, EventArgs e)
    {
      MScene.Physics.DebugWorld = !MScene.Physics.DebugWorld;
    }

    private void Tweaker1_ValueChanged(object sender, EventArgs e)
    {
      Globals.Tweak1 = Tweaker1.Value;
      TweakValue.Text = Globals.Tweak1 + "," + Globals.Tweak2;
    }


    private void Tweak2Bar_ValueChanged(object sender, EventArgs e)
    {
      Globals.Tweak2 = Tweak2Bar.Value;
      TweakValue.Text = Globals.Tweak1 + "," + Globals.Tweak2;
    }

    private void GetVisible_Click(object sender, EventArgs e)
    {

    }

    private void DeleteNode_Click(object sender, EventArgs e)
    {
      if (Selected != null)
      {
        if (Selected.Renderable)
        {
          MMessageBus.DeleteRequest(this, (MSceneObject)Selected);
        }
      }
    }

    private void GotoButton_Click(object sender, EventArgs e)
    {
      if (Selected != null)
      {
        MSceneObject mo = (MSceneObject)Selected;
        MMessageBus.TeleportRequest(this, "", mo.transform.Position + Globals.LocalUpVector, Quaterniond.Identity);
      }
    }

    private void TriggerButton_Click(object sender, EventArgs e)
    {
      if (Selected == null) return;
      if (Selected.Type == MObject.EType.Sound)
      {
        MSound s = (MSound)Selected;
        s.Play(MScene.audioListener);
      }
    }

  }
}
