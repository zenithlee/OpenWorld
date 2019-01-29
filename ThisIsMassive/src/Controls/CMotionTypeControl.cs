using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Massive;
using Massive.Events;
using OpenTK;

namespace ThisIsMassive.src.Controls
{
  public partial class CMotionTypeControl : UserControl
  {    

    public CMotionTypeControl()
    {
      InitializeComponent();

      MMessageBus.ChangeModeHandler += MMessageBus_ChangeModeHandler;
      MMessageBus.ChangeGravityHandler += MMessageBus_ChangeGravityHandler;
    }

    private void MMessageBus_ChangeGravityHandler(object sender, ChangeModeEvent e)
    {
      ToggleGravity();
    }

    private void MMessageBus_ChangeModeHandler(object sender, ChangeModeEvent e)
    {
      Globals.Avatar.SetMoveMode(e.NewMode);
      MScene.Camera.TargetOffset = Vector3d.Zero;
      if ( Globals.Avatar.GetMoveMode() == MAvatar.eMoveMode.Flying)
      {
        MotionTypeFlying.BackColor = Color.Teal;
        WalkButton.BackColor = Color.DarkGray;
      }
      if (Globals.Avatar.GetMoveMode() == MAvatar.eMoveMode.Walking)
      {
        MotionTypeFlying.BackColor = Color.DarkGray;
        WalkButton.BackColor = Color.Teal;
      }
    }

    private void WalkButton_Click(object sender, EventArgs e)
    {
      MMessageBus.ChangeModeRequest(this, MAvatar.eMoveMode.Walking);
    }

    private void FlyButton_Click(object sender, EventArgs e)
    {
      MMessageBus.ChangeModeRequest(this, MAvatar.eMoveMode.Flying);
    }

    void ToggleGravity()
    {
      if (MScene.Physics.UseGravity == false)
      {
        MScene.Physics.UseGravity = true;
        MScene.Physics.SetGravity(new Vector3d(0, -9.8, 0));
        GravityButton.BackColor = Color.FromArgb(118, 118, 175);
      }
      else
      {
        MScene.Physics.UseGravity = false;
        MScene.Physics.SetGravity(Vector3d.Zero);
        GravityButton.BackColor = Color.FromArgb(118, 118, 118);
      }
    }


    private void GravityButton_Click(object sender, EventArgs e)
    {
      ToggleGravity();
    }
  }
}
