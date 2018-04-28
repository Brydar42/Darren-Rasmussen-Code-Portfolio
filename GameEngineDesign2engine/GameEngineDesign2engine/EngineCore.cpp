#include "EngineCore.h"
EngineCore* EngineCore::runningApp = NULL;
void EngineCore::onCreate()
{
	onStart();
}
void EngineCore::stopRunning()
{
	continueRendering = false;
}
void EngineCore::shutdown()
{
	coreWindow.Shutdown();
	
}
void EngineCore::onStart()
{
	continueRendering = true;
	coreWindow.Initialize("gameEngine2", 500, 500);
}
void EngineCore::onRender()
{
	OpenGLRender test;
	test.Draw();
}
inline void EngineCore::preRender()
{
	
}
inline void EngineCore::postRender()
{
	
}
inline void EngineCore::LogMessage(string message)
{
	//EngineCore::coreManager.log(LogManager::LogLevel::LOG_NONE, message);
}

EngineCore * EngineCore::getRunningApp()
{
	return runningApp;
}
void EngineCore::startRender()
{
	preRender();

}


void EngineCore::endRender()
{
	postRender();
}
bool EngineCore::stillRendering()
{
	return continueRendering;
}