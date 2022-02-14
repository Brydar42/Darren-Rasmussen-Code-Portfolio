package com.example.scuba.scubasurvivor;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Paint.Align;
import android.graphics.Point;
import android.graphics.Rect;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class InGameScreen extends GameScreen
{
	private final String TAG = "InGameScreen: ";

	private Game game;
	// MAP ITEMS
	int tilesX;
	int tilesY;
	private final float SCROLL_SPEED = -200.0f;
	
	Canvas c;
	// Two copies will be used for background to scroll
	Bitmap tex01_Level, tex02_Level;
	
	// ENEMY ITEMS
	private List<Enemy> enemyList;
	private List<Enemy2> enemy2List;
	private float enemyTimer;
	private int enemyEvasionCount;
	private int enemytype=0;
	// UI ITEMS
	private static Rect rect_UI;
	private Paint paint_UIRect;
	private Paint paint_UIText;
	
	public static int uiTop()
	{
		return rect_UI.top;
	}
	
	public InGameScreen(Game game, Rect screenRect)
	{
		super(screenRect, Assets.tex_mapTiles);
		
		this.game = game;
		velocity = new Vector2(0, SCROLL_SPEED);
		
		int tileWH = Assets.getTileWH();
		// this will get me the number of tiles that fit onto the screen
		// round up to go past the screen a little in case the numbers don't work out precisely. 
		// Take 150 0ff the height to have UI space
		tilesX = (int)Math.ceil(screenRect.width()/tileWH);
		tilesY = (int)Math.ceil((screenRect.height())/tileWH);
		
		tex01_Level = null;
		tex01_Level = Bitmap.createBitmap(tilesX * tileWH, tilesY * tileWH, Bitmap.Config.ARGB_8888);
		c = new Canvas(tex01_Level);
		
		for(int x = 0; x < tilesX; x++)
		{
			for(int y = 0; y < tilesY; y++)
			{
				// Capture each 64x64 square on the screen to place a tile
				position.set((float)(x * tileWH), (float)(y * tileWH));
				
				// Left side of screen
				if(position.x == 0)
					imageBounds = Assets.mapTileRects[0][1];
				else if(position.x == tileWH)
					imageBounds = Assets.mapTileRects[1][1];
				// Right side of screen
				else if(position.x == tilesX*tileWH - tileWH*2)
					imageBounds = Assets.mapTileRects[1][2];
				else if(position.x == tilesX*tileWH - tileWH)
					imageBounds = Assets.mapTileRects[0][2];
				else
					// Default Tile
					imageBounds = Assets.mapTileRects[1][3];

				dstRect.set((int)position.x, (int)position.y, (int)position.x + tileWH, (int)position.y + tileWH);
				c.drawBitmap(texture, imageBounds, dstRect, null);
				tex02_Level = tex01_Level;
			}
		}
		// Position is being used for the update, hence resetting it
		// The positive 8 is because there is for some reason a small gap at the edge of the screen,
		// even though I rounded up with Math.ceil. Nevertheless,
		// I up the x by 8 so at least it's even on both sides.
		position.set(8, 0);
		
		rect_UI = new Rect(0, gameBox.bottom, screenRect.width(), screenRect.height());
		paint_UIRect = new Paint();
		paint_UIRect.setColor(Color.YELLOW);
		paint_UIText = new Paint();
		paint_UIText.setTextSize(80);
		paint_UIText.setColor(Color.MAGENTA);
		paint_UIText.setTextAlign(Align.CENTER);
		
		enemyList = new ArrayList<Enemy>();
		enemy2List =new ArrayList<Enemy2>();
		Log.d(TAG, "constructed");
	}

	@Override
	public void receiveTouchEvent(Point touchPos)
	{
		Log.d(TAG, String.valueOf(touchPos));
	}
	//collision responce
	@Override
	public void update(float deltaTime)
	{
		if (game.getPlayer().health<=0)
		{
			resetGame();
		}
		velocity.set(0, (int)(SCROLL_SPEED*deltaTime));
		// This is a cheap way of implementing a scrolling background
		// Works with the two images being drawn below.
		if(position.y <= -tex01_Level.getHeight())
			position.y = 0;
		position.set(position.x + velocity.x,  position.y + velocity.y);
		//adds enemies at a certain time
		enemyTimer += deltaTime;

		if(enemyTimer >= 2.25f)
		{
			if (enemytype==0) {
				enemyList.add(new Enemy(screenRect));
				enemytype=1;
			}
			else {
				enemy2List.add(new Enemy2(screenRect));
				enemytype=0;
			}
			enemyTimer = 0.0f;
		}

		//update for enemies
		for(int i = enemyList.size()-1; i >= 0; i--)
		{
			Enemy e = enemyList.get(i);
			
			e.update(deltaTime);
			//removing enemies
			if(e.getPosition().y < 0 - e.getImageBounds().height())
			{
				enemyList.remove(e);
				enemyEvasionCount++;
			}
			else if(game.getPlayer().getDstRect().intersect(e.getDstRect())) {
				game.getPlayer().health -= 1;
				enemyList.remove(e);
			}
		}
		for(int i = enemy2List.size()-1; i >= 0; i--)
		{
			Enemy2 e = enemy2List.get(i);

			e.update(deltaTime);
			//removing enemies
			if(e.getPosition().y < 0 - e.getImageBounds().height())
			{
				enemy2List.remove(e);
				enemyEvasionCount++;
			}
			else if(game.getPlayer().getDstRect().intersect(e.getDstRect()))
			{
				game.getPlayer().health-=2;
				enemy2List.remove(e);
			}
		}
	}
	
	@Override
	public void draw(Canvas canvas)
	{
		// Brought all enemy items in here to achieve needed drawing order
		canvas.drawBitmap(tex01_Level, position.x, position.y, null);
		canvas.drawBitmap(tex02_Level, position.x, position.y + tex02_Level.getHeight(), null);
		for(int i = enemyList.size()-1; i >= 0; i--)
			enemyList.get(i).draw(canvas);
		for(int i = enemy2List.size()-1; i >= 0; i--)
			enemy2List.get(i).draw(canvas);
		canvas.drawRect(rect_UI, paint_UIRect);
		canvas.drawText(String.valueOf(enemyEvasionCount), screenRect.width()/2, rect_UI.bottom - 50, paint_UIText);
		canvas.drawText(String.valueOf(game.getPlayer().health), screenRect.width()+20, rect_UI.bottom - 50, paint_UIText);
	}
	
	private void resetGame()
	{
		//everything to zero
		game.setScreen(new GameOverScreen(game, screenRect, enemyEvasionCount));
		enemyEvasionCount = 0;
		enemyTimer = 0.0f;
		enemyList.clear();
		enemy2List.clear();
		game.getPlayer().health=3;
	}
}
