using Assimp;
using Assimp.Configs;
using Massive;
using Massive.Platform;
using Massive.Tools;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.IO;

namespace Massive2.Graphics.Character
{
  public class MAnimatedModel2 : MSceneObject
  {
    public const int MAX_BONES = 64;
    public string sFileName;
    private Vector3d m_sceneCenter, m_sceneMin, m_sceneMax;

    //List<AnimatedVertex> vertices = new List<AnimatedVertex>();
    //List<int> indices = new List<int>();
    //int[] indices;
    //List<MTexture> textures = new List<MTexture>();
    public new AnimatedVertex[] Vertices;
    Matrix4[] bonemats;

    List<MBone> Bones = new List<MBone>();
    private Dictionary<string, List<MPose>> animationPoses = new Dictionary<string, List<MPose>>();
    Matrix4 GlobalInverseTransform;
    int FrameTimer = 0;

    MGeomShader _geomShader;
    MPhysicsDebug _debug;

    public MAnimatedModel2(EType type = EType.AnimatedModel, string inname = "AnimatedModel") :
      base(type, inname)
    {
      Console.WriteLine("New animated model");

      bonemats = new Matrix4[MAX_BONES];
      for (int i = 0; i < MAX_BONES; i++)
      {
        bonemats[i] = Matrix4.Identity;
      }
    }

    public override void CopyTo(MObject m1)
    {
      base.CopyTo(m1);
      MAnimatedModel2 an = (MAnimatedModel2)m1;
      if (an != null)
      {
        an.Vertices = Vertices;
        an.VerticesLength = VerticesLength;
        an.Indices = Indices;
        an.IndicesLength = IndicesLength;
        an.sFileName = sFileName;
        an.m_sceneCenter = m_sceneCenter;
        an.m_sceneMax = m_sceneMax;
        an.m_sceneMin = m_sceneMin;
        an.VAO = VAO;
        an.VBO = VBO;
        an.EBO = EBO;
        an.material = material;

        an.bonemats = bonemats;
        an.animationPoses = animationPoses;
        an.FrameTimer = FrameTimer;
        an._geomShader = _geomShader;
        an._debug = _debug;
        an.Bones = Bones;
        an.GlobalInverseTransform = GlobalInverseTransform;
      }

    }

    public override void Setup()
    {
      base.Setup(); //overwrites lengths with MSceneObject lengths, but we've redefined it here
      VerticesLength = Vertices.Length;
      IndicesLength = Indices.Length;
      MMaterial mat = new MMaterial("AnimatedMaterial");
      MShader shade = new MShader("AnimatedShader");

      string sVertFile = "Animation\\animated_vs.glsl";
      string sFragPath = "Animation\\animated_fs.glsl";
      shade.Load(sVertFile, sFragPath, "", "");
      shade.Compile();

      this.SetMaterial(mat);
      mat.AddShader(shade);

      _geomShader = new MGeomShader();
      _geomShader.Load();
      _debug = new MPhysicsDebug();


      SetupBuffers();
    }

    public bool Load(string inFilename)
    {
      sFileName = inFilename;

      string sFullPath = Path.Combine(MFileSystem.AssetsPath, sFileName);
      //string sFullPath =  sPath;
      if (!File.Exists(sFullPath))
      {
        Console.WriteLine("MAnimatedModel.Load: File:" + sFullPath + " not found");
        return false;
      }
      // Console.WriteLine("Create MEsh:" + sFullPath);
      AssimpContext importer = new AssimpContext();
      importer.SetConfig(new NormalSmoothingAngleConfig(35.0f));
      try
      {
        Scene _modelScene = importer.ImportFile(sFullPath, PostProcessSteps.Triangulate | PostProcessSteps.FlipUVs);
        GlobalInverseTransform = TKMatrix( _modelScene.RootNode.Transform);
        GlobalInverseTransform.Invert();
        
        LoadPose(_modelScene.RootNode, _modelScene, this);
        LoadAnimations(_modelScene.RootNode, _modelScene, this);
        LoadMesh(_modelScene.RootNode, _modelScene, this);

        //ComputeBoundingBox();
        ComputeBoundingBox(_modelScene);
        BoundingBox.P1 = m_sceneMin;
        BoundingBox.P2 = m_sceneMax;
      }
      catch (Exception e)
      {
        Globals.Log(this, e.Message);
        Console.WriteLine(e.Message);
        if (e.InnerException != null)
        {
          Console.WriteLine(e.InnerException.Message);
        }
        return false;
      }
      return true;
    }


   
    void LoadPose(Node node, Scene scene, MObject parent)
    {    
      Mesh mesh = scene.Meshes[0];
      Dictionary<string, int> BoneMapping = new Dictionary<string, int>();

      for (int i = 0; i < mesh.BoneCount; i++)
      {
        Bone b = mesh.Bones[i];
        MBone bone = new MBone();
        bone.sName = b.Name;
        //Matrix4x4 GlobalTransformation = ParentTransform * b.OffsetMatrix;
        //bone.matrix = TKMatrix(b.OffsetMatrix);        
        Matrix4x4 invm = b.OffsetMatrix;
        invm.Inverse();
        bone.invmatrix = TKMatrix(invm);
        bone.offsetmatrix = TKMatrix(b.OffsetMatrix);
        //ParentTransform = GlobalTransformation;
        bone.Calc();
        Bones.Add(bone);
      }

      for (int i = 0; i < Bones.Count; i++)
      {
        int id = GetBoneID(Bones[i].sName, scene);
        bonemats[i] = Bones[i].offsetmatrix;
        //bonemats[i].Transpose();
      }

    }


