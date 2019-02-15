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
    public static int MaxTerrains = 1;
    public static int MaxTreesPerTerrain = 2000;
    public static bool DrawPlanets = true;
    public static bool DrawBackdrop = true;
    public static bool DrawTrees = true;
    public static bool DrawTerrains = true;
    public static double TreeDensity = 0.04;
    public static bool TerrainPhysics = true;
    public static bool Gravity = true;
    public static Vector3d OffsetFirstPerson = Vector3d.Zero;
    public static Vector3d OffsetThirdPerson = new Vector3d(0, 1.3, 2);

    public static string CDNIP = "127.0.0.1";
    public static string UpdateServerIP = "10.0.0.3";
    //public static string TileDataPath = @"D:\MASSIVE_TEMP\UserData\Cache\";
    public static string TileDataPath = @".\Assets\Terrain\";

    public static bool DebugNetwork = false;
    public static bool DebugRender = false;    
  }
}
