using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Events
{
  public class TeleportRequestHandler
  {
    public string Location;
    public Vector3d Position;
    public Quaterniond Rotation;

    public TeleportRequestHandler(string inLocation, Vector3d pos, Quaterniond rot)
    {
      Location = inLocation;
      Position = pos;
      Rotation = rot;
    }
  }
}
