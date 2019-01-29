#version 450 core
layout (location = 0) in vec3 Pos;
layout (location = 1) in vec3 Normal;
layout (location = 2) in vec2 TexCoord;

out vec2 vs_textureCoordinate;

layout (location = 20) uniform  mat4 model;
layout (location = 21) uniform  mat4 mvp;

void main(void)
{
	gl_Position =   mvp* vec4(Pos,1) ;
	vs_textureCoordinate = TexCoord;	
}