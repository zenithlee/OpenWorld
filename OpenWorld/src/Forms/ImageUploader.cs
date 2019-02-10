using Massive;
using Massive.Platform;
using Massive.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWorld.Forms
{
  public partial class ImageUploader : DToolForm
  {
    public string sLocalFile;
    public string sPublicFile;
    public string sTargetID;

    public ImageUploader()
    {
      InitializeComponent();
    }

    void Status(string s)
    {
      StatusText.Text = s;
    }

    private void SelectFileButton_Click(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "Image Files (*.jpg,*.png)|*.jpg;*.png";
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        sLocalFile = openFileDialog1.FileName;
        pictureBox1.ImageLocation = sLocalFile;
      }
    }



    private void UploadButton_Click(object sender, EventArgs e)
    {
      Status("Uploading...");
      if (string.IsNullOrEmpty(sLocalFile)) return;
      //string sLocalCache = Path.Combine(Globals.AppDataPath, Helper.GUID() + ".jpg");
      System.Net.WebClient Client = new System.Net.WebClient();
      // Client.Credentials = CredentialCache.DefaultCredentials;
      //Client.Headers.Add("Content-Type", "binary/octet-stream");
      Image bmp = Bitmap.FromFile(sLocalFile);

      int size = 800;
      if (HDBox.Checked == true) size = 1024;

      Image bmp2 = ImageTools.ScaleImageProportional(bmp, size, size);

      FileInfo fi = new FileInfo(sLocalFile);
      string extension = fi.Extension;

      string tempname = Helper.HashString(DateTime.Now.ToString()) + extension;
      string TempName = Path.Combine(MFileSystem.AppDataPath, tempname);

      if (File.Exists(TempName))
      {
        File.Delete(TempName);
      }

      bmp2.Save(TempName);

      bmp.Dispose();
      bmp2.Dispose();

      Client.Headers.Add("UserID:" + Globals.UserAccount.UserID);
      Client.Headers.Add("Target:" + sTargetID);
      Client.Headers.Add("Locus:" + sPublicFile);
      string ServerIP = Globals.Network.ServerIP;
      Client.UploadFileAsync(new Uri("http://" + ServerIP + "/massive/fu/fu.php"), "POST", TempName);
      Client.UploadFileCompleted += Client_UploadFileCompleted;
      Client.UploadProgressChanged += Client_UploadProgressChanged;
    }    

    private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        Globals.Log(this, e.Error.Message);
        return;
      }
      string s = System.Text.Encoding.UTF8.GetString(e.Result, 0, e.Result.Length);
      //Console.WriteLine(s);
      Status(s);
      sPublicFile = s;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void Client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
      float progress = ((float)e.BytesSent / (float)e.TotalBytesToSend) * 100.0f;
      UploadProgressBar.Value = (int)progress;
      string s = string.Format("Progress: {0:F2}%", progress);
      //Console.WriteLine(s);
      Status(s);
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
