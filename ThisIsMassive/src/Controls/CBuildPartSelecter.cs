using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Massive;
using Massive.Events;
using ThisIsMassive.src.Handlers;
using Massive.Tools;

namespace ThisIsMassive.src.Controls
{
  public partial class CBuildPartSelecter : UserControl
  {
    MSceneObject Selected;


    public CBuildPartSelecter()
    {
      InitializeComponent();
      if (!DesignMode)
      {
        ListViewItem_SetSpacing(PartsView, 50, 50);
        MMessageBus.SelectEventHandler += MMessageBus_SelectEventHandler;
        timer1.Start();
      }
    }

    public void Closing()
    {
      timer1.Stop();
      MMessageBus.SelectEventHandler -= MMessageBus_SelectEventHandler;
    }

    private void MMessageBus_SelectEventHandler(object sender, SelectEvent e)
    {
      Selected = e.Selected;
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    public int MakeLong(short lowPart, short highPart)
    {
      return (int)(((ushort)lowPart) | (uint)(highPart << 16));
    }

    public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
    {
      const int LVM_FIRST = 0x1000;
      const int LVM_SETICONSPACING = LVM_FIRST + 53;
      SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
    }

    private void DuplicateButton_Click(object sender, EventArgs e)
    {
      if (MStateMachine.ZoneLocked == true) return;
      MMessageBus.CreateObjectRequest(this, BuildParts.DUPLICATE);
    }

    private void PartsView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (Selected == null) return;
      if (Selected.OwnerID.Equals(Globals.UserAccount.UserID))
      {
        MMessageBus.DeleteRequest(this, null);
      }

      //if (MStateMachine.ZoneLocked == true) return;      
    }

    private void PartsView_MouseClick(object sender, MouseEventArgs e)
    {
      if (MStateMachine.ZoneLocked == true) return;
      if (PartsView.SelectedItems.Count == 0) return;
      ListViewItem lvi = PartsView.SelectedItems[0];
      if (lvi != null)
      {
        MMessageBus.CreateObjectRequest(this, (string)lvi.Tag);
      }
    }

    private void EditPropertiesButton_Click(object sender, EventArgs e)
    {
      //if (Selected.Tag == null) return;      
      if (Selected == null) return;
      if (!Selected.OwnerID.Equals(Globals.UserAccount.UserID)) return;

      if (Selected.TemplateID.Equals(BuildParts.TELEPORT01))
      {
        string sTag = (string)Selected.Tag;
        string[] parms = sTag.Split('|');
        string sDestination = "";
        string sDescription = "";
        if (parms.Length > 0) sDestination = parms[1];
        if (parms.Length > 1) sDescription = parms[2];
        TeleporterConfigForm tp = new TeleporterConfigForm();
        tp.Setup(Selected.InstanceID, sDestination, sDescription);
        tp.Show();
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (Globals.Avatar == null) return;
      if (Globals.Avatar.Target == null) return;
      MZoneService.ZoneLocked(Globals.Avatar.GetPosition());
      if (MStateMachine.ZoneLocked)
      {
        CanBuildHere.BackColor = Color.Red;
        CanBuildHere.Text = "Zone Locked";
      }
      else
      {
        CanBuildHere.BackColor = Color.Green;
        CanBuildHere.Text = "Zone Unlocked";
      }
    }

    private void CBuildPartSelecter_VisibleChanged(object sender, EventArgs e)
    {
      Console.WriteLine("visible");
    }
  }
}
