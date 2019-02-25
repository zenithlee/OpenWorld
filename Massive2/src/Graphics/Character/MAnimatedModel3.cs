using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using Assimp;
using System.IO;
using Massive.Platform;
using Assimp.Configs;
using OpenTK;

namespace Massive2.Graphics.Character
{
  public class MAnimatedModel3 : MSceneObject
  {
    const uint MAX_BONES = 100;
    int[] m_bone_location;
    float ticks_per_second = 0.0f;
    List<MAnimatedMesh> meshes; // one mesh in one object
    Dictionary<string, uint> m_bone_mapping; // maps a bone name and their index
    uint m_num_bones = 0;
    List<BoneMatrix> m_bone_matrices;
    Matrix4x4 m_global_inverse_transform;    
    Scene scene;

    int FrameCurrent = 0;

    public MAnimatedModel3(MObject.EType type, string sName) :
      base(EType.AnimatedModel, "AnimatedModel")
    {
      m_bone_location = new int[MAX_BONES];
      meshes = new List<MAnimatedMesh>();
    }

    public override void CopyTo(MObject m1)
    {
      base.CopyTo(m1);
      MAnimatedModel3 an = (MAnimatedModel3)m1;
      if (an != null)
      {
        an.Vertices = Vertices;
        an.VerticesLength = VerticesLength;
        an.Indices = Indices;
        an.IndicesLength = IndicesLength;
        //an.sFileName = sFileName;
        //an.m_sceneCenter = m_sceneCenter;
        //an.m_sceneMax = m_sceneMax;
        //an.m_sceneMin = m_sceneMin;
        an.VAO = VAO;
        an.VBO = VBO;
        an.EBO = EBO;
        an.material = material;

        an.ticks_per_second = ticks_per_second;
        an.m_bone_location = m_bone_location;
        an.m_bone_mapping = m_bone_mapping;
        an.m_num_bones = m_num_bones;
        an.meshes = meshes;
        an.m_bone_matrices = m_bone_matrices;
        an.m_global_inverse_transform = m_global_inverse_transform;

        //an.bonemats = bonemats;
        //an.animationPoses = animationPoses;
        //an.FrameTimer = FrameTimer;
        //an._geomShader = _geomShader;
        //an._debug = _debug;
        //an.Bones = Bones;
        //an.GlobalInverseTransform = GlobalInverseTransform;
        an.scene = scene;
      }

    }

    void initShaders(int shader_program)
    {
      for (uint i = 0; i < MAX_BONES; i++) // get location all matrices of bones
      {
        string name = "bones[" + i + "]";// name like in shader
        m_bone_location[i] = GL.GetUniformLocation(shader_program, name);
      }

      // rotate head AND AXIS(y_z) about x !!!!!  Not be gimbal lock
      //rotate_head_xz *= glm::quat(cos(glm::radians(-45.0f / 2)), sin(glm::radians(-45.0f / 2)) * glm::vec3(1.0f, 0.0f, 0.0f));
    }

    void Update()
    {
      /*
      // making new quaternions for rotate head
      if (InputHandler::Instance()->isKeyDown(SDL_SCANCODE_1))
      {
        rotate_head_xz *= glm::quat(cos(glm::radians(1.0f / 2)), sin(glm::radians(1.0f / 2)) * glm::vec3(1.0f, 0.0f, 0.0f));
      }

      if (InputHandler::Instance()->isKeyDown(SDL_SCANCODE_2))
      {
        rotate_head_xz *= glm::quat(cos(glm::radians(-1.0f / 2)), sin(glm::radians(-1.0f / 2)) * glm::vec3(1.0f, 0.0f, 0.0f));
      }

      if (InputHandler::Instance()->isKeyDown(SDL_SCANCODE_3))
      {
        rotate_head_xz *= glm::quat(cos(glm::radians(1.0f / 2)), sin(glm::radians(1.0f / 2)) * glm::vec3(0.0f, 0.0f, 1.0f));
      }

      if (InputHandler::Instance()->isKeyDown(SDL_SCANCODE_4))
      {
        rotate_head_xz *= glm::quat(cos(glm::radians(-1.0f / 2)), sin(glm::radians(-1.0f / 2)) * glm::vec3(0.0f, 0.0f, 1.0f));
      }
      */
    }

