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
using ThisIsMassive.src;

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using MassiveUniverse;
using ThisIsMassive.src.Handlers;
using ThisIsMassive.src.Controls;
using Massive.Events;
using Massive.Network;
using Massive.Tools;
using System.Runtime.InteropServices;
using ThisIsMassive.src.Forms;
using System.Threading;
using OpenTK.Graphics;

namespace ThisIsMassive
{
  public partial class Main : Form
  {
    MWorld MyWorld;
    //Time time;
    MScene _Scene;
    MMouseHandler _mouseHandler;
    MKeyboardHandler _keyboardHandler;
    MCameraHandler _cameraHandler;
    MTeleportHandler _locusHandler;
    MSpawnHandler _spawnHandler;
    MZoneService _zoneService;
    UserMessage _userMessage;
    MUpdateApplicationHandler _updateAppHandler;
    bool Paused = true;
    SplashScreen splash;
    MStateMachine _stateMachine;
    DebugWindow _debugWindow;
    BackgroundWorker UpdateThread;
    InfoOverlayForm _infoForm;

    bool RenderingEnabled = true;
    bool CanExit = false;

    //string SERVERIP = "197.93.157.217";
    string SERVERIP = "10.0.0.3";
    public static Point ClientLocation;
    public static Size RenderClientSize;
    static Main _Instance;
    Color InfoColor = Color.Gray;
    Color ErrorColor = Color.DarkRed;

    private GLControl glControl1;

    public Main()
    {
      //this.glControl1 = new OpenTK.GLControl(new GraphicsMode(new ColorFormat(32), 32, 8, 4),4,3, OpenTK.Graphics.GraphicsContextFlags.Default);
      InitializeComponent();

      SetupGLControl();
      _Instance = this;

#if DEBUG
      SERVERIP = "10.0.0.3";
#endif
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
      this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
      this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
      this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
      this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
      this.tableLayoutPanel1.Controls.Add(this.glControl1, 1, 1);
    }

    public static Main GetInstance()
    {
      return _Instance;
    }

    private void Main_Shown(object sender, EventArgs e)
    {
      Application.DoEvents();
      Globals.Network.ServerIP = SERVERIP;
      SetupForm();
    }

    void SetupForm()
    {
      Globals.SetProjectPath(@".\");

#if DEBUG
      Console.WriteLine("DEBUG Mode");

#else
      //Globals.SetProjectPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Massive"));
      Console.WriteLine("Release Mode");
#endif
      Globals.VERSION = MVersion.VERSION;

      Text = "_MASSIVE v" + Globals.VERSION + " Alpha";

      Console.WriteLine("Current:" + Directory.GetCurrentDirectory());
      Console.WriteLine("AppData:" + Globals.AppDataPath);
      CheckFolders();

      _stateMachine = new MStateMachine(this);

      MyWorld = new MWorld();
      Globals.GUIThreadOwner = this;

      Globals.ErrorEventGlobal += Globals_ErrorEventGlobal;
      Globals.InfoEventGlobal += Globals_InfoEventGlobal;

      //Globals.SetProjectPath(Directory.GetCurrentDirectory());
      MMessageBus.LoggedIn += Network_LoggedInHandler;
      MMessageBus.NetworkError += MMessageBus_NetworkError;
      MMessageBus.ChangeUserIDHandler += MMessageBus_ChangeUserIDHandler;
      MMessageBus.ChangedUserInfoHandler += MMessageBus_ChangedUserInfoHandler;
      MMessageBus.InfoEventHandler += MMessageBus_GlobalInfoEvent;
      MMessageBus.UpdateRequiredHandler += MMessageBus_UpdateRequiredHandler;
      MMessageBus.ChangeModeHandler += MMessageBus_ChangeModeHandler;
      MMessageBus.DisableRender += MMessageBus_DisableRender;

      LocusBox.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
      glControl1.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);

      Globals.Network.StatusEventHandler += Network_StatusEventHandler; ;
      Globals.Network.ConnectedToLobbyHandler += Network_ConnectedToLobbyHandler;
      Globals.Network.ConnectedToMASSIVEHandler += Network_ConnectedToMASSIVEHandler;

      Globals.Network.ChatEventHandler += Network_ChatEventHandler;
      //Globals.Network.LoggedInHandler += Network_LoggedInHandler;
      //Globals.Network.USerDetailsChanged += Network_USerDetailsChanged;
      //Globals.Network.ZoneCreateHandler += Network_ZoneCreateHandler;
      //Globals.Network.ZoneCompleteEventHandler += Network_ZoneCompleteEventHandler;
      //SetWindowTheme(ModeControl.Handle, "Explorer", null);


      MStateMachine.StateChanged += MStateMachine_StateChanged;

      _zoneService = new MZoneService();
      // Setup();
      LoadUserDetails();
      MStateMachine.ChangeState(MStateMachine.eStates.CheckTerms);

      //UpdateThread = new BackgroundWorker();
      //UpdateThread.WorkerSupportsCancellation = true;
      //UpdateThread.DoWork += Bw_DoWork;

      Application.Idle += Application_Idle;

    }

