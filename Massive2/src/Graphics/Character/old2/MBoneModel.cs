using Assimp;
using Assimp.Configs;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace Massive
{
  public class MBoneModel : MSceneObject
  {    
    int CurrentFrame = 0;    
    public string Filename;
    Scene _modelScene;

    MBone RootBone;
    int JointCount;
    MAnimator Animator;

    public MBoneModel(int in_VAOModel, MMaterial mat, MBone in_Root, int in_JointCount ) : base(EType.BoneMesh, "BoneMesh")
    {
      VAO = in_VAOModel;
      AddMaterial(mat);
      RootBone = in_Root;
      JointCount = in_JointCount;
      Animator = new MAnimator();
      RootBone.CalcInverseBindTransform(new Matrix4());
    }

    public int GetVAO()
    {
      return VAO;
    }

    public override void Update()
    {
      base.Update();
      Animator.Update();
    }

    public Matrix4[] GetJointTransforms()
    {
      Matrix4[] JointMatrices = new Matrix4[JointCount];
      AddJointsToArray(RootBone, JointMatrices);
      return JointMatrices;
    }

    void AddJointsToArray(MBone ParentJoint, Matrix4[] JointMatrices)
    {
      JointMatrices[ParentJoint.Index] = ParentJoint.GetAnimatedTransform();
      foreach( MBone b in ParentJoint.Children)
      {
        AddJointsToArray(b, JointMatrices);
      }
    }


    public void SetFrame(int t)
    {
      CurrentFrame = t;
    }

    public override void Bind()
    {
      Matrix4[] Bones;
      if (Animations.Count > 0)
      {
        string sKey = Animations.Keys.First();
        MBoneAnimation ani = Animations[sKey];
         Bones = ani.GetAsMatrix(CurrentFrame);
        //Bones[0] = Matrix4.Identity;
      }
      else
      {
        Bones = new Matrix4[1];
        Bones[0] = Matrix4.Identity;
      }
      //OpenTK.Quaternion q = OpenTK.Quaternion.FromEulerAngles(0, MathHelper.DegreesToRadians(5), MathHelper.DegreesToRadians(15));
      //Bones[1] = Matrix4.CreateFromQuaternion(q);
      //Pose[1].Transpose();
      material.shader.Bind();
      material.shader.SetMatrices("Bones", Bones);
    }

    public double GetTotalTime()
    {
      if (Animations.Count == 0) return 0;
      MBoneAnimation mb = Animations.Last().Value;
      return mb.GetTotalTime();
    }

    public virtual void Load(string sPath)
    {
      Filename = sPath;
      string sFullPath = Path.Combine(Globals.ResourcePath, sPath);
      //string sFullPath =  sPath;
      if (!File.Exists(sFullPath))
      {
        Console.WriteLine("File:" + sFullPath + " not found");
        return;
      }

      CreateMesh(sFullPath);

      LoadAnimations(sFullPath);

      Setup();
    }

    public override void Setup()
    {
      GL.GenVertexArrays(1, out VAO);
      GL.GenBuffers(1, out VBO);
      GL.GenBuffers(1, out EBO);

      int MSize = TexturedVertexAnim.Size;

      GL.BindVertexArray(VAO);
      GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
      GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * MSize, Vertices, BufferUsageHint.DynamicDraw);

      GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
      GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(int), Indices, BufferUsageHint.DynamicDraw);

      // vertex positions
      GL.EnableVertexAttribArray(0);
      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, MSize, 0);
      // vertex normals
      GL.EnableVertexAttribArray(1);
      GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 3);
      // vertex texture coords
      GL.EnableVertexAttribArray(2);
      GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 6);
      // Bone Index
      GL.EnableVertexAttribArray(3);
      GL.VertexAttribPointer(3, 4, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 8);
      // Bone weight
      GL.EnableVertexAttribArray(4);
      GL.VertexAttribPointer(4, 4, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 12);

      // vertex tangent
      //GL.EnableVertexAttribArray(3);
      //GL.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 8);
      // vertex bitangent
      //GL.EnableVertexAttribArray(4);
      //GL.VertexAttribPointer(4, 3, VertexAttribPointerType.Float, false, MSize, sizeof(float) * 11);


      GL.BindVertexArray(0);

      base.Setup();
    }


    protected bool CreateMesh(string sFullPath)
    {
      // Console.WriteLine("Create MEsh:" + sFullPath);
      AssimpContext importer = new AssimpContext();
      importer.SetConfig(new NormalSmoothingAngleConfig(35.0f));
      List<TexturedVertexAnim> Verts = new List<TexturedVertexAnim>();
      List<int> indices = new List<int>();

      try
      {
        _modelScene = importer.ImportFile(sFullPath, PostProcessSteps.Triangulate);
        Dictionary<int, List<MBoneWeight>> Weights = GetBoneWeights(_modelScene);

        Mesh mesh = _modelScene.Meshes[0];
        for (int i = 0; i < mesh.Vertices.Count; i++)
        {
          Assimp.Vector3D v = mesh.Vertices[i];
          Assimp.Vector3D n = mesh.Normals[i];
          Assimp.Vector3D tc = new Vector3D();
          if (_modelScene.Meshes[0].HasTextureCoords(0))
          {
            tc = mesh.TextureCoordinateChannels[0][i];
          }

          float Weight1 = 0;
          float BoneID1 = 0;
          float Weight2 = 0;
          float BoneID2 = 0;
          if (Weights.ContainsKey(i))
          {
            Weight1 = Weights[i][0].Weight1;
            BoneID1 = Weights[i][0].BoneID1;
            if (Weights[i].Count > 1)
            { 
              Weight2 = Weights[i][1].Weight1;
              BoneID2 = Weights[i][1].BoneID1;
            }            
          }

          Verts.Add(new TexturedVertexAnim(
            new Vector3(v.X, v.Y, v.Z),
            new Vector3(n.X, n.Y, n.Z),
            new Vector2(tc.X, tc.Y),
            new Vector4(BoneID1, BoneID2, 0, 0),
            new Vector4(Weight1,Weight2,0,0)));
        }

        // now wak through each of the mesh's faces (a face is a mesh its triangle) and retrieve the corresponding vertex indices.
        for (int i = 0; i < mesh.FaceCount; i++)
        {
          Face face = mesh.Faces[i];
          // retrieve all indices of the face and store them in the indices vector
          for (int j = 0; j < face.IndexCount; j++)
            indices.Add(face.Indices[j]);
        }
        
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

      Vertices = Verts.ToArray();
      Indices = indices.ToArray();

      return true;
    }

    public Dictionary<int, List<MBoneWeight>> GetBoneWeights(Scene _modelScene)
    {
      Dictionary<int,List<MBoneWeight>> weights = new Dictionary<int, List<MBoneWeight>>();
      for (int i = 0; i < _modelScene.Meshes[0].BoneCount; i++)
      {        
        for (int j = 0; j < _modelScene.Meshes[0].Bones[i].VertexWeights.Count; j++)
        {
          int id = _modelScene.Meshes[0].Bones[i].VertexWeights[j].VertexID;
          if (!weights.ContainsKey(id))
          { 
            weights[id] = new List<MBoneWeight>();
          }
          float weight = _modelScene.Meshes[0].Bones[i].VertexWeights[j].Weight;          
          weights[id].Add(new MBoneWeight(i+1, weight));
        }
      }
      return weights;
    }
    
    public bool LoadAnimations(string sPath)
    {
      string sFullPath = Path.Combine(Globals.ResourcePath, sPath);
      //string sFullPath =  sPath;
      if (!File.Exists(sFullPath))
      {
        Console.WriteLine("File:" + sFullPath + " not found");
        return false;
      }

      //AssimpContext importer = new AssimpContext();
      //importer.SetConfig(new NormalSmoothingAngleConfig(35.0f));
      try
      {
        //Scene _modelScene = importer.ImportFile(sFullPath, PostProcessSteps.Triangulate);
        processAnimations(_modelScene);
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

    void processAnimations(Scene _scene)
    {
      if ( _scene.Animations.Count == 0)
      {
        MBoneAnimation newANim = new MBoneAnimation();
        Animations.Add("BindPose", newANim);

        for ( int i=0; i< _scene.Meshes[0].Bones.Count; i++)
        {
          List<MAnimationKey> keys = new List<MAnimationKey>();
          MAnimationKey key = new MAnimationKey();
          key.Mat = convertMatrix(_scene.Meshes[0].Bones[i].OffsetMatrix);          
          keys.Add(key);
          Console.WriteLine(key.Mat);
          newANim.AddKey(i,keys);
        }
      }


      foreach (Animation ani in _scene.Animations)
      {
        MBoneAnimation newANim = new MBoneAnimation();
        Animations.Add(ani.Name, newANim);
        newANim.Name = ani.Name;
        
        int Channel = 0;

        Matrix4 start = convertMatrix( _scene.RootNode.Transform);        

        foreach (NodeAnimationChannel channel in ani.NodeAnimationChannels)
        {
          List<MAnimationKey> keys = new List<MAnimationKey>();

          Matrix4 Previous = Matrix4.Identity;          
          //ASSUMPTION: 1 translate, rotate, and scale key per animation tick
          
          for ( int i=0; i< channel.PositionKeyCount; i++)
          {            
            MAnimationKey mykey = new MAnimationKey();
            mykey.Time = channel.PositionKeys[i].Time;

            Assimp.QuaternionKey aq = channel.RotationKeys[i];
            OpenTK.Quaternion q = new OpenTK.Quaternion(aq.Value.X, aq.Value.Y, aq.Value.Z, aq.Value.W);

            Assimp.Vector3D av = channel.PositionKeys[i].Value;
            OpenTK.Vector3 v = new Vector3(av.X, av.Y, av.Z);

            Matrix4 offset = GetOffset(_scene, channel.NodeName);

            Matrix4 mat =              
            Matrix4.CreateFromQuaternion(q)
            * Matrix4.CreateTranslation(v);

            mat.Transpose();
            //mat = offset * mat;
            mykey.Mat = mat;
            keys.Add(mykey);
          }
          newANim.AddKey(Channel, keys);
          Channel++;
        }
      }
    }

    Matrix4 GetOffset(Scene _scene, string sName)
    {
      foreach( Bone b in _scene.Meshes[0].Bones)
      {
        if (b.Name.Equals(sName)) return convertMatrix(b.OffsetMatrix);
      }
      return Matrix4.Identity;
    }

    public static Matrix4 convertMatrix(Matrix4x4 inputMat)
    {
      // This is the best code I've ever written
      Matrix4 matrix = new Matrix4();
      matrix.M11 = inputMat.A1;
      matrix.M12 = inputMat.A2;
      matrix.M13 = inputMat.A3;
      matrix.M14 = inputMat.A4;

      matrix.M21 = inputMat.B1;
      matrix.M22 = inputMat.B2;
      matrix.M23 = inputMat.B3;
      matrix.M24 = inputMat.B4;

      matrix.M31 = inputMat.C1;
      matrix.M32 = inputMat.C2;
      matrix.M33 = inputMat.C3;
      matrix.M34 = inputMat.C4;

      matrix.M41 = inputMat.D1;
      matrix.M42 = inputMat.D2;
      matrix.M43 = inputMat.D3;
      matrix.M44 = inputMat.D4;

      // Correction: the above is the worst code, and this is the best code
      matrix.Transpose();

      // nb. AssImp stores matrices in row-major form, but OpenTK
      // stores them in column-major form (so the translations in translation
      // matrices are at the bottom, and not at the right).
      // Column-major is also why the result of Mult(A,B) actually applies
      // the transformation of A before B.

      return matrix;
    }


    public void SetMaterial(MMaterial mat)
    {
      material = mat;
    }

  }
}
