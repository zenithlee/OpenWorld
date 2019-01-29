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
  public partial class CTableControl : UserControl
  {
    public string sTableName;

    public CTableControl()
    {
      InitializeComponent();
      MMessageBus.TableHandler += MMessageBus_TableHandler;
    }

    private void MMessageBus_TableHandler(object sender, TableEvent e)
    {
      //if ( e.Table.TableName == sTableName)
      {
        dataGridView1.DataSource = e.Table;
      }
    }

    public void GetTable(string sTable)
    {
      sTableName = sTable;
      Globals.Network.GetTableRequest(sTable);
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
      DataGridViewSelectedCellCollection col = dataGridView1.SelectedCells;      

      if (col.Count > 0)
      {
        DataRowView drv = (DataRowView)col[0].OwningRow.DataBoundItem;
        DataRow row = drv.Row;
        //DataRow mo = (DataRow);

        double x = Convert.ToDouble(row["x"]);
        double y = Convert.ToDouble(row["y"]);
        double z = Convert.ToDouble(row["z"]);
        MMessageBus.Navigate(this, new Vector3d(x, y, z));
      }
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewSelectedCellCollection col = dataGridView1.SelectedCells;

      if (col.Count > 0)
      {
        DataRowView drv = (DataRowView)col[0].OwningRow.DataBoundItem;
        DataRow row = drv.Row;
        //DataRow mo = (DataRow);

        double x = Convert.ToDouble(row["x"]);
        double y = Convert.ToDouble(row["y"]);
        double z = Convert.ToDouble(row["z"]);
        MMessageBus.Navigate(this, new Vector3d(x, y, z));
        MMessageBus.TeleportRequest(this, "", new Vector3d(x,y,z), Quaterniond.Identity);
      }
    }
  }
}
