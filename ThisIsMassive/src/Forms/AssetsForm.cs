using Massive;
using Massive.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Forms
{
  public partial class AssetsForm : DToolForm
  {
    List<MSceneObject> AssetsList;

    public AssetsForm()
    {
      InitializeComponent();
      AssetsList = new List<MSceneObject>();
      Refresh();      
    }

    void Style()
    {
      foreach(DataGridViewColumn c in AssetsView.Columns)
      {
        c.HeaderCell.Style.BackColor = Color.Black;
        c.HeaderCell.Style.ForeColor = Color.LightGray;
        c.HeaderCell.Style.SelectionBackColor = Color.DarkGray;        
      }
      foreach (DataGridViewRow r in AssetsView.Rows)
      {
        r.HeaderCell.Style.BackColor = Color.Black;        
      }
    }

    private void AssetsView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
      AssetsView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
      AssetsView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
    }

    void Refresh()
    {
      //AssetsView.DataSource = AssetsList;

      foreach (MObject mo in MScene.Priority1.Modules.ToList())
      {
        if (mo.Renderable == false) continue;
        MSceneObject mso = (MSceneObject)mo;
        AssetsList.Add(mso);
      }

      AssetsView.DataSource = AssetsList;
      AssetsView.Columns["OwnerID"].ReadOnly = true;
      AssetsView.Columns["InstanceID"].ReadOnly = true;

      Style();
    }

    private void AssetsView_SelectionChanged(object sender, EventArgs e)
    {
      //DataGridViewSelectedRowCollection col = AssetsView.SelectedRows;

      DataGridViewSelectedCellCollection col = AssetsView.SelectedCells;

      if (col.Count > 0)
      {
        MSceneObject mo = (MSceneObject)col[0].OwningRow.DataBoundItem;
        MMessageBus.Navigate(this, mo.transform.Position);
      }

    }

    private void AssetsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewRow vrow = AssetsView.Rows[e.RowIndex];
      MSceneObject row = (MSceneObject)vrow.DataBoundItem;

      MMessageBus.TeleportRequest(this, "", row.transform.Position + row.BoundingBox.Size(), row.transform.Rotation);

    }
  }
}
