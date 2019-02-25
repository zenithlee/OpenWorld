using Assimp;
using Assimp.Configs;
using Massive;
using Massive.Platform;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using Massive.Tools;

namespace Massive2.Graphics.Character
{
  public class MAnimatedModel : MSceneObject
  {
    const uint MAX_BONES = 50;
    List<MAnimatedMesh> Meshes;
    Scene scene;
    Matrix4x4 m_global_inverse_transform;
    int m_num_bones = 0;
    Dictionary<string, int> m_bone_mapping; // maps a bone name and their index
    List<BoneMatrix> m_bone_matrices = new List<BoneMatrix>();
    float ticks_per_second = 25.0f;
    float FrameCounter = 0;
    MPhysicsDebug _debug;

    public static Matrix4[] debug_transforms = new Matrix4[MAX_BONES];

    public MAnimatedModel(EType type = EType.AnimatedModel, string sName = "AnimatedModel")
      : base(type, sName)
    {
      Meshes = new List<MAnimatedMesh>();
      m_bone_mapping = new Dictionary<string, int>();
    }

    public void CopyTo(MAnimatedModel m)
    {
      //do not call base(MSceneObject) CopyTo here because it is handled by SpawnHandler and adds extra Physics
      m.Meshes = Meshes;
      m.scene = scene;
      m.m_global_inverse_transform = m_global_inverse_transform;
      m.m_num_bones = m_num_bones;
      m.m_bone_matrices = m_bone_matrices;
      m.m_bone_mapping = m_bone_mapping;
      m.ticks_per_second = ticks_per_second;
      m._debug = _debug;
    }

