package com.example.scuba.scubasurvivor;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Rect;
import android.util.Log;

public class Sprite extends DisplayObject
{
	private final String TAG = "Sprite: ";
	protected float moveSpeed;

	public Sprite(Rect screenRect, Bitmap texture)
	{
		super(screenRect, texture);

		Log.d(TAG, "constructed");
	}
	public Sprite(Rect screenRect, Bitmap texture, Vector2 position)
	{
		super(screenRect, texture, position);

		Log.d(TAG, "constructed");
	}
	
	public void update(float deltaTime)
	{
		position.set(position.x + (velocity.x * deltaTime),  position.y + (velocity.y * deltaTime));
		dstRect.set((int)position.x, (int)position.y, (int)position.x + imageBounds.width(), (int)position.y + imageBounds.height());
	}
	
	public void draw(Canvas canvas)
	{
		canvas.drawBitmap(texture, imageBounds, dstRect, null);
	}
}
