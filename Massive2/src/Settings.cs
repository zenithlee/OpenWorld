//#define DEBUG_EVENTS
//#define DEBUG_STATEMACHINE

using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public static class Settings
  {
    public static int MaxTerrains = 2;
    public static bool DrawTrees = false;
    public static double TreeDensity = 0.04;
    public static bool TerrainPhysics = false;
    public static Vector3d OffsetFirstPerson = Vector3d.Zero;
    public static Vector3d OffsetThirdPerson = new Vector3d(0, 2, 2);

    public static string CDNIP = "197.93.157.217";
    public static string UpdateServerIP = "10.0.0.3";
    public static string TileDataPath = @"D:\MASSIVE_TEMP\UserData\Cache\";

    public static bool DebugNetwork = false;
    public static bool DebugRender = false;    
  }
}
