using Massive;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MDistanceClipper : MObject
  {
    public Vector3d AvatarPos;

    int SkipCounter = 0;
    int SkipMax = 30;

    public MDistanceClipper() : base(EType.Other, "DistanceClipper")
    {

    }

    public override void Update()
    {
      base.Update();
      AvatarPos = Globals.Avatar.GetPosition();
      SkipCounter++;
      if (SkipCounter < SkipMax)
      {
        return;
      }
      SkipCounter = 0;

      CalcObject(MScene.ModelRoot);
    }

    //This is a potentially slow operation and can be called every nth frame.
    void CalcObject(MObject moParent)
    {
      Array ar = moParent.Modules.ToArray();
      for (int i = 0; i < ar.Length; i++)
      {
        MObject m = (MObject)ar.GetValue(i);
        if (m == null) continue;

        if (m.Renderable)
        {
          MSceneObject mo = (MSceneObject)m;
          if (mo.Type != EType.Mesh)
          {
            mo.DistanceFromAvatar = Vector3d.Distance(mo.transform.Position, AvatarPos);
          }
        }
        CalcObject(m);

      }
    }

  }
}