    public void Load(string sName)
    {
      string sFileName = sName;
      string sFullPath = Path.Combine(MFileSystem.AssetsPath, sFileName);
      AssimpContext importer = new AssimpContext();
      importer.SetConfig(new NormalSmoothingAngleConfig(35.0f));
      try
      {
        scene = importer.ImportFile(sFullPath, PostProcessSteps.Triangulate);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      m_global_inverse_transform = scene.RootNode.Transform;
      m_global_inverse_transform.Inverse();

      processNode(scene.RootNode, scene);
    }

    void processNode(Node node, Scene scene)
    {
      MAnimatedMesh mesh;
      for (int i = 0; i < scene.MeshCount; i++)
      {
        Mesh ai_mesh = scene.Meshes[i];
        mesh = processMesh(ai_mesh, scene);

        Matrix4d tr = FromMatrixd(node.Transform);
        mesh.transform.Position = tr.ExtractTranslation();
        mesh.transform.Rotation = tr.ExtractRotation();
        mesh.transform.Scale = tr.ExtractScale();
        mesh.AddMaterial(this.material);

        Meshes.Add(mesh); //accumulate all meshes in one vector
        Add(mesh);
      }
    }

    MAnimatedMesh processMesh(Mesh mesh, Scene scene)
    {
      Console.WriteLine("bones: ", mesh.BoneCount, " vertices: ", mesh.VertexCount);

      List<AnimatedVertex> vertices = new List<AnimatedVertex>();
      List<int> indices = new List<int>();

      //List<MTexture> textures = new List<MTexture>();
      VertexBoneData[] bones_id_weights_for_each_vertex = new VertexBoneData[mesh.VertexCount];
      for (int i = 0; i < bones_id_weights_for_each_vertex.Length; i++)
      {
        bones_id_weights_for_each_vertex[i].InitVertexBoneData();
      }

      //vertices
      for (int i = 0; i < mesh.VertexCount; i++)
      {
        AnimatedVertex vertex = new AnimatedVertex();
        Vector3 vector;
        vector.X = mesh.Vertices[i].X;
        vector.Y = mesh.Vertices[i].Y;
        vector.Z = mesh.Vertices[i].Z;
        vertex._position = vector;

        if (mesh.Normals != null)
        {
          vector.X = mesh.Normals[i].X;
          vector.Y = mesh.Normals[i].Y;
          vector.Z = mesh.Normals[i].Z;
          vertex._normal = vector;
        }
        else
        {
          vertex._normal = Vector3.Zero;
        }

        // in assimp model can have 8 different texture coordinates
        // we only care about the first set of texture coordinates
        if (mesh.HasTextureCoords(0))
        {
          Vector2 vec = new Vector2(0, 0);
          vec.X = mesh.TextureCoordinateChannels[0][i].X;
          vec.Y = mesh.TextureCoordinateChannels[0][i].Y;
          vertex._textureCoordinate = vec;
        }
        else
        {
          vertex._textureCoordinate = new Vector2(0.0f, 0.0f);
        }
        vertices.Add(vertex);
      }

      //int[] indices = mesh.GetIndices();

      //indices
      for (int i = 0; i < mesh.FaceCount; i++)
      {
        Face face = mesh.Faces[i];
        // retrieve all indices of the face and store them in the indices vector
        for (int j = 0; j < face.IndexCount; j++)
          indices.Add(face.Indices[j]);
      }

      //Indices = indices.ToArray();


      //material
      /*
      if (mesh.MaterialIndex >= 0)
      {
        //all pointers created in assimp will be deleted automaticaly when we call import.FreeScene();
        Material material = scene.Materials[mesh.MaterialIndex];
        List<MTexture> diffuse_maps = LoadMaterialTexture(material, aiTextureType_DIFFUSE, "texture_diffuse");
        bool exist = false;
        for (int i = 0; (i < textures.size()) && (diffuse_maps.size() != 0); i++)
        {
          if (textures[i].path == diffuse_maps[0].path) // ������ ���� �������� 1 �������� ������� � 1 ������� � ����� ����
          {
            exist = true;
          }
        }
        if (!exist && diffuse_maps.size() != 0) textures.push_back(diffuse_maps[0]); //������ �������� �� 1 �������� !!!
                                                                                     //textures.insert(textures.end(), diffuse_maps.begin(), diffuse_maps.end());

        vector<Texture> specular_maps = LoadMaterialTexture(material, aiTextureType_SPECULAR, "texture_specular");
        exist = false;
        for (int i = 0; (i < textures.size()) && (specular_maps.size() != 0); i++)
        {
          if (textures[i].path == specular_maps[0].path) // ������ ���� �������� 1 �������� ������� � 1 ������� � ����� ����
          {
            exist = true;
          }
        }
        if (!exist && specular_maps.size() != 0) textures.push_back(specular_maps[0]); //������ �������� �� 1 �������� !!!
                                                                                       //textures.insert(textures.end(), specular_maps.begin(), specular_maps.end());

      }
      */

      // Dictionary<string, uint>  m_bone_mapping = new Dictionary<string, uint>();

      // load bones
      for (int i = 0; i < mesh.BoneCount; i++)
      {
        int bone_index = 0;
        string bone_name = mesh.Bones[i].Name;

        //cout << mesh->mBones[i]->mName.data << endl;

        if (!m_bone_mapping.ContainsKey(bone_name)) // ��������� ��� �� � ������� ��������
        {
          // Allocate an index for a new bone
          bone_index = m_num_bones;
          m_num_bones++;
          BoneMatrix bi = new BoneMatrix();
          m_bone_matrices.Add(bi);


          BoneMatrix bbi = m_bone_matrices[bone_index];
          bbi.offset_matrix = mesh.Bones[i].OffsetMatrix;
          m_bone_matrices[bone_index] = bbi;
          //m_bone_matrices[bone_index]
          m_bone_mapping[bone_name] = bone_index;

          //cout << "bone_name: " << bone_name << "			 bone_index: " << bone_index << endl;
        }
        else
        {
          bone_index = m_bone_mapping[bone_name];
        }

        //bones_id_weights_for_each_vertex = new List<VertexBoneData>(mesh.Bones[i].VertexWeightCount);

        for (int j = 0; j < mesh.Bones[i].VertexWeightCount; j++)
        {
          int vertex_id = mesh.Bones[i].VertexWeights[j].VertexID; // �� ������� �� ������ ����� �������� �����
          float weight = mesh.Bones[i].VertexWeights[j].Weight;
          bones_id_weights_for_each_vertex[vertex_id].addBoneData(bone_index, weight); // � ������ ������� ����� ����� � �� ���

          // ������ ������� vertex_id �� ������ ����� � �������� bone_index  ����� ��� weight
          //cout << " vertex_id: " << vertex_id << "	bone_index: " << bone_index << "		weight: " << weight << endl;
        }
      }


      return new MAnimatedMesh(vertices, indices.ToArray(), bones_id_weights_for_each_vertex);
    }

    public override void Setup()
    {
      initShaders(material.shader.ProgramID);
      _debug = new MPhysicsDebug();
      base.Setup();
    }

    void initShaders(int shader_program)
    {
      for (uint i = 0; i < MAX_BONES; i++) // get location all matrices of bones
      {
        string name = "bones[" + i + "]";// name like in shader
        // m_bone_location[i] = GL.GetUniformLocation(shader_program, name);
      }

      // rotate head AND AXIS(y_z) about x !!!!!  Not be gimbal lock
      //rotate_head_xz *= glm::quat(cos(glm::radians(-45.0f / 2)), sin(glm::radians(-45.0f / 2)) * glm::vec3(1.0f, 0.0f, 0.0f));
    }

    void DebugBones(Matrix4d viewproj, Matrix4d parentmodel, Matrix4x4[] transforms)
    {
      if (Globals.RenderPass != Globals.eRenderPass.ShadowDepth)
      {
        GL.Clear(ClearBufferMask.DepthBufferBit);

        Vector3d v = Globals.Avatar.GetPosition();
        Vector3d v1 = Vector3d.Zero;
        Vector3d v2 = Vector3d.Zero;

        _debug.UserColorCoding = true;
        Matrix4 test = Matrix4.CreateTranslation(0, 0.5f, 0);
        float f = 0;
        for (int i = 0; i < transforms.Length; i++)
        {
          //(MBone b in Bones)

          f += 0.1f;
          v1 = v2;
          v2 = MassiveTools.Vector3dFromVector3(TKMatrix(transforms[i]).ExtractTranslation());

          Vector3d r1 = v1 + v;
          Vector3d r2 = v2 + v;
          _debug.DrawLine(ref r1, ref r2, i == 0 ? OpenTK.Graphics.Color4.Red : OpenTK.Graphics.Color4.White);
        }

        _debug.Render(viewproj, parentmodel);
      }
    }

    public override void Update()
    {
      FrameCounter += (float)Time.DeltaTime;
      if (FrameCounter > 35) FrameCounter = 0;

      base.Update();
    }

    public override void Render(Matrix4d viewproj, Matrix4d parentmodel)
    {
      material.Bind();
      Matrix4x4[] transforms = new Matrix4x4[MAX_BONES];
      for (int i = 0; i < MAX_BONES; i++)
      {
        transforms[i] = Matrix4x4.Identity;
      }
      
      CalcAnimation((int)FrameCounter, ref transforms, "Standard");

      /*
      float val1 = (float)Settings.Tweak1 * (float)Math.PI / 180.0f;
      transforms[0] = m_global_inverse_transform * Matrix4x4.FromRotationX(val1);
      float val2 = (float)Settings.Tweak2 * (float)Math.PI / 180.0f;
      transforms[1] = transforms[0] * Matrix4x4.FromRotationX(val2);
      float val3 = (float)Settings.Tweak3 * (float)Math.PI / 180.0f;
      transforms[2] = transforms[1] * transforms[0] * Matrix4x4.FromRotationX(val3);
      */

      // Matrix4[] tktransforms = new Matrix4[MAX_BONES];
      for (int i = 0; i < MAX_BONES; i++)
      {
        debug_transforms[i] = TKMatrix(transforms[i]);
      }

      CalculateDrawMatrices(viewproj, parentmodel);
      material.shader.SetMat4("mvp", mvp);
      material.shader.SetMat4("model", modelMatrix);
      material.shader.SetBool("selected", Selected);
      material.shader.SetBool("CastsShadow", CastsShadow);

      for (int i = 0; i < Meshes.Count(); i++)
      {
        MAnimatedMesh mesh = Meshes[i];
        int location = material.shader.GetLocation("bones");
        GL.UniformMatrix4(location, transforms.Length, false, ref transforms[0].A1);
        //material.shader.SetMatrices("bones", tktransforms);
        mesh.Render(viewproj, WorldTransform);
      }
      DebugBones(viewproj, WorldTransform, transforms);
      base.Render(viewproj, WorldTransform);
    }

    public void CalcAnimation(int frame, ref Matrix4x4[] mat, string sName)
    {
      Animation ani = FindAnimation(sName);

      Mesh m = scene.Meshes[0];
      Matrix4x4 parent = m_global_inverse_transform;
      for (int i = 0; i < m.BoneCount; i++)
      {
        Bone b = m.Bones[i];
        NodeAnimationChannel n = FindChannel(ani, b.Name);
        for ( int c = 0; c< n.RotationKeyCount; c++)
        {
          QuaternionKey q = n.RotationKeys[c];
          VectorKey pk = n.PositionKeys[c];
          if (frame <= q.Time) {
            mat[i] = m_global_inverse_transform* parent * (Matrix4x4)q.Value.GetMatrix() ;
            parent = mat[i];
            break;
          }
        }
      }
    }

    NodeAnimationChannel FindChannel(Animation ani, string NodeName)
    {
      for (int i = 0; i < ani.NodeAnimationChannelCount; i++)
      {
        NodeAnimationChannel n = ani.NodeAnimationChannels[i];
        if (n.NodeName == NodeName) return n;
      }
      return null;
    }

    Animation FindAnimation(string sName)
    {
      foreach (Animation ani in scene.Animations)
      {
        if (ani.Name.Contains(sName))
        {
          return ani;
        }
      }
      return null;
    }

    public static OpenTK.Matrix4 TKMatrix(Assimp.Matrix4x4 input)
    {
      return new OpenTK.Matrix4(input.A1, input.B1, input.C1, input.D1,
                                 input.A2, input.B2, input.C2, input.D2,
                                 input.A3, input.B3, input.C3, input.D3,
                                 input.A4, input.B4, input.C4, input.D4);
    }

    public static OpenTK.Matrix4d TKMatrixd(Assimp.Matrix4x4 input)
    {
      return new OpenTK.Matrix4d(input.A1, input.B1, input.C1, input.D1,
                                 input.A2, input.B2, input.C2, input.D2,
                                 input.A3, input.B3, input.C3, input.D3,
                                 input.A4, input.B4, input.C4, input.D4);
    }


    private Matrix4d FromMatrixd(Matrix4x4 mat)
    {
      Matrix4d m = new Matrix4d();
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

    Assimp.Quaternion nlerp(Assimp.Quaternion a, Assimp.Quaternion b, float blend)
    {
      //cout << a.w + a.x + a.y + a.z << endl;
      a.Normalize();
      b.Normalize();

      Assimp.Quaternion result;
      float dot_product = a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
      float one_minus_blend = 1.0f - blend;

      if (dot_product < 0.0f)
      {
        result.X = a.X * one_minus_blend + blend * -b.X;
        result.Y = a.Y * one_minus_blend + blend * -b.Y;
        result.Z = a.Z * one_minus_blend + blend * -b.Z;
        result.W = a.W * one_minus_blend + blend * -b.W;
      }
      else
      {
        result.X = a.X * one_minus_blend + blend * b.X;
        result.Y = a.Y * one_minus_blend + blend * b.Y;
        result.Z = a.Z * one_minus_blend + blend * b.Z;
        result.W = a.W * one_minus_blend + blend * b.W;
      }
      result.Normalize();
      return result;
    }
  }
}
