#version 450 core

layout (location = 0) in vec4 position;
layout (location = 1) in vec2 textureCoordinate;

out vec2 vs_textureCoordinate;

layout (location = 21) uniform  mat4 modelView;

void main(void)
{
	gl_Position = modelView * position;	
	vs_textureCoordinate = textureCoordinate;	
}