using Massive;
using Massive.Network;
using Massive.GIS;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 
 * Reference date 2000/01/01
 * Reference point : Sol Center
 * Units: Meters, kg
 * 
 * */

namespace ThisIsMassive.src
{



  public class MPlanetInitializer : MObject
  {
    public static List<MAstroBody> Bodies = new List<MAstroBody>();

    const string CloudTexURL = @"Textures\Planets\Clouds.jpg";
    //MCube GravityIndicator;

    public MPlanetInitializer() : base(MObject.EType.Null, "Planet")
    {

    }

    public override void Setup()
    {

      //TODO:
      //ADD URL TEXTURES!
      /*
      Bodies.Add(new MAstroBody("Sol", "The Sun", 1.988544E+30, new Vector3d(0, 0, 0), new Vector3d(696000000, 696000000, 696000000), "Textures\\sun.jpg"));

      Bodies.Add(new MAstroBody("Venus", "The planet Venus", 48.685E+23, new Vector3d(-1.048122216556790E+08, 2.393654051492437E+07, -6.939236908324338E+06) * 1000,
         new Vector3d(6051.8, 6051.8, 6051.8) * 1000, "Textures\\2k_venus_surface.jpg"));
      //X = -1.048122216556790E+08 Y = 2.393654051492437E+07 Z = -6.939236908324338E+06
      //VX = -8.048894150515352E+00 VY = -3.423458014481214E+01 VZ = 6.724535965214056E-01

      Bodies.Add(new MAstroBody("Mars", "The planet Mars", 6.4185E+23, new Vector3d(1.995782587374064E+8, -5.523248829579433E+7, 2.040911708145680E+7) * 1000,
        new Vector3d(3389.9, 3389.9, 3389.9) * 1000, "Textures\\2k_mars.jpg"));
      //VX= 7.888925502949942E+00 VY= 2.512145341232943E+01 VZ=-1.428163670266684E-01

      Bodies.Add(new MAstroBody("Earth", "The planet Earth. Humans live here. For now.", 5.97219E+24, new Vector3d(1.272267138537290E+7, 1.463568132767451E+8, -7.583510712786615E+6) * 1000,
        new Vector3d(6371, 6371, 6371) * 1000, "Textures\\Planets\\Albedo.jpg",
        true, 7980169.7076954339));
      //VX = -2.999254798461512E+01 VY = 2.409743982501453E+00 VZ = -3.489312789986800E+00
      */
      Bodies.Add(new MAstroBody("Moon", "The Moon", 734.9E+20, new Vector3d(1.235183178863080E+7, 1.462044997645861E+8, -7.578605371678978E+6) * 1000, 
        new Vector3d(1738000.0, 1738000.0, 1738000.0), "https://www.bigfun.co.za/fu/static/2k_moon.jpg"));
      //VX=-2.965755272661235E+01 VY= 1.496658883251257E+00 VZ=-3.397496558449063E+00

      InitializePlanets();
    }



    public override void Update()
    {
      //Console.WriteLine("Update");
      Vector3d g = GetGravityVector();

      MPhysics.Instance.SetGravity(g);
      Globals.LocalUpVector = -g.Normalized();
      if (double.IsNaN(Globals.LocalUpVector.X))
      {
        Globals.LocalUpVector = Globals.Avatar.Target.transform.Up();
      }
      if (double.IsNaN(g.X))
      {
        g = new Vector3d(0, -9.8, 0);
      }
      Globals.LocalGravity = g;
      base.Update();
    }

    Vector3d GetGravityVector()
    {
      Vector3d g = Vector3d.Zero;
      if (Globals.Avatar.Target == null)
      {
        return Vector3d.UnitY * -9.8;
      }


      //bool EnableFog = false;
      double FogHeight = 0;
      foreach (MAstroBody b in Bodies)
      {
        double dist = Math.Abs(Vector3d.Distance(b.Position, Globals.Avatar.Target.transform.Position) - b.Radius.X);

        if (b.Name == "Earth")
        {

          FogHeight = MathHelper.Clamp(1 - ((dist - b.Radius.X) / (b.AtmosphereStart - b.Radius.X)), 0, 1);
          //EnableFog = true;
          //MMessageBus.Status(this, "Distance to: " + b.Name + " = " + dist + "," + b.Radius + " _>" + FogHeight);
        }

        Vector3d single = (b.Position - Globals.Avatar.Target.transform.Position).Normalized();
        single *= (1 / dist); //TODO Radius at direction vector
        g += single;
      }
      g *= 100000000.0;
      g *= 2;


      //MScene.Fog.FogEnabled = EnableFog==true?1:0;
      MScene.Fog.FogMultiplier = (float)FogHeight;
      //g *= 0.0000000000000000001; //the radius of a particle in MASSIVE
      //Console.WriteLine("Gravity:" + g);

      if (g.Length < 0.01) g = new Vector3d(0, -9.8, 0);

      // GravityIndicator.transform.Position = Globals.Avatar.Target.transform.Position + g.Normalized() * 0.5;

      // GravityIndicator.transform.Rotation = Extensions.LookAt(Globals.Avatar.Target.transform.Position, Globals.Avatar.Target.transform.Position + g.Normalized())
      //  * Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0);



      return g;
    }

