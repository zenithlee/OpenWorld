using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MWalkController : IControllerContext
  {
    public MWalkController(MAvatar avatar)
      :base (avatar)
    {
    }

    public override void Brake(double b)
    {
      throw new NotImplementedException();
    }

    public override void Jump(double b)
    {      
      Vector3d vo = Vector3d.Zero;
     
        vo = _Avatar.GetRotation()
         * new Vector3d(0, b, 0); //jetpack
      
      _Avatar._physics._rigidBody.ApplyCentralForce(vo);
    }

    public override void MouseWheel(double b)
    {
      Settings.OffsetThirdPerson.Z += b;
    }
  }
}
