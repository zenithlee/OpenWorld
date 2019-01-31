using Massive;
using Massive.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.src
{
  public class MBuildParts
  {
    List<MBuildingBlock> Blocks;

    public void Setup()
    {
      Blocks = new List<MBuildingBlock>();
      //AddDefaults();
      string sData = MFileSystem.GetFile(MFileSystem.RegistryPath);
      if (string.IsNullOrEmpty(sData)) return;
      Blocks = JsonConvert.DeserializeObject<List<MBuildingBlock>>(sData);
    }

    public void AddDefaults()
    {
      MBuildingBlock b = new MBuildingBlock();
      b.Name = "FOUNDATION01";
      b.Size = new double[] { 1, 1, 1 };
      b.Model = Path.Combine(Globals.AssetsPath, "Models", "Construction", "foundation01.3ds");
      Blocks.Add(b);
      b = new MBuildingBlock();
      Blocks.Add(b);
      b = new MBuildingBlock();
      Blocks.Add(b);
      string sTemp = JsonConvert.SerializeObject(Blocks);
    }
  }
}
