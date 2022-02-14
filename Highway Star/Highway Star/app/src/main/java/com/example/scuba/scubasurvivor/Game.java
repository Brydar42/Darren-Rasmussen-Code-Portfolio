package com.example.scuba.scubasurvivor;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Point;
import android.graphics.Rect;
import android.util.Log;

public class Game
{
	private final String TAG = "Game: ";
	
	private enum GameState { start, inGame, over }
	GameState gameState;

	Rect screenRect;
	Point touchPos;
	
	private Player player;
	private GameScreen screen;
	
	private Accelerometer accelerometer;
	private TouchHandler touchHandler;
	private TouchEventDispatcher dispatcher;
	
	public GameScreen getScreen()
	{
		return screen;
	}
	public void setScreen(GameScreen screen)
	{
		this.screen = screen;
		
		if(screen instanceof TitleScreen)
			gameState = GameState.start;
		else if(screen instanceof InGameScreen)
			gameState = GameState.inGame;
		else if(screen instanceof GameOverScreen)
			gameState = GameState.over;
	}
	public Player getPlayer()
	{
		return player;
	}
	
	public Game(GameView gameView, Rect screenRect)
	{
		this.screenRect = screenRect;
		
		loadContent(gameView.context);
		initialize(gameView);

		Log.d(TAG, "constructed");
	}
	
	private void loadContent(Context context)
	{
		Assets.loadTextures(context);
	}

	private void initialize(GameView gameView)
	{
		accelerometer = new Accelerometer(gameView.context);
		dispatcher = new TouchEventDispatcher(this);
		touchHandler = new TouchHandler(gameView, dispatcher);
		
		touchPos = new Point();
		
		setScreen(new TitleScreen(this, screenRect));
		player = new Player(screenRect);
	}

	// Take control of loop thread?? That would be nicely efficient.
	public void loop(float deltaTime, Canvas canvas)
	{
		canvas.drawColor(Color.CYAN);
		screen.draw(canvas);
		
		if(gameState == GameState.inGame)
		{
			// Each screen should be a class without inheritance, using Sprite objects
			// for what gets drawn, and containing their own game logic.
			// Too late to change a bit of poor code design now.
			screen.update(deltaTime);
			player.update(deltaTime, accelerometer.getValues());
			player.draw(canvas);
		}
	}
}
