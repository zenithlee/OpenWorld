#version 450 core

in vec2 vs_textureCoordinate;
in vec3 fragNormal;

uniform mat4 modelView;
uniform sampler2D textureObject;
out vec4 color;

void main(void)
{
     float brightness = 1;
	//color = texelFetch(textureObject, ivec2(vs_textureCoordinate.x, vs_textureCoordinate.y), 0).rgba;
	vec4 surface = texture2D(textureObject, vs_textureCoordinate);
	color = vec4(surface.rgb * brightness, surface.a);
}