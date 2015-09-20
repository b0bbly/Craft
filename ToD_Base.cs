using UnityEngine;
using System.Collections;
//Base class for controlling the sun and rotation
//code credit to Tobias Johannson - http://www.johansson-tobias.com


public class toD_Base : MonoBehaviour {

	//Directional light we use as the sun
	public Light lSun;

	//how long is a full day going to be in-game
	public float fSecondInAFullDay;

	[Range(0, 24)]
	public float fCurrentTimeOfDay = 0.0f;


	//This is so we can control the speed of our time of day
	[HideInInspector]
	public float fTimeMultiplier = 1.0f;

	//Get the initial intensity of the sun so we can remember it
	private float fSunStartIntensity;


	void Start ()
	{
		fSunStartIntensity = lSun.intensity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateSun ();
		fCurrentTimeOfDay += (Time.deltaTime / fSecondInAFullDay) * fTimeMultiplier;
	}

	void UpdateSun()
	{
		//This rotates the sun 360 decrees in X-Axis according to our current time of day
		lSun.transform.localRotation = Quaternion.Euler((fCurrentTimeOfDay * 360)- 90, 170, 0);

		//Set the sun to full intensity during the day
		float fIntensityMultiplier = 1.0f;
		//During night the intensity is 0! This will make it completely black but we might add a moon in the future that gives a bit of light
		if (fCurrentTimeOfDay <= 0.23f || fCurrentTimeOfDay >= 0.75f)
		{
			fIntensityMultiplier = 0.0f;
		}
		else if (fCurrentTimeOfDay <= 0.25f)
		{
			fIntensityMultiplier = Mathf.Clamp01((fCurrentTimeOfDay - 0.23f) * (1 / 0.2f));
		}
		else if (fCurrentTimeOfDay >= 0.73f)
		{
			fIntensityMultiplier = Mathf.Clamp01((fCurrentTimeOfDay - 0.73f) * (1 / 0.2f));
		}

		//Multiply the intensity of the sun according to the time of day
		lSun.intensity = fSunStartIntensity * fIntensityMultiplier;
	}
}
