using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public abstract class IControllerContext
  {
    protected MAvatar _Avatar;
    public IControllerContext(MAvatar avatar)
    {
      _Avatar = avatar;
    }
    public abstract void Jump(double b);
    public abstract void Brake(double b);
    public abstract void MouseWheel(double b);
  }
}
