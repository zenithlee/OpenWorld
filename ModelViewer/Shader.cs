using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using System.Drawing;
using System.Diagnostics;


public class MShader
{
  string Name = "";

 
  private int programID;
  public int ProgramID { get => programID; set => programID = value; }

  private string vertexShader;
  public string VertexShader { get => vertexShader; set => vertexShader = value; }

  private string pixelShader;
  public string PixelShader { get => pixelShader; set => pixelShader = value; }

  private string textureFile;
  public string TextureFile { get => textureFile; set => textureFile = value; }

  public MShader(string _name)
  {
    Name = _name;
  }

  public int Load(string sPathVert, string sPathFrag)
  {
    VertexShader = sPathVert;
    PixelShader = sPathFrag;

    ProgramID = GL.CreateProgram();

    int vertexShader = GL.CreateShader(ShaderType.VertexShader);
    GL.ShaderSource(vertexShader, File.ReadAllText(sPathVert));
    GL.CompileShader(vertexShader);

    var info = GL.GetShaderInfoLog(vertexShader);
    if (!string.IsNullOrWhiteSpace(info))
      Debug.WriteLine($"GL.CompileShader had info log: {info}");

    int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
    GL.ShaderSource(fragmentShader, File.ReadAllText(sPathFrag));
    GL.CompileShader(fragmentShader);

    info = GL.GetShaderInfoLog(fragmentShader);
    if (!string.IsNullOrWhiteSpace(info))
      Debug.WriteLine($"GL.CompileShader had info log: {info}");


    GL.AttachShader(ProgramID, vertexShader);
    GL.AttachShader(ProgramID, fragmentShader);
    GL.LinkProgram(ProgramID);

    info = GL.GetProgramInfoLog(ProgramID);
    if (!string.IsNullOrWhiteSpace(info))
    {
      Debug.WriteLine(info);
      Console.Error.Write(info);
    }

    GL.DetachShader(ProgramID, vertexShader);
    GL.DetachShader(ProgramID, fragmentShader);
    GL.DeleteShader(vertexShader);
    GL.DeleteShader(fragmentShader);
    return ProgramID;
  }

  public void Bind()
  {    
    GL.UseProgram(ProgramID);
  }

  public void SetInt(string name, int value)
  {
    int location = GL.GetUniformLocation(ProgramID, name);
    GL.Uniform1(location, value);
  }

  public void SetFloat(string name, float value)
  {
    int location = GL.GetUniformLocation(ProgramID, name);
    GL.Uniform1(location, value);
  }

  public void SetVec3(string name, Vector3 v)
  {
    int location = GL.GetUniformLocation(ProgramID, name);
    GL.Uniform3(location, ref v);
  }

  public void SetMat4(string sPropName, Matrix4 d)
  {
    int vertexColorLocation = GL.GetUniformLocation(ProgramID, sPropName);
    GL.UniformMatrix4(vertexColorLocation, false, ref d);
  }

  public void Dispose()
  {
    GL.DeleteProgram(ProgramID);
  }

}

