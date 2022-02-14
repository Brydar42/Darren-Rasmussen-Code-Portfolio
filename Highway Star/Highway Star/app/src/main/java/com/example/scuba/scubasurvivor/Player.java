package com.example.scuba.scubasurvivor;

import android.graphics.Canvas;
import android.graphics.Rect;
import android.util.Log;

public class Player extends Sprite
{
	private final String TAG = "Player: ";
	public int health=3;
	public Player(Rect screenRect)
	{
		super(screenRect, Assets.tex_Player, new Vector2(screenRect.width()/2 - (Assets.tex_Player.getWidth()/2), 0));

		moveSpeed = 200.0f;
		velocity = new Vector2(0, 0);
		
		Log.d(TAG, "constructed");
	}
	
	public void update(float deltaTime, Vector3 accelValues)
	{
		// Very cheap "collision detection" for walls. Really all that's needed for this game though.
		if(position.x <= gameBox.left && accelValues.x > 0)
		{
			position.x = gameBox.left;
			velocity.x = 0;
		}
		else if(position.x >= gameBox.right - this.imageBounds.width() && accelValues.x < 0)
		{
			position.x = gameBox.right - this.imageBounds.width();
			velocity.x = 0;
		}
		else
			velocity.set((int)(-accelValues.x * moveSpeed), 0);
		
		super.update(deltaTime);
	}
	
	public void draw(Canvas canvas)
	{
		super.draw(canvas);
	}
}
