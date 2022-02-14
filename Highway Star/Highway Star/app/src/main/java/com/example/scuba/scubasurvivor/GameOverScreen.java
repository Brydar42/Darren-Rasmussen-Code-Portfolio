package com.example.scuba.scubasurvivor;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.Rect;
import android.util.Log;

public class GameOverScreen extends GameScreen
{
	private final String TAG = "GameOverScreen: ";

	private String[] endMsg;
	private int enemyCount;
	
	public GameOverScreen(Game game, Rect screenRect, int enemyCount)
	{
		super(screenRect, Assets.gameOverImage);
		
		this.game = game;
		this.enemyCount = enemyCount;

		stringPaints = new Paint[3];
		stringPositions = new Point[3];
		
		endMsg = Assets.gameOverString;
		
		for(int i=0; i<stringPaints.length; i++)
		{
			if(i < 2)
			{
				stringPaints[i] = new Paint();
				stringPaints[i].setColor(Color.RED);
				stringPaints[i].setTextSize(30.0f);
				stringPaints[i].setUnderlineText(false);
				stringPaints[i].setTextAlign(Paint.Align.CENTER);
			}
			else
			{
				stringPaints[i] = new Paint();
				stringPaints[i].setColor(Color.RED);
				stringPaints[i].setTextSize(30.0f);
				stringPaints[i].setUnderlineText(true);
				stringPaints[i].setTextAlign(Paint.Align.CENTER);
			}
			
			stringPositions[i] = new Point(screenRect.width()/2, (int)(position.y - (screenRect.height()/4) + (70*i)));
		}
		
		// Just some translate & scale changes for image
				dstRect.set(
						(int)position.x - texture.getWidth()/2,
						screenRect.centerY(),
						(int)position.x + (texture.getWidth()*3)/2,
						screenRect.centerY() + texture.getHeight()*2
						);
		
		Log.d(TAG, "constructed");
	}
	
	@Override
	public void receiveTouchEvent(Point touchPos)
	{
		game.setScreen(new TitleScreen(game, screenRect));
	}
	
	@Override
	public void draw(Canvas canvas)
	{
		for(int i=0; i<endMsg.length; i++)
		{
			if(i != 1)
				canvas.drawText(endMsg[i], (float)stringPositions[i].x, (float)stringPositions[i].y, stringPaints[i]);
			else
				canvas.drawText(endMsg[i] + String.valueOf(enemyCount), (float)stringPositions[i].x, (float)stringPositions[i].y, stringPaints[i]);
		}
		
		canvas.drawBitmap(texture, imageBounds, dstRect, null);
	}
}
