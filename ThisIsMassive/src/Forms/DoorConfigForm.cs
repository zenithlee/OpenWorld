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
using ThisIsMassive.Widgets;

namespace ThisIsMassive.src.Forms
{
  public partial class DoorConfigForm : DToolForm
  {
    public MSceneObject DoorObject;

    public DoorConfigForm()
    {
      InitializeComponent();
      MMessageBus.PropertyChangeEvent += MMessageBus_PropertyChangeEvent;
      SetTitle("Door Permissions");
    }

    private void MMessageBus_PropertyChangeEvent(object sender, ChangePropertyEvent e)
    {
      if (e.InstanceID.Equals(DoorObject.InstanceID))
      {
        StatusText.Text = "Success";
        StatusText.ForeColor = Color.DarkGreen;
        Updatebutton.Enabled = false;   
        timer1.Start();
      }
    }

    public void Setup(MSceneObject mo)
    {
      DoorObject = mo;

      if (DoorObject.Tag != null)
      {
        string stag = (string)DoorObject.Tag;
        string[] items = stag.Split('|');
        if (items.Length > 1)
        {
          if (items[1] == MDoor.PUBLIC) Public.Checked = true;
          if (items[1] == MDoor.FRIENDS) Friends.Checked = true;
          if (items[1] == MDoor.ONLYME) OnlyMe.Checked = true;
          if (items[1] == MDoor.LOCKED) LockedRadio.Checked = true;
        }
      }
    }

    void ChangeValue()
    {
      string sTag = (string)DoorObject.Tag;
      if (sTag == null) return;
      string[] parms = sTag.Split('|');
      if (parms.Length > 0)
      {
        MMessageBus.Status(DoorObject, "Teleporting to:" + parms[1] + " - " + parms[2]);
      }
    }

    private void Updatebutton_Click(object sender, EventArgs e)
    {
      string ACCESS = "";
      if (LockedRadio.Checked) ACCESS = MDoor.LOCKED;
      if (Friends.Checked) ACCESS = MDoor.FRIENDS;
      if (Public.Checked) ACCESS = MDoor.PUBLIC;
      if (OnlyMe.Checked) ACCESS = MDoor.ONLYME;
      string NewTag = BuildParts.DOOR01 + "|" + ACCESS;
      DoorObject.Tag = NewTag;
      Globals.Network.ChangePropertyRequest(DoorObject.InstanceID, NewTag);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Close();
    }

    private void DoorConfigForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      MMessageBus.PropertyChangeEvent -= MMessageBus_PropertyChangeEvent;
    }

  }
}
