using Massive;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.Widgets;

namespace ThisIsMassive
{
  public static class BuildParts
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

    public static MSceneObject AddModel(string Code, string File, Vector3d Scale,
      MPhysicsObject.EShape Shape = MPhysicsObject.EShape.Box,
      double mass = 0)
    {
      MMaterial DefaultMat = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);

      MModel mso = Helper.CreateModel(MScene.TemplateRoot, Code, File, Vector3d.Zero);
      mso.InstanceID = Code;
      mso.TemplateID = Code;
      mso.SetMaterial(DefaultMat);
      MPhysicsObject pow = new MPhysicsObject(mso, "TABLEPO", mass, Shape, true, Scale * 0.5);
      return mso;
    }

    public static void AddHinge(MSceneObject mo1, MSceneObject mo2)
    {
      //MPhysicsObject po = (MPhysicsObject)mo1.FindModuleByType(MObject.EType.PhysicsObject);
      //MPhysicsObject po2 = (MPhysicsObject)mo2.FindModuleByType(MObject.EType.PhysicsObject);
      //po.SetLinearFactor(0, 0, 0);      
      //po.SetAngularFactor(0.1, 0.1, 0.1);
      //po.AddHinge(po2);
    }

    public static void AddTree()
    {
      MShader TreeShader = Helper.CreateShader("TreeShader");
      MMaterial MTreeMaterial = new MMaterial("TREE01T");
      MTreeMaterial.AddShader(TreeShader);
      MTreeMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\foliage\\pine01.png"));
      MScene.MaterialRoot.Add(MTreeMaterial);

      MSceneObject motree = AddModel(BuildParts.TREE01, @"Models\tree01.3ds", new Vector3d(2, 4, 2));
      motree.SetMaterial(MTreeMaterial);
      motree.IsTransparent = true;

      MSceneObject motree2 = AddModel(BuildParts.TREE02, @"Models\tree02.3ds", new Vector3d(2, 4, 2));
      motree2.SetMaterial(MTreeMaterial);
      motree2.IsTransparent = true;

      MSceneObject motree3 = AddModel(BuildParts.TREE03, @"Models\tree03.3ds", new Vector3d(0.2, 1, 0.2));
      motree3.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL));
    }

    public static void AddGlass()
    {
      MShader GlassShader = Helper.CreateShader("GlassShader");
      MMaterial MGlassMaterial = new MMaterial("GLASS01M");
      MGlassMaterial.AddShader(GlassShader);
      MGlassMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\glass01.png"));
      MScene.MaterialRoot.Add(MGlassMaterial);

      MSceneObject Glasspane = AddModel(BuildParts.GLASS01, @"Models\glass01.3ds", new Vector3d(1, 2, 0.1));
      Glasspane.SetMaterial(MGlassMaterial);
      Glasspane.IsTransparent = true;
      Glasspane.CastsShadow = false;

      MSceneObject Glasspane2 = AddModel(BuildParts.GLASS02, @"Models\glass02.3ds", new Vector3d(2, 2, 0.1));
      Glasspane2.SetMaterial(MGlassMaterial);
      Glasspane2.IsTransparent = true;
      Glasspane2.CastsShadow = false;
    }

    public static void AddLights()
    {
      /////////////////// LIGHTING ////////////////////
      MSphere tPointLight = Helper.CreateSphere(MScene.TemplateRoot, 2, BuildParts.LIGHT01, Vector3d.Zero);
      //MModel tPointLight = Helper.CreateModel(MScene.TemplateRoot, BuildParts.LIGHT01, @"Models\earth.3ds", Vector3d.Zero);
      tPointLight.transform.Scale = new Vector3d(1, 1, 1);
      tPointLight.InstanceID = BuildParts.LIGHT01;
      tPointLight.TemplateID = BuildParts.LIGHT01;
      tPointLight.CastsShadow = false;
      tPointLight.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName("WHITEM"));
      MPointLight mp = new MPointLight("PointLight");
      tPointLight.Add(mp);
      //MPhysicsObject pp2 = new MPhysicsObject(tPointLight, "PICPO", 2.6f, MPhysicsObject.EShape.Sphere, true, tPointLight.transform.Scale);
      //pp2.SetRestitution(0.6);
      //pp2.SetDamping(0.5, 0.5);

      MModel ml = (MModel)Helper.CreateModel(MScene.TemplateRoot, BuildParts.LIGHT02, @"Models\light02.3ds", Vector3d.Zero);
      ml.transform.Scale = new Vector3d(0.2, 0.2, 0.2);
      ml.InstanceID = BuildParts.LIGHT02;
      ml.TemplateID = BuildParts.LIGHT02;
      ml.CastsShadow = false;
      ml.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName("WHITEM"));
      MPointLight mp2 = new MPointLight("PointLight");
      ml.Add(mp2);
    }

    public static void AddBooks()
    {
      MSceneObject mo = AddModel(BuildParts.BOOK01, @"Models\book01.3ds", new Vector3d(0.5, 0.6, 0.05));
      MClickHandler mc = new MClickHandler();
      mc.DoubleClicked = MBookWidget.CH_DoubleClick;
      mo.Add(mc);
      mo.Tag = "BOOK01|MY BOOK";
    }

    public static void AddRoads()
    {
      MShader RoadShader = Helper.CreateShader("RoadShader");

      MMaterial RoadMaterial = new MMaterial("ROAD01M");
      RoadMaterial.AddShader(RoadShader);
      RoadMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\roads\\asphalt01.jpg"));
      MScene.MaterialRoot.Add(RoadMaterial);

      MMaterial Road2Material = new MMaterial("ROAD02M");
      Road2Material.AddShader(RoadShader);
      Road2Material.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\roads\\asphalt02.jpg"));
      MScene.MaterialRoot.Add(Road2Material);

      MMaterial Road3Material = new MMaterial("ROAD03M");
      Road3Material.AddShader(RoadShader);
      Road3Material.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\roads\\asphalt03.jpg"));
      MScene.MaterialRoot.Add(Road3Material);

      MSceneObject rd = AddModel("STRAIGHT01", @"Models\roads\straight01.3ds", new Vector3d(10, 0.5, 20));
      rd.SetMaterial(RoadMaterial);
    }

    public static void AddDoors()
    {
      MShader DoorShader = Helper.CreateShader("DoorShader");

      MMaterial Door1Material = new MMaterial("DOOR01M");
      Door1Material.AddShader(DoorShader);
      Door1Material.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\door01.jpg"));
      MScene.MaterialRoot.Add(Door1Material);

      MSceneObject mo = AddModel(BuildParts.DOOR01, @"Models\door01.3ds", new Vector3d(1.4, 2.42, 0.1), MPhysicsObject.EShape.ConcaveMesh);
      mo.SetMaterial(Door1Material);
      mo.Add(new MDoor(mo));
      MClickHandler mc = new MClickHandler();
      mc.DoubleClicked = MDoorWidget.Mc_DoubleClick;
      mo.Add(mc);
      mo.Tag = "DOOR01|" + MDoor.PUBLIC;
    }

    public static void AddPeople()
    {
      MShader PeopleShader = Helper.CreateShader("PeopleShader");

      MMaterial PeopleMaterial = new MMaterial("PERSON01M");
      PeopleMaterial.AddShader(PeopleShader);
      PeopleMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\people\\lwpg0042.jpg"));
      MScene.MaterialRoot.Add(PeopleMaterial);

      MModel s = Helper.CreateModel(MScene.TemplateRoot, BuildParts.PERSON01, @"Models\people\person01.3ds", new Vector3d(0, 0, 0));
      s.InstanceID = BuildParts.PERSON01;
      s.TemplateID = BuildParts.PERSON01;
      s.SetMaterial(PeopleMaterial);
      MPhysicsObject poa = new MPhysicsObject(s, "AVATAR", 0, MPhysicsObject.EShape.Capsule, true, new Vector3d(0.3, 1.2, 0.5));
      MClickHandler mc = new MClickHandler();
      mc.DoubleClicked = MSalesmanWidget.Clicked;
      s.Add(mc);
      s.Tag = "SALES01|HELLO|01";

      MNPC npc = new MNPC(s);
      s.Add(npc);


      MShader WallShader = (MShader)MScene.MaterialRoot.FindModuleByName("WallShader");

      MMaterial AvatarMat = new MMaterial("AVATAR01T");
      AvatarMat.AddShader(WallShader);
      AvatarMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar01.jpg"));
      MScene.MaterialRoot.Add(AvatarMat);

      MMaterial Avatar2Mat = new MMaterial("AVATAR02T");
      Avatar2Mat.AddShader(WallShader);
      Avatar2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar02.jpg"));
      MScene.MaterialRoot.Add(Avatar2Mat);

      MMaterial Avatar3Mat = new MMaterial("AVATAR03T");
      Avatar3Mat.AddShader(WallShader);
      Avatar3Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\avatar02.jpg"));
      MScene.MaterialRoot.Add(Avatar3Mat);


      ////////////////// AVATARS /////////////////////

      MModel s1 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.AVATAR01, @"Models\avatar01.3ds", new Vector3d(0, 0, 0));
      s1.InstanceID = BuildParts.AVATAR01;
      s1.TemplateID = BuildParts.AVATAR01;
      s1.IsAvatar = true;
      s1.SetMaterial(AvatarMat);
      MPhysicsObject poa1 = new MPhysicsObject(s1, "Physics", 5f, MPhysicsObject.EShape.Capsule, true, new Vector3d(0.3, 1.2, 0.5));
      poa1.SetDamping(0.7, 0.5);
      poa1.SetRestitution(0.5);
      poa1.SetSleep(15);
      poa1.SetAngularFactor(0.0, 0.0, 0.0);


      MModel s2 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.AVATAR01, @"Models\avatar02.3ds", new Vector3d(0, 0, 0));
      s2.InstanceID = BuildParts.AVATAR02;
      s2.TemplateID = BuildParts.AVATAR02;
      s2.IsAvatar = true;
      s2.SetMaterial(Avatar2Mat);
      MPhysicsObject poa2 = new MPhysicsObject(s2, "Physics", 5f, MPhysicsObject.EShape.Capsule, true, new Vector3d(0.3, 1.2, 0.5));
      poa2.SetDamping(0.7, 0.5);
      poa2.SetRestitution(0.5);
      poa2.SetAngularFactor(0.0, 0.0, 0.0);
      poa2.SetSleep(15);

      MModel s3 = Helper.CreateModel(MScene.TemplateRoot, BuildParts.AVATAR03, @"Models\Vehicles\eagle.3ds", new Vector3d(0, 0, 0));
      s3.InstanceID = BuildParts.AVATAR03;
      s3.TemplateID = BuildParts.AVATAR03;
      s3.IsAvatar = true;
      s3.SetMaterial(Avatar3Mat);
      MPhysicsObject poa3 = new MPhysicsObject(s3, "Physics", 10.5f, MPhysicsObject.EShape.Sphere, true, new Vector3d(0.3, 1.2, 0.5));
      poa3.SetDamping(0.02, 0.02);
      poa3.SetRestitution(0.1);
      poa3.SetAngularFactor(1, 1, 1);
      poa3.SetSleep(15);
    }

    public static void AddBuildings()
    {
      MShader BuildingShader = Helper.CreateShader("BuildingShader");

      MMaterial BuildingMaterial = new MMaterial("BUILDING01M");
      BuildingMaterial.AddShader(BuildingShader);
      BuildingMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\buildings\\building01.jpg"));
      MScene.MaterialRoot.Add(BuildingMaterial);

      MSceneObject m = AddModel(BuildParts.BUILDING01, @"Models\buildings\building01.3ds", new Vector3d(20, 40, 20));
      m.SetMaterial(BuildingMaterial);

      MMaterial BuildingMaterial2 = new MMaterial("BUILDING02M");
      BuildingMaterial2.AddShader(BuildingShader);
      BuildingMaterial2.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\buildings\\building02.jpg"));
      MScene.MaterialRoot.Add(BuildingMaterial2);

      MSceneObject m2 = AddModel(BuildParts.BUILDING02, @"Models\buildings\building02.3ds", new Vector3d(30, 60, 30));
      m2.SetMaterial(BuildingMaterial2);

      MMaterial BuildingMaterial3 = new MMaterial("BUILDING03M");
      BuildingMaterial3.AddShader(BuildingShader);
      BuildingMaterial3.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\buildings\\building03.jpg"));
      MScene.MaterialRoot.Add(BuildingMaterial3);

      MSceneObject m3 = AddModel(BuildParts.BUILDING03, @"Models\buildings\building03.3ds", new Vector3d(15, 10, 15));
      m3.SetMaterial(BuildingMaterial3);

      MSceneObject citysound = AddModel(BuildParts.AUDIOCITY01, @"Models\cube01.3ds", new Vector3d(1, 1, 1));
      citysound.SetMaterial(BuildingMaterial3);
      MSound cs = new MSound();
      string sPath = Path.Combine(Globals.AssetsPath, @"Audio\street.wav");
      cs.Load(sPath);
      cs.PlayOnAwake = true;
      cs.Loop = true;
      cs.Volume = 0.1f;
      citysound.Add(cs);

      //MScene.UtilityRoot.Add(cs);
    }

    public static void AddShops()
    {
      AddModel(BuildParts.SHOPFRONT01, @"Models\shopfront01.3ds", new Vector3d(3, 1.5, 0.2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.SHOPFRONT02, @"Models\shopfront02.3ds", new Vector3d(1.5, 1.5, 0.2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.SHOPFRONT03, @"Models\shopfront03.3ds", new Vector3d(1.5, 1.5, 0.2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.COUNTER01, @"Models\shops\counter01.3ds", new Vector3d(0.6, 1.0, 1.0), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.COUNTER02, @"Models\shops\counter02.3ds", new Vector3d(0.4, 1.0, 0.4), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.BARRIER01, @"Models\barrier01.3ds", new Vector3d(1.5, 0.25, 0.2), MPhysicsObject.EShape.ConcaveMesh);
    }

    public static void AddPlanets()
    {
      MShader AsteroidShader = Helper.CreateShader("AsteroidShader");

      MMaterial AsteroidMaterial = new MMaterial("ASTEROID01T");
      AsteroidMaterial.AddShader(AsteroidShader);
      AsteroidMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\planets\\asteroid01.jpg"));
      MScene.MaterialRoot.Add(AsteroidMaterial);

      MMaterial AsteroidMaterial2 = new MMaterial("ASTEROID02T");
      AsteroidMaterial2.AddShader(AsteroidShader);
      AsteroidMaterial2.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\planets\\asteroid02.jpg"));
      MScene.MaterialRoot.Add(AsteroidMaterial2);

      MMaterial AsteroidBeltMaterial = new MMaterial("ASTEROIDBELTT");
      AsteroidBeltMaterial.AddShader(AsteroidShader);
      AsteroidBeltMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\planets\\asteroid03.jpg"));
      MScene.MaterialRoot.Add(AsteroidBeltMaterial);

      AddModel(BuildParts.ASTEROID01, @"Models\planets\asteroid01.3ds",
        new Vector3d(10.5, 10.25, 10.2),
        MPhysicsObject.EShape.Sphere, 5)
        .SetMaterial(AsteroidMaterial);

      AddModel(BuildParts.ASTEROID02, @"Models\planets\asteroid02.3ds",
        new Vector3d(10.5, 10.25, 10.2),
        MPhysicsObject.EShape.Sphere, 5)
        .SetMaterial(AsteroidMaterial2);

      MMaterial SpaceStationMaterial = new MMaterial("SPACESTATION01T");
      SpaceStationMaterial.AddShader(AsteroidShader);
      SpaceStationMaterial.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\buildings\\spacestation01.jpg"));
      MScene.MaterialRoot.Add(SpaceStationMaterial);

      AddModel(BuildParts.SPACESTATION01, @"Models\buildings\spacestation01.3ds",
       new Vector3d(100.5, 100.25, 100.2),
       MPhysicsObject.EShape.ConcaveMesh, 0)
       .SetMaterial(SpaceStationMaterial);      

      MMaterial DefaultMat = (MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL);

      MInstanceModel mso = new MInstanceModel("AsteroidBelt",
        @"Models\planets\asteroid01.3ds",
        @"Textures\planets\asteroid03.jpg");
      mso.InstanceID = BuildParts.ASTEROIDBELT;
      mso.TemplateID = BuildParts.ASTEROIDBELT;
      mso.SetMaterial(AsteroidBeltMaterial);
      MScene.TemplateRoot.Add(mso);
    }

    public static void AddColors()
    {
      MShader WallShader = (MShader)MScene.MaterialRoot.FindModuleByName("WallShader");

      MMaterial BlackMat = new MMaterial("BLACK01M");
      BlackMat.AddShader(WallShader);
      BlackMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\black01.jpg"));
      MScene.MaterialRoot.Add(BlackMat);

      MMaterial PinkMat = new MMaterial("PINK01M");
      PinkMat.AddShader(WallShader);
      PinkMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\pink01.jpg"));
      MScene.MaterialRoot.Add(PinkMat);

      MMaterial PurpleMat = new MMaterial("PURPLE01M");
      PurpleMat.AddShader(WallShader);
      PurpleMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\purple01.jpg"));
      MScene.MaterialRoot.Add(PurpleMat);

      MMaterial RedMat = new MMaterial("RED01M");
      RedMat.AddShader(WallShader);
      RedMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\red01.jpg"));
      MScene.MaterialRoot.Add(RedMat);

      MMaterial GreenMat = new MMaterial("GREEN01M");
      GreenMat.AddShader(WallShader);
      GreenMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\green01.jpg"));
      MScene.MaterialRoot.Add(GreenMat);

      MMaterial GrayMat = new MMaterial("GRAY01M");
      GrayMat.AddShader(WallShader);
      GrayMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\gray01.jpg"));
      MScene.MaterialRoot.Add(GrayMat);

      MMaterial Gray2Mat = new MMaterial("GRAY02M");
      Gray2Mat.AddShader(WallShader);
      Gray2Mat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\gray02.jpg"));
      MScene.MaterialRoot.Add(Gray2Mat);

      MMaterial BrownMat = new MMaterial("BROWN01M");
      BrownMat.AddShader(WallShader);
      BrownMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\brown01.jpg"));
      MScene.MaterialRoot.Add(BrownMat);

      MMaterial BeigeMat = new MMaterial("BEIGE01M");
      BeigeMat.AddShader(WallShader);
      BeigeMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\beige01.jpg"));
      MScene.MaterialRoot.Add(BeigeMat);

      MMaterial BlueMat = new MMaterial("BLUE01M");
      BlueMat.AddShader(WallShader);
      BlueMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\blue01.jpg"));
      MScene.MaterialRoot.Add(BlueMat);

      MMaterial GlassMat = new MMaterial("GLASS01M");
      GlassMat.AddShader(WallShader);
      GlassMat.SetDiffuseTexture(Globals.TexturePool.GetTexture("Textures\\construction\\glass01.jpg"));
      MScene.MaterialRoot.Add(GlassMat);
    }

    public static void AddConstruction()
    {
      MModel Foundation = Helper.CreateModel(MScene.TemplateRoot, BuildParts.FOUNDATION01, @"Models\Construction\foundation01.3ds", Vector3d.Zero);
      //MCube floor01 = Helper.CreateCube(MScene.TemplateRoot, BuildParts.FLOOR01);
      Foundation.InstanceID = BuildParts.FOUNDATION01;
      Foundation.TemplateID = BuildParts.FOUNDATION01;
      Foundation.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName("FLOOR03T"));
      MPhysicsObject pof = new MPhysicsObject(Foundation, "FLOOPO", 0f, MPhysicsObject.EShape.Box, true, new Vector3d(20, 2.0, 20) * 0.5);
      //floor01.Setup();
    }

    public static void CreateTemplates()
    {
      AddModel(BuildParts.TABLE01, @"Models\table01.3ds", new Vector3d(2, 0.75, 0.75));
      AddModel(BuildParts.PICTURE01, @"Models\picture01.3ds", new Vector3d(1.17, 1.7, 0.1));
      AddModel(BuildParts.PICTURE02, @"Models\picture02.3ds", new Vector3d(1.17, 1.17, 0.11));
      AddModel(BuildParts.PICTURE03, @"Models\picture03.3ds", new Vector3d(0.9, 1.17, 0.11));
      AddModel(BuildParts.PICTURE04, @"Models\picture04.3ds", new Vector3d(1.4, 1.0, 0.1));
      AddModel(BuildParts.PICTURE05, @"Models\picture05.3ds", new Vector3d(2.8, 1.6, 0.1));
      AddModel(BuildParts.CUBE03, @"Models\cube03.3ds", new Vector3d(3, 3, 3));
      AddModel(BuildParts.BLOCK3X1, @"Models\block3x1.3ds", new Vector3d(3, 1, 1));
      AddModel(BuildParts.BLOCK1X3, @"Models\block1x3.3ds", new Vector3d(1, 3, 1));
      AddModel(BuildParts.BANNER01, @"Models\banner01.3ds", new Vector3d(3, 1, 0.1));
      AddModel(BuildParts.BANNER02, @"Models\banner02.3ds", new Vector3d(2, 1, 0.1));
      AddModel(BuildParts.FLOOR01, @"Models\floor01.3ds", new Vector3d(2, 0.2, 2));
      AddModel(BuildParts.FLOOR02, @"Models\floor02.3ds", new Vector3d(4, 0.2, 4));
      AddModel(BuildParts.FLOOR03, @"Models\floor03.3ds", new Vector3d(6, 0.2, 6));
      AddModel(BuildParts.FLOOR04, @"Models\floor04.3ds", new Vector3d(6, 0.2, 2));
      AddModel(BuildParts.STAIRS01, @"Models\stairs01.3ds", new Vector3d(3, 3, 2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.WEDGE3X1, @"Models\wedge3x1.3ds", new Vector3d(3, 1, 1), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.FLOORTRI01, @"Models\floortri01.3ds", new Vector3d(1, 1, 1), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.PILLAR01, @"Models\pillar01.3ds", new Vector3d(0.2, 1.8, 0.2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.PILLAR02, @"Models\pillar02.3ds", new Vector3d(0.2, 1.8, 0.2), MPhysicsObject.EShape.ConcaveMesh);
      AddModel(BuildParts.DOORWAY01, @"Models\doorway01.3ds", new Vector3d(2, 3, 0.2), MPhysicsObject.EShape.ConcaveMesh);

      AddPlanets();
      AddConstruction();
      AddGlass();
      AddTree();
      AddLights();
      AddBooks();
      AddRoads();
      AddDoors();
      AddPeople();
      AddBuildings();
      AddShops();
      AddColors();


    }
  }
}

