using Massive;
using Massive.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class UserInfoForm : Form
  {
    Color OldBackColor = Color.Gray;
    Color ErrorColor = Color.Pink;

    public UserInfoForm()
    {
      InitializeComponent();
    }

    private void UserInfoForm_Shown(object sender, EventArgs e)
    {
      Setup();
    }

    void Setup()
    {
      OldBackColor = EmailBox.BackColor;
      LoadData();
      CheckValidate();
      SetupEvents();
#if DEBUG
      UserIDBox.ReadOnly = false;
#else
      //ServersCombo.Enabled = false;
      //ServersCombo.Visible = false;
#endif
    }

    void SetupEvents()
    {
      
    }

    bool ValidateEmail(string s)
    {
      if (string.IsNullOrEmpty(s)) return false;
      bool result = true;      

      if (s.Contains(' ')) result = false;
      if (!s.Contains('@')) result = false;
      if (!s.Contains('.')) result = false;
      return result;
    }

    bool CheckValidate()
    {
      bool valid = true;
      if ( !ValidateEmail(Globals.UserAccount.Email))
      {
        EmailBox.BackColor = ErrorColor;
        valid = false;
      }
      else
      {
        EmailBox.BackColor = OldBackColor;
      }

      return valid;

    }

    void LoadData()
    {
      EmailBox.Text = Globals.UserAccount.Email;
      UserNameBox.Text = Globals.UserAccount.UserName;
      PasswordBox.Text = Globals.UserAccount.Password;
      UserIDBox.Text = Globals.UserAccount.UserID;
      ServersCombo.Text = Globals.Network.ServerIP;

      switch (Globals.UserAccount.AvatarID)
      {
        case BuildParts.AVATAR01:
          Avatar1.Checked = true;
          break;
        case BuildParts.AVATAR02:
          Avatar2.Checked = true;
          break;
        case BuildParts.AVATAR03:
          Avatar3.Checked = true;
          break;
      }

      Globals.Network.USerDetailsChanged += Network_DetailsChanged;
    }

    void SaveData()
    {
      Globals.UserAccount.Email = EmailBox.Text;
      Globals.UserAccount.UserName = UserNameBox.Text;
      Globals.UserAccount.Password = PasswordBox.Text;
      CheckValidate();
      //Globals.UserAccount.UserID = UserIDBox.Text;
    }

    void Status(bool Success, string s)
    {
      if (StatusLabel.InvokeRequired)
      {
        StatusLabel.Invoke((MethodInvoker)delegate
        {
          if (Success == true)
          {
            StatusLabel.ForeColor = Color.Green;
          }
          else
          {
            StatusLabel.ForeColor = Color.Red;
          }
          StatusLabel.Text = s;
        });
      }
    }

    private void Network_DetailsChanged(object sender, ChangeDetailsEvent e)
    {
      Status(e.Success, e.Message);
      //AccessKeyBox.Invoke((MethodInvoker)delegate
      //{
       // AccessKeyBox.Text = Helper.HashString(EmailBox.Text);
      //});      
    }

 

    private void SaveButton_Click(object sender, EventArgs e)
    {
      SaveData();
      CheckValidate();
      StatusLabel.Text = "Update Details...";
      
      Globals.Network.ChangeDetailsRequest(Globals.UserAccount);
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      SaveData();
      Globals.Network.USerDetailsChanged -= Network_DetailsChanged;
      MMessageBus.ChangedUserInfo(this);
      Close();
    }

    private void ServersCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (ServersCombo.SelectedIndex < 0) return;
      string sServer = ServersCombo.Items[ServersCombo.SelectedIndex].ToString();
      Globals.Network.ServerIP = sServer;
    }

    private void UserIDBox_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(UserIDBox.Text))
      {
        MMessageBus.ChangeUserID(this, UserIDBox.Text);
      }
    }

    private void Avatar1_CheckedChanged(object sender, EventArgs e)
    {
      if (Avatar1.Checked == true)
      {
        Globals.UserAccount.AvatarID = BuildParts.AVATAR01;
        MMessageBus.ChangedUserInfo(this);
        MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      }
    }

    private void Avatar2_CheckedChanged(object sender, EventArgs e)
    {
      if (Avatar2.Checked == true)
      {
        Globals.UserAccount.AvatarID = BuildParts.AVATAR02;
        MMessageBus.ChangedUserInfo(this);
        MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      }
    }

    private void Avatar3_CheckedChanged(object sender, EventArgs e)
    {
      if (Avatar3.Checked == true)
      {
        Globals.UserAccount.AvatarID = BuildParts.AVATAR03;
        MMessageBus.ChangedUserInfo(this);
        MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      }
    }
  }
}
