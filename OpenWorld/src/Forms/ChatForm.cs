using OpenWorld;
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
  public partial class ChatForm : DToolForm
  {
    public ChatForm()
    {
      InitializeComponent();
      SetTitle("_SOCIAL");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ChatForm_Shown(object sender, EventArgs e)
    {
      Point p = Main.ClientLocation;
      p.Offset(Main.RenderClientSize.Width - Width, 0);
      Location = p;
      cChatControl1.Setup();
    }

    private void cChatControl1_Load(object sender, EventArgs e)
    {
         
    }
  }
}
