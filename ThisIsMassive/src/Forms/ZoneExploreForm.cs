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
  public partial class ZoneExploreForm : DToolForm
  {
    public ZoneExploreForm()
    {
      InitializeComponent();
      SetTitle("Zones");
    }

    private void ZoneExploreForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      cExploreControl1.Closing();
    }
  }
}
