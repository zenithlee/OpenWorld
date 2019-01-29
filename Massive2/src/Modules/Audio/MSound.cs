using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrrKlang;
using System.IO;
using OpenTK;

namespace Massive
{
  public class MSound : MObject
  {
    public string Filename;
    public bool Loop = false;
    public bool PlayOnAwake = false;
    public float Volume = 1;
    ISound _sound;

    public MSound() : base(EType.Sound, "Sound")
    {      
    }

    public override void CopyTo(MObject dobj)
    {
      MSound d = (MSound)dobj;
      d.Filename = Filename;
      d.Loop = Loop;
      d.Volume = Volume;
      d.PlayOnAwake = PlayOnAwake;
      base.CopyTo(d);
    }

    public void Load(string sFile)
    {
      //Filename = Path.Combine(Globals.ResourcePath, sFile);
      Filename = sFile;
      if (PlayOnAwake == true)
      {
        Play(MScene.audioListener);
      }
    }

    public void Play(MAudioListener listener)
    {
      if (listener == null) return;
      _sound = listener.engine.Play2D(Filename, Loop);
      
      /*
      _sound = listener.engine.Play3D(Filename,
        (float)this.transform.Position.X,
        (float)this.transform.Position.Y,
        (float)this.transform.Position.Z,
        Loop, false, StreamMode.AutoDetect);
        */
    }

    public override void Update()
    {
      base.Update();

      if (Parent.Renderable == false) return;      

      MSceneObject msp = (MSceneObject)Parent;
      Vector3d Delta = msp.transform.Position - Globals.Avatar.GetPosition();
      double d = Vector3d.Dot(Delta.Normalized(), Globals.Avatar.Right());

      if (_sound != null)
      {
        //_sound.Position = v3d;
        if ( msp.DistanceFromAvatar > 60 )
        {
          _sound.Volume = 0;
          if (_sound.Paused == false)
          {
            _sound.Paused = true;
          }
        }
        else
        {
          if ( _sound.Paused == true)
          {
            _sound.Paused = false;
          }
        }
        _sound.Pan = (float)d;
        _sound.Volume = 1.0f / (float)msp.DistanceFromAvatar;
      }
    }

    public override void Dispose()
    {
      base.Dispose();
    }
  }
}
