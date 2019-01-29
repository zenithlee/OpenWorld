using Massive;
using Massive.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThisIsMassive.src.Controls;

namespace ThisIsMassive.src.Forms
{
  public partial class ProductInfoForm : DFormBase
  {
    string InstanceID;
    MSceneObject Target;
    public string Description;
    public string Price;

    public ProductInfoForm()
    {
      InitializeComponent();     
      MMessageBus.PropertyChangeEvent += MMessageBus_PropertyChangeEvent;
    }

    private void MMessageBus_PropertyChangeEvent(object sender, ChangePropertyEvent e)
    {
      if ( e.InstanceID == InstanceID)
      {
        StatusText.Text = "SUCCESS";
      }
      else
      {
        StatusText.Text = "Can't update. Retry?";
      }
    }

    public void Setup(MSceneObject mo)
    {
      if (mo == null) return;
      Target = mo;
      InstanceID = Target.InstanceID;
      UpdateImage();
      UpdateData();
    }

    void UpdateData()
    {
      SetTitle("Info");
      if ( Target.Tag != null)
      {
        string sTag = (string)Target.Tag;

        string[] Items = sTag.Split('|');

        if (Items.Length > 0)
        {
          Description = Items[1];
          InfoBox.Text = Description;
        }

        if (Items.Length > 2)
        {
          Price= Items[2];
          MetaData.Text = Price;
        }
      }
    }

    void UpdateImage()
    {
      MTexture mt = (MTexture)Target.FindModuleByType(MObject.EType.Texture);
      if (mt == null) return;

      if ( File.Exists(mt.CacheFilename ))
      {
        pictureBox1.ImageLocation = mt.CacheFilename;
      }
      else
      if (File.Exists(mt.Filename))
      {
        pictureBox1.ImageLocation = mt.Filename;
      }
      else
      {
        //URL?
        //pictureBox1.ImageLocation = mt.Filename;
      }      
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
      Description = InfoBox.Text;
      Price = MetaData.Text;

      Globals.Network.ChangePropertyRequest(InstanceID, BuildParts.BOOK01+ "|" + Description + "|" + Price);
    }
  }
}
