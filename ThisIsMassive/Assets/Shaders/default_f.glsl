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

uniform vec2 TexCoordScale = vec2(1, 1);
uniform vec2 Tex2CoordScale = vec2(1, 1);

uniform int UseMultitexture = 0;
uniform int UseNormalMap = 0;
uniform int ShadowEnabled = 0;
uniform float SoftEdgeFactor = 0.5;

uniform float Opacity = 1;
//uniform float Ambient = 1;

uniform vec3 lightPos;
uniform vec3 viewPos;
uniform vec3 sunPos;

uniform vec3 lightColor = vec3(1);

uniform int selected = 0;
uniform int FogEnabled = 1;
uniform int isSky = 0;
uniform float FogAmount = 0.111;
uniform float FogMultiplier = 1;
uniform float iTime = 0;
uniform int Editor = 1;

struct PointLight {
	vec3 position;

	float constant;
	float linear;
	float quadratic;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};
#define MAX_POINT_LIGHTS 8
uniform int NumLights = 0;
uniform PointLight pointLights[MAX_POINT_LIGHTS];


vec3 FogColor = vec3(0.5, 0.6, 0.7);


float ShadowCalculation(vec3 lightDir, vec4 fragPosLightSpace)
{
	// perform perspective divide   
	vec3 projCoords = fragPosLightSpace.xyz / fragPosLightSpace.w;
	// transform to [0,1] range
	projCoords = projCoords * 0.5 + 0.5;
	// get closest depth value from light's perspective (using [0,1] range fragPosLight as coords)
	float closestDepth = texture(material.shadowMap, projCoords.xy).x;
	// get depth of current fragment from light's perspective
	float currentDepth = projCoords.z;
	// calculate bias (based on depth map resolution and slope)
	vec3 normal = normalize(fs_in.Normal);

	//float bias = max(0.05 * (1.0 - dot(normal, lightDir)), 0.005); ///ORIGINAL

	//float bias = max(0.05 * (0 - dot(normal, lightDir)), 0.0006);
	float bias = max(0.0001 * (1.0 - dot(normal, lightDir)), 0.008);
	// check whether current frag pos is in shadow
	float shadow = (currentDepth - bias) > closestDepth ? 1.0 : 0.0;
	// PCF
	//float shadow = 0.0;

	vec2 texelSize = 1.0 / textureSize(material.shadowMap, 0);
	for (int x = -1; x <= 1; ++x)
	{
		for (int y = -1; y <= 1; ++y)
		{
			float pcfDepth = texture(material.shadowMap, projCoords.xy + vec2(x, y) * texelSize).r;
			shadow += currentDepth - bias > pcfDepth ? 1.0 : 0.0;
		}
	}
	shadow /= 9.0; //9 for average of pcf loop


				   //float shadow = currentDepth > closestDepth ? 1.0 : 0.0;

				   // keep the shadow at 0.0 when outside the far_plane region of the light's frustum.
				   if (projCoords.z > 1.0)
				     shadow = 0.0;

				   //falloff
				   //if(projCoords.y > 0.67)
				   //  shadow *= (3-projCoords.y*3);


	return shadow * 0.4;
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
	float distance = length(light.position - fragPos) * 3;
	float attenuation = 1.0 / (light.constant + light.linear * distance +
		light.quadratic * (distance * distance));
	// combine results
	vec3 ambient = light.ambient  * vec3(texture(material.diffuse, fs_in.TexCoords * TexCoordScale));
	vec3 diffuse = light.diffuse  * diff * vec3(texture(material.diffuse, fs_in.TexCoords * TexCoordScale));
	vec3 specular = light.specular * spec * vec3(texture(material.specular, fs_in.TexCoords * TexCoordScale));
	ambient *= attenuation;
	diffuse *= attenuation;
	specular *= attenuation;
	return (ambient + diffuse + specular);
}

vec3 ApplyFogKL(in vec3 viewDir) {
	//float dist = length(viewPos - fs_in.FragPos) * 0.00002 * FogMultiplier * FogAmount;
	float dist = length(viewPos - fs_in.FragPos);

	vec3 FogColor = FogColor;// * viewDir.length;   
	dist = clamp(dist, 0, 1);
	return FogColor * dist*0.35;
}

vec3 camera(float time)
{
	return vec3(500.0 * sin(1.5 + 1.57*iTime), 0.0, 1200.0*iTime);
}

vec3 ApplySun(in vec3 viewDir, in vec3 lightDir) {


	//float time = (iTime + 13.5 + 44.)*.05;
	vec3 col;

	vec3 skybottom = vec3(0.6, 0.8, 1.0);
	vec3 skytop = vec3(0.05, 0.2, 0.7);
	float sundot = clamp(dot(lightDir, viewDir), 0.0, 1.0);
	// render sky
	float t = pow(1.0 - 0.7, 12.0);
	col = 0.8*(skybottom*t + skytop * (1.0 - t));

	// sun
	col += vec3(2.5, 2.5, 0.4)*pow(sundot, 1350.0);
	// sun haze
	col += 0.4*vec3(0.8, 0.9, 1.0)*pow(sundot, 2.0);

	return col;
}


