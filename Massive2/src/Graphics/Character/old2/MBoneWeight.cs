using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MBoneWeight
  {
    public int BoneID1;
    public float Weight1;    

    public MBoneWeight(int id1, float weight1)
    {
      BoneID1 = id1;
      Weight1 = weight1;      
    }
  }
}
