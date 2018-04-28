#pragma once
#include <vector>
#include <windows.h>
#include <glew.h>
#include "AbstractRender.h"
#include <vector>

//#include <gl\GL.h>
class OpenGLRender:AbstractRender
{
public:
	OpenGLRender();
	~OpenGLRender();
	 void Draw();
	 void init();
private:
	GLuint VAO, VBO;
	
};