using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MNPC : MObject
  {
    public enum State { Idle, Talking, Walking, Running };
    public State CurrentState = State.Idle;

    double accum = 0;
    double direction = -1;
    double speed = 0.5;
    Quaterniond OriginalRotation;

    public MNPC(MSceneObject parent, string inname = "") : base(EType.NPCPlayer, inname)
    {
      OriginalRotation = parent.transform.Rotation;
    }

    public void CopyTo(MNPC t)
    {
      t.Name = Name;
      t.CurrentState = CurrentState;
    }

    void DoIdle()
    {
      accum += Time.DeltaTime * direction * speed;
      if (accum > 1)
      {
        direction = -direction;
        accum = 1;
      }
      if (accum <= -1)
      {
        accum = -1;
        direction = -direction;
      }
      MSceneObject msoParent = (MSceneObject)Parent;
      msoParent.SetRotation(OriginalRotation * Quaterniond.FromEulerAngles(0, accum, 0));
    }

    public override void Update()
    {
      switch (CurrentState)
      {
        case State.Idle:
          DoIdle();
          break;
      }
    }
  }
}
