#ifndef ENGINE_CORE_H
#define ENGINE_CORE_H
#include "LogManager.h"
#include "Clock.h"
#include "OpenGLRenderer.h"
#include "Window.h"
class EngineCore
{
public:
	static LogManager coreManager;
	static Clock CoreClock;

	//static OpenGLRender coreRender = OpenGLRender();
	static void LogMessage(string message);
	static EngineCore *getRunningApp();
	static void startRender();
	static void endRender();
	bool stillRendering();
	void onCreate();
	void stopRunning();
	void shutdown();
	void onStart();
	Window coreWindow;
	static void onRender();
	static void preRender();
	static void postRender();
private:
	
	bool continueRendering=false;
	static EngineCore *runningApp;
};


#endif // !ENGINE_CORE_H

