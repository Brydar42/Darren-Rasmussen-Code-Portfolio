package com.example.scuba.scubasurvivor;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.Rect;
import android.util.Log;

// This should be a separate hierarchy of classes that use sprite objects
public class GameScreen extends DisplayObject
{
	private final String TAG = "GameScreen: ";
	protected Paint[] stringPaints;
	protected Point[] stringPositions;
	protected Game game;
	
	public GameScreen(Rect screenRect)
	{
		super(screenRect);
		Log.d(TAG, "constructed");
	}
	
	public GameScreen(Rect screenRect, Bitmap texture)
	{
		super(screenRect, texture);
		Log.d(TAG, "constructed");
	}
	
	public GameScreen(Rect screenRect, Bitmap texture, Vector2 position)
	{
		super(screenRect, texture, position);
		Log.d(TAG, "constructed");
	}
	
	public void receiveTouchEvent(Point touchPos){}
	
	public void update(float deltaTime){}
	public void draw(Canvas canvas){}
}
