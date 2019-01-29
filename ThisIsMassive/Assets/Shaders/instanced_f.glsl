#version 430 core
out vec4 FragColor;

in VS_OUT{
	vec3 FragPos;
	vec3 Normal;
	vec2 TexCoords;
	vec4 FragPosLightSpace;
} fs_in;


struct Material {
	sampler2D diffuse;
	sampler2D multitex;
	sampler2D normalmap;
	sampler2D specular;
	sampler2D shadowMap;
	float shininess;
};
uniform Material material;

void main() {

	vec4 color = texture(material.diffuse, fs_in.TexCoords);
	float trans = color.a;
	if (trans < 0.5) discard;
	//trans -= gl_FragCoord.z * 0.5;
	float originalZ = gl_FragCoord.z / gl_FragCoord.w;
	float c =1- (originalZ * .0002);
	c= clamp(c, 0.0, 1.0);
	FragColor = vec4(color.rgb, c);	
}
