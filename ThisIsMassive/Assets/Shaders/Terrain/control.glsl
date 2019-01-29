#version 430 core
//you need to specify the OpenGL version, of course
//specify the number of vertices per patch
layout(vertices = 3) out;
void main(void) {
	if (gl_InvocationID == 0) {
		gl_TessLevelInner[0] = 7.0;
		gl_TessLevelOuter[0] = 2.0;
		gl_TessLevelOuter[1] = 3.0;
		gl_TessLevelOuter[2] = 7.0;

		//in case of quad, you have to specify both gl_TessLevelInner[1] and //gl_TessLevelOuter[3]
	}
	gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;

}