// 2D Random
float random(in vec2 st) {
	return fract(sin(dot(st.xy,
		vec2(12.9898, 78.233)))
		* 43758.5453123);
}

// 2D Noise based on Morgan McGuire @morgan3d
// https://www.shadertoy.com/view/4dS3Wd
float noise(in vec2 st) {
	vec2 i = floor(st);
	vec2 f = fract(st);

	// Four corners in 2D of a tile
	float a = random(i);
	float b = random(i + vec2(1.0, 0.0));
	float c = random(i + vec2(0.0, 1.0));
	float d = random(i + vec2(1.0, 1.0));

	// Smooth Interpolation

	// Cubic Hermine Curve.  Same as SmoothStep()
	vec2 u = f * f*(3.0 - 2.0*f);
	// u = smoothstep(0.,1.,f);

	// Mix 4 coorners percentages
	return mix(a, b, u.x) +
		(c - a)* u.y * (1.0 - u.x) +
		(d - b) * u.x * u.y;
}

vec3 AddNoise(vec3 viewDir) {
	vec2 div = fs_in.TexCoords.xy * 200;
	// vec2 div = vec2(512,512);
	vec2 st = fs_in.FragPos.xy / div;

	// Scale the coordinate system to see
	// some noise in action
	vec2 pos = vec2(st*1.0);


	// Use the noise function
	float n = noise(pos);
	//return viewDir.xyz;
	return vec3(n);
}

vec3 AddSelection() {
	//float d = pow(dot(viewDir, fs_in.Normal), 4);
	//d = clamp(d, 0.0, 0.5);
	//const float scale = 5.0;
	//bvec2 toDiscard = greaterThan(fract(fs_in.TexCoords * scale), vec2(0.1, 0.1));
	//if (all(toDiscard))
	//      discard;
	return vec3(0.14, 0.14, 0.14) * abs(sin(iTime * 2));// *vec3(toDiscard.x, toDiscard.x, toDiscard.x);
}

float luma(vec3 color) {
	return dot(color, vec3(0.299, 0.587, 0.114));
}

float luma(vec4 color) {
	return dot(color.rgb, vec3(0.299, 0.587, 0.114));
}

vec3 CalcLighting(vec3 viewDir, vec3 lightDir, vec3 normal) {

	//   ambient   

	vec3 ambient = 0.25 * dirLight.ambient;

	// diffuse
	float diff = max(dot(normal, lightDir), 0);
	vec3 diffuse = diff * dirLight.ambient * 0.5;

	//return (ambient + diffuse) * color;

	// specular
	vec3 reflectDir = reflect(-lightDir, normal);
	float spec = 0.0;
	vec3 halfwayDir = normalize(lightDir + viewDir);
	spec = pow(max(dot(normal, halfwayDir * dirLight.specular), 0.0), 64);
	vec3 specular = spec * lightColor;
	//falloff
	// calculate shadow
	float shadow = 1; //no shadow by default
	if (ShadowEnabled == 1) {
		shadow = ShadowCalculation(lightDir, fs_in.FragPosLightSpace) * 0.61;//  +  fs_in.TexCoords.y*0.11;
	}

	vec3 lighting = ambient + diffuse + specular - shadow;

	vec3 pointcontrib = vec3(0, 0, 0);
	for (int i = 0; i < NumLights; i++) {
		if (i >= MAX_POINT_LIGHTS) continue;
		pointcontrib += CalcPointLight(pointLights[i], normal, fs_in.FragPos, viewDir);
	}

	lighting += pointcontrib;

	return lighting * 0.6;
}

vec3 ApplyMultitexture(vec3 color) {

	vec3 color2 = texture(material.multitex, fs_in.TexCoords * Tex2CoordScale * 10.95).rgb;

	//vec3 projCoords = fs_in.FragPosLightSpace.xyz / fs_in.FragPosLightSpace.w;

	//outer region

	float dist = length(fs_in.FragPos * 0.000006);
	dist = clamp(dist, 0, 1);// * FogMultiplier;                
	vec3 lumacol = color * luma(color2) * 1.1;
	//lumacol = vec3(1, 0, 0);
	color.rgb = mix(color, lumacol, (1 - dist)*0.8);

	/*
	//inner region
	vec3 color2b = texture(material.multitex, fs_in.TexCoords * Tex2CoordScale * 20).rgb;
	float dist2 = length(fs_in.FragPos * 0.00002);
	dist2 = clamp(dist2, 0, 1);
	vec3 lumacol2 = color * luma(color2b);
	//lumacol2 = vec3(0, 1, 0);
	color.rgb = mix(color, lumacol2, (1 - dist2)*0.75);
	*/

	return color;
}