    List<MBoneWeight> FindWeights(int vindex, Mesh mesh, Scene scene)
    {
      List<MBoneWeight> bws = new List<MBoneWeight>();

      for (int ibone = 0; ibone < mesh.BoneCount; ibone++)
      {
        Bone bone = mesh.Bones[ibone];
        for (int iweight = 0; iweight < bone.VertexWeightCount; iweight++)
        {
          VertexWeight w = bone.VertexWeights[iweight];
          if (vindex == w.VertexID)
          {
            //Console.WriteLine("found:" + w.VertexID + "=" + w.Weight + " bone:" + ibone + "(" + bone.Name + ")");
            MBoneWeight bw = new MBoneWeight();
            bw.BoneID = ibone;
            bw.BoneWeight = w.Weight;
            bws.Add(bw);
          }
        }
      }
      return bws;
    }


    void LoadMesh(Node node, Scene scene, MObject parent)
    {
      Mesh mesh = scene.Meshes[0];
      List<AnimatedVertex> vertices = new List<AnimatedVertex>();
      // Walk through each of the mesh's vertices
      for (int i = 0; i < mesh.VertexCount; i++)
      {
        AnimatedVertex v = new AnimatedVertex();
        v._position = new Vector3(mesh.Vertices[i].X, mesh.Vertices[i].Y, mesh.Vertices[i].Z);
        v._normal = new Vector3(mesh.Normals[i].X, mesh.Normals[i].Y, mesh.Normals[i].Z);
        v._textureCoordinate = new Vector2(mesh.TextureCoordinateChannels[0][i].X,
                  1 - mesh.TextureCoordinateChannels[0][i].Y);        

        //float f = FindWeight(i, mesh);
        List<MBoneWeight> bws = FindWeights(i, mesh, scene);

        //v._BoneID = new Vector4(0, 0, 0, 0);
        //v._BoneWeight = new Vector4(0f, 0f, 0f, 0f);

        for (int j = 0; j < bws.Count; j++)
        {
          MBoneWeight bw = bws[j];
          //v._BoneID[j] = bw.BoneID;
          //v._BoneWeight[j] = bw.BoneWeight;
        }

        //v._BoneWeight = new Vector4(0.5f, 0.5f, 0.5f, 0f);
        vertices.Add(v);
      }

      Vertices = vertices.ToArray();
      VerticesLength = Vertices.Length;
      //Indices = mesh.GetIndices();
      //IndicesLength = Indices.Length;
      List<int> VIndices = new List<int>();
      for (int i = 0; i < mesh.FaceCount; i++)
      {
        Face face = mesh.Faces[i];
        
        VIndices.Add(face.Indices[0]);
        VIndices.Add(face.Indices[1]);
        VIndices.Add(face.Indices[2]);
        
      }
      Indices = VIndices.ToArray();
      IndicesLength = Indices.Length;

      //bonemats = new Matrix4[32];
      // bonemats[0] = Matrix4.CreateRotationX(0.1f);
      // bonemats[1] = Matrix4.CreateRotationX(0.2f);
      //bonemats[2] = Matrix4.CreateRotationX(1.0f);
    }

