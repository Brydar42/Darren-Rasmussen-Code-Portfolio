#include "LogManager.h"

LogManager* LogManager::theInstance = NULL;

LogManager::LogManager(void)
{
	outStream = NULL;
	defaultLogFileName = "logfile.log";
	currentSeverity = LOG_ERROR;
}

LogManager::~LogManager(void)
{
	close();
}

LogManager& LogManager::getInstance(void)
{
	if (theInstance == NULL)
	{
		theInstance = new LogManager();
	}
	return *theInstance;
}

void LogManager::setLogFile(string &fileName)
{
	close();
	outStream = new ofstream(fileName.c_str());
	currentSeverity = LOG_ERROR;
}

void LogManager::close()
{
	if (outStream != NULL)
	{
		outStream->close();
		delete outStream;
		outStream = NULL;
	}
}

void LogManager::log(LogLevel severity, string msg)
{
	if (severity <= currentSeverity && currentSeverity > LOG_NONE)
	{
		if (outStream == NULL)
		{
			setLogFile(defaultLogFileName);
		}
		(*outStream) << msg << "\n";
		outStream->flush();
	}
}
