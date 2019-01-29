#version 450 core
#extension GL_ARB_gpu_shader_fp64 : enable
#extension GL_ARB_vertex_attrib_64bit : enable

layout (location = 0) in highp vec4 position;
layout (location = 1) in vec2 textureCoordinate;
layout (location = 2) in vec3 vertNormal;

layout (location = 10) uniform vec3 lightColor;

out vec2 vs_textureCoordinate;
out vec3 fragNormal;
out vec3 vs_lightColor;


//layout(location = 20) uniform  mat4 projection;
layout (location = 21) uniform  mat4 modelView;

void main(void)
{
	//gl_Position = projection * modelView * vec4(position.xyz,1);	
	gl_Position = modelView * position ;
	vs_textureCoordinate = textureCoordinate;	
	fragNormal = vertNormal;
                //fragNormal = vec3(1,1,0);
	vs_lightColor = lightColor;
}