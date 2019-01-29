using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Massive.Events;
using Massive;

namespace ThisIsMassive.src.Controls
{
  public partial class CUserNameControl : UserControl
  {
    public CUserNameControl()
    {
      InitializeComponent();
      MMessageBus.LoggedIn += MMessageBus_LoggedIn;
      MMessageBus.UserDetailsChanged += MMessageBus_UserDetailsChanged;
    }

    private void MMessageBus_UserDetailsChanged(object sender, ChangeDetailsEvent e)
    {
      SetName(Globals.UserAccount.UserName);
      SetStatus(Globals.UserAccount.TotalObjects, Globals.UserAccount.MaxObjects, Globals.UserAccount.Credit);
    }

    private void MMessageBus_LoggedIn(object sender, ChangeDetailsEvent e)
    {
      SetName(Globals.UserAccount.UserName);
      SetStatus(Globals.UserAccount.TotalObjects, Globals.UserAccount.MaxObjects, Globals.UserAccount.Credit);
    }

    void SetStatus(int Objects, int Max, double Credit)
    {
      StatusText.Text = string.Format("Build: {0}/{1} ${2}", Objects, Max, Credit);
    }

    void SetName(string s)
    {
      Username.Text = Globals.UserAccount.UserName;
    }

    private void Username_Click(object sender, EventArgs e)
    {
      UserInfoForm ui = new UserInfoForm();
      ui.Show();
    }
  }
}