    public override void Render(Matrix4d viewproj, Matrix4d parentmodel)
    {
      // Prep();
      if ((Globals.RenderPass != Globals.eRenderPass.ShadowDepth))
      {
        FrameTimer++;
        if ( FrameTimer > GetAnimationLength("Standard"))
        {
          FrameTimer = 0;
        }
        material.shader.Bind();
        SetAnimationFrame("Standard", FrameTimer);
        //bonemats[0] = Matrix4.CreateRotationX(timer);
        // bonemats[0] = Matrix4.CreateRotationX(Settings.Tweak1 * 0.1f);
        //bonemats[1] = Bones[0].invmatrix * Matrix4.CreateRotationX(Settings.Tweak2 * 0.1f);
        // bonemats[2] = Matrix4.CreateRotationX(Settings.Tweak2 * 0.1f);
        //bonemats[3] = Matrix4.CreateRotationX(Settings.Tweak1 * 0.1f);
        //bonemats[4] = Matrix4.CreateRotationX(Settings.Tweak1 * 0.1f);
        //bonemats[5] = Matrix4.CreateRotationX(Settings.Tweak1 * 0.1f);
       // material.shader.SetMatrices("bones", bonemats);
        //Helper.CheckGLError(this, "TestPoint MShader");
      }
      base.Render(viewproj, parentmodel);

      if (Globals.RenderPass != Globals.eRenderPass.ShadowDepth)
      {
        /*
        MShader prev = Globals.ShaderOverride;
        Globals.ShaderOverride = _geomShader;
        _geomShader.Bind();
        _geomShader.SetMatrices("bones", bonemats);
        base.Render(viewproj, parentmodel);
        Globals.ShaderOverride = prev;
        */


        GL.Clear(ClearBufferMask.DepthBufferBit);

        Vector3d v = Globals.Avatar.GetPosition();
        Vector3d v1 = Vector3d.Zero;
        Vector3d v2 = Vector3d.Zero;

        _debug.UserColorCoding = true;
        Matrix4 test = Matrix4.CreateTranslation(0, 0.5f, 0);
        float f = 0;
        for (int i = 0; i < Bones.Count; i++)
        {
          //(MBone b in Bones)

          f += 0.1f;
          v1 = v2;
          v2 = MassiveTools.Vector3dFromVector3( Bones[i].offsetmatrix.ExtractTranslation());

          Vector3d r1 = v1 + v;
          Vector3d r2 = v2 + v;
          _debug.DrawLine(ref r1, ref r2, i==0? OpenTK.Graphics.Color4.Red:OpenTK.Graphics.Color4.White);
        }

        _debug.Render(viewproj, parentmodel);
      }
    }

    public int GetAnimationLength(string animation)
    {
      if (!animationPoses.ContainsKey(animation))
      {
        return 0;
      }
      return animationPoses[animation].Count-1;
    }

    public void DumpArray(string animation, int frame, int component)
    {
      OpenTK.Quaternion q = animationPoses[animation][frame].MatrixArray[component].ExtractRotation();
      Console.WriteLine("Frame:" + frame + " = " + q.ToString());
    }

      public void SetAnimationFrame(string animation, float frame)
    {
      int prevFrame = Convert.ToInt32(Math.Floor(frame));
      int nextFrame = Convert.ToInt32(Math.Ceiling(frame));

      // we're sitting on an exact frame
      if (prevFrame == nextFrame)
      {
        material.shader.SetMatrices("bones", animationPoses[animation][nextFrame].MatrixArray);
       // DumpArray(animation, (int)frame, 0);       
        return;
      }

      if (nextFrame >= animationPoses[animation].Count)
        nextFrame = 0;

      // we need to interpolate between framese
      float blend = Convert.ToSingle(frame % 1.0);

      Matrix4[] prev = animationPoses[animation][prevFrame].MatrixArray;
      Matrix4[] next = animationPoses[animation][nextFrame].MatrixArray;

      Matrix4[] inter = InterpolateMatrix(prev, next, blend);

      material.shader.SetMatrices("bones", inter);      
    }

    public void SetupBuffers()
    {
      GL.GenVertexArrays(1, out VAO);
      GL.GenBuffers(1, out VBO);
      GL.GenBuffers(1, out EBO);

      int MSize = AnimatedVertex.Size;

      GL.BindVertexArray(VAO);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
      GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * MSize, Vertices, BufferUsageHint.StaticDraw);

      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
      GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(int), Indices, BufferUsageHint.StaticDraw);

