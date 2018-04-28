//This is like #pragmaonce
//but is cross platform compatible
#ifndef WINDOW_H
#define WINDOW_H

#include <SDL.h>
#include <glew.h>
#include <SDL_opengl.h>
#include <glut.h>
#include <iostream>

//Set up the GL3_Prototypes
#define GL3_PROTOTYPES 1

class Window
{
public:
	Window();
	~Window();

	//Initailize all the parameters of the window
	bool Initialize(std::string windowName_, int width_, int height_);
	//Will deallocate all the variables upon destruction
	void Shutdown();

	//Getters
	SDL_Window* GetWindow() const;
	int GetWidth() const;
	int GetHeight() const;
	
	bool isactive;
private:
	//This will be where we set all the openGL attributes for the window
	void SetAttributes();

	SDL_Window* SDLWindow; //Will point to the window in memory
	SDL_GLContext SDLGLContext; //Will create a context in able to use OpenGL

	int width;
	int height;
};

#endif
