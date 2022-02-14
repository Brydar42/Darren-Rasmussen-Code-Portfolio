package com.example.scuba.scubasurvivor;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.Window;
import android.view.WindowManager;

public class SCUBA_main extends Activity
{
	private final String TAG = "Main: ";

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		GameView gameView = new GameView(this);
		setContentView(gameView);
		Log.d(TAG, "created");
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
	return true;
	}
}
