#version 400 core
out vec4 FragColor;

in VS_OUT{
	vec3 FragPos;
	vec3 Normal;
	vec2 TexCoords;
	vec4 FragPosLightSpace;
} fs_in;

struct DirLight {
	vec3 direction;
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};
uniform DirLight dirLight;

struct Material {
	sampler2D diffuse;
	sampler2D multitex;
	sampler2D normalmap;
	sampler2D specular;
	sampler2D shadowMap;
	float shininess;
};
uniform Material material;

uniform vec3 lightPos;
uniform vec3 viewPos;
uniform vec3 sunPos;

void main()
{
	vec3 viewDir = normalize(viewPos - fs_in.FragPos);
	vec3 normal = normalize(fs_in.Normal);
	vec3 lightDir = normalize(lightPos - fs_in.FragPos);
	vec3 sunDir = normalize(sunPos - fs_in.FragPos);

	float dist = length(viewPos - fs_in.FragPos) * 0.5;
	dist = clamp(dist, 0, 1);
	vec3 color = texture(material.diffuse, fs_in.TexCoords).rgb;
	//float trans = 1 - pow(gl_FragCoord.z, 16);
	//trans = clamp(trans, 0.0, 1.0);
	//color = viewDir;
	//float originalZ = gl_FragCoord.z / gl_FragCoord.w; //to get original z
	//float c = 1 - (originalZ * .00006);
	//c = clamp(c, 0.0, 1.0);
	FragColor = vec4(color, 1);
}