using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MBoneAnimation
  {
    public string Name;
    //bone number, animation keys
    public Dictionary<int, List<MAnimationKey>> Keys;
    public Matrix4 OffsetMatrix;

    public MBoneAnimation()
    {
      Keys = new Dictionary<int, List<MAnimationKey>>();
    }

    public double GetTotalTime()
    {
      List<MAnimationKey> lak = Keys.Last().Value;
      MAnimationKey mak = lak.Last();
      return mak.Time;
    }

    public Matrix4[] GetAsMatrix(int Frame)
    {
      List<Matrix4> Bones = new List<Matrix4>();
      //List<MAnimationKey> k = Keys[0];
      //if (Keys.ContainsKey(Frame))
      //{
//        k = Keys[Frame];
      //};

      //Matrix4[] m = k.Select((r) => r.Mat).ToArray();

      for( int i=0; i< Keys.Count; i++)
      {
        //Bones.Add(Keys[i][0].Mat);
        Bones.Add(GetKeyAtFrame(i, Frame));
      }

      return Bones.ToArray();
    }

    Matrix4 GetKeyAtFrame(int Bone, int Frame)
    {
      Matrix4 Current = Matrix4.Identity;
      for (int i=0; i< Keys[Bone].Count; i++)
      {
        MAnimationKey k = Keys[Bone][i];
        if ( k.Time > Frame)
        {
          break;
        }
        else
        {
          Current = k.Mat;
        }
      }
      return Current;
    }


    public void AddKey(int Channel, List<MAnimationKey> keys)
    {
      Keys.Add(Channel, keys);
    }
  }
}
