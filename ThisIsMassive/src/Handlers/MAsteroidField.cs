using Massive;
using Massive.Platform;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.src;

namespace ThisIsMassive
{
  public class MAsteroidField
  {
    public void Generate()
    {
      string sAsteroid01 = Path.Combine(MFileSystem.AppDataPath, @"Models\planets\asteroid01.3ds");
      Random r = new Random();

      for (int i = 0; i < 10; i++)
      {
        Vector3d pos = Globals.Avatar.GetPosition() + new Vector3d(r.NextDouble() * 100, r.NextDouble() * 100, r.NextDouble() * 100);
        Globals.Network.SpawnRequest(BuildParts.ASTEROID01, "ASTEROID01T", "Asteroid", "10", pos, Quaterniond.Identity);
      }
    }

    public void Generate2()
    {
      string sAsteroid01 = Path.Combine(MFileSystem.AppDataPath, @"Models\planets\asteroid02.3ds");
      Random r = new Random();

      for (int i = 0; i < 10; i++)
      {
        Vector3d pos = Globals.Avatar.GetPosition() + new Vector3d(r.NextDouble() * 100, r.NextDouble() * 100, r.NextDouble() * 100);
        Globals.Network.SpawnRequest(BuildParts.ASTEROID02, "ASTEROID02T", "Asteroid", "10", pos, Quaterniond.Identity);
      }
    }
  }
}
