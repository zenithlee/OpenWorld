

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assimp;
using Assimp.Configs;
using Massive;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Massive
{

  public struct VertexBoneData
  {
    const int NUM_BONES_PER_VEREX = 4;
    public const int Size = (4 + 4);
    int[] ids;
    float[] weights;

    //public VertexBoneData()
    //{
//      ids = new uint[NUM_BONES_PER_VEREX];   // we have 4 bone ids for EACH vertex & 4 weights for EACH vertex
  //    weights = new float[NUM_BONES_PER_VEREX];      
//    }

    public void AddBoneData(int bone_id, float weight)
    {

    }
  };

  public class BoneMatrix
  {
    public Matrix4x4 offset_matrix;
    public Matrix4x4 final_world_transform;
  };

  class MSimpleBoned
  {
    AssimpContext import;
    Scene scene;
    Matrix4x4 m_global_inverse_transform;
    double ticks_per_second = 0.0f;
    string directory;
    List<MSimpleMesh> meshes; // one mesh in one object
    List<VertexBoneData> bones_id_weights_for_each_vertex;
    Dictionary<string, int> m_bone_mapping; // maps a bone name and their index
    int m_num_bones = 0;
    List<BoneMatrix> m_bone_matrices;

    public void loadModel(string path)
    {
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
      AssimpContext import = new AssimpContext();
      import.SetConfig(new NormalSmoothingAngleConfig(35.0f));

      scene = import.ImportFile(path, PostProcessSteps.Triangulate | PostProcessSteps.FlipUVs);

      if (scene == null || scene.SceneFlags == SceneFlags.Incomplete || scene.RootNode == null)
      {
        Console.WriteLine("ASSIMP ERROR in MSimpleBoned");
        return;
      }
      m_global_inverse_transform = scene.RootNode.Transform;
      m_global_inverse_transform.Inverse();

      if (scene.Animations[0].TicksPerSecond != 0.0)
      {
        ticks_per_second = scene.Animations[0].TicksPerSecond;
      }
      else
      {
        ticks_per_second = 25.0f;
      }

      // directoru = container for model.obj and textures and other files
      directory = path.Substring(0, path.LastIndexOf('/'));

      //cout << "scene->HasAnimations() 1: " << scene->HasAnimations() << endl;
      //cout << "scene->mNumMeshes 1: " << scene->mNumMeshes << endl;
      //cout << "scene->mAnimations[0]->mNumChannels 1: " << scene->mAnimations[0]->mNumChannels << endl;
      //cout << "scene->mAnimations[0]->mDuration 1: " << scene->mAnimations[0]->mDuration << endl;
      //cout << "scene->mAnimations[0]->mTicksPerSecond 1: " << scene->mAnimations[0]->mTicksPerSecond << endl << endl;

      //cout << "		name nodes : " << endl;
      showNodeName(scene.RootNode);
      //cout << endl;

      //cout << "		name bones : " << endl;
      processNode(scene.RootNode, scene);

      //cout << "		name nodes animation : " << endl;
      for (int i = 0; i < scene.Animations[0].NodeAnimationChannelCount; i++)
      {
        //cout << scene->mAnimations[0]->mChannels[i]->mNodeName.C_Str() << endl;
        Console.WriteLine(scene.Animations[0].NodeAnimationChannels[i].NodeName);
      }
      //cout << endl;
    }

    void processNode(Node node, Scene scene)
    {

      MSimpleMesh mesh;
      for (int i = 0; i < scene.MeshCount; i++)
      {
        Mesh ai_mesh = scene.Meshes[i];
        mesh = processMesh(ai_mesh, scene);
        meshes.Add(mesh); //accumulate all meshes in one vector
      }
    }

    MSimpleMesh processMesh(Mesh mesh, Scene scene)
    {

      Console.WriteLine("bones: " + mesh.BoneCount + " vertices: " + mesh.VertexCount);

      List<TexturedVertex> vertices;
      List<int> indices;
      List<MTexture> textures = new List<MTexture>();
      List<VertexBoneData> bones_id_weights_for_each_vertex;

      //size � resize - ����� �� ������ � �������� ������ ��������� �������
      //capacity � reserve - �� ������ � �����.
      //size - ������ ���������� ��������� � �������
      //resize - ������� ���������� ��������� � �������
      //capacity - ������ ��� ������� ��������� �������� �����
      //reserve - ���������� �����

      vertices = new List<TexturedVertex>(mesh.VertexCount); // ������ ������� ����� ��� ������������� !!! ��������� �������
      indices = new List<int>(mesh.VertexCount); // ������ ���� ����� ����� vector.push_back(i);

      // .resize(n) == ����� ������ ������� � �������������� !!!! ��� ����������� ��������� ���� ������ ���� ������ 
      // ������ � �� processMesh(....) ����� ����� ��������� ��() �� ��������� �������
      // ������� ��� �������� ���� ���������������� ����� ( ��� ����� �� ������� �������� vector.push_back(i); ����� �������������� �������� )
      bones_id_weights_for_each_vertex = new List<VertexBoneData>(mesh.VertexCount);

      //vertices
      for (int i = 0; i < mesh.VertexCount; i++)
      {
        TexturedVertex vertex = new TexturedVertex();
        Vector3 vector = new Vector3();
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
          Vector2 vec = new Vector2();
          vec.X = mesh.TextureCoordinateChannels[0][i].X;
          vec.Y = mesh.TextureCoordinateChannels[0][i].Y;
          vertex._textureCoordinate = vec;
        }
        else
        {
          vertex._textureCoordinate = Vector2.Zero;
        }
        vertices.Add(vertex);
      }

      //indices
      for (int i = 0; i < mesh.FaceCount; i++)
      {
        Face face = mesh.Faces[i]; // ������� ������ � ����� ��������� ������� �� ���������� �����
        indices.Add(face.Indices[0]); // ������� ������� � ���� ����� � �������� ������� ����� ������� 
        indices.Add(face.Indices[1]); // �� ����� ����� (� ����� ����� ������� � �� ������� �������� � ������)
        indices.Add(face.Indices[2]);
      }

      //material
      if (mesh.MaterialIndex >= 0)
      {
        //all pointers created in assimp will be deleted automaticaly when we call import.FreeScene();
        Material material = scene.Materials[mesh.MaterialIndex];
        List<MTexture> diffuse_maps = LoadMaterialTexture(material, TextureType.Diffuse, "texture_diffuse");
        bool exist = false;
        for (int i = 0; (i < textures.Count) && (diffuse_maps.Count != 0); i++)
        {
          if (textures[i].Filename == diffuse_maps[0].Filename) // ������ ���� �������� 1 �������� ������� � 1 ������� � ����� ����
          {
            exist = true;
          }
        }
        if (!exist && diffuse_maps.Count != 0) textures.Add(diffuse_maps[0]); //������ �������� �� 1 �������� !!!
                                                                                     //textures.insert(textures.end(), diffuse_maps.begin(), diffuse_maps.end());

        List<MTexture> specular_maps = LoadMaterialTexture(material, TextureType.Specular, "texture_specular");
        exist = false;
        for (int i = 0; (i < textures.Count) && (specular_maps.Count != 0); i++)
        {
          if (textures[i].Filename == specular_maps[0].Filename) // ������ ���� �������� 1 �������� ������� � 1 ������� � ����� ����
          {
            exist = true;
          }
        }
        if (!exist && specular_maps.Count != 0) textures.Add(specular_maps[0]); //������ �������� �� 1 �������� !!!
                                                                                       //textures.insert(textures.end(), specular_maps.begin(), specular_maps.end());

      }

      // load bones
      for (int i = 0; i < mesh.BoneCount; i++)
      {
        int bone_index = 0;
        string bone_name = mesh.Bones[i].Name;

        Console.WriteLine(mesh.Bones[i].Name);

        if (!m_bone_mapping.ContainsKey(bone_name)) // ��������� ��� �� � ������� ��������
        {
          // Allocate an index for a new bone
          bone_index = m_num_bones;
          m_num_bones++;
          BoneMatrix bi = new BoneMatrix();
          m_bone_matrices.Add(bi);
          m_bone_matrices[bone_index].offset_matrix = mesh.Bones[i].OffsetMatrix;
          m_bone_mapping[bone_name] = bone_index;

          //cout << "bone_name: " << bone_name << "			 bone_index: " << bone_index << endl;
        }
        else
        {
          bone_index = m_bone_mapping[bone_name];
        }

        for (int j = 0; j < mesh.Bones[i].VertexWeightCount; j++)
        {
          int vertex_id = mesh.Bones[i].VertexWeights[j].VertexID; // �� ������� �� ������ ����� �������� �����
          float weight = mesh.Bones[i].VertexWeights[j].Weight;
          bones_id_weights_for_each_vertex[vertex_id].AddBoneData(bone_index, weight); // � ������ ������� ����� ����� � �� ���

          // ������ ������� vertex_id �� ������ ����� � �������� bone_index  ����� ��� weight
          //cout << " vertex_id: " << vertex_id << "	bone_index: " << bone_index << "		weight: " << weight << endl;
        }
      }

      return new MSimpleMesh(vertices, indices, textures, bones_id_weights_for_each_vertex);
    }

    List<MTexture> LoadMaterialTexture(Material mat, TextureType type, string type_name)
    {
      List<MTexture> textures = new List<MTexture>();
      for (int i = 0; i < mat.GetMaterialTextureCount(type); i++)
      {
        String ai_str;
        TextureSlot slot;
        mat.GetMaterialTexture(type, i, out slot);

        string filename = slot.FilePath;
        filename = directory + '/' + filename;

        //cout << filename << endl;

        MTexture texture = new MTexture(slot.FilePath);
        //texture.id = Triangle::loadImageToTexture(filename); // return prepaired openGL texture
        //texture.ty= type_name;
        //texture.path = ai_str;
        texture.Filename = slot.FilePath;
        textures.Add(texture);
      }
      return textures;
    }

    void showNodeName(Node node)
    {
      Console.WriteLine(node.Name);
      for (int i = 0; i < node.ChildCount; i++)
      {
        showNodeName(node.Children[i]);
      }
    }

  }
}
