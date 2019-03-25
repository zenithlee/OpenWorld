using Massive;
using Massive.Graphics.Character;
using Massive2.Graphics.Character;
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

namespace OpenWorld.Forms
{
  public partial class DebugForm : DToolForm
  {
    BindingList<MSceneObject> AssetsList;

    public DebugForm()
    {
      InitializeComponent();
      SetTitle("Debug");
      AssetsList = new BindingList<MSceneObject>();
      timer1.Start();
    }

    public void Setup()
    {
      AssetsList.Clear();


      foreach (MObject mo in MScene.Background.Modules)
      {
        if (!mo.Renderable) continue;
        MSceneObject mso = (MSceneObject)mo;
        AssetsList.Add(mso);
      }

      /*
      foreach (Matrix4 mo in MAnimatedModel.debug_transforms)
      {                
        AssetsList.Add(mo);
      }
  */
      try
      {
        DebugTable.DataSource = AssetsList;
        DebugTable.Refresh();
      }
      catch (Exception e)
      {
        Console.WriteLine("DebugForm:"+e.Message);
      }
      //DebugTable.Columns["OwnerID"].Visible = false;

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Setup();
    }
  }
}
