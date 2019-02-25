﻿using OpenWorld.Forms;
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
      _chatForm.Show(ParentForm);
    }

    private void BuildButton_Click(object sender, EventArgs e)
    {
      _buildForm = new BuildForm();
      _buildForm.Show(ParentForm);
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
      SettingsForm f = new SettingsForm();
      f.Show(ParentForm);
    }

    private void AssetsButton_Click(object sender, EventArgs e)
    {
      AssetsForm af = new AssetsForm();
      af.Show(ParentForm);
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      TermsOfService f = new TermsOfService();
      f.Setup();
      f.Show(ParentForm);
    }

    private void MapButton_Click(object sender, EventArgs e)
    {
      MapForm f = new MapForm();
      f.Setup();
      f.Show(this.ParentForm);
    }

    private void DebugButton_Click(object sender, EventArgs e)
    {
      DebugForm f = new DebugForm();
      f.Setup();
      f.Show(this.ParentForm);
    }
  }
}
