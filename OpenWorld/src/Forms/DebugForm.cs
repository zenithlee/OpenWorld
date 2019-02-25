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
    List<Matrix4> AssetsList;

    public DebugForm()
    {
      InitializeComponent();
      SetTitle("Debug");
      AssetsList = new List<Matrix4>();
      timer1.Start();
    }

    public void Setup()
    {
      AssetsList.Clear();
      foreach (Matrix4 mo in MAnimatedModel.debug_transforms)
      {                
        AssetsList.Add(mo);
      }

      DebugTable.DataSource = AssetsList;
      DebugTable.Refresh();
      //DebugTable.Columns["OwnerID"].Visible = false;
    
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Setup();      
    }
  }
}
