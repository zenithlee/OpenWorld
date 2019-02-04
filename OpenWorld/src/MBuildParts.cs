using Massive;
using Massive.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld
{
  public class MBuildParts
  {
    public const string FOUNDATION01 = "FOUNDATION01";
    public const string TELEPORT01 = "TELEPORT01";

    public static string SHOPFRONT01 = "SHOPFRONT01";
    public static string SHOPFRONT02 = "SHOPFRONT02";
    public static string SHOPFRONT03 = "SHOPFRONT03";
    public static string COUNTER01 = "COUNTER01";
    public static string COUNTER02 = "COUNTER02";
    public static string BARRIER01 = "BARRIER01";
    public static string PILLAR01 = "PILLAR01";
    public static string PILLAR02 = "PILLAR02";

    public const string AVATAR01 = "AVATAR01";
    public const string AVATAR02 = "AVATAR02";
    public const string AVATAR03 = "AVATAR03";

    public const string PERSON01 = "PERSON01";

    public static string WALL01 = "WALL01";
    public static string WALL03 = "WALL03";
    public static string WINDOW01 = "WINDOW01";
    public static string DOOR01 = "DOOR01";
    public static string DOORWAY01 = "DOORWAY01";
    public static string FLOOR01 = "FLOOR01";
    public static string FLOOR02 = "FLOOR02";
    public static string FLOOR03 = "FLOOR03";
    public static string FLOOR04 = "FLOOR04";
    public static string FLOORTRI01 = "FLOORTRI01";
    public static string CEILING01 = "CEILING01";

    public static string PICTURE01 = "PICTURE01";
    public static string PICTURE02 = "PICTURE02";
    public static string PICTURE03 = "PICTURE03";
    public static string PICTURE04 = "PICTURE04";
    public static string PICTURE05 = "PICTURE05";
    public static string BANNER01 = "BANNER01";
    public static string BANNER02 = "BANNER02";

    public static string CUBE01 = "CUBE01";
    public static string CUBE03 = "CUBE03";
    public static string BLOCK3X1 = "BLOCK3X1";
    public static string BLOCK1X3 = "BLOCK1X3";
    public static string SPHERE01 = "SPHERE01";
    public static string WEDGE01 = "WEDGE01";
    public static string WEDGE3X1 = "WEDGE3X1";
    public static string LIGHT01 = "LIGHT01";
    public static string LIGHT02 = "LIGHT02";

    public static string BOOK01 = "BOOK01";
    public static string TREE01 = "TREE01";
    public static string TREE02 = "TREE02";
    public static string TREE03 = "TREE03";
    public static string GLASS01 = "GLASS01";
    public static string GLASS02 = "GLASS02";

    public static string STAIRS01 = "STAIRS01";
    public static string BUILDING01 = "BUILDING01";
    public static string BUILDING02 = "BUILDING02";
    public static string BUILDING03 = "BUILDING03";

    public static string DUPLICATE = "DUPLICATE";
    public static string AUDIOCITY01 = "AUDIOCITY01";

    //////////// FURNITURE //////////////////
    public static string TABLE01 = "TABLE01";

    public static string ASTEROID01 = "ASTEROID01";
    public static string ASTEROID02 = "ASTEROID02";
    public static string ASTEROID03 = "ASTEROID03";
    public static string ASTEROIDBELT = "ASTEROIDBELT";
    public static string SPACESTATION01 = "SPACESTATION01";

    public const string MModel = "MModel";
    public const string MSphere = "MSphere";
    public const string MCube = "MCube";

    static Dictionary<string, MBuildingBlock> Blocks;

    public void Setup()
    {
      Blocks = new Dictionary<string, MBuildingBlock>();
     // AddDefaults();
      string sData = MFileSystem.GetFile(MFileSystem.RegistryPath);
      if (string.IsNullOrEmpty(sData)) return;
      Blocks = JsonConvert.DeserializeObject<Dictionary<string, MBuildingBlock>>(sData);

      SetupMaterials();
    }

    void SetupMaterials()
    {
      MShader WallShader = new MShader("WallShader");
      WallShader.Load("Shaders\\default_v.glsl",
        "Shaders\\default_f.glsl",
        "Shaders\\Terrain\\eval.glsl",
        "Shaders\\Terrain\\control.glsl"
        );
      WallShader.Bind();
      WallShader.SetInt("material.diffuse", MShader.LOCATION_DIFFUSE);
      WallShader.SetInt("material.specular", MShader.LOCATION_SPECULAR);
      WallShader.SetInt("material.multitex", MShader.LOCATION_MULTITEX);
      WallShader.SetInt("material.normalmap", MShader.LOCATION_NORMALMAP);
      WallShader.SetInt("material.shadowMap", MShader.LOCATION_SHADOWMAP);

      MMaterial Avatar2Mat = new MMaterial("AVATAR02M");
      Avatar2Mat.AddShader(WallShader);
      Avatar2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar02.jpg"));
      MScene.MaterialRoot.Add(Avatar2Mat);
    }

    public static MBuildingBlock GetBlock(string sTemplateID)
    {
      if (Blocks.ContainsKey(sTemplateID))
      {
        return Blocks[sTemplateID];
      }

      //if we can't find a registry entry, return sphere.
      MBuildingBlock bb = new MBuildingBlock(sTemplateID);
      bb.Type = "MSPHERE";
      return bb;
    }

    public void AddDefaults()
    {
      MBuildingBlock b = new MBuildingBlock("FOUNDATION01");      
      b.Size = new double[] { 1, 1, 1 };
      b.Model = Path.Combine(Globals.AssetsPath, "Models", "Construction", "foundation01.3ds");
      Blocks.Add(b.Name, b);
      b = new MBuildingBlock("Test1");
      Blocks.Add(b.Name, b);
      b = new MBuildingBlock("Test2");
      Blocks.Add(b.Name, b);
      string sTemp = JsonConvert.SerializeObject(Blocks);
    }
  }
}