    void Draw(int shaders_program)
    {
      List<Matrix4x4> transforms = new List<Matrix4x4>();

      boneTransform((double)FrameCurrent, out transforms);

      Matrix4x4[] atransforms = transforms.ToArray();
      for (uint i = 0; i < transforms.Count(); i++) // move all matrices for actual model position to shader
      {
        GL.UniformMatrix4(m_bone_location[i], 1, true, ref atransforms[0].A1);
      }

      for (int i = 0; i < meshes.Count(); i++)
      {
        //meshes[i].Draw(shaders_program);
      }
    }

    public override void Render(Matrix4d viewproj, Matrix4d parentmodel)
    {
      this.material.Bind();
      Draw(material.shader.ProgramID);
      //base.Render(viewproj, parentmodel);
    }

    public override void Setup()
    {
      
      MMaterial mat = new MMaterial("AnimatedMaterial");
      MScene.MaterialRoot.Add(mat);
      MShader shade = new MShader("AnimatedShader");

      string sVertFile = "Animation\\animated_vs.glsl";
      string sFragPath = "Animation\\animated_fs.glsl";
      shade.Load(sVertFile, sFragPath, "", "");
      shade.Compile();

      this.SetMaterial(mat);
      mat.AddShader(shade);

      initShaders(shade.ProgramID);
    }


    public void Load(string inFilename)
    {
      string sFileName = inFilename;
      string sFullPath = Path.Combine(MFileSystem.AssetsPath, sFileName);

      // how work skeletal animation in assimp //translated with google =) :
      // node is a separate part of the loaded model (the model is not only a character)
      // for example, the camera, armature, cube, light source, part of the character's body (leg, rug, head).
      // a bone can be attached to the node
      // in the bone there is an array of vertices on which the bone affects (weights from 0 to 1).
      // each mChannels is one aiNodeAnim.
      // In aiNodeAnim accumulated transformations (scaling rotate translate) for the bone with which they have the common name
      // these transformations will change those vertices whose IDs are in the bone with a force equal to the weight.
      // the bone simply contains the ID and the weight of the vertices to which the transformation from aiNodeAnim is moving (with no common name for the bone)
      // (the vertex array and the weight of the transforms for each vertex are in each bone)

      // result: a specific transformation will affect a particular vertex with a certain force.
      AssimpContext importer = new AssimpContext();
      importer.SetConfig(new NormalSmoothingAngleConfig(35.0f));
      scene = importer.ImportFile(sFullPath, PostProcessSteps.Triangulate | PostProcessSteps.FlipUVs);

      m_global_inverse_transform = scene.RootNode.Transform;
      m_global_inverse_transform.Inverse();

      if (scene.Animations[0].TicksPerSecond != 0.0)
      {
        ticks_per_second = (float)scene.Animations[0].TicksPerSecond;
      }
      else
      {
        ticks_per_second = 25.0f;
      }

      showNodeName(scene.RootNode);
      processNode(scene.RootNode, scene);

      for (int i = 0; i < scene.Animations[0].NodeAnimationChannelCount; i++)
      {
        Console.WriteLine(scene.Animations[0].NodeAnimationChannels[i].NodeName);
      }
    }

    void showNodeName(Node node)
    {
      Console.WriteLine(node.Name);
      for (int i = 0; i < node.ChildCount; i++)
      {
        showNodeName(node.Children[i]);
      }
    }

    void processNode(Node node, Scene scene)
    {
      MAnimatedMesh mesh;
      for (int i = 0; i < scene.MeshCount; i++)
      {
        Mesh ai_mesh = scene.Meshes[i];
        mesh = processMesh(ai_mesh, scene);
        meshes.Add(mesh); //accumulate all meshes in one vector
      }

    }

