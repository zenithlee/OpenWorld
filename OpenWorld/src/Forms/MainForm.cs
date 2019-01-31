using Massive;
using OpenWorld.controllers;
using OpenWorld.src.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWorld
{
  public partial class MainForm : Form
  {
    COpenWorld ow = new COpenWorld();
   // View3D view3D1;
    LobbyForm LobbyForm;

    public MainForm()
    {
      InitializeComponent();
      Globals.GUIThreadOwner = this;
      timer1.Tick += Timer1_Tick;
     
    }

    void SetupGLControl()
    {
     // view3D1 = new View3D();
     // this.view3D1.Dock = System.Windows.Forms.DockStyle.Fill;
     // this.view3D1.Location = new System.Drawing.Point(195, 35);
     // this.view3D1.Name = "view3D1";
     // this.view3D1.Size = new System.Drawing.Size(751, 569);
     // this.view3D1.TabIndex = 0;
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      UpdateWorld();
    }

    public void UpdateWorld()
    {
      ow.Update();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      SetupGLControl();
      LobbyForm = new LobbyForm();
      ow.Setup();
      view3D1.Setup();
      timer1.Interval = 30;
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {

    }

    private void connectControl1_Load(object sender, EventArgs e)
    {

    }
  }
}