    public void InitializePlanets()
    {

      //GravityIndicator = Helper.CreateCube(MScene.AstroRoot, "GravitySphere", Vector3d.Zero);
      //GravityIndicator.transform.Scale = new Vector3d(0.05, 0.1, 0.1);
      //GravityIndicator.OwnerID = "MasterAstronomer";
      //MScene.AstroRoot.Add(GravityIndicator);
      //GravityIndicator.SetMaterial((MMaterial)MScene.MaterialRoot.FindModuleByName(MMaterial.DEFAULT_MATERIAL));

      int ListIndex = 0;
      foreach (MAstroBody m in Bodies)
      {
        m.ListIndex = ListIndex++;
        MServerZone zone = new MServerZone("MASTER_ASTRONOMER", m.Name, "Astronomical", MassiveTools.ToVector3_Server(m.Position + m.Radius * 2));
        zone.Description = m.Description + " \nRadius:"+m.Radius;
        MMessageBus.AddZone(this, zone);
        //Extensions.LookAt(m.Position + m.Radius * 2, m.Position), m.Name));
        //MSphere mo = Helper.CreateSphere(MScene.AstroRoot, 4, m.Name, Vector3d.Zero);
        MModel mo = Helper.CreateModel(MScene.AstroRoot, m.Name, @"Models\earth.3ds", Vector3d.Zero);
        mo.transform.Position = m.Position;
        mo.transform.Scale = m.Radius * 2.001;
        mo.InstanceID = m.Name;
        mo.TemplateID = m.Name;
        mo.OwnerID = "MasterAstronomer";
        mo.Tag = m;
        m.Tag = mo;

        MMaterial mat = new MMaterial(m.Name + "_mat");
        mat.AddShader((MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER));
        MTexture tex = new MTexture(m.Name+"_tex");
        mat.SetDiffuseTexture(Globals.TexturePool.GetTexture(m.TextureName));
        mo.SetMaterial(mat);
        MScene.MaterialRoot.Add(mat);

        //


        if (m.HasAtmosphere)
        {
          MPhysicsObject po = new MPhysicsObject(mo, "Physics", 0, MPhysicsObject.EShape.Sphere, false, m.Radius * 2.00);
          //MPhysicsObject po = new MPhysicsObject(mo, "Physics", 0, MPhysicsObject.EShape.Sphere, false, m.Radius * 2.00);
          mo.Add(po);
          //MSphere moc = Helper.CreateSphere(MScene.AstroRoot, 3, m.Name+ "Clouds", Vector3d.Zero);
          MModel moc = Helper.CreateModel(MScene.AstroRoot, m.Name, @"Models\clouds.3ds", Vector3d.Zero);
          moc.CastsShadow = false;
          moc.transform.Position = m.Position;
          moc.transform.Scale = m.Radius * 1.94;
          //moc.transform.Scale = m.Radius*2.1;
          moc.InstanceID = m.Name;
          moc.TemplateID = m.Name;
          moc.OwnerID = "MasterAstronomer";
          moc.Tag = m;

          MObjectAnimation ani = new MObjectAnimation();
          //ani.Speed.Rotation = Quaterniond.FromEulerAngles(0.0000005, 0.0000001, 0);
          ani.Speed = 0.001;
          moc.Add(ani);

          MMaterial cmat = new MMaterial("CloudMat");
          cmat.AddShader((MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER));
          cmat.Opacity = 1.0;
          // = new MTexture("CloudTex");
          MTexture ctex = Globals.TexturePool.GetTexture(CloudTexURL);
          ctex.Additive = true;
          cmat.SetDiffuseTexture(ctex);
          moc.SetMaterial(cmat);
          MScene.MaterialRoot.Add(cmat);
        }
        else
        {
          MPhysicsObject po = new MPhysicsObject(mo, "Physics", 0, MPhysicsObject.EShape.Sphere, false, m.Radius * 2.00);
          mo.Add(po);
        }

        Console.WriteLine("Created:" + mo.Name + ":" + (mo.transform.Position) + " R:" + m.Radius);

      }

    }
  }
}