    private void Application_Idle(object sender, EventArgs e)
    {
      //throw new NotImplementedException();
//      UpdateEngine();
      //Render();
    }

    private void MMessageBus_NetworkError(object sender, ErrorEvent e)
    {
      Status("NETWORK ERROR:" + e.ErrorMessage, InfoColor);
    }

    private void Bw_DoWork(object sender, DoWorkEventArgs e)
    {
      while (CanExit == false)
      {
        UpdateEngine();
        Thread.Sleep(25);
      }
    }

    private void MMessageBus_DisableRender(object sender, InfoEvent e)
    {
      RenderingEnabled = !RenderingEnabled;
    }

    private void MMessageBus_ChangeModeHandler(object sender, ChangeModeEvent e)
    {
      glControl1.Focus();
    }

    void Invoker(Control c, Delegate d)
    {
      if (c.InvokeRequired == true)
      {
        c.Invoke(d);
      }
    }

    private void MMessageBus_UpdateRequiredHandler(object sender, InfoEvent e)
    {
      Invoke((MethodInvoker)delegate
      {
        _userMessage.Visible = true;
        _userMessage.Location = PointToScreen(glControl1.Location);
        _userMessage.SetText(e.Message);
      });
    }

    private void Network_StatusEventHandler(object sender, NetworkStatusEvent e)
    {
      Invoke((MethodInvoker)delegate
      {
        if (e.Connected == true)
        {
          ConnectionButton.BackColor = Color.DarkGreen;
          ConnectionButton.ImageIndex = 1;
        }
        else
        {
          ConnectionButton.BackColor = Color.DarkRed;
          ConnectionButton.ImageIndex = 0;
          toolTip1.SetToolTip(ConnectionButton, e.Message);
        }

        if (e.Failure == true)
        {
          Status("FAILED TO CONNECT. PLEASE TRY AGAIN LATER", Color.Red);
        }

      });
    }

    //private void Network_ZoneCompleteEventHandler(object sender, EventArgs e)
    //{
//      MStateMachine.ChangeState(MStateMachine.eStates.DownloadingWorld);
  //  }

    /// <summary>
    /// ////////////////////// STATE //////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MStateMachine_StateChanged(object sender, EventArgs e)
    {
      switch (MStateMachine.CurrentState)
      {
        case MStateMachine.eStates.CheckTerms:
          CheckTermsOfService();
          break;
        case MStateMachine.eStates.ConnectToLobby:
          ConnectToLobby();
          break;
        case MStateMachine.eStates.ConnectToMASSIVE:
          ConnectToMASSIVE();
          break;
        case MStateMachine.eStates.CheckLoginDetails:
          CheckLoginDetails();
          break;
        case MStateMachine.eStates.Login:
          Login();
          break;
        case MStateMachine.eStates.Setup:
          Setup();
          break;
        //case MStateMachine.eStates.DownloadingZones:
          //Globals.Network.GetZones();
          //MStateMachine.ChangeState(MStateMachine.eStates.DownloadingWorld);
          //break;
        case MStateMachine.eStates.DownloadingWorld:
          Globals.Network.GetWorld();
          MStateMachine.ChangeState(MStateMachine.eStates.Viewing);
          break;
        case MStateMachine.eStates.Viewing:
          Viewing();
          break;
      }
    }
    void Viewing()
    {
      _infoForm = new InfoOverlayForm();
      _infoForm.Show(this);
      _infoForm.UpdateData();
    }

    void ConnectToLobby()
    {
#if DEBUG
      Status("Logging in:" + Globals.UserAccount.UserID + " on " + Globals.Network.ServerIP, InfoColor);
#endif
      Status("Logging in:" + Globals.UserAccount.UserID, InfoColor);
      Globals.Network.ConnectToLobby();
    }

    private void Network_ConnectedToLobbyHandler(object sender, StatusEvent e)
    {
      if (e.Succeded == true)
      {
        MStateMachine.ChangeState(MStateMachine.eStates.ConnectToMASSIVE);
      }
    }

