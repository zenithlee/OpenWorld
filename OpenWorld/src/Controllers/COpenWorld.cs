using Massive;
using Massive.Events;
using Massive.Tools;
using OpenTK;
using OpenWorld.Handlers;
using OpenWorld.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.controllers
{
  public class COpenWorld
  {    
    MSpawnHandler _spawnHandler;
    MCameraHandler _cameraHandler;    
    MBuildParts _buildParts;

    public COpenWorld()
    {      
      Globals.Network.ConnectedToLobbyHandler += Network_ConnectedToLobbyHandler;
      Globals.Network.ConnectedToMASSIVEHandler += Network_ConnectedToMASSIVEHandler;
      Globals.Network.ConnectedToServerHandler += Network_ConnectedToServerHandler;
      Globals.Network.LoggedInHandler += Network_LoggedInHandler;

      Globals.Network.PositionChangeHandler += Network_PositionChangeHandler;
      Globals.Network.TeleportHandler += Network_TeleportHandler;
    }

    public void Setup()
    {
      Globals.VERSION = MVersion.VERSION;

      Globals.SetProjectPath(@".\");
      Globals._scene = new MScene(true, true);
      _spawnHandler = new MSpawnHandler();
      _cameraHandler = new MCameraHandler();

      Globals._scene.SetupInitialObjects();

      _buildParts = new MBuildParts();
      _buildParts.Setup();

      Globals._scene.Setup();
      Globals._scene.Play();
      Settings.DebugNetwork = true;
      MStateMachine.ChangeState(MStateMachine.eStates.Viewing);
    }

    //1 client connects to Zone Controller and receives this callback
    private void Network_ConnectedToMASSIVEHandler(object sender, Massive.Events.StatusEvent e)
    {
      Console.WriteLine("Connected To Universe");
      Globals.Network.SendLoginRequest();
    }

    //2 we're logged in. Let's create an avatar and tell the server the AvatarID
    private void Network_LoggedInHandler(object sender, ChangeDetailsEvent e)
    {
      Globals.Network.GetWorld();

      Globals.Network.SpawnRequest(Globals.UserAccount.AvatarID, MTexture.DEFAULT_TEXTURE, Globals.UserAccount.UserID, "TAG",
      new OpenTK.Vector3d(12717655889.4, 146353256822.3, -7581841339.4), Quaterniond.Identity, Globals.UserAccount.UserID, 0, 10);
      //MMessageBus.ChangeAvatarRequest(this, Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      Globals.Network.ChangeAvatarRequest(Globals.UserAccount.UserID, Globals.UserAccount.AvatarID);
      //12717655889.4, 146353256822.3, -7581841339.4(18.4096672612293, -33.9328163657347, 0)
      //Globals.Network.PositionRequest(Globals.UserAccount.UserID, new OpenTK.Vector3d(12717655889.4, 146353256822.3, -7581841339.4), Quaterniond.Identity);
      Globals.Network.TeleportRequest(Globals.UserAccount.UserID, new OpenTK.Vector3d(12717655889.4, 146353256822.3, -7581841339.4), Quaterniond.Identity);

    }

    private void Network_TeleportHandler(object sender, MoveEvent e)
    {
      //throw new NotImplementedException();
    }

    private void Network_PositionChangeHandler(object sender, Massive.Events.MoveEvent e)
    {
      //throw new NotImplementedException();
    }

   

    //1 client connects to server and receives this callback
    private void Network_ConnectedToServerHandler(object sender, Massive.Events.StatusEvent e)
    {
      Console.WriteLine("Connected to Server");
    }

    //2 client connects to lobby and receives this callback
    private void Network_ConnectedToLobbyHandler(object sender, Massive.Events.StatusEvent e)
    {
      Console.WriteLine("Connected To Lobby");
      Globals.Network.SendConnectToMASSIVERequest();
    }

  
    public void Update()
    {
      Globals._scene.Update();
    }

    public void Render()
    {
      Globals._scene.ClearBackBuffer();
      Globals._scene.Render();
        
    }
  }
}
