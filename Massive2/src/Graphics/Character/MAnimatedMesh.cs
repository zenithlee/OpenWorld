using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace Massive2.Graphics.Character
{
  class MAnimatedMesh : MMesh
  {
    new AnimatedVertex[] Vertices;        
    VertexBoneData[] bones_id_weights_for_each_vertex;

    int VBO_bones;    
    public MAnimatedMesh(string sName):
      base ("BoneMesh", EType.BoneMesh)
    {

    }

    public MAnimatedMesh(List<AnimatedVertex> vertic, int[] ind, VertexBoneData[] bone_id_weights)
      : base("BoneMesh", EType.BoneMesh)
    {
      Vertices = vertic.ToArray();
      VerticesLength = Vertices.Length;
      Indices = ind;
      IndicesLength = Indices.Length;    
      bones_id_weights_for_each_vertex = bone_id_weights;

      // Now that we have all the required data, set the vertex buffers and its attribute pointers.
     
    }

    public override void Setup()
    {
      Console.WriteLine("Not here");
      SetupMesh();
    }

    void SetupMesh()
    {
      //vertices data
      int MSize = AnimatedVertex.Size;

      GL.GenBuffers(1, out VBO);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
      Helper.CheckGLError(this, "Setup");
      GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * MSize, Vertices, BufferUsageHint.StaticDraw);
      Helper.CheckGLError(this, "Setup");
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

      
      //bones data
      int BoneDataSize = (4 + 4) * 4;
      GL.GenBuffers(1, out VBO_bones);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_bones);      
      GL.BufferData(BufferTarget.ArrayBuffer, bones_id_weights_for_each_vertex.Length 
        * BoneDataSize, bones_id_weights_for_each_vertex, BufferUsageHint.StaticDraw);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

      GL.GenBuffers(1, out EBO);
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
      GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(int), Indices, BufferUsageHint.StaticDraw);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

      //numbers for sequence indices

      GL.GenVertexArrays(1, out VAO);
      GL.BindVertexArray(VAO);           
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
      //vertex position
      GL.EnableVertexAttribArray(0);
      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, MSize, 0);

      GL.EnableVertexAttribArray(1); // offsetof(Vertex, normal) = returns the byte offset of that variable from the start of the struct
      GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 3);

      GL.EnableVertexAttribArray(2);
      GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 6);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      
      //bones
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_bones);
      GL.EnableVertexAttribArray(3);
      GL.VertexAttribIPointer(3, 4, VertexAttribIntegerType.UnsignedInt, BoneDataSize, IntPtr.Zero); // for INT Ipointer      
      GL.EnableVertexAttribArray(4);
      GL.VertexAttribPointer(4, 4, VertexAttribPointerType.Float, false, BoneDataSize, sizeof(uint) * 4);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      
      //indices
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
      GL.BindVertexArray(0);
     
     // base.Setup();
    }

    
    public override void Render(Matrix4d viewproj, Matrix4d parentmodel)
    {
        base.Render(viewproj, parentmodel);
      //Draw(viewproj, parentmodel);
    }
    
      public void Draw(Matrix4d viewproj, Matrix4d parentmodel)
    {
      
      /*
    int diffuse_nr = 1;
    int specular_nr = 1;

    for (int i = 0; i < textures.size(); i++)
    {
      glActiveTexture(GL_TEXTURE0 + i);

      string number;
      string name = textures[i].type;
      if (name == "texture_diffuse")
      {
        number = to_string(diffuse_nr++);
      }
      else if (name == "texture_specular")
      {
        number = to_string(specular_nr++);
      }

      glBindTexture(GL_TEXTURE_2D, textures[i].id);
      glUniform1i(glGetUniformLocation(shaders_program, ("material." + name + number).c_str()), i);

      //cout << "added in shader : " << ("material." + name + number).c_str() << endl;
    }
    
    //glUniform1f(glGetUniformLocation(shaders_program, "material.shininess"), 32.0f);

    //glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
    //glLineWidth(2);
    //Draw
    */

      try
      {
        GL.BindVertexArray(VAO);
        GL.DrawElements(BeginMode.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
        GL.BindVertexArray(0);
      } catch ( Exception e)
      {
        Console.WriteLine(e.Message);
      }


    //for (int i = 0; i < textures.size(); i++)
    //{
    //glActiveTexture(GL_TEXTURE0 + i);
    //glBindTexture(GL_TEXTURE_2D, 0);
    //}
    //*/
    }
  

  }
}
