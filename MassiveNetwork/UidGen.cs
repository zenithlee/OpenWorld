using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Network
{
  public static class UidGen
  {
    public static string GUID()
    {
      Guid g = Guid.NewGuid();

      string sGUID = g.ToString();
      return HashString(sGUID);
      /*
       * string sGuid = Convert.ToBase64String(g.ToByteArray());      
      */
      
    }

    public static byte[] Hash(string inputString)
    {
      HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
      return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string HashString(string inputString)
    {
      StringBuilder sb = new StringBuilder();
      foreach (byte b in Hash(inputString))
        sb.Append(b.ToString("X2"));

      return sb.ToString();
    }
  }
}
