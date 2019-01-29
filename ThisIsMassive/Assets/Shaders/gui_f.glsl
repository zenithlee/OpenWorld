#version 450 core
in vec2 vs_textureCoordinate;
uniform sampler2D textureObject;
out vec4 color;

uniform float iTime = 0;
uniform float Opacity = 1.0;

void main(void)
{	
color = texture2D(textureObject, vs_textureCoordinate);
color.a *= Opacity;
//color = vec4(1,1,1,1);
//color += vec4( 0, 0, sin(iTime* 0.01), 0);
}