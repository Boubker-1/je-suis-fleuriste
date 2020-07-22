using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetScores();
    }

    private void ResetScores()
    {
    	PlayerPrefs.SetFloat("Composante1Time1", 0);
    	PlayerPrefs.SetFloat("Composante1Time2", 0);
    	PlayerPrefs.SetFloat("Composante1Time3", 0);

    	PlayerPrefs.SetFloat("Composante2Time1", 0);
    	PlayerPrefs.SetFloat("Composante2Time2", 0);
    	PlayerPrefs.SetFloat("Composante2Time3", 0);

    	PlayerPrefs.SetInt("Flower1Attempt1", 0);
    	PlayerPrefs.SetInt("Flower1Attempt2", 0);
    	PlayerPrefs.SetInt("Flower1Attempt3", 0);
    }
}
