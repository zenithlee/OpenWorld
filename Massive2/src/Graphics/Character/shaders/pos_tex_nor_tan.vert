/*
 * Written for Cornell CS 5625 (Interactive Computer Graphics).
 * Copyright (c) 2015, Department of Computer Science, Cornell University.
 * 
 * This code repository has been authored collectively by:
 * Ivaylo Boyadzhiev (iib2), John DeCorato (jd537), Asher Dunn (ad488), 
 * Pramook Khungurn (pk395), and Sean Ryan (ser99)
 */

#version 140
#extension GL_ARB_explicit_attrib_location : enable

layout(location = 0) in vec3 vert_position;
layout(location = 1) in vec3 vert_normal;
layout(location = 2) in vec2 vert_texCoord;
layout(location = 3) in vec4 vert_tangent;

uniform mat4 modelViewMatrix;
uniform mat4 projectionMatrix;
uniform mat3 normalMatrix;

out vec3 geom_position;
out vec3 geom_normal;
out vec2 geom_texCoord;
out vec3 geom_tangent;
out vec3 geom_bitangent;

void main()
{
	gl_Position = projectionMatrix *
			(modelViewMatrix * vec4(vert_position,1));	

	geom_position = (modelViewMatrix * vec4(vert_position,1)).xyz;	
	geom_texCoord = vert_texCoord;

	vec3 N = normalize(vert_normal);
	vec3 T = normalize(vert_tangent.xyz);
	vec3 B = normalize(cross(N, T) * vert_tangent.w);
	geom_normal = normalize(normalMatrix * N);	
	geom_tangent = normalize(modelViewMatrix * vec4(T,0)).xyz;
	geom_bitangent = normalize(modelViewMatrix * vec4(B,0)).xyz;
}
