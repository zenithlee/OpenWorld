using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class HelpForm : Form
  {
    public HelpForm()
    {
      InitializeComponent();
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void AboutButton_Click(object sender, EventArgs e)
    {
      AboutForm af = new AboutForm();
      af.Show();
    }
  }
}
