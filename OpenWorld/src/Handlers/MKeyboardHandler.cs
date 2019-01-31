using Massive;
using Massive.Events;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassiveUniverse
{
  class MKeyboardHandler
  {
    Form Parent;
    MScene _Scene;
    public static bool ShiftDown = false;
    public static bool ControlDown = false;
    public static bool AltDown = false;
    public static bool[] KeyState = new bool[255];

    public MKeyboardHandler(Form f, Control c, MScene inScene)
    {
      Parent = f;
      _Scene = inScene;
      c.KeyDown += C_KeyDown;
      c.KeyUp += C_KeyUp;
      f.KeyDown += FormKey;
      //f.GetGraView().KeyDown += KeyboardHandler_KeyDown;
    }

    private void C_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          MMessageBus.ChangeModeRequest(this, MAvatar.eMoveMode.Walking);
          break;
        case Keys.F3:
          MMessageBus.ChangeModeRequest(this, MAvatar.eMoveMode.Flying);
          break;
        case Keys.F4:
          MMessageBus.ToggleGravity(this);
          break;
        case Keys.F:
          MMessageBus.Focus(this, null);
          break;
        case Keys.Y:
          CreateTest();
          break;
      }
    }

    void FormKey(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F1:
          //HelpForm hf = new HelpForm();
          //hf.Show();
          break;
      }
    }
    public void HandleKey(KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Add:
          MMessageBus.Rotate(this, new Quaterniond(0, 45 * Math.PI / 180.0, 0));
          break;
        case Keys.Subtract:
          MMessageBus.Rotate(this, new Quaterniond(0, -45 * Math.PI / 180.0, 0));
          break;
      }

    }

    void CreateTest()
    {
      for (int i = 0; i < 1000; i++)
      {
        Vector3d pos = Globals.Avatar.Target.transform.Position + Globals.LocalUpVector * i;

        MCube c = (MCube)Helper.CreateCube(MScene.ModelRoot, "Cube" + i, pos);
        MPhysicsObject po = new MPhysicsObject(c, "cube", 0.1, MPhysicsObject.EShape.Box, false, Vector3d.One);
      }
    }

    public static double GetMinifier()
    {
      double mult = 1;

      if (Control.ModifierKeys == Keys.Shift)
      {
        mult = 0.1;

      }

      if (Control.ModifierKeys == Keys.Control)
      {
        mult = 0.01;
      }

      if (Control.ModifierKeys == Keys.Alt)
      {
        mult = 10.0;
      }
      return mult;
    }

    public static double GetMultiplier()
    {
      double mult = 1;

      if (Control.ModifierKeys == Keys.Shift)
      {
        mult *= 10;
      }

      if (Control.ModifierKeys == Keys.Control)
      {
        mult *= 1000;
      }

      if (Control.ModifierKeys == (Keys.Control | Keys.Shift))
      {
        mult *= 10000;
      }

      if (Control.ModifierKeys == Keys.Alt)
      {
        mult *= 0.1;
      }
      return mult;
    }

    private void C_KeyDown(object sender, KeyEventArgs e)
    {
      HandleKey(e);
    }

    public void ClearState()
    {
      for (int i = 0; i < KeyState.Length; i++)
      {
        KeyState[i] = false;
      }
    }

    public void UpdateWalking()
    {
      //ShiftDown = KeyState[(int)Keys.ShiftKey];
      //ControlDown = KeyState[(int)Keys.ControlKey];
      //AltDown = KeyState[(int)Keys.CapsLock];
      double mult = GetMultiplier() * 25;

      if (KeyState[(int)Keys.Space])
      {
        Globals.Avatar.InputB1(Time.DeltaTime * mult * 140);
      }

      if (KeyState[(int)Keys.W])
      {
        Globals.Avatar.InputV(Time.DeltaTime * mult);
      }
      if (KeyState[(int)Keys.A])
      {
        Globals.Avatar.InputH(-Time.DeltaTime * mult);
      }
      if (KeyState[(int)Keys.S])
      {
        Globals.Avatar.InputV(Time.DeltaTime * -mult);
      }
      if (KeyState[(int)Keys.D])
      {
        Globals.Avatar.InputH(Time.DeltaTime * mult);
      }
    }

    void UpdateFlying()
    {
      double mult = GetMultiplier();

      double BaseEnergy = 10;

      if (KeyState[(int)Keys.Escape])
      {
        //Globals.Avatar.InputB1(Time.DeltaTime * mult * 40);
        Globals.Avatar.Reset();
      }

      if (KeyState[(int)Keys.Space])
      {
        Globals.Avatar.Jump(Time.DeltaTime * mult * 40);
      }

      if (KeyState[(int)Keys.W])
      {
        //Globals.Avatar.InputPitchV(Time.DeltaTime * 50);
        Globals.Avatar.InputB1(Time.DeltaTime * mult * 26);
        Globals.Avatar.Throttle = 1;
      }
      else
      {
        Globals.Avatar.Throttle = 0;
      }
      if (KeyState[(int)Keys.S])
      {
        //Globals.Avatar.InputB1();
        Globals.Avatar.Brake(Time.DeltaTime * mult * BaseEnergy/10.0);
      }

      if (KeyState[(int)Keys.Up])
      {
        Globals.Avatar.InputPitchV(-Time.DeltaTime * -BaseEnergy);

      }

      if (KeyState[(int)Keys.Down])
      {
        Globals.Avatar.InputPitchV(Time.DeltaTime * -BaseEnergy);
      }

      if (KeyState[(int)Keys.Q])
      {
        Globals.Avatar.InputRollH(-Time.DeltaTime * BaseEnergy);
      }
      if (KeyState[(int)Keys.E])
      {
        Globals.Avatar.InputRollH(Time.DeltaTime * BaseEnergy);
      }

      if (KeyState[(int)Keys.Left])
      {
        Globals.Avatar.InputRollH(-Time.DeltaTime * BaseEnergy);
      }
      if (KeyState[(int)Keys.Right])
      {
        Globals.Avatar.InputRollH(Time.DeltaTime * BaseEnergy);
      }

      if (KeyState[(int)Keys.A])
      {
        Globals.Avatar.InputYawH(Time.DeltaTime * BaseEnergy);
      }
      if (KeyState[(int)Keys.D])
      {
        Globals.Avatar.InputYawH(-Time.DeltaTime * BaseEnergy);
      }
    }

    public void Update()
    {
      if (Globals.Avatar.GetMoveMode() == MAvatar.eMoveMode.Walking)
      {
        UpdateWalking();
      }
      else
      {
        UpdateFlying();
      }


    }

  }
}