    MAnimatedMesh processMesh(Mesh mesh, Scene scene)
    {
      Console.WriteLine("bones: ", mesh.BoneCount, " vertices: ", mesh.VertexCount);

      List<AnimatedVertex> vertices = new List<AnimatedVertex>();
      
      List<MTexture> textures = new List<MTexture>();
      VertexBoneData[] bones_id_weights_for_each_vertex = new VertexBoneData[mesh.VertexCount];


      //    vertices.reserve(mesh->mNumVertices); // ������ ������� ����� ��� ������������� !!! ��������� �������
      //  indices.reserve(mesh->mNumVertices); // ������ ���� ����� ����� vector.push_back(i);

      // .resize(n) == ����� ������ ������� � �������������� !!!! ��� ����������� ��������� ���� ������ ���� ������ 
      // ������ � �� processMesh(....) ����� ����� ��������� ��() �� ��������� �������
      // ������� ��� �������� ���� ���������������� ����� ( ��� ����� �� ������� �������� vector.push_back(i); ����� �������������� �������� )
      //bones_id_weights_for_each_vertex.siz.resize(mesh->mNumVertices);

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
        if (mesh.TextureCoordinateChannels[0] != null)
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

      int[] indices = mesh.GetIndices();
      /*
      //indices
      for (int i = 0; i < mesh.FaceCount; i++)
      {
        Face face = mesh.Faces[i]; // ������� ������ � ����� ��������� ������� �� ���������� �����
        indices.Add(face.Indices[0]); // ������� ������� � ���� ����� � �������� ������� ����� ������� 
        indices.Add(face.Indices[1]); // �� ����� ����� (� ����� ����� ������� � �� ������� �������� � ������)
        indices.Add(face.Indices[2]);
      }
      */

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
      m_bone_mapping = new Dictionary<string, uint>();
      m_bone_matrices = new List<BoneMatrix>();
      // load bones
      for (int i = 0; i < mesh.BoneCount; i++)
      {
        uint bone_index = 0;
        string bone_name = mesh.Bones[i].Name;

        //cout << mesh->mBones[i]->mName.data << endl;

        if (!m_bone_mapping.ContainsKey(bone_name)) // ��������� ��� �� � ������� ��������
        {
          // Allocate an index for a new bone
          bone_index = m_num_bones;
          m_num_bones++;
          BoneMatrix bi = new BoneMatrix();
          m_bone_matrices.Add(bi);


          BoneMatrix bbi = m_bone_matrices[(int)bone_index];
          bbi.offset_matrix = mesh.Bones[i].OffsetMatrix;
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

          bones_id_weights_for_each_vertex[vertex_id].InitVertexBoneData();
          bones_id_weights_for_each_vertex[vertex_id].addBoneData(bone_index, weight); // � ������ ������� ����� ����� � �� ���
          
          // ������ ������� vertex_id �� ������ ����� � �������� bone_index  ����� ��� weight
          //cout << " vertex_id: " << vertex_id << "	bone_index: " << bone_index << "		weight: " << weight << endl;
        }
      }

      return new MAnimatedMesh(vertices, indices, bones_id_weights_for_each_vertex);
    }

    /*
    List<MTexture> Model::LoadMaterialTexture(aiMaterial* mat, aiTextureType type, string type_name)
    {
      vector<Texture> textures;
      for (uint i = 0; i < mat->GetTextureCount(type); i++)
      {
        aiString ai_str;
        mat->GetTexture(type, i, &ai_str);

        string filename = string(ai_str.C_Str());
        filename = directory + '/' + filename;

        //cout << filename << endl;

        Texture texture;
        texture.id = Triangle::loadImageToTexture(filename.c_str()); // return prepaired openGL texture
        texture.type = type_name;
        texture.path = ai_str;
        textures.push_back(texture);
      }
      return textures;
    }
    */

