#ifndef Log_Manager_H
#define Log_Manager_H
#include <fstream>
#include <iomanip>
#include <string>
using namespace std;
class LogManager
{
public:
	enum LogLevel { LOG_NONE, LOG_ERROR, LOG_WARN, LOG_TRACE, LOG_INFO };
	string defaultLogFileName;

private:
	static LogManager	*theInstance;
	ofstream		*outStream;
	LogLevel			currentSeverity;
	LogManager(void);
public:
	static LogManager& getInstance();
	~LogManager(void);
	void setLogFile(string &fileName);
	void close();
	void inline setSeverity(LogLevel severity)
	{
		currentSeverity = severity;
	}
	LogLevel inline getSeverity()
	{
		return currentSeverity;
	}
	void log(LogLevel severity, string msg);
	void inline error(string msg)
	{
		log(LOG_ERROR, msg);
	}
	void inline warn(string msg)
	{
		log(LOG_WARN, msg);
	}
	void inline trace(string msg)
	{
		log(LOG_TRACE, msg);
	}
	void inline info(string msg)
	{
		log(LOG_INFO, msg);
	}

};

#endif // !LogManager_H
