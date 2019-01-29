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
  public partial class TeleporterConfigForm : Form
  {
    string InstanceID;
    string Destination;
    string Description;
    bool Success = false;

    public TeleporterConfigForm()
    {
      InitializeComponent();      
      MMessageBus.PropertyChangeEvent += Network_PropertyChangeHandler;
      timer1.Tick += Timer1_Tick;
    }

    private void MMessageBus_PropertyChangeEvent(object sender, ChangePropertyEvent e)
    {
      throw new NotImplementedException();
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      Globals.Network.PropertyChangeHandler -= Network_PropertyChangeHandler;
      timer1.Tick -= Timer1_Tick;
      Close();
    }

    private void Network_PropertyChangeHandler(object sender, ChangePropertyEvent e)
    {

      MObject mo = MScene.Root.FindModuleByInstanceID(e.InstanceID);
      if ( mo != null )
      {
        mo.Tag = e.PropertyTag;
      }

      if (e.InstanceID.Equals(InstanceID))
      {
        Invoke((MethodInvoker)delegate
        {
          ErrorLabel.Text = "Success!";
          ErrorLabel.ForeColor = Color.DarkGreen;
          Success = true;
          //UpdatePropertiesButton.Text = "OK";
          timer1.Start();
        });        
      }
      else
      {
        ErrorLabel.Text = "Can't Update. Try Again?";
        ErrorLabel.ForeColor = Color.DarkRed;
        UpdatePropertiesButton.Text = "Try Again";
      }
    }

    public void Setup(string inInstanceID, string inDestination, string inDescription)
    {
      InstanceID = inInstanceID;
      Destination = inDestination;
      DestinationBox.Text = Destination;

      Description = inDescription;
      DescriptionBox.Text = Description;
    }

    private void UpdatePropertiesButton_Click(object sender, EventArgs e)
    {
      if ( Success == true )
      {
        Globals.Network.PropertyChangeHandler -= Network_PropertyChangeHandler;
        Close();
      }
      if (string.IsNullOrEmpty(DestinationBox.Text))
      {
        return;
      }
      Destination = DestinationBox.Text;
      Description = DescriptionBox.Text;

      Globals.Network.ChangePropertyRequest(InstanceID, BuildParts.TELEPORT01 + "|" + Destination + "|" + Description);
    }
  }
}
