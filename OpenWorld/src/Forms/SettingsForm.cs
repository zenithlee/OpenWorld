using Massive;
using Massive.Events;
using System;

namespace OpenWorld.Forms
{
  public partial class SettingsForm : DToolForm
  {
    public SettingsForm()
    {
      InitializeComponent();
    }

    private void GravityCheck_CheckedChanged(object sender, EventArgs e)
    {
      Settings.Gravity = GravityCheck.Checked;
      MMessageBus.GravityStateChanged(this, new BooleanEvent(Settings.Gravity));
    }

    private void TerrainPhysicsCheck_CheckedChanged(object sender, EventArgs e)
    {
      Settings.TerrainPhysics = TerrainPhysicsCheck.Checked;
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
      TerrainPhysicsCheck.Checked = Settings.TerrainPhysics;
      GravityCheck.Checked = Settings.Gravity;
    }

    private void DebugPhysicsCheck_CheckedChanged(object sender, EventArgs e)
    {
      MScene.Physics.DebugWorld = DebugPhysicsCheck.Checked;
    }
  }
}
