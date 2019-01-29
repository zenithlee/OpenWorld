#version 430 core
out vec4 FragColor;

in VS_OUT {
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

uniform sampler2D diffuseTexture;
uniform sampler2D shadowMap;

uniform vec3 lightPos;
uniform vec3 viewPos;

//uniform float inambient = 0.7;
//uniform float inspecular = 1;
uniform vec3 lightColor = vec3(1);
uniform int ShadowEnabled = 1;

uniform int selected = 0;

uniform int FogEnabled =0;
uniform float FogAmount = 0.101;

uniform int Editor = 0;

struct PointLight {
    vec3 position;
    
    float constant;
    float linear;
    float quadratic;
	
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
#define MAX_POINT_LIGHTS 3
uniform int NumLights = 0;
uniform PointLight pointLights[MAX_POINT_LIGHTS];

struct Material {
    sampler2D diffuse;
    sampler2D specular;
    float shininess;
}; 
  
uniform Material material;


float ShadowCalculation(DirLight light, vec4 fragPosLightSpace)
{
  // perform perspective divide
    vec3 projCoords = fragPosLightSpace.xyz / fragPosLightSpace.w;
    // transform to [0,1] range
    projCoords = projCoords * 0.5 + 0.5;
    // get closest depth value from light's perspective (using [0,1] range fragPosLight as coords)
    float closestDepth = texture(material.shadowMap, projCoords.xy).r; 
    // get depth of current fragment from light's perspective
    float currentDepth = projCoords.z;
    // calculate bias (based on depth map resolution and slope)
    vec3 normal = normalize(fs_in.Normal);
    vec3 lightDir = normalize(lightPos - fs_in.FragPos);
    float bias = max(0.05 * (0 - dot(normal, lightDir)), 0.0006) ;
    // check whether current frag pos is in shadow
    // float shadow = currentDepth - bias > closestDepth  ? 1.0 : 0.0;
    // PCF
    float shadow = 0.0;
    vec2 texelSize = 1.0 / textureSize(material.shadowMap, 0);
    for(int x = -1; x <= 1; ++x)
    {
        for(int y = -1; y <= 1; ++y)
        {
            float pcfDepth = texture(material.shadowMap, projCoords.xy + vec2(x, y) * texelSize).r; 
            shadow += currentDepth - bias > pcfDepth  ? 1.0 : 0.0;        
        }    
    }
    shadow *= 0.5;
    
    // keep the shadow at 0.0 when outside the far_plane region of the light's frustum.
    if(projCoords.z > 1.0)
        shadow = 0.0;

//falloff
    if(projCoords.y > 0.67)
        shadow *= (3-projCoords.y*3);

        
    return shadow;
}

vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(normal, lightDir), 0.0);
    // specular shading
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    // attenuation
    float distance    = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + 
  			     light.quadratic * (distance * distance));    
    // combine results
    vec3 ambient  = light.ambient  * vec3(texture(material.diffuse, fs_in.TexCoords));
    vec3 diffuse  = light.diffuse  * diff * vec3(texture(material.diffuse, fs_in.TexCoords));
    vec3 specular = light.specular * spec * vec3(texture(material.specular, fs_in.TexCoords));
    ambient  *= attenuation;
    diffuse  *= attenuation;
    specular *= attenuation;
    return (ambient + diffuse + specular);
} 

void main()
{           
      vec4 color = texture(diffuseTexture, fs_in.TexCoords).rgba;
    vec3 normal = normalize(fs_in.Normal);
    vec3 lightColor =lightColor;
    // ambient
    vec3 ambient =dirLight.ambient * color.rgb;	
    // diffuse
    vec3 lightDir = normalize(lightPos - fs_in.FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * lightColor;
    // specular
    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = 0.0;
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    spec = pow(max(dot(normal, halfwayDir * dirLight.specular ), 0.0), 32.0);
   vec3 specular = spec * lightColor;    
    // calculate shadow
	float shadow =0;
	if ( ShadowEnabled==1){	
     shadow = ShadowCalculation(dirLight, fs_in.FragPosLightSpace);//  +  fs_in.TexCoords.y*0.11;
	}	

 vec3 projCoords = fs_in.FragPosLightSpace.xyz / fs_in.FragPosLightSpace.w;
//falloff
 vec3 lighting = (ambient + (1- (shadow)) * (diffuse + specular)) * color.rgb;
    
float trans = 1;
trans = color.a;
if ( Editor ==1) {
  //trans = gl_FragCoord.z*3;
}

    vec3 pts = vec3(0.0);
	//lighting *= 0.1;
	//lighting = vec3(0,0,0);

	/*
	for(int i = 0; i < NumLights; i++) {
	 if ( i > MAX_POINT_LIGHTS) break;
  	  lighting += CalcPointLight(pointLights[i], normal, fs_in.FragPos, viewDir);  	
	}
	*/

    if ( selected == 1 ) {	
	  FragColor = vec4(1,1,1, 0.45) ;
	}
	else {
	 FragColor = vec4(lighting,trans);
	}

	if ( FogEnabled ==1 ) {
       float dist = length( fs_in.FragPos * (FogAmount) );
	   vec4 FogColor = vec4(0.5, 0.5, 0.7, 0.9) * viewDir.length;       
       dist = clamp(dist, 0,1);
	   if ( dist>0.999) dist = 1-dist;
       vec4 fcolor =mix(FragColor, FogColor, dist); 
	   FragColor = fcolor;
	}
	
}