    int findPosition(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      // ����� ���� ������� ����� ����� ����� ������� ���������� ����� ������ ��������
      for (int i = 0; i < p_node_anim.PositionKeyCount - 1; i++) // �������� ����� ��������
      {
        if (p_animation_time < (float)p_node_anim.PositionKeys[i + 1].Time) // �������� �� �������� ��������� !!!
        {
          return i; // �� ������� ������ �������� !!!!!!!!!!!!!!!!!! ����������������������������
        }
      }

      //assert(0);
      return 0;
    }

    int findRotation(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      // ����� ���� ������� ����� ����� ����� ������� ���������� ����� ������ ��������
      for (int i = 0; i < p_node_anim.RotationKeyCount - 1; i++) // �������� ����� ��������
      {
        if (p_animation_time < (float)p_node_anim.RotationKeys[i + 1].Time) // �������� �� �������� ��������� !!!
        {
          return i; // �� ������� ������ �������� !!!!!!!!!!!!!!!!!! ����������������������������
        }
      }

      //assert(0);
      return 0;
    }

    int findScaling(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      // ����� ���� ������� ����� ����� ����� ������� ���������� ����� ������ ��������
      for (int i = 0; i < p_node_anim.ScalingKeyCount - 1; i++) // �������� ����� ��������
      {
        if (p_animation_time < (float)p_node_anim.ScalingKeys[i + 1].Time) // �������� �� �������� ��������� !!!
        {
          return i; // �� ������� ������ �������� !!!!!!!!!!!!!!!!!! ����������������������������
        }
      }

      //assert(0);
      return 0;
    }

    Vector3D calcInterpolatedPosition(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      if (p_node_anim.PositionKeyCount == 1) // Keys ��� ������� �����
      {
        return p_node_anim.PositionKeys[0].Value;
      }

      int position_index = findPosition(p_animation_time, p_node_anim); // ������ ������ �������� ����� ������� ������
      int next_position_index = position_index + 1; // ������ ��������� �������� �����
                                                    //assert(next_position_index<p_node_anim->mNumPositionKeys);
                                                    // ���� ����� �������
      float delta_time = (float)(p_node_anim.PositionKeys[next_position_index].Time
            - p_node_anim.PositionKeys[position_index].Time);
      // ������ = (���� ������� ������ �� ������ �������� ��������� �����) / �� ���� ����� �������
      float factor = (p_animation_time - (float)p_node_anim.PositionKeys[position_index].Time) / delta_time;
      //assert(factor >= 0.0f && factor <= 1.0f);
      Vector3D start = p_node_anim.PositionKeys[position_index].Value;
      Vector3D end = p_node_anim.PositionKeys[next_position_index].Value;
      Vector3D delta = end - start;

      return start + factor * delta;
    }

    Assimp.Quaternion calcInterpolatedRotation(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      if (p_node_anim.RotationKeyCount == 1) // Keys ��� ������� �����
      {
        return p_node_anim.RotationKeys[0].Value;
      }

      int rotation_index = findRotation(p_animation_time, p_node_anim); // ������ ������ �������� ����� ������� ������
      int next_rotation_index = rotation_index + 1; // ������ ��������� �������� �����
                                                    //assert(next_rotation_index<p_node_anim->mNumRotationKeys);
                                                    // ���� ����� �������
      float delta_time = (float)(p_node_anim.RotationKeys[next_rotation_index].Time
            - p_node_anim.RotationKeys[rotation_index].Time);
      // ������ = (���� ������� ������ �� ������ �������� ��������� �����) / �� ���� ����� �������
      float factor = (p_animation_time - (float)p_node_anim.RotationKeys[rotation_index].Time) / delta_time;

      //cout << "p_node_anim->mRotationKeys[rotation_index].mTime: " << p_node_anim->mRotationKeys[rotation_index].mTime << endl;
      //cout << "p_node_anim->mRotationKeys[next_rotaion_index].mTime: " << p_node_anim->mRotationKeys[next_rotation_index].mTime << endl;
      //cout << "delta_time: " << delta_time << endl;
      //cout << "animation_time: " << p_animation_time << endl;
      //cout << "animation_time - mRotationKeys[rotation_index].mTime: " << (p_animation_time - (float)p_node_anim->mRotationKeys[rotation_index].mTime) << endl;
      //cout << "factor: " << factor << endl << endl << endl;

      //assert(factor >= 0.0f && factor <= 1.0f);
      Assimp.Quaternion start_quat = p_node_anim.RotationKeys[rotation_index].Value;
      Assimp.Quaternion end_quat = p_node_anim.RotationKeys[next_rotation_index].Value;

      return nlerp(start_quat, end_quat, factor);
    }

