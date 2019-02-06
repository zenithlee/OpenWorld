using Massive;
using OpenTK;
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

namespace OpenWorld.src.Controls
{
  public partial class StatusControl : UserControl
  {
    public StatusControl()
    {
      InitializeComponent();
      Globals.Network.PositionChangeHandler += Network_PositionChangeHandler;
      Globals.Network.TeleportHandler += Network_TeleportHandler;
      Globals.Network.StatusEventHandler += Network_StatusEventHandler;
      //Globals.Network.ErrorEventHandler += Network_ErrorEventHandler;
      MMessageBus.ErrorHandler += MMessageBus_ErrorHandler;
      MMessageBus.InfoEventHandler += MMessageBus_InfoEventHandler;
      MMessageBus.AvatarMovedEvent += MMessageBus_AvatarMovedEvent;
    }

    private void MMessageBus_AvatarMovedEvent(object sender, MoveEvent e)
    {
      SetPosition(e.Position);
    }

    private void Network_StatusEventHandler(object sender, NetworkStatusEvent e)
    {
      BeginInvoke(new MethodInvoker(delegate ()
      {
        if (Globals.Network.Connected == false)
        {
          StatusBox.BackColor = Color.Red;
          StatusBox.Text = "SERVER DISCONNECTED";
        }
        else
        {
          StatusBox.BackColor = Color.White;
          StatusBox.Text = "Connected";
        }
      }));
    }

    private void MMessageBus_ErrorHandler(object sender, ErrorEvent e)
    {
      StatusBox.BackColor = Color.Red;
      StatusBox.Text += e.ErrorMessage + "\r\n";
    }

    private void MMessageBus_InfoEventHandler(object sender, InfoEvent e)
    {
      StatusBox.BackColor = Color.White;
      StatusBox.Text = e.Message;
    }

    private void Network_PositionChangeHandler(object sender, Massive.Events.MoveEvent e)
    {
      SetPosition(e.Position);
    }

    private void Network_TeleportHandler(object sender, Massive.Events.MoveEvent e)
    {
      SetPosition(e.Position);
    }

    void SetPosition(Vector3d pos)
    {
      Invoke(new MethodInvoker(delegate ()
      {
        PositionBox.Text = pos.ToString();
      }));      
    }   
  }
}
