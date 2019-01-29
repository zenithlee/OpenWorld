using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassiveServer.src.forms
{
  public partial class SQLForm : Form
  {
    MDatabase db = new MDatabase();

    public SQLForm()
    {
      InitializeComponent();

      HostnameBox.Text = db.Hostname;
      UsernameBox.Text = db.UserName;
      PasswordBox.Text = db.Password;
      PortBox.Text = db.Port;
    }

    private void Execute_Click(object sender, EventArgs e)
    {
      ExecuteQuery();
    }

    void ExecuteQuery()
    {
      dataGridView1.DataSource = db.QueryReader(QueryBox.Text);
      ResultBox.Text = db.ResultText;
    }

    private void SQLForm_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F5)
      {
        ExecuteQuery();
      }
    }
  }
}
