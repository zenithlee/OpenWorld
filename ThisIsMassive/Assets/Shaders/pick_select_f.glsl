#version 430 core
out vec4 FragColor;

uniform vec3 object_index = vec3(0,0,0);

/**
   Pass in the color that represents the index.
   Read the color from the screen to determinine index in screen coordinates 
   (gl.ReadPixels)
*/
void main()
{   
  // FragColor = vec4(1,0,0,1);
  //FragColor = vec4(object_index*10, 1.0); 
  FragColor = vec4(object_index.x, object_index.y, object_index.z, 1.0);
}