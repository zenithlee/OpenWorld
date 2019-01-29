using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL4;
using Assimp;
using OpenTK;
using System.Runtime.InteropServices;

//this.glControl1 = new OpenTK.GLControl(new OpenTK.Graphics.GraphicsMode(new OpenTK.Graphics.ColorFormat(32), 24, 0, 2));

namespace ModelViewer
{
  public partial class MainWindow : Form
  {
    public Cube cube;
    public MShader shader;
    public MShader simpleDepthShader;
    public MShader debugDepthQuad;

    int depthMapFBO;
    int depthMap;

    int WoodTex;

    public MainWindow()
    {
      InitializeComponent();

      glControl1.Load += GlControl1_Load;
      cube = new Cube("hi");

      timer1.Tick += Timer1_Tick;

    }

    private void GlControl1_Load(object sender, EventArgs e)
    {
      cube.CreateGeometry();
      // configure depth map FBO
      // -----------------------

      GL.Enable(EnableCap.DepthTest);

      GL.GenFramebuffers(1, out depthMapFBO);

      GL.GenTextures(1, out depthMap);
      GL.BindTexture(TextureTarget.Texture2D, depthMap);

      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)OpenTK.Graphics.ES11.TextureWrapMode.Clamp);
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)OpenTK.Graphics.ES11.TextureWrapMode.Clamp);
      GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.DepthComponent,
                 1024, 1024, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
      //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureCompareFunc, CompareFun.GL_LEQUAL);

      float[] borderColor = { 1.0f, 0.0f, 0.0f, 1.0f };
      GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor, borderColor);

      // attach depth texture as FBO's depth buffer
      GL.BindFramebuffer(FramebufferTarget.Framebuffer, depthMapFBO);
      GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureTarget.Texture2D, depthMap, 0);
      GL.DrawBuffer(DrawBufferMode.None);
      GL.ReadBuffer(ReadBufferMode.None);
      GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

      shader = new MShader("shader");
      shader.Load("shadow_mapping.vs", "shadow_mapping.fs");
      shader.Bind();
      shader.SetInt("material.diffuseTexture", 0);
      shader.SetInt("shadowMap", 1);

      simpleDepthShader = new MShader("simpleDepthShader");
      simpleDepthShader.Load("shadow_mapping_depth.vs", "shadow_mapping_depth.fs");


      debugDepthQuad = new MShader("debugDepthQuad");
      debugDepthQuad.Load("debug_quad.vs", "debug_quad.fs");
      debugDepthQuad.Bind();
      debugDepthQuad.SetInt("depthMap", 0);

      WoodTex = loadTexture("wood.png");

      timer1.Start();

    }

    int TriangleProgram = 0;
    int VBO, VAO;
    void HelloTriangle()
    {

      if (TriangleProgram == 0)
      {
        string vertexShaderSource = @"#version 330 core
            layout (location = 0) in vec3 aPos;
            void main()
            {
               gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);
            }";
        string fragmentShaderSource = @"#version 330 core
            out vec4 FragColor;
            void main()
            {
               FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);
            }";
        // vertex shader
        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);
        GL.CompileShader(vertexShader);
        // check for shader compile errors
        int success;
        string infoLog;
        infoLog = GL.GetShaderInfoLog(vertexShader);
        if (!string.IsNullOrEmpty(infoLog))
        {
          Console.WriteLine(infoLog);
        }
        // fragment shader
        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);
        GL.CompileShader(fragmentShader);
        // check for shader compile errors
        infoLog = GL.GetShaderInfoLog(vertexShader);
        if (!string.IsNullOrEmpty(infoLog))
        {
          Console.WriteLine(infoLog);
        }
        // link shaders
        TriangleProgram = GL.CreateProgram();
        GL.AttachShader(TriangleProgram, vertexShader);
        GL.AttachShader(TriangleProgram, fragmentShader);
        GL.LinkProgram(TriangleProgram);
        // check for linking errors
        infoLog = GL.GetShaderInfoLog(vertexShader);
        if (!string.IsNullOrEmpty(infoLog))
        {
          Console.WriteLine(infoLog);
        }
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);


        // set up vertex data (and buffer(s)) and configure vertex attributes
        // ------------------------------------------------------------------
        float[] vertices = {
        -0.5f, -0.5f, 0.0f, // left  
         0.5f, -0.5f, 0.0f, // right 
         0.0f,  0.5f, 0.0f  // top   
    };


        GL.GenVertexArrays(1, out VAO);
        GL.GenBuffers(1, out VBO);
        // bind the Vertex Array Object first, then bind and set vertex buffer(s), and then configure vertex attributes(s).
        GL.BindVertexArray(VAO);

        GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        GL.EnableVertexAttribArray(0);

        // note that this is allowed, the call to glVertexAttribPointer registered VBO as the vertex attribute's bound vertex buffer object so afterwards we can safely unbind
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        // You can unbind the VAO afterwards so other VAO calls won't accidentally modify this VAO, but this rarely happens. Modifying other
        // VAOs requires a call to glBindVertexArray anyways so we generally don't unbind VAOs (nor VBOs) when it's not directly necessary.
        GL.BindVertexArray(0);
      } //if

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
      GL.Clear(ClearBufferMask.ColorBufferBit);

      // draw our first triangle
      GL.UseProgram(TriangleProgram);
      GL.BindVertexArray(VAO); // seeing as we only have a single VAO there's no need to bind it every time, but we'll do so to keep things a bit more organized
      GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, 0, 3);
      // glBindVertexArray(0); // no need to unbind it every time 

      // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
      // -------------------------------------------------------------------------------
      glControl1.SwapBuffers();

    }

    float pos = 0;

    private void Timer1_Tick(object sender, EventArgs e)
    {
      GL.ClearColor(Color.Gray);

      GL.DepthFunc(DepthFunction.Lequal);
      GL.Enable(EnableCap.DepthTest);
     // GL.Enable(EnableCap.DepthClamp);

      //  HelloTriangle();
      // return;

      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      // glControl1.SwapBuffers();

      pos += 0.1f;

      Vector3 lightPos = new Vector3(-5 + pos, 10.0f, -5.0f);
      float near_plane = 0.1f, far_plane = 120.5f;

      Matrix4 lightProjection, lightView, lightSpaceMatrix;
      // 1. render depth of scene to texture (from light's perspective)
      // --------------------------------------------------------------
      //lightProjection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), (float)1024 / (float)1024, 1f, 100.0f);
      lightProjection = Matrix4.CreateOrthographicOffCenter(-10.0f, 10.0f, -10.0f, 10.0f, near_plane, far_plane);
      lightView = Matrix4.LookAt(lightPos, new Vector3(0.0f), new Vector3(0.0f, 1.0f, 0.0f));
      lightSpaceMatrix =   lightView * lightProjection;

      GL.Enable(EnableCap.CullFace);
      //GL.CullFace(CullFaceMode.Front);

      // render scene from light's point of view      
      GL.Viewport(0, 0, Width, Height);

      simpleDepthShader.Bind();
      simpleDepthShader.SetMat4("lightSpaceMatrix", lightSpaceMatrix);

      GL.Viewport(0, 0, 1024, 1024);
      GL.BindFramebuffer(FramebufferTarget.Framebuffer, depthMapFBO);
      GL.Clear(ClearBufferMask.DepthBufferBit);

      //GL.ActiveTexture(TextureUnit.Texture0);
      //GL.BindTexture(TextureTarget.Texture2D, WoodTex);
      //GL.ActiveTexture(TextureUnit.Texture1);
      //GL.BindTexture(TextureTarget.Texture2D, depthMap);

      //renderScene(simpleDepthShader);
      renderScene(simpleDepthShader);
      GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);


      // reset viewport
      // 2. render scene as normal using the generated depth/shadow map  
      // --------------------------------------------------------------
      //  GL.Enable(EnableCap.DepthTest);
      
        GL.Viewport(0, 0, Width, Height);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
   
      //  GL.CullFace(CullFaceMode.Back);
        shader.Bind();
        Matrix4 view = GetViewMatrix(new Vector3(5, 10, 10));
        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(75), (float)Width / (float)Height, 0.1f, 100.0f);

        shader.SetMat4("projection", projection);
        shader.SetMat4("view", view);
        // set light uniforms
        shader.SetVec3("viewPos", new Vector3(10, 10, 10));
        shader.SetVec3("lightPos", lightPos);
        shader.SetMat4("lightSpaceMatrix", lightSpaceMatrix);
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, WoodTex);
        GL.ActiveTexture(TextureUnit.Texture1);
        GL.BindTexture(TextureTarget.Texture2D, depthMap);
        renderScene(shader);
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

  
      GL.Disable(EnableCap.DepthTest);
      // render Depth map to quad for visual debugging
      // ---------------------------------------------
      debugDepthQuad.Bind();
      debugDepthQuad.SetFloat("near_plane", near_plane);
      debugDepthQuad.SetFloat("far_plane", far_plane);
      GL.ActiveTexture(TextureUnit.Texture0);
      GL.BindTexture(TextureTarget.Texture2D, depthMap);
      renderQuad();

  

      glControl1.SwapBuffers();


      // GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

    }

    public Matrix4 GetViewMatrix(Vector3 Position)
    {

      //lookat = Target.transform.Position;       
      return Matrix4.LookAt(
        Position,
        Vector3.Zero,
        // lookat, 
        Vector3.UnitY);
    }

    // renders the 3D scene
    // --------------------
    public void renderScene(MShader shader)
    {
      // floor
      //Matrix4 model = Matrix4.Identity;
      //shader.SetMat4("model", model);
      //GL.BindVertexArray(planeVAO);
      //GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, 0, 6);
      // cubes

      Matrix4 model = Matrix4.Identity;
      model =
        Matrix4.CreateScale(5, 0.5f, 5) *
        Matrix4.CreateTranslation(0, 0, 0);

      shader.SetMat4("model", model);
      cube.Render();

      model = Matrix4.Identity;
      model = Matrix4.CreateScale(0.5f, 3, 0.5f)
          * Matrix4.CreateTranslation(new Vector3(02.0f, -1.0f, 0.0f));

      shader.SetMat4("model", model);
      cube.Render();

      model = Matrix4.Identity;
      model = Matrix4.CreateScale(0.5f)
        * Matrix4.CreateRotationX(0.5f)
      * Matrix4.CreateTranslation(new Vector3(3.0f, 3.0f, 1.0f));

      shader.SetMat4("model", model);
      cube.Render();


      model = Matrix4.Identity;
      model = Matrix4.CreateScale(0.1f, 4, 2f)
        * Matrix4.CreateRotationX(0.5f)
      * Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 1.0f));

      shader.SetMat4("model", model);
      cube.Render();

    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AssimpContext con = new AssimpContext();
      if ( openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        string sPath = openFileDialog1.FileName;
        Scene s = con.ImportFile(sPath);
      }
      //string sPath = @"I:\root\dev\_Massive_64bit\Massive\TestProject\Models\shuttle.obj";
      //Scene s = con.ImportFile(sPath);
    }

    int quadVAO = 0;
    int quadVBO;
    public void renderQuad()
    {
      if (quadVAO == 0)
      {
        float[] quadVertices = {
            // positions        // texture Coords
            -1f,  1.0f, 0.0f, 0.0f, 1.0f,
            -1f, -.1f, 0.0f, 0.0f, 0.0f,
             -0.5f,  1.0f, 0.0f, 1.0f, 1.0f,
             -0.5f, -0.1f, 0.0f, 1.0f, 0.0f,
        };
        // setup plane VAO
        GL.GenVertexArrays(1, out quadVAO);
        GL.GenBuffers(1, out quadVBO);
        GL.BindVertexArray(quadVAO);
        GL.BindBuffer(BufferTarget.ArrayBuffer, quadVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * quadVertices.Length, quadVertices, BufferUsageHint.StaticDraw);
        GL.EnableVertexAttribArray(0);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
        GL.EnableVertexAttribArray(1);
        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
      }
      GL.BindVertexArray(quadVAO);
      GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleStrip, 0, 4);
      GL.BindVertexArray(0);
    }

    // utility function for loading a 2D texture from file
    // ---------------------------------------------------
    int loadTexture(string path)
    {
      int textureID;
      GL.GenTextures(1, out textureID);

      int width, height, nrComponents;
      var data = LoadTextureData(path, out width, out height);


      GL.BindTexture(TextureTarget.Texture2D, textureID);
      GCHandle pp_pixels = GCHandle.Alloc(data, GCHandleType.Pinned);
      GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.Float, pp_pixels.AddrOfPinnedObject());
      GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

      //GL.TexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, format == GL_RGBA? GL_CLAMP_TO_EDGE : GL_REPEAT); // for this tutorial: use GL_CLAMP_TO_EDGE to prevent semi-transparent borders. Due to interpolation it takes texels from next repeat 
      //      GL.TexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, format == GL_RGBA? GL_CLAMP_TO_EDGE : GL_REPEAT);
      //GL.TexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
      //GL.TexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

      return textureID;
    }

    private void glControl1_Load_1(object sender, EventArgs e)
    {

    }

    public static float[] LoadTextureData(string filename, out int width, out int height)
    {
      float[] r;
      using (var bmp = (Bitmap)Image.FromFile(filename))
      {
        width = bmp.Width;
        height = bmp.Height;
        r = new float[width * height * 4];
        int index = 0;
        for (int y = 0; y < height; y++)
        {
          for (int x = 0; x < width; x++)
          {
            var pixel = bmp.GetPixel(x, y);
            r[index++] = pixel.R / 255f;
            r[index++] = pixel.G / 255f;
            r[index++] = pixel.B / 255f;
            r[index++] = pixel.A / 255f;
          }
        }
      }
      return r;
    }


  }
}
