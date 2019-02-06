using Massive;
using Massive.Events;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenWorld.Forms
{
  public partial class BuildForm : DToolForm
  {
    public BuildForm()
    {
      InitializeComponent();
      SetTitle("Building");
    }

    void Add(string s)
    {      
      Vector3d pos = Globals.Avatar.GetPosition();
      
      Quaterniond rot = Globals.LocalUpRotation(); 
      Globals.Network.SpawnRequest(s, "TEXTURE01", s, s, pos, rot);
    }

    void Populate()
    {
      PartsView.Items.Clear();
      Dictionary<string, MBuildingBlock> Blocks = MBuildParts.GetBlocks();

      foreach( KeyValuePair<string, MBuildingBlock> kv in Blocks)
      {
        if (string.IsNullOrEmpty(kv.Value.Model)) continue;
        string sIconPath = GetIconPathForModel(kv.Value.Model);
        ListViewItem lvi = new ListViewItem(kv.Value.Name);
        lvi.Tag = kv.Value;
        if (!File.Exists(sIconPath))
        {
          Console.WriteLine("BuildForm: File not found: " + sIconPath);
        }
        else
        {
          Bitmap icon = new Bitmap(sIconPath);
          imageList1.Images.Add(kv.Value.Name, icon);
        }
        
        lvi.ImageKey = kv.Value.Name;
        PartsView.Items.Add(lvi);
      }
    }

    string GetIconPathForModel(string sModelPath)
    {
      string sName = Path.Combine(Path.GetDirectoryName(sModelPath), Path.GetFileNameWithoutExtension(sModelPath));
      return Path.GetFullPath(Path.Combine("Assets",sName + ".png"));
    }

    private void AddFoundation_Click(object sender, EventArgs e)
    {
      Add(MBuildParts.FOUNDATION01);
    }

    private void BuildForm_Load(object sender, EventArgs e)
    {
      Populate();
    }

    private void PartsView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (PartsView.SelectedItems.Count > 0)
      {
        ListViewItem lvi = PartsView.SelectedItems[0];
        MBuildingBlock mb = (MBuildingBlock)lvi.Tag;
        if ( mb != null)
        {
          Add(mb.TemplateID);
        }
        
      }      
    }
  }
}
