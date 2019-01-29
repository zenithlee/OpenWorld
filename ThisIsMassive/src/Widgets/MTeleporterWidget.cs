using Massive;
using Massive.Events;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.src;
using ThisIsMassive.src.Handlers;

namespace ThisIsMassive.Widgets
{
  public class MTeleporterWidget : MWidget
  {
    public static void Mc_DoubleClick(MObject mo)
    {
      string sTag = (string)mo.Tag;
      string[] parms = sTag.Split('|');
      if (parms.Length > 0)
      {
        Vector3d v = MZoneService.Find(parms[1]);
        MMessageBus.Status(mo, "Teleporting to:" + parms[1] + " - " + parms[2]);
        MMessageBus.TeleportRequest(mo, (string)parms[1], v, Quaterniond.Identity);
      }
    }
  }
}
