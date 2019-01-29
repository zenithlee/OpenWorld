using Massive;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  class MSimpleMesh
  {
    //Mesh data
    TexturedVertex[] vertices;
    int[] indices;
    List<MTexture> textures;
    VertexBoneData[] bones_id_weights_for_each_vertex;

    //buffers
    int VAO;
    int VBO_vertices;
    int VBO_bones;
    int EBO_indices;

    public MSimpleMesh(List<TexturedVertex> vertic, List<int> ind, List<MTexture> textur, List<VertexBoneData> bone_id_weights)
    {
      vertices = vertic.ToArray();
      indices = ind.ToArray();
      textures = textur;
      bones_id_weights_for_each_vertex = bone_id_weights.ToArray();

      // Now that we have all the required data, set the vertex buffers and its attribute pointers.
      SetupMesh();
    }

    void SetupMesh()
    {
      //vertices data
      GL.GenBuffers(1, out VBO_vertices);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_vertices);
      GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * TexturedVertex.Size, vertices, BufferUsageHint.StaticDraw);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

      //bones data
      GL.GenBuffers(1, out VBO_bones);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_bones);
      GL.BufferData(BufferTarget.ArrayBuffer, bones_id_weights_for_each_vertex.Length * VertexBoneData.Size, bones_id_weights_for_each_vertex, BufferUsageHint.StaticDraw);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

      //numbers for sequence indices
      GL.GenBuffers(1, out EBO_indices);
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO_indices);
      GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

      // create VAO and binding data from buffers to shaders
      GL.GenVertexArrays(1, out VAO);
      GL.BindVertexArray(VAO);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_vertices);
      //vertex position
      GL.EnableVertexAttribArray(0);
      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, TexturedVertex.Size, 0);
      GL.EnableVertexAttribArray(1); // offsetof(Vertex, normal) = returns the byte offset of that variable from the start of the struct
      GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, TexturedVertex.Size, sizeof(float) * 3);
      GL.EnableVertexAttribArray(2);
      GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, TexturedVertex.Size, sizeof(float) * 6);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      //bones
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_bones);
      GL.EnableVertexAttribArray(3);
      GL.VertexAttribIPointer(3, 4, VertexAttribIntegerType.Int, VertexBoneData.Size, IntPtr.Zero); // for INT Ipointer
      GL.EnableVertexAttribArray(4);
      GL.VertexAttribPointer(4, 4, VertexAttribPointerType.Float, false, VertexBoneData.Size, sizeof(int));
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      //indices
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO_indices);
      GL.BindVertexArray(0);
    }

  }
}
