#version 330 core
out vec4 FragColor;
uniform vec2 u_resolution = vec2(800,600);

uniform vec3 lightPos;
uniform vec3 viewPos;
uniform float iTime = 0;

uniform sampler2D image;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
    vec4 FragPosLightSpace;
} fs_in;


float random (vec2 st) {
    return fract(sin(dot(st.xy,
                         vec2(12.9898,78.233)))*
        43758.5453123);
}



void main()
{    
 vec2 st = (gl_FragCoord.xy)/u_resolution.xy;

//    float rnd = random( st * viewPos.xy );
//float tr = dot(fs_in.FragPos, vec3(0.1, 0.1, 0));

// FragColor= vec4(vec3(rnd),tr);
vec4 pex = texture(image, fs_in.TexCoords);
vec4 nc = vec4(1, 0.5+sin(iTime*0.0005)*0.255, 0.3, 1);
vec4 col = mix(nc, pex,0.5);
FragColor = vec4(col.xyz,1.0);
}