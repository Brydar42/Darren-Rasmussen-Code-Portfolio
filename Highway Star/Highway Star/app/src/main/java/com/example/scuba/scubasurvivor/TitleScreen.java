package com.example.scuba.scubasurvivor;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.Rect;
import android.util.Log;

public class TitleScreen extends GameScreen
{
	private final String TAG = "TitleScreen: ";
	
	private String[] title;
	
	public TitleScreen(Game game, Rect screenRect)
	{
		super(screenRect, Assets.titleImage);
		
		this.game = game;
		title = Assets.titleString;
		
		stringPaints = new Paint[3];
		stringPositions = new Point[3];
		
		for(int i=0; i<stringPaints.length; i++)
		{
			if(i < 2)
			{
				stringPaints[i] = new Paint();
				stringPaints[i].setColor(Color.RED);
				stringPaints[i].setTextSize(60.0f);
				stringPaints[i].setUnderlineText(false);
				stringPaints[i].setTextAlign(Paint.Align.CENTER);
			}
			else
			{
				stringPaints[i] = new Paint();
				stringPaints[i].setColor(Color.RED);
				stringPaints[i].setTextSize(40.0f);
				stringPaints[i].setUnderlineText(true);
				stringPaints[i].setTextAlign(Paint.Align.CENTER);
			}
			
			stringPositions[i] = new Point(screenRect.width()/2, (int)(position.y + (screenRect.height()/6) + (70*i)));
		}
		
		// Just some translate & scale changes for image
		dstRect.set(
				(int)position.x - texture.getWidth()/2,
				0,
				(int)position.x + (texture.getWidth()*3)/2,
				texture.getHeight()*2
				);

		Log.d(TAG, "constructed");
	}

	@Override
	public void receiveTouchEvent(Point touchPos)
	{
		game.setScreen(new InGameScreen(game, screenRect));
	}
	
	@Override
	public void draw(Canvas canvas)
	{
		for(int i=0; i<title.length; i++)
			canvas.drawText(title[i], (float)stringPositions[i].x, (float)stringPositions[i].y, stringPaints[i]);	
		
		canvas.drawBitmap(texture, imageBounds, dstRect, null);
	}
}
