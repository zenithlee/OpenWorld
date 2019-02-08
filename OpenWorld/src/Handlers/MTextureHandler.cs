using Massive;
using Massive.Events;
using Massive.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.Handlers
{
  public class MTextureHandler
  {
    public MTextureHandler()
    {
      Globals.Network.TextureHandler += Network_TextureHandler;
    }

    private void Network_TextureHandler(object sender, Massive.Events.TextureEvent e)
    {
      MSceneObject mo = (MSceneObject)MScene.ModelRoot.FindModuleByInstanceID(e.InstanceID);
      MMaterial mat = (MMaterial)MScene.MaterialRoot.FindModuleByName(e.TextureID);
      if (mat != null)
      {        
        mo.SetMaterial(mat);
      }
      else
      {
        if (MassiveTools.IsURL(e.TextureID))
        {
          mat = (MMaterial)new MMaterial("URLShader");
          MShader DefaultShader = (MShader)MScene.MaterialRoot.FindModuleByName(MShader.DEFAULT_SHADER);
          mat.AddShader(DefaultShader);
          mat.ReplaceTexture(Globals.TexturePool.GetTexture(e.TextureID));
          MScene.MaterialRoot.Add(mat);
          mo.SetMaterial(mat);
          mo.material.Setup();
        }
        else
        {
          Console.WriteLine("Object " + e.InstanceID + " was null");
          MMessageBus.Error(this, "Could not find Material:" + e.TextureID);
        }
      }
    }
  }
}
