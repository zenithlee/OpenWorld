using Massive;
using Massive.Tools;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MBone
  {
    public int Index;
    public string Name;
    public Vector3d Position;
    public Quaterniond Rotation;

    public List<MBone> Children;

    Matrix4 AnimatedTransform; //model space, sent to shader
    Matrix4 LocalBindTransform; //original transform, bone space, relative to parent joint
    Matrix4 InverseBindTransform; //original transform, in model space

    public MBone(int in_Index, string in_name, Matrix4 in_BindLocalTransform)
    {
      Index = in_Index;
      Name = in_name;
      LocalBindTransform = in_BindLocalTransform;

      Children = new List<MBone>();
      AnimatedTransform = new Matrix4();
      LocalBindTransform = new Matrix4();
      InverseBindTransform = new Matrix4();
    }

    public void AddChild(MBone in_bone)
    {
      Children.Add(in_bone);
    }

    public Matrix4 GetAnimatedTransform()
    {
      return AnimatedTransform;
    }

    public void SetAnimatedTransform(Matrix4 in_Transform)
    {
      AnimatedTransform = in_Transform;
    }

    public Matrix4 GetInverseBindTransform()
    {
      return InverseBindTransform;
    }

    public void CalcInverseBindTransform(Matrix4 ParentBindTransform)
    {
      Matrix4 BindTransform = Matrix4.Mult(ParentBindTransform, LocalBindTransform);
      Matrix4.Invert(ref BindTransform, out InverseBindTransform);
      foreach( MBone b in Children)
      {
        b.CalcInverseBindTransform(BindTransform);
      }
    }
    /*
    Matrix4 GetMat()
    {
      Matrix4d mat = Matrix4d.CreateTranslation(Position)
        * Matrix4d.CreateFromQuaternion(Rotation);
      return MTransform.GetFloatMatrix(mat);
    }
    */
  }
}
