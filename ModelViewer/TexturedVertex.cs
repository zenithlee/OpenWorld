using OpenTK;

public struct TexturedVertex
{
  public const int Size = (4 + 2) * 4; // size of struct in bytes

  public Vector4 _position;
  public Vector2 _textureCoordinate;

  public TexturedVertex(Vector4 position, Vector2 textureCoordinate)
  {
    _position = position;
    _textureCoordinate = textureCoordinate;
  }

}