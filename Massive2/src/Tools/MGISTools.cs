using Massive.GIS;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Tools
{
  public static class MGISTools
  {

    public static Vector3d PositionFromMap(MAstroBody b, Vector2d p, Vector2d MapSize)
    {
      Vector3d r = Vector3d.Zero;

      //get percentage
      Vector2d per = new Vector2d(p.X / MapSize.X, p.Y / MapSize.Y);
      r.X = per.X;
      r.Y = per.Y;

      return r;
    }

    public static double Tile2long(int x, int zoom)
    {
      return (x / Math.Pow(2, zoom) * 360 - 180);
    }

    public static double Tile2lat(int y, int zoom)
    {
      var n = Math.PI - 2 * Math.PI * y / Math.Pow(2, zoom);
      return (180 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n))));
    }
    
    //X,Y Map point 0 - 1
    public static Vector3d PositionOnBodyFromMapPoint(double X, double Y, double Radius, double distanceOffset = 1)
    {
      Vector3d P = new Vector3d();

      double theta = 2 * Math.PI * (1 - X);
      double phi = Math.PI * (1 - Y);

      double RadPDO = Radius + distanceOffset;

      P.X = Math.Cos(theta) * Math.Sin(phi) * RadPDO;
      P.Y = Math.Cos(phi) * RadPDO;
      P.Z = Math.Sin(theta) * Math.Sin(phi) * RadPDO;      

      return P;
    }

    public static Vector3d LonLatMercatorToPosition(double lon, double lat, double radius)
    {
      Vector3d v = Vector3d.Zero;      
      v.X = 0.5 + lon / 360.0;
      v.Y = 0.5 + lat / 180.0;
      return PositionOnBodyFromMapPoint(v.X, v.Y, radius, 1);
    }
  }
}
