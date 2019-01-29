#version 430 core
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
uniform float FogMultiplier = 1;

vec3 ApplySun(in vec3 viewDir, in vec3 lightDir) {

    vec3 skybottom = vec3(0.6, 0.8, 1.0);
    vec3 skytop = vec3(0.05, 0.2, 0.7);
    float sundot = max(dot(viewDir, normalize(-dirLight.direction)), 0.0);
    // render sky
    float t = pow(1.0 - 0.7, 1);
    vec3 col = 0.9*(skybottom*t + skytop * (1.0 - t));
    // sun
    col += 2.77*vec3(0.7, 0.7, 0.5)*pow(sundot, 90.0);
    // sun haze
    col += 0.2*vec3(0.8, 0.9, 1.0)*pow(sundot, 2.0);
    return col;
}

void main()
{
    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    vec3 normal = normalize(fs_in.Normal);
    vec3 lightDir = normalize(lightPos - fs_in.FragPos);
    vec3 sunDir = normalize(sunPos - fs_in.FragPos);

    vec4 col = vec4(ApplySun(viewDir, lightDir), 1);
    vec4 clouds = texture(material.diffuse, fs_in.TexCoords);

    FragColor = mix( mix(col, clouds, 0.5), vec4(0,0,0,0), 1-FogMultiplier);
}