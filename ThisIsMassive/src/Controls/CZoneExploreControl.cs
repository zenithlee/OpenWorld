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
using Massive.Tools;
using System.IO;
using OpenTK;
using Massive.GIS;
using Massive.Network;
using System.Runtime.InteropServices;
using ThisIsMassive.src.Handlers;
using ThisIsMassive.src;

/// <summary>
/// The user can jump/teleport to zone 'bookmarks'
/// </summary>
namespace ThisIsMassive.src.Controls
{
  public partial class CZoneExploreControl : UserControl
  {
    //MBookmarks BookMarkManager = new MBookmarks();
    public string BookmarksFile = "Bookmarks.json";

    public CZoneExploreControl()
    {
      InitializeComponent();

      if (DesignMode == false)
      {
        //BookmarkListView.DataSource = BookMarkManager.Bookmarks;
        MMessageBus.ZoneAddHandler += MMessageBus_ZoneAddHandler;
        Globals.Network.ZoneCreateHandler += Network_ZoneCreateHandler;
        Globals.Network.ZoneDeletedHandler += Network_ZoneDeletedHandler;
        Globals.Network.ZoneUpdatedEventHandler += Network_ZoneUpdatedEventHandler;
      }
      // SetWindowTheme(BookmarkListView.Handle, "Explorer", null);
    }

    private void Network_ZoneUpdatedEventHandler(object sender, ZoneEvent e)
    {
      MMessageBus.Status(this, "Bookmark:" + e.Zone.Name + "," + e.Zone.Position + " R:" + e.Zone.Rotation);
    }

    public void Closing()
    {
      MMessageBus.ZoneAddHandler -= MMessageBus_ZoneAddHandler;
      Globals.Network.ZoneCreateHandler -= Network_ZoneCreateHandler;
      Globals.Network.ZoneDeletedHandler -= Network_ZoneDeletedHandler;
      Globals.Network.ZoneUpdatedEventHandler -= Network_ZoneUpdatedEventHandler;
    }

    private void Network_ZoneDeletedHandler(object sender, ZoneEvent e)
    {
      MServerZone zone = MZoneService.Zones.Find(x => x.Name.Equals(e.Zone.Name));
      if (zone != null)
      {
        lock (MZoneService.Zones)
        {
          MZoneService.Zones.Remove(zone);
          MMessageBus.SelectZone(this, null);
        }
        Populate();
      }
    }

    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

    private void Network_ZoneCreateHandler(object sender, ZoneEvent e)
    {
      if (MZoneService.Zones.Find(x => x.Name == e.Zone.Name) == null)
      {
        lock (MZoneService.ZoneLocker)
        {
          MZoneService.Zones.Add(e.Zone);
          Invoke((MethodInvoker)delegate
          {
            UpdateTimer.Start();
          });
        }
      }
    }

    private void MMessageBus_ZoneAddHandler(object sender, ZoneEvent e)
    {
      //lock (MZoneService.ZoneLocker)
      {
        MZoneService.Zones.Add(e.Zone);
      }
      UpdateTimer.Start();
    }

    public void Setup()
    {
      UpdateTimer.Start();
    }

    private void AddBookmarkButton_Click(object sender, EventArgs e)
    {
      /*
      MBookmark bm = new MBookmark(Globals.Avatar.Target.transform.Position,
        Globals.Avatar.Target.transform.Rotation,
        "Locus" + Globals.Bookmarks.Bookmarks.Count);
      Globals.Bookmarks.Add(bm);
      Globals.Bookmarks.Save(Path.Combine(Globals.AppDataPath, BookmarksFile));
      Populate();
      */
      ZoneForm zf = new ZoneForm();
      zf.SetPosition(Globals.Avatar.GetPosition() + Globals.LocalUpVector);
      zf.Show();
    }

    ListViewGroup GetGroup(string s)
    {
      if (string.IsNullOrEmpty(s)) return null;
      foreach (ListViewGroup g in BookmarkListView.Groups)
      {
        if (g.Name.Equals(s)) return g;
      }
      ListViewGroup result = new ListViewGroup(s, s);
      BookmarkListView.Groups.Add(result);
      return result;
    }

    void Populate()
    {
      if (BookmarkListView == null) return;
      BookmarkListView.Items.Clear();

      this.Invoke((MethodInvoker)delegate
      {
        //lock (MZoneService.ZoneLocker)
        {
          foreach (MServerZone zone in MZoneService.Zones.ToArray())
          {
            ListViewItem lvi = new ListViewItem(zone.Name);
            lvi.Group = GetGroup(zone.Group);
            lvi.Tag = zone;
            lvi.ToolTipText = zone.Description + " @" + zone.Position;
            BookmarkListView.Items.Add(lvi);
          }
        }
      });
    }

