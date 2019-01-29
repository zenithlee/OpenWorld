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
  public partial class TermsOfService : Form
  {
    public TermsOfService()
    {
      InitializeComponent();
    }

    private void AcceptButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }
  }
}
