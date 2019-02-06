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
  }
}
