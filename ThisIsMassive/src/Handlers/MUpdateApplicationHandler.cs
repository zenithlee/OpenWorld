using Massive;
using Massive.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThisIsMassive.src.Handlers
{
  public class MUpdateApplicationHandler
  {
    BackgroundWorker bw;
    string Version;
    public void CheckForUpdates()
    {
      bw = new BackgroundWorker();
      bw.DoWork += Bw_DoWork;
      bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
      bw.RunWorkerAsync();
    }

    private void Bw_DoWork(object sender, DoWorkEventArgs e)
    {
      WebClient wc = new WebClient();
      string UpdateServer = "http://" + Settings.UpdateServerIP + "/massive/version.txt";
      //Version = wc.DownloadString(UpdateServer);
    }

    private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Console.WriteLine(Version);
      int ServerVersion = 0;
      int.TryParse(Version, out ServerVersion);

      Globals.Log(this, "Running version:" + Globals.VERSION + ". Latest version: " + ServerVersion);

      if (ServerVersion> Globals.VERSION)
        {
          MMessageBus.UpdateRequired(this, "An update is required. Please upgrade to Version " + (ServerVersion*0.001) + " to avoid data loss. Visit http://bigfun.co.za to download the latest version.");
        }
    }
  }
}
