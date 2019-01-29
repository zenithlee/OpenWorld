using Massive;
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
  public partial class AdminTools : Form
  {
    public AdminTools()
    {
      InitializeComponent();
    }

    private void GenAsteroids_Click(object sender, EventArgs e)
    {
      MAsteroidField maf = new MAsteroidField();
      maf.Generate();
    }

    private void GenAsteroids2_Click(object sender, EventArgs e)
    {
      MAsteroidField maf = new MAsteroidField();
      maf.Generate2();
    }

    private void Tweak1Num_ValueChanged(object sender, EventArgs e)
    {
      Settings.OffsetThirdPerson.X = Convert.ToDouble(OffsetX.Value);
    }

    private void OffsetY_ValueChanged(object sender, EventArgs e)
    {
      Settings.OffsetThirdPerson.Y = Convert.ToDouble(OffsetY.Value);
    }

    private void OffsetZ_ValueChanged(object sender, EventArgs e)
    {
      Settings.OffsetThirdPerson.Z = Convert.ToDouble(OffsetZ.Value);
    }
  }
}
