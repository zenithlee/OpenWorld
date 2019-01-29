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
using MassiveUniverse;
using Massive;
using Massive.Events;
using ThisIsMassive.src.Handlers;

namespace ThisIsMassive.src.Controls
{
  public partial class CObjectInspector : UserControl
  {
    MSceneObject Selected;
    string sCopiedTextureID;

    public CObjectInspector()
    {
      InitializeComponent();

      if (DesignMode == false)
      {
        MMessageBus.SelectEventHandler += MMessageBus_SelectedHandler;
        Globals.Network.DeletedHandler += Network_DeletedHandler;
        MMessageBus.ObjectCreatedHandler += MMessageBus_ObjectCreatedHandler;
      }
    }

    public void SetSelection(MSceneObject newSel)
    {
      SelecteObject(newSel);
    }

    double GetMultiplier()
    {
      double mult = 1;
      if ( Control.ModifierKeys == Keys.Shift)
      {
        mult = 0.1;
      }
      if ( Control.ModifierKeys == Keys.Control)
      {
        mult = 0.01;
      }

      if (Control.ModifierKeys == Keys.Alt)
      {
        mult = 0.001;
      }
      return mult;
    }

    public void Closing()
    {
      MMessageBus.SelectEventHandler -= MMessageBus_SelectedHandler;
      Globals.Network.DeletedHandler -= Network_DeletedHandler;
      MMessageBus.ObjectCreatedHandler -= MMessageBus_ObjectCreatedHandler;
    }

    private void MMessageBus_ObjectCreatedHandler(object sender, CreateEvent e)
    {
      if (e.CreatedObject.OwnerID == Globals.UserAccount.UserID)
      {
        MMessageBus.Select(this, e.CreatedObject);
      }
    }

    private void Network_DeletedHandler(object sender, DeleteEvent e)
    {
      if ((Selected != null) && (Selected.InstanceID == e.InstanceID))
      {
        Selected = null;
      }
    }

    Vector3d Relative(Vector3d rel)
    {
      double mult = GetMultiplier();

      /*
      Vector3d m = Selected.transform.Position
        //+ Globals.LocalUpRotation() 
        + Globals.LocalUpRotation()
        * Quaterniond.FromEulerAngles(0, 0, 90 * Math.PI / 180.0)
        * (rel * mult);
        * */

      Vector3d delta = Vector3d.Zero;      
      delta = mult* rel * (Selected.BoundingBox.Size());

      Vector3d m = Selected.transform.Position
        + Selected.transform.Rotation
        *delta;
      if (MZoneService.ZoneLocked(m))
      {
        MMessageBus.Status(this, "Zone is locked at that position");
      }
      else
      {
        return m;
      }
      return Selected.transform.Position;
    }

    bool IsOwner()
    {
      if (Selected == null) return false;
      if (Selected.OwnerID.Equals(Globals.UserAccount.UserID))
      {
        return true;
      }
      return false;
    }

    private void MMessageBus_SelectedHandler(object sender, SelectEvent e)
    {
      SelecteObject(e.Selected);
    }

    void SelecteObject(MSceneObject mo)
    {
      Selected = mo;
      if (Globals.Avatar.Owns(mo)) {
        ObjectName.BackColor = Color.FromArgb(255, 192, 128);
      }
      else
      {
        ObjectName.BackColor = Color.Red;
      }

      ObjectName.Invoke((MethodInvoker)delegate
      {
        if (mo == null)
        {
          ObjectName.Text = "-";
        }
        else
        {
          ObjectName.Text = mo.Name;
        }
      });
    }

    private void DeleteObjectButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.DeleteRequest(this, null);
    }

