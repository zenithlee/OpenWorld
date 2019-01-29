using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisIsMassive.src.Controls
{
  public partial class CCloseButton : UserControl
  {
    public CCloseButton()
    {
      InitializeComponent();
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      Form f = (Form)Parent;
      if (f != null)
      {
        f.Close();
      }
    }
  }
}
