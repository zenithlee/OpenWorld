using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThisIsMassive.src.Forms;

namespace OpenWorld.src.Controls
{
  public partial class ToolbarControl : UserControl
  {
    public ToolbarControl()
    {
      InitializeComponent();
    }

    private void ChatButton_Click(object sender, EventArgs e)
    {
      ChatForm chat = new ChatForm();
      chat.Show(Main.ActiveForm);
    }
  }
}
