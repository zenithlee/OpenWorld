using Massive.Network;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Massive
{
  public static class Globals
  {
    public static int VERSION = 1;
    public static int Index = 0;
    public static int Editor = 1;
    public static int DrawCalls = 0;    
    public static double Tweak1 = 8.5;
    public static double Tweak2 = 0;
    public static bool ApplicationExiting = false; //true when we're shutting down. Threads will monitor this 

    public static Control GUIThreadOwner;

    public static bool RenderSelectedOnly = false;
    //when set, all objects will render with this shader. Set to null to disable override
    public static Vector3d LocalUpVector = Vector3d.UnitY;
    public static Vector3d LocalGravity = new Vector3d(0, -9.8, 0);
    public static Quaterniond LocalUpRotation()
    {
      //if (Globals.Avatar.Target == null) return Quaterniond.Identity;
      Quaterniond rot = Extensions.LookAt(Globals.Avatar.GetPosition(), 
        Globals.Avatar.GetPosition()+ Globals.LocalUpVector, Vector3d.UnitY);
      
      if (double.IsNaN(rot.X))
      {
        rot = Quaterniond.Identity;
      }
      return rot;
    }

    public static Vector3d GlobalOffset = Vector3d.Zero;
    public static Vector3d GlobalOffsetCalc = Vector3d.Zero;

    public enum eRenderPass { Normal, ShadowDepth, Pick, Outline, FX, Reflection };
    public static eRenderPass RenderPass = eRenderPass.Normal;
    public static MShader ShaderOverride;
    public static event EventHandler<ErrorEvent> ShaderErrorEvent;
    public static event EventHandler<InfoEvent> InfoEventGlobal;
    public static event EventHandler<StatusEvent> ShaderCompilerEvent;
    public static event EventHandler<ErrorEvent> ErrorEventGlobal;
    public static event EventHandler<GraphChangedEvent> GraphChangeHandler;
    public static MScriptHost ScriptHost;
    public static MassiveNetwork Network = new MassiveNetwork();
    public static MMessageBus MessageBus = new MMessageBus();
    public static TexturePool TexturePool;
    public static MAvatar Avatar;
    public static MUserAccount UserAccount = new MUserAccount();

    public static string ProjectPath = @".\";
    public static string ResourcePath = @".\Assets\";
    public static string AppDataPath = @".\Assets\UserData";
    public static string CachePath = @".\Assets\UserData\Cache";
    
    public static void Log(object sender, string s)
    {
      InfoEventGlobal?.Invoke(sender, new InfoEvent(s));
    }

    public static void SetProjectPath(string path)
    {
      if (!path.EndsWith("\\")) path += "\\";
      ProjectPath = path;
      ResourcePath = Path.Combine(path, "Assets\\");
      AppDataPath = Path.Combine(path, @"UserData");
      CachePath = Path.Combine(path, @"UserData\Cache");
      if (!Directory.Exists(AppDataPath)) Directory.CreateDirectory(AppDataPath);
      if (!Directory.Exists(CachePath)) Directory.CreateDirectory(CachePath);
    }

    public static void NotifyChange(object sender, MObject mo, GraphChangedEvent.ChangeType Reason)
    {
      if (GraphChangeHandler != null)
      {
        GraphChangeHandler(sender, new GraphChangedEvent(mo, Reason));
      }
    }
  }
}
