using Massive;
using Massive.Events;
using OpenTK;
using System;
using System.Drawing;
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

    private void AddFoundation_Click(object sender, EventArgs e)
    {
      Add(MBuildParts.FOUNDATION01);
    }
  }
}
