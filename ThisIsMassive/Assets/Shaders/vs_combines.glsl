#version 330

layout(location = 0) in vec4 position;

uniform mat4 cameraToClipMatrix;
uniform mat4 worldToCameraMatrix;
uniform mat4 modelToWorldMatrix;

void main()
{
    vec4 worldPos = modelToWorldMatrix * position;
    vec4 cameraPos = worldToCameraMatrix * worldPos;
    gl_Position = cameraToClipMatrix * cameraPos;
}