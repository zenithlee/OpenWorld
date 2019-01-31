using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//platform specific access to files

namespace Massive.Platform
{
  public class MFileSystem
  {
    public static string RegistryPath = "Assets\\Registry.json";

    public static string GetFile(string sPath)
    {      
      if (!File.Exists(sPath)) return "";
      return File.ReadAllText(sPath);
    }
  }
}
