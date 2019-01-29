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

namespace ThisIsMassive.src.Forms
{
  public partial class SalesForm : DToolForm
  {
    MSceneObject Target;

    public SalesForm()
    {
      InitializeComponent();
      SetTitle("Sales");
      MMessageBus.PropertyChangeEvent += MMessageBus_PropertyChangeEvent;
    }

    private void MMessageBus_PropertyChangeEvent(object sender, ChangePropertyEvent e)
    {
      if ( e.InstanceID == Target.InstanceID)
      {
        StatusText.Text = "Order Placed";
      }
    }

    void DoClose()
    {
      MMessageBus.PropertyChangeEvent -= MMessageBus_PropertyChangeEvent;
    }

    public void Setup(MObject mo)
    {
      Target = (MSceneObject)mo;
    }

    private void PlaceOrderButton_Click(object sender, EventArgs e)
    {
      if (Target == null) return;
      string sTag = (string)Target.Tag;
      Globals.Network.ChangePropertyRequest(Globals.UserAccount.UserID, sTag);
    }
  }
}
