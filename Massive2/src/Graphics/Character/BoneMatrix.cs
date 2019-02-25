using Assimp;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive2.Graphics
{
  public struct BoneMatrix
  {
    public Matrix4x4 offset_matrix;
    public Matrix4x4 final_world_transform;
    public Vector3 position;
  }
}
