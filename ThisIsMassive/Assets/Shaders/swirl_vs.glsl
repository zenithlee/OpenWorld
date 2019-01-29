precision highp float;
precision highp int;
uniform mat4 modelMatrix;
uniform mat4 modelViewMatrix;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat3 normalMatrix;
attribute vec3 position;
attribute vec3 normal;
attribute vec2 uv;
attribute vec2 uv2;
varying vec2 vUv;
varying vec3 vPosition;
varying vec3 vNormal;
vec4 Star_Swamp_3D_version_1518181399092_348_main()
{
	vec4 Star_Swamp_3D_version_1518181399092_348_gl_Position = vec4(0.0);
	vUv = uv;
	vPosition = position;
	vNormal = normal;
	Star_Swamp_3D_version_1518181399092_348_gl_Position = projectionMatrix * modelViewMatrix * vec4(position, 1.0);
	return Star_Swamp_3D_version_1518181399092_348_gl_Position *= 1.0;
}
void main()
{
	gl_Position = Star_Swamp_3D_version_1518181399092_348_main();
}
