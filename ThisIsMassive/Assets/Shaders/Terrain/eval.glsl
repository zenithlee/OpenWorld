#version 430 core
layout(triangles, equal_spacing, ccw) in;
in vec3 vPos[];
out vec3 tePos;
uniform mat4 mvp;

void main() {
	tePos = gl_TessCoord.x * vPos[0] + gl_TessCoord.y * vPos[1] + gl_TessCoord.z * vPos[2];
	gl_Position = mvp * vec4(tePos, 1.0);
}