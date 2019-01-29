#version 430 core
layout(location = 0) in vec4 aPos;
layout(location = 1) in vec3 aNormal;
layout(location = 2) in vec2 aTexCoords;
layout(location = 3) in mat4 offset;
//4  taken up by mat4
//5  taken up by mat4
//6  taken up by mat4

//out vec2 TexCoords;
out vec3 vPos;

out VS_OUT{
	vec3 FragPos;
vec3 Normal;
vec2 TexCoords;
vec4 FragPosLightSpace;
} vs_out;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;
uniform mat4 lightSpaceMatrix;

uniform mat4 mvp;
uniform int Closeup = 0;
//uniform float  Fcoef = 2.0 / log2(farplane + 1.0);

float Fcoef = 0.001;
//gl_Position.z = log2(max(1e-6, 1.0 + gl_Position.w)) * Fcoef - 1.0;

void main()
{
	vs_out.FragPos = aPos.xyz;
	//account for scaling    
	vs_out.Normal = aNormal;
	vs_out.TexCoords = aTexCoords;
	vs_out.FragPosLightSpace = lightSpaceMatrix * vec4(vs_out.FragPos, 1.0);

	gl_Position =  mvp * offset * aPos ;

	if (Closeup == 0) {
		//gl_Position.z = log2(max(1e-6, 1.0 + gl_Position.w)) * Fcoef - 1.0;	
	}
}


