package com.example.scuba.scubasurvivor;

import android.graphics.Canvas;
import android.util.Log;

public class GameLoopThread extends Thread
{
	private final String TAG = "GameLoopThread: ";
	
	private GameView view;
	private boolean running = false;
	
	public GameLoopThread(GameView view)
	{
		this.view = view;
		Log.d(TAG, "constructed");
	}
	
	public void setRunning(boolean run)
	{
		running = run;
	}
	
	@Override
	public void run()
	{
		long startTime = System.nanoTime();
		while(running)
		{
			Canvas canvas = null;
			try
			{
				canvas = view.getHolder().lockCanvas();
				synchronized(view.getHolder())
				{
					float deltaTime = (System.nanoTime()-startTime) / 1000000000.0f;
		            startTime = System.nanoTime();
		            
		            view.loop(deltaTime, canvas);
				}
			}
			finally
			{
				if(canvas != null)
				{
					view.getHolder().unlockCanvasAndPost(canvas);
				}
			}
		}
	}
}
