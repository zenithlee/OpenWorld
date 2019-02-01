using Massive;
using Massive.Network;
using Massive.Services;
using Massive.Tools;
using OpenTK;
using OpenTK.Graphics;
using OpenWorld.controllers;
using OpenWorld.Handlers;
using OpenWorld.src.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenWorld
{
  public partial class Form1 : Form
  {
    COpenWorld openWorld;
    private GLControl glControl1;
    public static Point ClientLocation;
    public static Size RenderClientSize;
    LobbyForm lobbyForm;
    MKeyboardHandler keyboardHandler;
    MMouseHandler mouseHandler;

    public Form1()
    {
      InitializeComponent();
      SetupGLControl();
      Globals.GUIThreadOwner = this;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      openWorld = new COpenWorld();
      keyboardHandler = new MKeyboardHandler(this, glControl1);      
      lobbyForm = new LobbyForm();
      openWorld.Setup();
      mouseHandler = new MMouseHandler(glControl1);
      timer1.Start();
      Application.Idle += Application_Idle; ;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      openWorld.Render();
      glControl1.SwapBuffers();
    }

    void SetupGLControl()
    {
      this.glControl1 = new OpenTK.GLControl(new GraphicsMode(new ColorFormat(32), 32, 8, 8), 4, 3, OpenTK.Graphics.GraphicsContextFlags.Default);
      this.glControl1.BackColor = System.Drawing.Color.Black;
      this.tableLayoutPanel1.SetColumnSpan(this.glControl1, 1);
      this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.glControl1.Location = new System.Drawing.Point(180, 64);
      this.glControl1.Margin = new System.Windows.Forms.Padding(0);
      this.glControl1.Name = "glControl1";
      this.glControl1.Size = new System.Drawing.Size(920, 542);
      this.glControl1.TabIndex = 0;
      this.glControl1.TabStop = false;
      this.glControl1.VSync = false;      
      //this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
      //this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
      this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
      this.tableLayoutPanel1.Controls.Add(this.glControl1, 0, 1);
    }

    private void glControl1_Resize(object sender, EventArgs e)
    {
      Point p = PointToScreen(glControl1.Location);
      ClientLocation = p;
      RenderClientSize = glControl1.Size;

      int w = 800;
      int h = 600;

      if (glControl1 != null)
      {
        w = glControl1.Width;
        h = glControl1.Height;
        glControl1.MakeCurrent();
      }
      //GL.Viewport(0, 32, w, h);
      if ((w > 16) && (h > 16))
      {
        MScreen.Resize(w, h);
      }
      //if (_infoForm != null)
      //{
        //_infoForm.UpdateData();
      //}
    }

  

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      MKeyboardHandler.KeyState[(int)e.KeyCode] = true;
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      /*if (_keyboardHandler == null)
      {
        Console.WriteLine("KeyboardHandler is null in  Main_KeyUp ");
        return;
      }
      _keyboardHandler.HandleKey(e);
      */
      MKeyboardHandler.KeyState[(int)e.KeyCode] = false;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      keyboardHandler.Update();      
      openWorld.Update();
    }

    private void HomeButton_Click(object sender, EventArgs e)
    {
      MServerZone zone = MZoneService.Find("Earth");
      Vector3d pos = MassiveTools.Vector3dFromVector3_Server(zone.Position);
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, pos, Quaterniond.Identity);
    }
  }
}
