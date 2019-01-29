#version 430 core
out vec4 FragColor;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
    vec4 FragPosLightSpace;
} fs_in;


struct Material {
    sampler2D diffuse;
    sampler2D specular;
	sampler2D normalmap;
	sampler2D multitex;
    float shininess;
};

uniform Material material;

uniform float Ambient =0;
uniform int selected = 0;
uniform int object_index = 0;

uniform int FogEnabled = 1;
uniform int isSky = 0;
uniform float FogAmount = 0.111;
uniform float FogMultiplier = 1;

void main()
{    
  vec3 color = texture(material.diffuse, fs_in.TexCoords).rgb;
  vec3 ambient =  color;
  FragColor = vec4(ambient, 1.0);	
  //FragColor = vec4(1,0,0,1);
}