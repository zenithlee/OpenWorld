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
      SetTitle("Settings");
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

    private void DebugDepthCheck_CheckedChanged(object sender, EventArgs e)
    {
      Globals._scene.light.DebugDepth = DebugDepthCheck.Checked;
    }

    private void TweakBar1_Scroll(object sender, EventArgs e)
    {
      Settings.Tweak1 = TweakBar1.Value;
    }

    private void TweakBar2_Scroll(object sender, EventArgs e)
    {
      Settings.Tweak2 = TweakBar2.Value;
    }

    private void TweakBar3_Scroll(object sender, EventArgs e)
    {
      Settings.Tweak3 = TweakBar3.Value;
    }

    private void TweakBar4_Scroll(object sender, EventArgs e)
    {
      Settings.Tweak4 = TweakBar4.Value;
    }
  }
}
