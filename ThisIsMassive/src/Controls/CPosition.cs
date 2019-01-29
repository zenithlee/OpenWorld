using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using Massive;
using Massive.Events;

namespace ThisIsMassive.src.Controls
{
  public partial class CPosition : UserControl
  {
    public MSceneObject Selected;
    Vector3d Previous;
    double PreviousTotal = 0;
    public CPosition()
    {
      InitializeComponent();

      Console.WriteLine("DesignMode:" + DesignMode);

      if (DesignMode == false)
      {
        Setup();
      }
    }

    public void Setup()
    {
      MMessageBus.SelectEventHandler += MMessageBus_SelectEventHandler;
      MMessageBus.TeleportedEventHandler += MMessageBus_TeleportEventHandler;
      MMessageBus.ObjectMovedEvent += PositionChangeHandler;
      SpeedTimer.Start();
    }

    private void PositionChangeHandler(object sender, MoveEvent e)
    {
      if ((Selected != null) && (Selected.InstanceID.Equals(e.InstanceID)))
      {
        SelectedPositionText.Text = Format(Selected.transform.Position);
      }
    }

    void CalcSpeed()
    {
      if (PreviousTotal == 0) PreviousTotal = 0.01;
      if (Globals.Avatar == null) return;
      Vector3d AP = Globals.Avatar.GetPosition();
      double km = Vector3d.Distance(Globals.Avatar.GetPosition(), Previous) / (Time.TotalTime - PreviousTotal);
      //km *= 0.01;
      km *= 3.6;
      SpeedKMH.Text = km.ToString("#.0") + "km/h";
      Previous = Globals.Avatar.GetPosition();
      PreviousTotal = Time.TotalTime;

      WorldPositionText.Text = Format(AP);
      if (MPlanetHandler.CurrentNear != null)
      {
        Vector3d pos = MPlanetHandler.CurrentNear.GetLonLatOnShere(AP);
        WorldPositionText.Text += pos.ToString();
      }

      UpVector.Invoke((MethodInvoker)delegate
      {
        //UpVector.Text = Format(Globals.LocalGravity) + "O:" + Format(Globals.GlobalOffsetCalc);
        UpVector.Text = string.Format("{0:0.00}g", Globals.LocalGravity.Length);
      });
    }

    string Format(Vector3d d)
    {
      double dx = d.X;
      double dy = d.Y;
      double dz = d.Z;
      string sp = string.Format("{0:0.0}, {1:0.0}, {2:0.0}", dx, dy, dz);
      return sp;
    }

    private void MMessageBus_TeleportEventHandler(object sender, MoveEvent e)
    {
      WorldPositionText.Text = Format(MScene.Camera.transform.Position);
    }

    private void MMessageBus_SelectEventHandler(object sender, SelectEvent e)
    {
      if (e.Selected == null)
      {
        SelectedPositionText.Text = "-,-,-";
      }
      else
      {
        SelectedPositionText.Text = Format(e.Selected.transform.Position);
      }
      Selected = e.Selected;
    }

    private void PositionText_Click(object sender, EventArgs e)
    {

    }

    private void GravityCheck_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void SpeedTimer_Tick(object sender, EventArgs e)
    {
      CalcSpeed();
    }
  }
}
