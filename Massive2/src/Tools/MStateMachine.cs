using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Massive.Tools
{
  public class MStateMachine
  {
    public static Control Owner;
    public enum eStates
    {
      CheckTerms, ConnectToLobby, ConnectToMASSIVE, CheckLoginDetails, Login, Splash, Setup,
      DownloadingWorld, Viewing, Building, Decorating, Error
    };
    public static eStates CurrentState = eStates.CheckTerms;

    public static double BuildThreshold = 40;
    //when true, the user can't build here
    public static bool ZoneLocked = false;

    public static event EventHandler<EventArgs> StateChanged;


    public MStateMachine(Control inOwner)
    {
      Owner = inOwner;
    }

    public static void ChangeState(eStates NewState)
    {
      CurrentState = NewState;
      Console.WriteLine("STATE:" + CurrentState.ToString());
      if (StateChanged != null)
      {
        Owner.Invoke((MethodInvoker)
          delegate
          {
            StateChanged(null, new EventArgs());
          });
      }
    }
  }
}
