#define WIN32_LEAN_AND_MEAN
#define WIN32_EXTRA_LEAN

#include <windows.h>
#include <vector>
//#include <gl/gl.h>
//#include <gl/glu.h>

#include "EngineCore.h"

EngineCore	*hdApp;

long windowWidth = 1024;
long windowHeight = 768;
long windowBits = 32;
bool fullscreen = false;

HDC hDC;


class TrialApp : public EngineCore
{
private:
	double lastFpsPrint = 0.0;

public:
	TrialApp()
	{
	}


	virtual void postRender()
	{

	}

	virtual void initializeWindowingSystem()
	{

	}

	virtual void onCreate()
	{
		string cubeName("cube1");

	}

	virtual void preRender(double timeSinceLastFrame)
	{

	}
	void onRender()
	{
		OpenGLRender tester;
		tester.init();
		tester.Draw();
		tester.~OpenGLRender();
	}
};