    Vector3D calcInterpolatedScaling(float p_animation_time, NodeAnimationChannel p_node_anim)
    {
      if (p_node_anim.ScalingKeyCount == 1) // Keys ��� ������� �����
      {
        return p_node_anim.ScalingKeys[0].Value;
      }

      int scaling_index = findScaling(p_animation_time, p_node_anim); // ������ ������ �������� ����� ������� ������
      int next_scaling_index = scaling_index + 1; // ������ ��������� �������� �����
                                                  //assert(next_scaling_index<p_node_anim->mNumScalingKeys);
                                                  // ���� ����� �������
      float delta_time = (float)(p_node_anim.ScalingKeys[next_scaling_index].Time
            - p_node_anim.ScalingKeys[scaling_index].Time);
      // ������ = (���� ������� ������ �� ������ �������� ��������� �����) / �� ���� ����� �������
      float factor = (p_animation_time - (float)p_node_anim.ScalingKeys[scaling_index].Time) / delta_time;
      //assert(factor >= 0.0f && factor <= 1.0f);
      Vector3D start = p_node_anim.ScalingKeys[scaling_index].Value;
      Vector3D end = p_node_anim.ScalingKeys[next_scaling_index].Value;
      Vector3D delta = end - start;

      return start + factor * delta;
    }

    NodeAnimationChannel findNodeAnim(Animation p_animation, string p_node_name)
    {
      // channel in animation contains aiNodeAnim (aiNodeAnim its transformation for bones)
      // numChannels == numBones
      for (int i = 0; i < p_animation.NodeAnimationChannelCount; i++)
      {
        NodeAnimationChannel node_anim = p_animation.NodeAnimationChannels[i]; // ��������� ������� ������ node
        if (node_anim.NodeName == p_node_name)
        {
          return node_anim;// ���� ����� �������� �� ������� ����� (� ������� ����������� node) ������������ ���� node_anim
        }
      }

      return null;
    }
    // start from RootNode
    void readNodeHierarchy(float p_animation_time, Node p_node, Matrix4x4 parent_transform)
    {

      string node_name = p_node.Name;

      //������� node, �� ������� ������������ �������, ������������� �������� ���� ������(aiNodeAnim).
      Animation animation = scene.Animations[0];
      Matrix4x4 node_transform = p_node.Transform;

      NodeAnimationChannel node_anim = findNodeAnim(animation, node_name); // ����� ������� �� ����� ����

      if (node_anim != null)
      {

        //scaling
        //aiVector3D scaling_vector = node_anim->mScalingKeys[2].mValue;
        Vector3D scaling_vector = calcInterpolatedScaling(p_animation_time, node_anim);
        Matrix4x4 scaling_matr = Matrix4x4.FromScaling(scaling_vector);

        //rotation
        //aiQuaternion rotate_quat = node_anim->mRotationKeys[2].mValue;
        Assimp.Quaternion rotate_quat = calcInterpolatedRotation(p_animation_time, node_anim);
        Matrix4x4 rotate_matr = new Matrix4x4(rotate_quat.GetMatrix());

        //translation
        //aiVector3D translate_vector = node_anim->mPositionKeys[2].mValue;
        Vector3D translate_vector = calcInterpolatedPosition(p_animation_time, node_anim);
        Matrix4x4 translate_matr = Matrix4x4.FromTranslation(translate_vector); ;

        if (node_anim.NodeName == "Head")
        {
          //Quaternion rotate_head = new Quaternion(rotate_head_xz.w, rotate_head_xz.x, rotate_head_xz.y, rotate_head_xz.z);

          //node_transform = translate_matr * (rotate_matr * aiMatrix4x4(rotate_head.GetMatrix())) * scaling_matr;
        }
        else
        {
          node_transform = translate_matr * rotate_matr * scaling_matr;
        }

      }

      Matrix4x4 global_transform = parent_transform * node_transform;

      // ���� � node �� �������� ����������� bone, �� �� node ������ ��������� � ������ bone !!!
      if (m_bone_mapping.ContainsKey(node_name)) // true if node_name exist in bone_mapping
      {
        uint bone_index = m_bone_mapping[node_name];
        BoneMatrix bmi = m_bone_matrices[(int)bone_index];
        bmi.final_world_transform =
        //m_bone_matrices[bone_index].final_world_transform = 
          m_global_inverse_transform * global_transform * m_bone_matrices[(int)bone_index].offset_matrix;
      }

      for (int i = 0; i < p_node.ChildCount; i++)
      {
        readNodeHierarchy(p_animation_time, p_node.Children[i], global_transform);
      }

    }

