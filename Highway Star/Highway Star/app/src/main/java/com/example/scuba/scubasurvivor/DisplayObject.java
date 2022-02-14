package com.example.scuba.scubasurvivor;

import android.graphics.Bitmap;
import android.graphics.Rect;
import android.util.Log;

public class DisplayObject
{
	private final String TAG = "DisplayObject: ";
	
	// That which is likely common to every displayed object
	
	protected Bitmap texture;
	protected Rect screenRect;
	protected Rect imageBounds;
	protected Rect dstRect;
	protected Vector2 position;
	protected Vector2 velocity;
	public Vector2 getPosition()
	{
		return position;
	}
	public Rect getImageBounds()
	{
		return imageBounds;
	}
	public Rect getDstRect()
	{
		return dstRect;
	}
	// Game Box should definitely be a part of a separate screen hierarchy.
	protected Rect gameBox;
	
	public DisplayObject(Rect screenRect)
	{
		this.screenRect = screenRect;
		this.position = new Vector2(screenRect.width()/2, screenRect.height()/2);
		
		this.gameBox = new Rect((Assets.getTileWH() * 3)/2, 0, screenRect.width() - (Assets.getTileWH() * 3)/2, screenRect.height() - 150);
		
		Log.d(TAG, "constructed");
	}
	public DisplayObject(Rect screenRect, Bitmap texture)
	{
		this.screenRect = screenRect;
		this.position = new Vector2(screenRect.width()/2 - texture.getWidth()/2, screenRect.height()/2 - texture.getHeight()/2);
		this.texture = texture;
		imageBounds = new Rect(0, 0, texture.getWidth(), texture.getHeight());
		dstRect = new Rect((int)position.x, (int)position.y, (int)position.x + imageBounds.width(), (int)position.y + imageBounds.height());
		
		this.gameBox = new Rect((Assets.getTileWH() * 3)/2, 0, screenRect.width() - (Assets.getTileWH() * 3)/2, screenRect.height() - 150);
		
		Log.d(TAG, "constructed");
	}
	
	public DisplayObject(Rect screenRect, Bitmap texture, Vector2 position)
	{
		this.screenRect = screenRect;
		this.position = position;
		this.texture = texture;
		imageBounds = new Rect(0, 0, texture.getWidth(), texture.getHeight());
		dstRect = new Rect((int)position.x, (int)position.y, (int)position.x + imageBounds.width(), (int)position.y + imageBounds.height());
		
		this.gameBox = new Rect((Assets.getTileWH() * 3)/2, 0, screenRect.width() - (Assets.getTileWH() * 3)/2, screenRect.height() - 150);
		
		Log.d(TAG, "constructed");
	}
}
