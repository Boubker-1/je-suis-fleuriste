using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SwitchScene : MonoBehaviour
{
	public static int currentScene;

	public void Start()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;		
	}

	
}