    void boneTransform(double time_in_sec, out List<Matrix4x4> transforms)
    {
      Matrix4x4 identity_matrix = Matrix4x4.Identity; // = mat4(1.0f);

      double time_in_ticks = time_in_sec * ticks_per_second;
      //float animation_time = (float)(time_in_ticks % scene.Animations[0].DurationInTicks); //������� �� ����� (������� �� ������)
      // animation_time - ���� ������� ������ � ���� ������ �� ������ �������� (�� ������� �������� ����� � �������� )
      float animation_time = FrameCurrent;
      FrameCurrent++;
      if (FrameCurrent > 25) FrameCurrent = 0;

      readNodeHierarchy(animation_time, scene.RootNode, identity_matrix);

      transforms = new List<Matrix4x4>();
      for( int c = 0; c< m_num_bones; c++)
      {
        transforms.Add(new Matrix4x4());
      }

      for (int i = 0; i < m_num_bones; i++)
      {
        transforms[i] = m_bone_matrices[i].final_world_transform;
      }
    }

    Matrix4 aiToGlm(Matrix4x4 mat)
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
      /*
      glm::mat4 result;
      result[0].x = ai_matr.a1; result[0].y = ai_matr.b1; result[0].z = ai_matr.c1; result[0].w = ai_matr.d1;
      result[1].x = ai_matr.a2; result[1].y = ai_matr.b2; result[1].z = ai_matr.c2; result[1].w = ai_matr.d2;
      result[2].x = ai_matr.a3; result[2].y = ai_matr.b3; result[2].z = ai_matr.c3; result[2].w = ai_matr.d3;
      result[3].x = ai_matr.a4; result[3].y = ai_matr.b4; result[3].z = ai_matr.c4; result[3].w = ai_matr.d4;
      */

      //cout << " " << result[0].x << "		 " << result[0].y << "		 " << result[0].z << "		 " << result[0].w << endl;
      //cout << " " << result[1].x << "		 " << result[1].y << "		 " << result[1].z << "		 " << result[1].w << endl;
      //cout << " " << result[2].x << "		 " << result[2].y << "		 " << result[2].z << "		 " << result[2].w << endl;
      //cout << " " << result[3].x << "		 " << result[3].y << "		 " << result[3].z << "		 " << result[3].w << endl;
      //cout << endl;

      //cout << " " << ai_matr.a1 << "		 " << ai_matr.b1 << "		 " << ai_matr.c1 << "		 " << ai_matr.d1 << endl;
      //cout << " " << ai_matr.a2 << "		 " << ai_matr.b2 << "		 " << ai_matr.c2 << "		 " << ai_matr.d2 << endl;
      //cout << " " << ai_matr.a3 << "		 " << ai_matr.b3 << "		 " << ai_matr.c3 << "		 " << ai_matr.d3 << endl;
      //cout << " " << ai_matr.a4 << "		 " << ai_matr.b4 << "		 " << ai_matr.c4 << "		 " << ai_matr.d4 << endl;
      //cout << endl;

      // return result;
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