    void ConnectToMASSIVE()
    {
      Globals.Network.SendConnectToMASSIVERequest();
    }

    private void Network_ConnectedToMASSIVEHandler(object sender, StatusEvent e)
    {
      if (e.Succeded == true)
      {
        MStateMachine.ChangeState(MStateMachine.eStates.CheckLoginDetails);
      }

      Status(e.Message, InfoColor);
    }

    private void Network_LoggedInHandler(object sender, ChangeDetailsEvent e)
    {
      MStateMachine.ChangeState(MStateMachine.eStates.Setup);
    }

    void Login()
    {
#if DEBUG
#else
      Invoke((MethodInvoker)delegate
      {
        splash = new SplashScreen();
        splash.Show();
      });
#endif
      Globals.Network.SendLoginRequest();
    }

    void Setup()
    {
      //time = new Time();
      _userMessage = new UserMessage();
      //cExploreControl1.Setup();
      _Scene = new MScene(true, true);
      _Scene.Clear();
      _Scene.SetupInitialObjects();
      //MPanel panel = MGUI.AddPanel(null, 0, 0, 20, 10, "MyPanel");
      //MButton but = MGUI.AddButton(panel, 0, 20, 20, 7, "Clicky", "Button Label");
      MScene.UtilityRoot.Add(_zoneService);

      _locusHandler = new MTeleportHandler();


      MyWorld.Setup();
      _Scene.Setup();

      _keyboardHandler = new MKeyboardHandler(this, glControl1, _Scene);
      _mouseHandler = new MMouseHandler(this, glControl1, _Scene);
      _cameraHandler = new MCameraHandler();

      _spawnHandler = new MSpawnHandler();
      _updateAppHandler = new MUpdateApplicationHandler();
      
      RenderTimer.Start();      
      _Scene.Play();
#if DEBUG
#else
      Invoke((MethodInvoker)delegate
      {
        splash.DoClose();
      });
#endif
      MStateMachine.ChangeState(MStateMachine.eStates.DownloadingWorld);
      Paused = false;      
      _updateAppHandler.CheckForUpdates();
      MyWorld.AddAvatar();
      //UpdateThread.RunWorkerAsync();
      //UpdateThread = new BackgroundWorker();
      //UpdateThread.DoWork += UpdateThread_DoWork;
      //UpdateThread.RunWorkerAsync();
    }

    private void UpdateThread_DoWork(object sender, DoWorkEventArgs e)
    {
      while (CanExit== false)
      {
        UpdateEngine();
        Thread.Sleep(1);
      }
    }

    private void Globals_ErrorEventGlobal(object sender, ErrorEvent e)
    {
      Status("ERROR:" + e.ErrorMessage, ErrorColor);
    }

    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

    void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
      {
        e.IsInputKey = true;
      }
    }

    void CheckFolders()
    {
      if (!Directory.Exists(Globals.AppDataPath))
      {
        Directory.CreateDirectory(Globals.AppDataPath);
      }
      //Status("App path is :" + Globals.AppDataPath);
    }

    private void MMessageBus_ChangedUserInfoHandler(object sender, InfoEvent e)
    {
      SaveUserDetails();
    }

    private void MMessageBus_ChangeUserIDHandler(object sender, InfoEvent e)
    {
      Globals.UserAccount.UserID = e.Message;
      SaveUserDetails();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // bool isDesignMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName.IndexOf("devenv") != -1);
      //if (isDesignMode)
      //        return;
    }

    private void glControl1_Load(object sender, EventArgs e)
    {

    }

    void CheckLoginDetails()
    {
      if (string.IsNullOrEmpty(Globals.UserAccount.Email))
      {
        UserInfoForm ui = new UserInfoForm();
        ui.ShowDialog();
      }
      MStateMachine.ChangeState(MStateMachine.eStates.Login);
    }

    void Clear()
    {
      //MMessageBus.InfoEventHandler -= MMessageBus_GlobalInfoEvent;
      //Globals.Network.StatusEventHandler -= Network_StatusHandler;
      //Globals.Network.ChatEventHandler -= Network_ChatEventHandler;
      _Scene.Clear();
      _Scene.SetupInitialObjects();
    }

