using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;
using System.IO;

public class PresentationManger : MonoBehaviour {

//    private bool TutoWindow = true;
    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject click;
    public GameObject presentationAudio;

	private bool isPlay = true;

    public void playGame()
    {
        loadScene(2);
    }

	public void songPlaying()
    {
        if (isPlay)
        {
            isPlay = false;
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            presentationAudio.SetActive(false);
        }
        else
        {
            isPlay = true;
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            presentationAudio.SetActive(true);
        }

    }

     public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void loadScene (int sceneIndex)
    {
        StartCoroutine (loadAsync(sceneIndex));
    }

    IEnumerator loadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01 (operation.progress / .9f);
            yield return null;
        }
    }

}