package com.example.scuba.scubasurvivor;

import android.graphics.Point;

public class TouchEventDispatcher
{
	private Game game;
	
	public TouchEventDispatcher(Game game)
	{
		this.game = game;		
	}
	
	public void dispatch(Point touchPos)
	{
		game.getScreen().receiveTouchEvent(touchPos);
	}
}