    void LoadUserDetails()
    {
      string userfile = Path.Combine(Globals.AppDataPath, "Settings.txt");
      if (File.Exists(userfile))
      {
        string sData = File.ReadAllText(userfile);
        try
        {
          Globals.UserAccount = MUserAccount.Deserialize<MUserAccount>(sData);
        }
        catch (Exception e)
        {
          Console.WriteLine("Problem with Useraccount file");
          Globals.UserAccount = new MUserAccount();
        }
      }
      else
      {
        Globals.UserAccount.Email = "";
        Globals.UserAccount.Password = Helper.HashString(Helper.GUID());
        Globals.UserAccount.ServerIP = SERVERIP;
      }


#if DEBUG
      if (Globals.UserAccount == null)
      {
        Console.WriteLine("UserAccount is null");
      }
      else
      {
        Globals.Network.ServerIP = Globals.UserAccount.ServerIP;
        string[] args = Environment.GetCommandLineArgs();
        if ((args.Length > 1) && (args[1] == "-ua"))
        {
          Globals.UserAccount.UserID = args[2];
        }
        Status("Command:" + Environment.CommandLine, InfoColor);
      }
#else
      Globals.Network.ServerIP = SERVERIP;
#endif

    }

    void CheckTermsOfService()
    {
      if (Globals.UserAccount.TermsAccepted == false)
      {
        TermsOfService tos = new TermsOfService();
        if (tos.ShowDialog() == DialogResult.OK)
        {
          Globals.UserAccount.TermsAccepted = true;
          SaveUserDetails();
        }
        else
        {
          Close();
        }
      }
      else
      {
        Status("Terms of service accepted", InfoColor);
      }
      MStateMachine.ChangeState(MStateMachine.eStates.ConnectToLobby);
    }

    void SaveUserDetails()
    {
      Globals.UserAccount.ServerIP = Globals.Network.ServerIP;
      string sData = Globals.UserAccount.Serialize();
      string userfile = Path.Combine(Globals.AppDataPath, "Settings.txt");
      File.WriteAllText(userfile, sData);
    }

    /**
     * show a messagebox from the server
     * */
    private void Network_ChatEventHandler(object sender, ChatEvent e)
    {
      Status(e.message.OwnerID + ":" + e.message.Message, InfoColor);
      if (!e.message.OwnerID.Equals(ChatEvent.TYPESERVER)) return;
      Invoke((MethodInvoker)delegate
      {
        _userMessage.Visible = true;
        _userMessage.Location = PointToScreen(glControl1.Location);
        _userMessage.SetText(e.message.Message);
      });

    }

    private void MMessageBus_GlobalInfoEvent(object sender, InfoEvent e)
    {
      if (e.Message == MKey.Keys.P.ToString())
      {
        Paused = false;
      }
      Status(e.Message, InfoColor);
    }



    void Logout()
    {
      Globals.Network.Enabled = false;
    }

    private void Globals_InfoEventGlobal(object sender, InfoEvent e)
    {
      Status(e.Message, InfoColor);
    }

