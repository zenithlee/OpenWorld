using Massive;
using Massive.GIS;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.GIS
{
  public class MClimate : MObject
  {
    public MClimate() 
      : base (EType.Other, "MClimate")
    {

    }

    public static void SetTimeOfDay(double time)
    {
      MAstroBody Sol = MPlanetHandler.Get("Sol");
      Quaterniond q = Quaterniond.FromEulerAngles(0, 0, time * Math.PI / 180.0);
      MSceneObject mo = (MSceneObject)MScene.AstroRoot.FindModuleByName("Sol");
      mo.SetPosition(new Vector3d(time * 10000000000, 0, 0));
    }
  }
}
