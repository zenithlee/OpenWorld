#version 430 core

out vec4 FragColor;

in VS_OUT{
 vec3 FragPos;
 vec3 Normal;
 vec2 TexCoords;
 vec4 FragPosLightSpace;
} fs_in;

void main()
{
	const float scale = 5.0;
	bvec2 toDiscard = greaterThan(fract(fs_in.TexCoords * scale), vec2(0.1, 0.1));
	if (all(toDiscard))
		discard;

 FragColor = vec4(0.9,0.9,1.0, 0.5) ;
}