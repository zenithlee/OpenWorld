using Massive;
using Massive.Events;
using Massive.Network;
using Massive.Platform;
using Massive.Tools;
using OpenTK;
using OpenWorld.Handlers;
using System;

namespace OpenWorld.Controllers
{
  public class COpenWorld
  {
    MSpawnHandler _spawnHandler;
    MDeleteHandler _deleteHandler;
    MTeleportHandler _teleportHandler;
    MTextureHandler _textureHandler;
    MCameraHandler _cameraHandler;
    MLightHandler _lightHandler;
    MBuildParts _buildParts;
    UserDetails _userDetails;
    MPropertyChangeHandler _propertyHandler;
    MMoveHandler _moveHandler;
    MNavigationPointer _navPointer;
    BookmarkController _bookmarkController;
    MAvatarHandler _avatarHandler;

    public COpenWorld()
    {
      Settings.TerrainPhysics = true;
      Settings.DrawTrees = false;
      Settings.DrawTerrains = true;
      Settings.DrawBackdrop = true;
      Settings.DrawPlanets = true;

      Settings.DebugDepth = true;

      Globals.Network.ConnectedToMASSIVEHandler += Network_ConnectedToMASSIVEHandler;
      Globals.Network.ConnectedToServerHandler += Network_ConnectedToServerHandler;
      //Globals.Network.LoggedInHandler += Network_LoggedInHandler;
      MMessageBus.LoggedIn += MMessageBus_LoggedIn;
    }

    public void Setup()
    {
      Globals.VERSION = MVersion.VERSION;

      MFileSystem.SetProjectPath(@".\");
      Globals._scene = new MScene(true);
      _spawnHandler = new MSpawnHandler();
      _deleteHandler = new MDeleteHandler();
      _cameraHandler = new MCameraHandler();
      _teleportHandler = new MTeleportHandler();
      _textureHandler = new MTextureHandler();
      _lightHandler = new MLightHandler();
      _propertyHandler = new MPropertyChangeHandler();
      _navPointer = new MNavigationPointer();
      _bookmarkController = new BookmarkController();
      _moveHandler = new MMoveHandler();
      _avatarHandler = new MAvatarHandler();

      MStateMachine state = new MStateMachine(Globals.GUIThreadOwner);

      Globals._scene.SetupInitialObjects();

      _buildParts = new MBuildParts();
      _buildParts.Setup();

      _userDetails = new UserDetails();
      _userDetails.Setup();
      ParseCmdLine();

      //TODO: get from server     
      Globals.UserAccount.HomePosition = MassiveTools.ArrayFromVector(new Vector3d(12717655836.0836, 146353256922.555, -7581841295.85195));
      Globals.UserAccount.CurrentPosition = Globals.UserAccount.HomePosition;

      Globals._scene.Setup();
      _navPointer.Setup();

      Globals._scene.Play();
      //Settings.DebugNetwork = true;
      CreateAvatar();
      MStateMachine.ChangeState(MStateMachine.eStates.Viewing);
    }

    void CreateAvatar()
    {
      MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);      
    }

    void ParseCmdLine()
    {
      string[] args = Environment.GetCommandLineArgs();

      if (args.Length > 1)
      {
        Globals.UserAccount.UserID = args[1];
      }
    }

    //1 client connects to MASSIVE server and receives this callback
    private void Network_ConnectedToMASSIVEHandler(object sender, Massive.Events.StatusEvent e)
    {
      Console.WriteLine("Connected To Universe");
      Globals.Network.SendLoginRequest();
    }

    //2 user logs in, gets a userID, ends up here
    private void MMessageBus_LoggedIn(object sender, ChangeDetailsEvent e)
    {
      ParseCmdLine();

      Globals.Network.GetWorld();

      //TODO: Use Server-side home position
      Vector3d Home = MassiveTools.VectorFromArray(Globals.UserAccount.HomePosition);
      //Globals.UserAccount.HomePosition = MassiveTools.ArrayFromVector(Home);

      Globals.Network.SpawnRequest(Globals.UserAccount.AvatarID, MTexture.DEFAULT_TEXTURE, Globals.UserAccount.UserID, "TAG",
        Home, Quaterniond.Identity, Globals.UserAccount.UserID, 0, 10);

      Globals.Network.ChangeAvatarRequest(Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      //12717655889.4, 146353256822.3, -7581841339.4(18.4096672612293, -33.9328163657347, 0)     
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, Home,
        Quaterniond.Identity);
    }

    //1 client connects to server and receives this callback
    private void Network_ConnectedToServerHandler(object sender, Massive.Events.StatusEvent e)
    {
      Console.WriteLine("Connected to Server");
    }

    public void Update()
    {
      /// MPlanetHandler.GetUpAt(MassiveTools.VectorFromArray((Globals.UserAccount.CurrentPosition)));
      Globals._scene.Update();
    }

    public void Render()
    {
      Globals._scene.ClearBackBuffer();
      Globals._scene.Render();
    }

    public void Dispose()
    {
      Globals.ApplicationExiting = true;
      MScene.Physics.DisposeWorld();
      Globals._scene.Dispose();
    }
  }
}
