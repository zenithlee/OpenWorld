using Massive.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Events
{
  public class CreateObjectRequestEvent : EventArgs
  {    
    public MServerObject ServerObject;
    public CreateObjectRequestEvent(string sInTemplateID, string sTag = "", string sTextureID = "")
    {
      ServerObject = new MServerObject();
      ServerObject.TemplateID = sInTemplateID;
      ServerObject.Tag = sTag;
      ServerObject.TextureID = sTextureID;
    }
  }
}
