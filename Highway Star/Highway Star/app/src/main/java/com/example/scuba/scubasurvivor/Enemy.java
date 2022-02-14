package com.example.scuba.scubasurvivor;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Rect;
import android.util.Log;

import java.util.Random;

public class Enemy extends Sprite
{
	private final String TAG = "Enemy: ";
	private Random random;
	public Enemy(Rect screenRect)
	{

		super(screenRect, Assets.tex_Enemy);

		// Place an enemy randomly, anywhere along the bottom of the game area.
		random = new Random();
		position = new Vector2(gameBox.left + random.nextInt(gameBox.width()-texture.getWidth()), gameBox.bottom);
		//Log.d(TAG, String.valueOf(position.x) + ", " + String.valueOf(position.y));
		moveSpeed = 500.0f;
		velocity = new Vector2(0, -moveSpeed);
		
		Log.d(TAG, "constructed");
	}
	
	public Enemy(Rect screenRect, Bitmap texture, Vector2 position)
	{
		super(screenRect, texture, position);
		
		Log.d(TAG, "constructed");
	}
	
	public void update(float deltaTime)
	{
		super.update(deltaTime);
	}
	
	public void draw(Canvas canvas)
	{
		super.draw(canvas);
	}
}
