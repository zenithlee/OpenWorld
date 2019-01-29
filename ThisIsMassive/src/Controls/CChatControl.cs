using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Massive;
using Massive.Events;

namespace ThisIsMassive.src.Controls
{
  public partial class CChatControl : UserControl
  {
    int IncrementID = 0;
    Font BoldFont = new Font("Arial", 8, FontStyle.Bold);
    Font StdFont = new Font("Arial", 8, FontStyle.Regular);


    public CChatControl()
    {
      InitializeComponent();

     
    }

    private void Network_ChatEventHandler(object sender, ChatEvent e)
    { 
      ChatBox.Invoke((MethodInvoker)delegate
      {
        int st = ChatBox.TextLength;
        ChatBox.SelectionFont = BoldFont;
        ChatBox.SelectionBackColor = Color.DarkCyan;              
        ChatBox.AppendText(e.message.OwnerName + ":" );        
        
        ChatBox.Select(st, ChatBox.TextLength - st);
        ChatBox.SelectionFont = StdFont;
        ChatBox.DeselectAll();

        st = ChatBox.TextLength;        
        ChatBox.AppendText(e.message.Message + "\r\n");
        ChatBox.Select(st, ChatBox.TextLength-st);
        ChatBox.SelectionBackColor = Color.Black;
        ChatBox.DeselectAll();

        ChatBox.ScrollToCaret();
      });

      if (e.message.MessageID == IncrementID)
      {
        ChatBoxMessage.Invoke((MethodInvoker)delegate
        {
          ChatBoxMessage.Text = "";
          IncrementID++;
          ChatBoxMessage.Focus();
        });
      }

    }

    private void SendButton_Click(object sender, EventArgs e)
    {      
      SendChat(ChatBoxMessage.Text);
    }
    void SendChat( string s)
    {
      s = s.Trim(new char[] { ' ', '\n', '\r' });
      if (string.IsNullOrEmpty(s)) return;
      IncrementID++;
      Globals.Network.ChatRequest("*", s, IncrementID);
    }

    private void ChatBoxMessage_KeyUp(object sender, KeyEventArgs e)
    {
      if ( e.KeyCode == Keys.Return )
      {
        SendChat(ChatBoxMessage.Text);
      }
    }

    private void GiveCake_Click(object sender, EventArgs e)
    {
      SendChat("*Cake*");
    }

    private void ChatBox_VisibleChanged(object sender, EventArgs e)
    {
      if ( Visible == true)
      {
        Globals.Network.ChatEventHandler += Network_ChatEventHandler;
      }
      else
      {
        Globals.Network.ChatEventHandler -= Network_ChatEventHandler;
      }
    }
  }
}
