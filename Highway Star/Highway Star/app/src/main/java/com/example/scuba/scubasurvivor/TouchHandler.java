package com.example.scuba.scubasurvivor;

import android.graphics.Point;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnTouchListener;

public class TouchHandler implements OnTouchListener
{
	private final String TAG = "TouchHandler: ";
	
	private boolean isTouched;
	private Point touchPos;
	
	private TouchEventDispatcher dispatcher;
    
    public TouchHandler(View view, TouchEventDispatcher dispatcher)
    {
    	view.setOnTouchListener(this);
    	touchPos = new Point();
    	this.dispatcher = dispatcher;
    	Log.d(TAG, "constructed");
    }
	    
	public boolean onTouch(View view, MotionEvent event)
	{
		switch(event.getAction())
		{
		case MotionEvent.ACTION_DOWN:
			touchPos.set((int)event.getX(), (int)event.getY());
			isTouched = true;
			dispatcher.dispatch(touchPos);
			break;
		case MotionEvent.ACTION_UP:
			isTouched = false;
			break;
		}
		return isTouched;
	}
	
	public Point getLastTouchPos()
	{
		return touchPos;
	}
	
	public boolean getIsTouched()
	{
		return isTouched;
	}
}