    void Status(string s, Color c)
    {

      StatusBox.Invoke((MethodInvoker)delegate
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(s);
        StatusBox.BackColor = c;
        StatusBox.AppendText(s + "\r\n");
        StatusBox.ScrollToCaret();
        //ResetGUI();       
      });
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
      if (_infoForm != null)
      {
        _infoForm.UpdateData();
      }
    }

    private void Main_Move(object sender, EventArgs e)
    {
      Point p = PointToScreen(glControl1.Location);
      ClientLocation = p;
      RenderClientSize = glControl1.Size;
      if (_infoForm != null)
      {
        _infoForm.UpdateData();
      }
    }

    private void Main_LocationChanged(object sender, EventArgs e)
    {
      Point p = PointToScreen(glControl1.Location);
      ClientLocation = p;
      RenderClientSize = glControl1.Size;
      if (_infoForm != null)
      {
        _infoForm.UpdateData();
      }
    }

    void CheckMouseLost()
    {
      Point pos = Control.MousePosition;
      bool inForm = pos.X >= Left && pos.Y >= Top && pos.X < Right && pos.Y < Bottom;
      //this.Opacity = inForm ? 0.99 : 0.10;
      if (Control.MouseButtons == MouseButtons.Left && (inForm == false) && (_keyboardHandler != null))
      {
        //  _keyboardHandler.ClearState();
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      UpdateEngine();
      Render();      
    }

    void UpdateEngine()
    {
      // if (time == null) return;
      Globals.Network.Update();
      if ( _keyboardHandler != null)
      {
        _keyboardHandler.Update();
      }
      
      if ( _Scene != null)
      {
        _Scene.Update();
      }
      
    }

    void Render()
    {
      if (Paused == true) return;
      if (_Scene == null) return;
      
      if (RenderingEnabled)
      {
        _Scene.Render();
      }
      glControl1.SwapBuffers();
    }

    private void ViewModeButton_Click(object sender, EventArgs e)
    {
      MStateMachine.CurrentState = MStateMachine.eStates.Viewing;
    }

    private void DecorateModeButton_Click(object sender, EventArgs e)
    {
      MStateMachine.CurrentState = MStateMachine.eStates.Decorating;
    }

    private void HomeButton_Click(object sender, EventArgs e)
    {

    }

    private void ConnectionButton_Click(object sender, EventArgs e)
    {
      Globals.Network.Enabled = !Globals.Network.Enabled;
      if (Globals.Network.Enabled == false)
      {
        Clear();
      }
      else
      {
        Setup();
      }
    }

    private void userNameControl1_MouseClick(object sender, MouseEventArgs e)
    {
      UserInfoForm ui = new UserInfoForm();
      ui.Show();
    }


    private void userNameControl1_Click(object sender, EventArgs e)
    {
      UserInfoForm ui = new UserInfoForm();
      ui.Show();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      Globals.ApplicationExiting = true;
      CanExit = true;
      Paused = true;      
      RenderTimer.Stop();

      if (_Scene != null)
      {
        _Scene.Stop();
      }
      
      SaveUserDetails();

      if (_Scene != null)
      {
        _Scene.Dispose();
      }
    }



    private void ModeControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      /*if (ModeControl.SelectedIndex == 0)
      {
        MStateMachine.CurrentState = MStateMachine.eStates.Viewing;
      }
      if (ModeControl.SelectedIndex == 1)
      {
        MStateMachine.CurrentState = MStateMachine.eStates.Building;
      }
      */
    }

    private void GoButton_Click(object sender, EventArgs e)
    {
      Go();
    }

    private void Main_KeyDown(object sender, KeyEventArgs e)
    {
      MKeyboardHandler.KeyState[(int)e.KeyCode] = true;
    }

    private void Main_KeyUp(object sender, KeyEventArgs e)
    {
      if (_keyboardHandler == null)
      {
        Console.WriteLine("KeyboardHandler is null in  Main_KeyUp ");
        return;
      }
      _keyboardHandler.HandleKey(e);
      MKeyboardHandler.KeyState[(int)e.KeyCode] = false;
    }

    private void ShadowBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void glControl1_MouseDown(object sender, MouseEventArgs e)
    {
      glControl1.Focus();
    }

    private void glControl1_KeyDown(object sender, KeyEventArgs e)
    {
      e.Handled = true;
    }

    private void FogEnabled_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void HomeButton_Click_1(object sender, EventArgs e)
    {
      //Globals.Avatar.SetPosition(new Vector3d(1, 2, 0));
      Vector3d hp = MassiveTools.VectorFromArray(Globals.UserAccount.HomePosition);
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, hp, Quaterniond.Identity);
      //MScene.Camera.transform.Position = new Vector3d(1, 2, 0);
      //MScene.Camera.Target.transform.Position = new Vector3d(2, 2, 0);
    }

    private void MapButton_Click(object sender, EventArgs e)
    {
      MapForm mf = new MapForm();
      mf.Setup();
      mf.Show();
    }

    private void LocusBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        Go();
      }
    }
    void Go()
    {
      string sText = LocusBox.Text;
      Vector3d pos = Vector3d.Zero;
      if (sText.Contains(','))
      {
        pos = MassiveTools.VectorFromString(sText);
      }
      else
      {
        //look in bookmarks
        pos = MZoneService.Find(sText);
      }

      MMessageBus.TeleportRequest(this, LocusBox.Text, pos, Quaterniond.Identity);

    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      HelpForm hf = new HelpForm();
      hf.Show();
    }

    private void DebugButton_Click(object sender, EventArgs e)
    {
      _debugWindow = new DebugWindow();
      _debugWindow.SetScene(_Scene);
      _debugWindow.Show(this);
      //MScene.Root.Debug();

    }

    private void ShadowButton_Click(object sender, EventArgs e)
    {
      _Scene.light.Shadows = !_Scene.light.Shadows;
    }

    private void FogEnableButton_Click(object sender, EventArgs e)
    {
      MScene.Fog.FogEnabled = 1 - MScene.Fog.FogEnabled;
    }

    private void Main_MouseLeave(object sender, EventArgs e)
    {
      _keyboardHandler.ClearState();
    }

    private void Main_Leave(object sender, EventArgs e)
    {
      _keyboardHandler.ClearState();
    }

    private void Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {

    }

    private void cTabSwitcher1_Load(object sender, EventArgs e)
    {

    }

    private void AssetsButton_Click(object sender, EventArgs e)
    {
      AssetsForm af = new AssetsForm();
      af.Show(this);
    }
  }
}
