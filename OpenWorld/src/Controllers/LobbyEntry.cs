using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld.src.Controllers
{
  public class LobbyEntry
  {
    private string name = "";
    private string iP = "127.0.0.1";
    private DateTime lastUsed = DateTime.Now;

    public string Name { get => name; set => name = value; }
    public string IP { get => iP; set => iP = value; }
    public DateTime LastUsed { get => lastUsed; set => lastUsed = value; }
  }
}
