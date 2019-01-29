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
using OpenTK;

namespace ThisIsMassive.src.Controls
{
  public partial class CacheControl : UserControl
  {
    public int UniqueObjectsTotal;
    public int TotalObjectsCounted;
    int Removes;
    int Disposes;

    public CacheControl()
    {
      InitializeComponent();
      Globals.GraphChangeHandler += Globals_GraphChangeHandler;
      if (!DesignMode)
      {
        timer1.Start();
      }
    }

    void UpdateUI()
    {
      Invoke((MethodInvoker)delegate
      {
        UniqueObjectsCount.Text = UniqueObjectsTotal.ToString();
        TotalObjectsCount.Text = TotalObjectsCounted.ToString();
      });
    }

    void Count(MObject mParent)
    {
      if (mParent == null) return;
      TotalObjectsCounted++;

      lock (MObject.ModuleLock)
      {
        foreach (MObject mo in mParent.Modules.ToArray())
        {
          Count(mo);
        }
      }
    }

    private void Globals_GraphChangeHandler(object sender, GraphChangedEvent e)
    {
      if (e.Reason == GraphChangedEvent.ChangeType.Created)
      {
        UniqueObjectsTotal++;
      }
      if (e.Reason == GraphChangedEvent.ChangeType.Disposed)
      {
        UniqueObjectsTotal--;
      }

      TotalObjectsCounted = 0;
      Count(MScene.Root);

      UpdateUI();
    }

    private void EmptyCacheButton_Click(object sender, EventArgs e)
    {
      if (Globals.Avatar.Target == null) return;
      Vector3d ap = Globals.Avatar.Target.transform.Position;

      foreach (MObject mo in MScene.ModelRoot.Modules.ToList())
      {
        if (mo.Type == MObject.EType.Null) continue;
        MSceneObject mso = (MSceneObject)mo;
        if (mso != null)
        {
          double dist = Vector3d.Distance(mso.transform.Position, ap);
          Console.WriteLine(mo.Name + ":" + dist);
          if (dist > 100)
          {
            MScene.ModelRoot.Remove(mo);
            Console.WriteLine("CULLED : " + mo.Name + ":" + dist);
            mo.SafeDispose();
          }
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Draws.Text = Globals.DrawCalls.ToString();
    }

    private void Draws_Click(object sender, EventArgs e)
    {

    }
  }
}
