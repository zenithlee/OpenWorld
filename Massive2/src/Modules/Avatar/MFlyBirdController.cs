using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MFlyBirdController : IControllerContext
  {
    public MFlyBirdController(MAvatar avatar)
      : base(avatar)
    {
    }

    public override void Brake(double b)
    {
      Vector3d vo = Vector3d.Zero;
      vo = _Avatar.GetRotation()
            * new Vector3d(0, 0, -b); //boost   
      _Avatar._physics._rigidBody.ApplyCentralImpulse(vo * 0.1);
    }

    public override void Jump(double b)
    {
      Vector3d vo = _Avatar.GetRotation()
         * new Vector3d(0, b, 0); //boost      
      _Avatar._physics._rigidBody.ApplyCentralForce(vo);
    }

    public override void MouseWheel(double b)
    {
      Settings.OffsetThirdPerson.Z += b;
    }
  }
}
