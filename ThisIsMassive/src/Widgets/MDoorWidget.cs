using Massive;
using Massive.Events;
using System.Drawing;
using ThisIsMassive.src.Forms;

namespace ThisIsMassive.Widgets
{
  public class MDoorWidget : MWidget
  {
    public static void Mc_DoubleClick(MObject mo)
    {
      if (mo.OwnerID.Equals(Globals.UserAccount.UserID))
      {
        DoorConfigForm dc = new DoorConfigForm();
        dc.Setup((MSceneObject)mo);
        //dc.Parent = Main.GetInstance();
        dc.ShowCenter(Main.GetInstance());
       
      }
      else
      {
        MMessageBus.Status(null, "Not the owner");
      }
    }
  }
}