    private void BookmarkList_DoubleClick(object sender, EventArgs e)
    {
      if (BookmarkListView.SelectedIndices.Count == 0) return;
      ListViewItem lvi = BookmarkListView.Items[BookmarkListView.SelectedIndices[0]];
      MServerZone zone = (MServerZone)lvi.Tag;
      Vector3d v = new Vector3d(zone.Position.X, zone.Position.Y, zone.Position.Z);
      Quaterniond q = MassiveTools.QuaternionFromArray(zone.Rotation);
      MMessageBus.SelectZone(this, zone);
      MMessageBus.TeleportRequest(this, zone.Name, v, q);
      
    }

    private void BookmarkList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (BookmarkListView.SelectedIndices.Count == 0) return;
      ListViewItem lvi = BookmarkListView.Items[BookmarkListView.SelectedIndices[0]];
      MServerZone zone = (MServerZone)lvi.Tag;
      Console.WriteLine(zone.Name + ":" + zone.Position);
      MMessageBus.SelectZone(this, zone);
    }

    private void BookmarkListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
      ListViewItem lvi = BookmarkListView.Items[e.Item];
      MServerZone zone = (MServerZone)lvi.Tag;
      if (!string.IsNullOrEmpty(e.Label))
      {
        //e.Label = b.Name;
      }

      //Populate();
      UpdateTimer.Start();
    }

    private void BookmarkDelete_Click(object sender, EventArgs e)
    {

      if (BookmarkListView.SelectedIndices.Count == 0) return;
      int Selected = BookmarkListView.SelectedIndices[0];
      if (Selected > -1)
      {
        ListViewItem lvi = BookmarkListView.Items[Selected];
        MServerZone zone = (MServerZone)lvi.Tag;
        Globals.Network.DeleteZoneRequest(zone);
        //Globals.Bookmarks.Remove(b.Value);
      }
      //Populate();
    }

    private void replaceWithCurrentLocationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (BookmarkListView.SelectedIndices.Count == 0) return;
      int Selected = BookmarkListView.SelectedIndices[0];

      if (Selected > -1)
      {
        ListViewItem lvi = BookmarkListView.Items[Selected];
        MServerZone zone = (MServerZone)lvi.Tag;
        zone.Position = MassiveTools.ToVector3_Server(Globals.Avatar.GetPosition());
        zone.Rotation = MassiveTools.ArrayFromQuaterniond(Globals.Avatar.GetRotation());

        MMessageBus.Status(this, "Updating Bookmark" + zone.Name + "...");
        Globals.Network.UpdateZoneRequest(zone);
      }
    }

    private void GoToSurfaceButton_Click(object sender, EventArgs e)
    {
      bool Result = false;
      Vector3d v = Vector3d.Zero;
      MScene.Physics.RayCastRequest(Globals.Avatar.GetPosition(), Globals.Avatar.GetPosition()
        + -Globals.LocalUpVector * 100000000, this, (RayResult) =>
        {
          v = RayResult.Hitpoint;
          v = v + Globals.LocalUpVector * 2;
          if (Result == true)
          {
            MMessageBus.TeleportRequest(this, "There", v, Globals.Avatar.GetRotation());
          }
          else
          {
            MMessageBus.Status(this, "Explore:Can't find near surface");
          }
        });


    }



    private void setAsHomeLocationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Globals.UserAccount.HomePosition = MassiveTools.ArrayFromVector(Globals.Avatar.GetPosition());
      Globals.Network.ChangeDetailsRequest(Globals.UserAccount);
    }

    private void lookAtToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (BookmarkListView.SelectedIndices.Count == 0) return;
      int Selected = BookmarkListView.SelectedIndices[0];

      if (Selected > -1)
      {
        ListViewItem lvi = BookmarkListView.Items[Selected];
        MServerZone zone = (MServerZone)lvi.Tag;
        Vector3d zonepos = MassiveTools.Vector3dFromVector3_Server(zone.Position);
        Matrix4d mat = Matrix4d.LookAt(Globals.Avatar.GetPosition(), zonepos, Globals.LocalUpVector);
        Quaterniond rot = mat.ExtractRotation();
        Globals.Avatar.SetRotation(rot);
      }
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      UpdateTimer.Stop();
      Populate();
    }

    private void CExploreControl_Load(object sender, EventArgs e)
    {
      Globals.Network.GetZones();
      Populate();
    }
  }
}
