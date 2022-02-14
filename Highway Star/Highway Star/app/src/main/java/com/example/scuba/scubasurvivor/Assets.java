package com.example.scuba.scubasurvivor;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;
import android.util.Log;

public class Assets
{
	private static final String TAG = "Assets: ";
	
	public static Bitmap tex_Player;
	public static Bitmap icon;
	public static Bitmap titleImage;
	public static Bitmap gameOverImage;
	public static Bitmap tex_Enemy;
	public static Bitmap tex_Enemy2;
	public static Bitmap lives;
	public static Bitmap tex_mapTiles;
	public static Rect[][] mapTileRects;
	private static int tileWH;
	public static final int TILE_COLS = 2;
	public static final int TILE_ROWS = 4;
	
	public static String[] titleString;
	public static String[] gameOverString;
	
	public static void loadTextures(Context context)
	{		
		tex_Player = BitmapFactory.decodeResource(context.getResources(), R.drawable.playercar);
		tex_Enemy = BitmapFactory.decodeResource(context.getResources(), R.drawable.car1);
		tex_Enemy2 = BitmapFactory.decodeResource(context.getResources(), R.drawable.car2);
		icon = BitmapFactory.decodeResource(context.getResources(), R.drawable.icon);
		titleImage = BitmapFactory.decodeResource(context.getResources(), R.drawable.tittle2);
		gameOverImage = BitmapFactory.decodeResource(context.getResources(), R.drawable.gameover);
		lives= BitmapFactory.decodeResource(context.getResources(), R.drawable.wheel);
		titleString = context.getResources().getStringArray(R.array.arr_title);
		gameOverString = context.getResources().getStringArray(R.array.arr_endGame);
		
		// For some reason, this image is scaled up. I put in a 96x192 image, which is now 128x256
		tex_mapTiles = BitmapFactory.decodeResource(context.getResources(), R.drawable.environment);
		prepareEnvironmentTileRects();
		
		Log.d(TAG, "Assets loaded");
	}
	
	private static void prepareEnvironmentTileRects()
	{
		tileWH = tex_mapTiles.getWidth() / TILE_COLS;
		
		// VERY specific to a particular tile sheet being used
		// Creating source rectangles, so any tile image is pulled from the one sheet
		mapTileRects = new Rect[TILE_COLS][TILE_ROWS];
		
		for(int x = 0; x < TILE_COLS; x ++)
			for(int y = 0; y < TILE_ROWS ; y ++)
				mapTileRects[x][y] = new Rect(x*tileWH, y*tileWH, x*tileWH +tileWH, y*tileWH + tileWH);
	}
	
	public static int getTileWH()
	{
		return tileWH;
	}
}
