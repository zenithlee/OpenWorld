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
    MSceneObject SelectedItem;
    string PendingID = "";
    public BuildForm()
    {
      InitializeComponent();
      SetTitle("Building");
      MMessageBus.SelectEventHandler += MMessageBus_SelectEventHandler;
      MMessageBus.ObjectDeletedEvent += MMessageBus_ObjectDeletedEvent;    
    }    

    private void MMessageBus_ObjectDeletedEvent(object sender, DeleteEvent e)
    {
      if (SelectedItem == null) return;
      if (e.InstanceID == SelectedItem.InstanceID)
      {
        SelectedItem = null;
      }
    }

    private void MMessageBus_SelectEventHandler(object sender, SelectEvent e)
    {
      if (e == null) return;
      SelectedItem = e.Selected;
      if ( SelectedItem != null)
      {
        SelectedLabel.Text = SelectedItem.Name;
      }
    }

    void Add(string s)
    {
      Vector3d pos = Globals.Avatar.GetPosition();
      pos += Globals.Avatar.Forward();

      Quaterniond rot = Globals.LocalUpRotation();
      Globals.Network.SpawnRequest(s, "TEXTURE01", s, s, pos, rot);
    }

    private void Duplicate_Click(object sender, EventArgs e)
    {
      if (SelectedItem == null) return;
      Vector3d pos = SelectedItem.transform.Position;
      Quaterniond rot = SelectedItem.transform.Rotation;
      string sTag = "";
      Globals.Network.SpawnRequest(SelectedItem.TemplateID, SelectedItem.material.MaterialID, SelectedItem.Name, sTag, pos, rot);
    }


    void Populate()
    {
      PartsView.Items.Clear();
      Dictionary<string, MBuildingBlock> Blocks = MBuildParts.GetBlocks();

      foreach (KeyValuePair<string, MBuildingBlock> kv in Blocks)
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
      return Path.GetFullPath(Path.Combine("Assets", sName + ".png"));
    }

    private void BuildForm_Load(object sender, EventArgs e)
    {      
      Populate();
      textureControl1.Setup();
    }

    private void PartsView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (PartsView.SelectedItems.Count > 0)
      {
        ListViewItem lvi = PartsView.SelectedItems[0];
        MBuildingBlock mb = (MBuildingBlock)lvi.Tag;
        if (mb != null)
        {
          Add(mb.TemplateID);
        }
      }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (SelectedItem == null) return;
      Globals.Network.DeleteRequest(SelectedItem.InstanceID);
    }

    private void BuildForm_Shown(object sender, EventArgs e)
    {
      Rectangle r = Main.ClientRect;
      this.Location = new Point(r.Location.X + r.Width - this.Width, r.Y);
    }
  }
}
