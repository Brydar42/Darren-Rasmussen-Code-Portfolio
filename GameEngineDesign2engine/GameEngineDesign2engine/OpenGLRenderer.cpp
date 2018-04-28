#include "OpenGLRenderer.h"
#include <gl\GL.h>

OpenGLRender::OpenGLRender()
{
	//init();
}
OpenGLRender::~OpenGLRender()
{
	
	glDeleteVertexArrays(1, &VAO);
	glDeleteBuffers(1, &VBO);
}
void OpenGLRender::Draw()
{	

	GLuint VAO, VBO;
	float verts[] = { 0.0, 0.5, 0.0, -0.5, -0.5, 0, 0.5, -0.5, 0.0 }; // default CCW winding
	//Generate the VAO & VBO
	//Pass in the VAO & VBO variable as a pointer to be filled by the GPU
	glGenVertexArrays(1, &VAO);
	glGenBuffers(1, &VBO);

	//Bind the VAO and VBO to the GPU to activate them for use
	glBindVertexArray(VAO);
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	//Fill the VBO that you activated above with your vertex data
	//(type of Buffer, size of array, pointer to the first item in array, type of draw call)
	glBufferData(GL_ARRAY_BUFFER, 9 * sizeof(float), verts, GL_STATIC_DRAW);

	//Enable a vertex attribute array
	//This will be where we define that data we are passing to our VBO
	glEnableVertexAttribArray(0);

	//Assign thd data to the specific attribute pointer you just made
	//(attribute pointer, number of variables, type of variable, 
	//is it normalized?, size of step to next vert, pointer to the spot in the Vertex this data is stored)
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);

	//Clear the vertex array and the buffer so no one else can access it or push to it
	glBindVertexArray(0);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	//-----------------------RENDER-----------------------------

	//Clears the current buffer before drawing the new frame on it
	glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
	//Clear existing buffers before rendering the frame
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	//Bind the VAO that you want to use for drawing
	glBindVertexArray(VAO);

	//Draw the array stored in the bound VAO
	//(type of render, start of array, end of array)
	glDrawArrays(GL_TRIANGLES, 0, 3);

	//Clear the vertex array for future use
	glBindVertexArray(0);

	
}

void OpenGLRender::init()
{
	

}
