#ifndef CLOCK_H
#define CLOCK_H

#include <Windows.h>

class Clock
{
private:
	static LARGE_INTEGER	counter;
	static LARGE_INTEGER	ticksPerSecond;
	static bool				highResolutionSupported;
	Clock()
	{}

	static inline LARGE_INTEGER getHardwareCounterValue()
	{
		LARGE_INTEGER v;
		QueryPerformanceCounter(&v);
		return v;
	}

public:

	static void init();

	static inline double ticksToSeconds(LARGE_INTEGER ticks)
	{
		return ((double)ticks.QuadPart) / ((double)ticksPerSecond.QuadPart);
	}

	static inline LARGE_INTEGER secondsToTicks(double secs)
	{
		LARGE_INTEGER result;
		result.QuadPart = (LONGLONG)(secs * ((double)ticksPerSecond.QuadPart));
		return result;
	}


	static inline LARGE_INTEGER getCurrentTicks()
	{
		LARGE_INTEGER result;
		result.QuadPart = /*counter.QuadPart -*/ getHardwareCounterValue().QuadPart;
		return result;
	}


	static inline LARGE_INTEGER getResolution()
	{
		return ticksPerSecond;
	}


	static inline double getCurrentTime()
	{
		return ticksToSeconds(getCurrentTicks());
	}


	static inline bool isReady()
	{
		return highResolutionSupported;
	}
	static inline double Difrence(double time1, double time2)
	{
		return time1 - time2;
	}
};

#endif