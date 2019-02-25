﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace ShaderPlay
{
  class Renderer
  {
    Cube cube;
    Triangle triangle;

    int depthMapFBO;
    int depthMap;

    public MShader simpleDepthShader;
    public MShader debugDepthQuad;

    bool IsSetup = false;
    public bool ShowNormals = false;

    float Rotation = 45;
    public bool DoRotation = true;

    MShader _shader;
    MGeomShader _geoShader;
    MTexture _texture;
    MCamera _camera;

    Vector3 lightPos = new Vector3(1, 1, 1);

    public Renderer()
    {

    }

    public void Setup(MShader shader)
    {
      _shader = shader;
      cube = new Cube("Cube");
      cube.CreateGeometry();

      triangle = new Triangle();
      triangle.Setup();


      _camera = new MCamera();
      _camera.Setup();

      _geoShader = new MGeomShader();
      _geoShader.Setup();


      // configure depth map FBO
      // -----------------------

      GL.Enable(EnableCap.DepthTest);

      //GL.GenFramebuffers(1, out depthMapFBO);

      //GL.GenTextures(1, out depthMap);
      //GL.BindTexture(TextureTarget.Texture2D, depthMap);

      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)OpenTK.Graphics.ES11.TextureWrapMode.Clamp);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)OpenTK.Graphics.ES11.TextureWrapMode.Clamp);
      //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.DepthComponent,
      //         1024, 1024, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
      //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureCompareFunc, CompareFun.GL_LEQUAL);

      float[] borderColor = { 1.0f, 0.0f, 0.0f, 1.0f };
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor, borderColor);

      // attach depth texture as FBO's depth buffer
      //GL.BindFramebuffer(FramebufferTarget.Framebuffer, depthMapFBO);
      //GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureTarget.Texture2D, depthMap, 0);
      //GL.DrawBuffer(DrawBufferMode.None);
      //GL.ReadBuffer(ReadBufferMode.None);
      //GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

      shader = new MShader("shader");


      //simpleDepthShader = new MShader("simpleDepthShader");
      //simpleDepthShader.Load("shadow_mapping_depth.vs", "shadow_mapping_depth.fs");


      //debugDepthQuad = new MShader("debugDepthQuad");
      //debugDepthQuad.Load("debug_quad.vs", "debug_quad.fs");
      //debugDepthQuad.Bind();
      //debugDepthQuad.SetInt("depthMap", 0);

      _texture = new MTexture();
      _texture.Setup(@"textures\wood.png", @"textures\asteroid01.jpg");

      IsSetup = true;
    }

    public void renderScene(float time)
    {
      if (IsSetup == false) return;
      GL.ClearColor(Color.FromArgb(255, 65, 65, 75));
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

      if (_texture != null)
      {
        _texture.Bind();
      }

      if (_shader != null)
      {
        _shader.Bind();
      }

      if ( DoRotation == true)
      {
        Rotation += 0.5f;
      }
      
      float xr = Rotation * (float)Math.PI / 180.0f;
      float yr = Rotation * (float)Math.PI / 180.0f;
      float zr = Rotation * 1.2f * (float)Math.PI / 180.0f;
      Matrix4 model = Matrix4.Identity;
      model =
        Matrix4.CreateScale(1f, 1f, 1f) *
        Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(xr, yr, zr)) *
        Matrix4.CreateTranslation(0, 0, 0);

      _shader.SetMat4("projection", _camera.GetMatrix());
      _shader.SetMat4("view", _camera.GetView());
      _shader.SetMat4("model", model);
      _shader.SetFloat("time", time);
      _shader.SetVec3("lightPos", lightPos);

      
      cube.Render();
      if (ShowNormals == true)
      {
         GL.Clear( ClearBufferMask.DepthBufferBit);
        _geoShader.Bind();
        _geoShader.SetMat4("projection", _camera.GetMatrix());
        _geoShader.SetMat4("view", _camera.GetView());
        _geoShader.SetMat4("model", model);      
        cube.Render();
       
      }

    }
  }
}
