using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public static Text time;
	public static float currentTime = 0;
	public static bool pausedGame = true;
	public static bool gameEnded = false;

	public void Start()
	{
		time = GetComponent<Text>();
	}

    public void Update()
    {
    	if (!pausedGame && !gameEnded)
		{
			currentTime += Time.deltaTime;
	    	FramesToSeconds(currentTime, time);
		}        
    }

    public static void FramesToSeconds(float frames, Text givenTime)
    {
			string min, sec;
			sec = Mathf.Floor(frames % 60).ToString("00"); 
			min = Mathf.Floor((frames % 3600)/60).ToString("00");
			givenTime.text = min + ":" + sec;
    }
}
