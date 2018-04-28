// Enginetest.cpp : Defines the entry point for the console application.
//
#include "EngineCore.h"
#include <glew.h>
void Render()
{
	string filename = "comments.log";
	EngineCore test;
	test.onRender();
	
}
int main(int argc, char* args[])
{
	Clock::init();
	float beforeRender = Clock::getCurrentTime();
	Render();
	printf("time taken between rendering %f", Clock::Difrence(Clock::getCurrentTime(), beforeRender));
	system("pause");
    return 0;
}

