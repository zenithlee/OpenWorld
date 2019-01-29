using Massive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThisIsMassive.src.Forms
{
  public partial class BuildForm : ThisIsMassive.src.Forms.DToolForm
  {
    public BuildForm()
    {
      InitializeComponent();
      SetTitle("_BUILD");
    }

    public void SetSelected(MSceneObject Selection)
    {
      cObjectInspector1.SetSelection(Selection);
    }

    private void BuildForm_Shown(object sender, EventArgs e)
    {      
      Location = Main.ClientLocation;
    }

    private void BuildForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      cObjectInspector1.Closing();
      cBuildPartSelecter1.Closing();
    }
  }
}