      // vertex positions
      GL.EnableVertexAttribArray(0);
      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, MSize, 0);
      // vertex normals
      GL.EnableVertexAttribArray(1);
      GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 3);
      // vertex texture coords
      GL.EnableVertexAttribArray(2);
      GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 6);

      // vertex tangent
      //GL.EnableVertexAttribArray(3);
      //GL.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 8);
      // vertex bitangent
      //GL.EnableVertexAttribArray(4);
      //GL.VertexAttribPointer(4, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 11);

      //bone ids x 4
      GL.EnableVertexAttribArray(3);
      GL.VertexAttribPointer(3, 4, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 9);

      //bone weights x 4
      GL.EnableVertexAttribArray(4);
      GL.VertexAttribPointer(4, 4, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 13);

      GL.BindVertexArray(0);

      base.Setup();
    }

    int GetBoneID(string sName, Scene scene)
    {
      for ( int i=0; i< scene.Meshes[0].BoneCount; i++)
      {
        if (scene.Meshes[0].Bones[i].Name == sName)
          return i;
      }
      return -1;
    }

    void LoadAnimations(Node node, Scene scene, MObject parent)
    {
      List<Animation> Animations = scene.Animations;

      foreach (Animation ani in Animations)
      {
        Console.Write(" ani " + ani.Name);
        List<NodeAnimationChannel> Channels = ani.NodeAnimationChannels;
        Matrix4 finalm = Matrix4.Identity;

        List<MPose> poses = new List<MPose>();
        for (int i = 0; i < (int)ani.DurationInTicks; i++)
        {
          Matrix4 parentm = Matrix4.Identity;

          MPose pose = new MPose((int)Channels.Count);
          for( int boneChannel = 0; boneChannel<Channels.Count; boneChannel++)
          {
            List<QuaternionKey> Keys = Channels[boneChannel].RotationKeys;
            List<VectorKey> tKeys = Channels[boneChannel].PositionKeys;
            if ( i< Channels[boneChannel].RotationKeys.Count)
            {            
              string BoneName = Channels[boneChannel].NodeName;
              int BoneID = GetBoneID(BoneName, scene);
              Console.WriteLine(BoneName + " BoneID:" + BoneID);
              if (BoneID == -1) continue;
              pose.MatrixArray[BoneID] = parentm * 
                Matrix4.CreateTranslation(new Vector3(tKeys[i].Value.X, tKeys[i].Value.Y, tKeys[i].Value.Z))
        *
                Matrix4.CreateFromQuaternion(
              new OpenTK.Quaternion(Keys[i].Value.X,
              Keys[i].Value.Y,
              Keys[i].Value.Z,
              Keys[i].Value.W));
              finalm = pose.MatrixArray[boneChannel];
              parentm = pose.MatrixArray[boneChannel];
            }
            else
            {
              pose.MatrixArray[boneChannel] = Matrix4.CreateTranslation(
                new Vector3(tKeys[0].Value.X, tKeys[0].Value.Y, tKeys[0].Value.Z))
        * Matrix4.CreateFromQuaternion(
              new OpenTK.Quaternion(Keys[0].Value.X,
              Keys[0].Value.Y,
              Keys[0].Value.Z,
              Keys[0].Value.W));
            }
          }          

          poses.Add(pose);
        }
        string[] sName = ani.Name.Split('|');
        animationPoses.Add("Standard", poses);
      }

      /*
      foreach (Animation ani in Animations)
      {
       
        Console.Write(" ani ");
        List<NodeAnimationChannel> Channels = ani.NodeAnimationChannels;
        foreach (NodeAnimationChannel bonechannel in Channels)
        {
          List<MPose> poses = new List<MPose>();
          Console.Write(" chan ");
          List<QuaternionKey> Keys = bonechannel.RotationKeys;
          int maxtime = 1;
          Matrix4 finalm = Matrix4.Identity;
          for ( int i=0; i< (int)ani.DurationInTicks; i++)
          {
            MPose pose = new MPose((int)Channels.Count);
            if ( i<Keys.Count)
            {
              int time = (int)Keys[i].Time;
              Matrix4 m = Matrix4.CreateFromQuaternion(
              new OpenTK.Quaternion(Keys[i].Value.X,
              Keys[i].Value.Y,
              Keys[i].Value.Z,
              Keys[i].Value.W));
              pose[i] = m;
              maxtime = time;
              finalm = m;
            }
            else
            {
              pose[i] = finalm;
            }
            poses.Add(pose);
          }

          string[] sName = ani.Name.Split('|');
          animationPoses.Add(sName[1], poses);
        }

       
      }
      */

    }

    private void ComputeBoundingBox(Scene _modelScene)
    {
      m_sceneMin = new Vector3d(1e10f, 1e10f, 1e10f);
      m_sceneMax = new Vector3d(-1e10f, -1e10f, -1e10f);
      Matrix4 identity = Matrix4.Identity;

      ComputeBoundingBox(_modelScene, _modelScene.RootNode, ref m_sceneMin, ref m_sceneMax, ref identity);

      m_sceneCenter.X = (m_sceneMin.X + m_sceneMax.X) / 2.0f;
      m_sceneCenter.Y = (m_sceneMin.Y + m_sceneMax.Y) / 2.0f;
      m_sceneCenter.Z = (m_sceneMin.Z + m_sceneMax.Z) / 2.0f;
    }

    private void ComputeBoundingBox(Scene _modelScene, Node node, ref Vector3d min, ref Vector3d max, ref Matrix4 trafo)
    {
      Matrix4 prev = trafo;
      trafo = Matrix4.Mult(prev, FromMatrix(node.Transform));

      if (node.HasMeshes)
      {
        foreach (int index in node.MeshIndices)
        {
          Mesh mesh = _modelScene.Meshes[index];
          for (int i = 0; i < mesh.VertexCount; i++)
          {
            Vector3 tmp = FromVector(mesh.Vertices[i]);
            //Vector3.TransformVector(ref tmp, ref trafo, out tmp);
            //tmp = (trafo. * tmp;

            min.X = Math.Min(min.X, tmp.X);
            min.Y = Math.Min(min.Y, tmp.Y);
            min.Z = Math.Min(min.Z, tmp.Z);

            max.X = Math.Max(max.X, tmp.X);
            max.Y = Math.Max(max.Y, tmp.Y);
            max.Z = Math.Max(max.Z, tmp.Z);
          }
        }
      }

      for (int i = 0; i < node.ChildCount; i++)
      {
        ComputeBoundingBox(_modelScene, node.Children[i], ref min, ref max, ref trafo);
      }
      trafo = prev;
    }

    public static OpenTK.Matrix4 TKMatrix(Assimp.Matrix4x4 input)
    {
      return new OpenTK.Matrix4(input.A1, input.B1, input.C1, input.D1,
                                 input.A2, input.B2, input.C2, input.D2,
                                 input.A3, input.B3, input.C3, input.D3,
                                 input.A4, input.B4, input.C4, input.D4);
    }

    private Matrix4 FromMatrix(Matrix4x4 mat)
    {
      Matrix4 m = new Matrix4();
      m.M11 = mat.A1;
      m.M12 = mat.A2;
      m.M13 = mat.A3;
      m.M14 = mat.A4;
      m.M21 = mat.B1;
      m.M22 = mat.B2;
      m.M23 = mat.B3;
      m.M24 = mat.B4;
      m.M31 = mat.C1;
      m.M32 = mat.C2;
      m.M33 = mat.C3;
      m.M34 = mat.C4;
      m.M41 = mat.D1;
      m.M42 = mat.D2;
      m.M43 = mat.D3;
      m.M44 = mat.D4;
      return m;
    }

    private Vector3 FromVector(Vector3D vec)
    {
      Vector3 v;
      v.X = vec.X;
      v.Y = vec.Y;
      v.Z = vec.Z;
      return v;
    }

    public static Matrix4[] InterpolateMatrix(Matrix4[] prev, Matrix4[] next, float blend)
    {
      Matrix4[] result = new Matrix4[prev.Length];

      for (int i = 0; i < prev.Length; i++)
      {
        Vector3 positionInter = Vector3.Lerp(prev[i].ExtractTranslation(), next[i].ExtractTranslation(), blend);
        Vector3 scaleInter = Vector3.Lerp(prev[i].ExtractScale(), next[i].ExtractScale(), blend);
        OpenTK.Quaternion rotationInter = OpenTK.Quaternion.Slerp(prev[i].ExtractRotation(), next[i].ExtractRotation(), blend);

        result[i] = Matrix4.CreateFromQuaternion(rotationInter) * Matrix4.CreateTranslation(positionInter) * Matrix4.CreateScale(scaleInter);
      }
      return result;
    }
  }
}