vec3 ApplyNormalMap(vec3 normal) {
	vec4 colorn = texture(material.normalmap, fs_in.TexCoords * Tex2CoordScale).rgba;
	return normal * colorn.rgb;
}

vec3 ApplyWater(vec3 color, vec3 viewDir, vec3 lightDir) {

	vec2 div = fs_in.TexCoords.xy * 10000;
	// vec2 div = vec2(512,512);
	vec2 st = fs_in.FragPos.xy / div;
	// Scale the coordinate system to see
	// some noise in action
	//vec2 pos = vec2(st*1.0);
	// Use the noise function
	float n = noise(div * st);

	vec4 colorn = texture(material.normalmap, fs_in.TexCoords * Tex2CoordScale * 100 - sin(iTime*0.1)).rgba;
	return color + FogColor * colorn.rgb + lightDir * 0.1;
}

float NORMDIST(float x, float mean, float standard_dev)
{
	float fact = standard_dev * sqrt(2.0 * 3.1415);
	float expo = (x - mean) * (x - mean) / (2.0 * standard_dev * standard_dev);
	return exp(-expo) / fact;
}

void main()
{
	vec3 viewDir = normalize(viewPos - fs_in.FragPos);
	vec3 normal = normalize(fs_in.Normal);
	vec3 lightDir = normalize(lightPos - fs_in.FragPos);
	vec3 sunDir = normalize(sunPos - fs_in.FragPos);

	vec3 originalcolor = texture(material.diffuse, fs_in.TexCoords * TexCoordScale).rgb;
	vec3 color = originalcolor + CalcLighting(viewDir, lightDir, normal);
	//float brightness = dot(normal, lightDir) / (length(lightDir) * length(normal));
	//brightness = clamp(brightness, 0, 1);

	//float diff = max(dot(norm, lightDir), 0.0);
	//vec3 diffuse = diff * lightColor;

	//color *= brightness * 2;

	float trans = texture(material.diffuse, fs_in.TexCoords * TexCoordScale).a;
	if (trans <= 0) discard;

	if (UseMultitexture == 1) {
		float blueness = (originalcolor.b - originalcolor.r) + (originalcolor.b - originalcolor.g);
		float f1 = NORMDIST(blueness, 0.32* noise(fs_in.TexCoords * 12), 0.1 * noise(fs_in.TexCoords * 256));
		float f2 = NORMDIST(blueness, 0.04* sin(iTime*0.01)  *noise(fs_in.TexCoords * 122), 0.15 * noise(fs_in.TexCoords * 222));
		blueness *= 1;
		float pos = 0.010 + sin(iTime*0.51) *0.09 + noise(fs_in.TexCoords)*0.2;
		vec3 color2 = texture(material.multitex, fs_in.TexCoords * Tex2CoordScale * 250.15).rgb;
		vec3 color3 = texture(material.multitex, fs_in.TexCoords * Tex2CoordScale * 820.15 + sin(iTime*0.15)).rgb;
		//beach
		color += clamp(vec3(0.76, 0.64, 0.5) * color2 * f1 * FogMultiplier * 0.11, 0.0, 0.7);
		//major wave
		color += color3 * NORMDIST(blueness, f2 * pos + 0.09, 0.045 + sin(iTime*0.5)*0.02) * 0.070 * FogMultiplier;
		//foam
		color += color3 * NORMDIST(blueness, f2 * pos + 0.04, 0.002 + abs(sin(iTime*0.5))*0.02)*0.010 * FogMultiplier;

		vec3 reflectDir = reflect(-lightDir, normal);
		float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
		color += dirLight.specular * spec * vec3(texture(material.specular, fs_in.TexCoords * TexCoordScale));


		blueness = clamp(blueness, 0.0, 1.0);
		color = mix(
			ApplyMultitexture(color),
			ApplyWater(color, viewDir, lightDir) * (0.55 + blueness), pow(blueness, 2.1));
	}

	if (UseNormalMap == 1) {
		normal = ApplyNormalMap(normal);
		//color += normal * 0.01;
	}

	if (Editor == 1) {
		//trans += gl_FragCoord.z*3;
	}

	if (selected == 1) {
		color.rgb += AddSelection();
	}

	if (isSky == 1) {
		color.rgb += ApplySun(viewDir, sunDir);
		//float diff = max(dot(normal, lightDir), 0.0);
		//trans *= clamp(pow(dot(normal, viewDir)*4.7, 0.7), 0.0, 1.0);
	}

	if (FogEnabled == 1) {
		color += ApplyFogKL(viewDir) * 0.5;
	}


	//wire
	//const float scale = 10.0;
	//bvec2 toDiscard = greaterThan(fract(fs_in.TexCoords * scale), vec2(0.1, 0.1));
	//if (all(toDiscard))
	//      discard;

	//FragColor.rgb += AddNoise(viewDir);   

	FragColor = vec4(color, trans);

}