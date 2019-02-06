using OpenWorld.Forms;
using System;
using System.Windows.Forms;

namespace OpenWorld.Controls
{
  public partial class ToolbarControl : UserControl
  {
    ChatForm _chatForm;
    BuildForm _buildForm;
    public ToolbarControl()
    {
      InitializeComponent();
    }

    private void ChatButton_Click(object sender, EventArgs e)
    {
      _chatForm = new ChatForm();
      _chatForm.Show(Main.ActiveForm);
    }

    private void BuildButton_Click(object sender, EventArgs e)
    {
      _buildForm = new BuildForm();
      _buildForm.Show(Main.ActiveForm);
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
      SettingsForm f = new SettingsForm();
      f.Show(Main.ActiveForm);
    }
  }
}
