package com.example.scuba.scubasurvivor;

import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.util.Log;

public class Accelerometer implements SensorEventListener
{
	private final String TAG = "Accelerometer: ";
	
	SensorManager sensorManager;
	private Vector3 values = new Vector3();
	
	public Accelerometer(Context context)
	{
		sensorManager = (SensorManager)context.getSystemService(Context.SENSOR_SERVICE);
		
		if (sensorManager.getSensorList(Sensor.TYPE_ACCELEROMETER).size() == 0)
		{
            Log.d(TAG, "No accelerometer installed");
        } 
		else
		{
            Sensor accelerometer = sensorManager.getSensorList(Sensor.TYPE_ACCELEROMETER).get(0);
            if (!sensorManager.registerListener(this, accelerometer, SensorManager.SENSOR_DELAY_GAME))
            {
            	Log.d(TAG, "Couldn't register sensor listener");
            }
        }
		
		Log.d(TAG, "constructed");
	}
	
	@Override
	public void onAccuracyChanged(Sensor sensor, int accuracy)
	{
		
	}

	@Override
	public void onSensorChanged(SensorEvent event)
	{
		values.x = event.values[0];
		values.y = event.values[1];
		values.z = event.values[2];
		//Log.d(TAG, String.valueOf(values.x));
	}
	
	public Vector3 getValues()
	{
		return values;
	}
}
