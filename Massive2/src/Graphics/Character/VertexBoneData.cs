using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Massive2.Graphics.Character
{
  [StructLayout(LayoutKind.Explicit)]
  public struct VertexBoneData
  {
    public const int Size = (4 + 4) * 4;
    const int NUM_BONES_PER_VEREX = 4;
    [FieldOffset(0)]
    public Vector4 ids;   // we have 4 bone ids for EACH vertex & 4 weights for EACH vertex
    [FieldOffset(16)]
    public Vector4 weights;
    
    public void InitVertexBoneData()
    {
      ids = new Vector4( 0, 0, 0, 0 );
      weights = new Vector4( 0f, 0f, 0f, 0f );
    }

    public void addBoneData(float bone_id, float weight)
    {
      for (int i = 0; i < NUM_BONES_PER_VEREX; i++)
      {
        if (weights[i] == 0.0)
        {
          ids[i] = bone_id;
          weights[i] = weight;
          return;
        }
      }
    }
  };
}
