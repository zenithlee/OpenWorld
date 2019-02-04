using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MBoundingBox
  {
    public Vector3d P1;
    public Vector3d P2;
    public override string ToString()
    {
      return P1.ToString() + "-" + P2.ToString();
    }

    public Vector3d Size()
    {
      return P2 - P1;
    }
  }
}