    private void NudgeXMButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(-1, 0, 0)));
    }

    private void NudeXPButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(1, 0, 0)));
    }

    private void NudgeYMButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(0, -1, 0)));
    }

    private void NudgeYPButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(0, 1, 0)));
    }

    private void NudgeZMButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(0, 0, 1)));
    }

    private void NudgeZPButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.MoveRequest(this, Selected.InstanceID, Relative(new Vector3d(0, 0, -1)));
    }

    private void NudgeRotMButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      double mult = GetMultiplier();
      MMessageBus.Rotate(this, new Quaterniond(0, (-45 * mult) * Math.PI / 180.0, 0));
    }

    private void NudgeRotPButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      double mult = GetMultiplier();
      MMessageBus.Rotate(this, new Quaterniond(0, (45 * mult) * Math.PI / 180.0, 0));
    }

    private void RXP_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      double mult = GetMultiplier();
      MMessageBus.Rotate(this, new Quaterniond((45 * mult) * Math.PI / 180.0, 0, 0));
    }

    private void RXM_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      double mult = GetMultiplier();
      MMessageBus.Rotate(this, new Quaterniond((-45 * mult) * Math.PI / 180.0, 0, 0));
    }

    private void Texture01Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "TEXTURE01T");
    }

    private void Texture02Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "TEXTURE02T");
    }

    private void Texture03Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "TEXTURE03T");
    }

    private void Texture04Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "FLOOR02T");
    }

    private void Texture05Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "FLOOR03T");
    }

    private void Texture06Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "FLOOR04T");
    }

    private void DOOR01Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "DOOR01T");
    }

    private void DOOR02Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "DOOR02T");
    }

    private void DOOR03Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "DOOR03T");
    }


    private void ROAD01Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "ROAD01M");
    }

    private void Road02Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "ROAD02M");
    }

    private void Road03Button_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;
      MMessageBus.ChangeTextureRequest(this, "ROAD03M");
    }

    private void NudgeXMButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (IsOwner() == false) return;
      MKeyboardHandler.ShiftDown = e.Shift;
    }

    private void NudgeXMButton_KeyUp(object sender, KeyEventArgs e)
    {
      if (IsOwner() == false) return;
      MKeyboardHandler.ShiftDown = e.Shift;
    }

    private void URLButton_Click(object sender, EventArgs e)
    {
      if (IsOwner() == false) return;

      ImageUploader iu = new ImageUploader();
      //iu.sLocus = Selected.transform.Position.ToString();
      iu.sTargetID = Selected.InstanceID;
      if (iu.ShowDialog() == DialogResult.OK)
      {
        //sLocus now contains the URL of the uploaded image
        MMessageBus.ChangeTextureRequest(this, iu.sLocus);
      }

    }

    private void CopyButton_Click(object sender, EventArgs e)
    {
      if (Selected != null)
      {
        sCopiedTextureID = Selected.material.Name;
      }
    }

    private void PasteButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(sCopiedTextureID)) return;
      if (IsOwner() == false) return;

      MMessageBus.ChangeTextureRequest(this, sCopiedTextureID);
    }

    private void NextObjectButton_Click(object sender, EventArgs e)
    {
      //if (Selected == null) return;

      MObject Current = null;
      if (Selected == null)
      {
        Current = MScene.ModelRoot.Modules[0];
      }
      else
      {
        Current = Selected;
      }

      int NextIndex = 0;
      for (int i = 0; i < MScene.ModelRoot.Modules.Count; i++)
      {
        MObject b = MScene.ModelRoot.Modules[i];
        if (b == Current)
        {
          NextIndex = i + 1;
          if (NextIndex >= MScene.ModelRoot.Modules.Count) NextIndex = 0;
          MObject test = MScene.ModelRoot.Modules[NextIndex];
          if (test.Renderable == false)
          {
            NextIndex++;
            continue;
          }
        }
      }

      MObject Candidate = MScene.ModelRoot.Modules[NextIndex];
      if (Candidate.Renderable == true)
      {
        MMessageBus.Select(this, (MSceneObject)Candidate);
      }
    }

    private void PeekButton_Click(object sender, EventArgs e)
    {
      if (Selected != null)
      {
        Vector3d Pos = Selected.transform.Position + Selected.transform.Rotation * Vector3d.UnitZ * 2;
        Quaterniond Look = Extensions.LookAt(Selected.transform.Position, 
          Selected.transform.Position + Selected.transform.Rotation * Vector3d.UnitZ, Vector3d.UnitY);
        Globals.Network.TeleportRequest(Globals.UserAccount.UserID, Pos, Look);
      }
    }

    private void ColorClick(object sender, EventArgs e)
    {
      Button b = (Button)sender;
      string sTex = (string)b.Tag;
      MMessageBus.ChangeTextureRequest(this, sTex);
    }

  }
}
