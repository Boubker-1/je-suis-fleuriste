using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class RotateGame3:MonoBehaviour {

	[SerializeField]
	private Transform[] photos = null;

	[SerializeField]
	private GameObject winText = null;

	public static bool youWin;

	public GameObject next;
	public GameObject again;
	public GameObject menu;

	public GameObject pic1;
	public GameObject pic2;
	public GameObject pic3;
	public GameObject pic4;
	public GameObject pic5;
	public GameObject pic6;

	public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject audio;

	private bool isPlay = true;

	//on utilise cette methode pour l'initialisation
	void Start()
	{
		winText.SetActive(false);
		next.SetActive(false);
		again.SetActive(false);
		menu.SetActive(false);
		youWin = false;

		pic1.SetActive(true);
		pic2.SetActive(true);
		pic3.SetActive(true);
		pic4.SetActive(true);
		pic5.SetActive(true);
		pic6.SetActive(true);
	}

	//
	void Update()
	{
		if(photos[0].rotation.z == 0 &&
			photos[1].rotation.z == 0 &&
			photos[2].rotation.z == 0 &&
			photos[3].rotation.z == 0 &&
			photos[4].rotation.z == 0 &&
			photos[5].rotation.z == 0)
		{
			youWin = true;
			StartCoroutine(win());

			next.SetActive(true);
			again.SetActive(true);
			menu.SetActive(true);	
		}
	}

	public void nextLevel()
	{
		//SceneManager.LoadScene("rotationImage4");
		loadScene(5);
	}

	public void playagain()
	{
		//SceneManager.LoadScene("rotationImage3");
		loadScene(4);
	}

	public void mainMenu()
	{
		//SceneManager.LoadScene("mainMenu");
		loadScene(0);
	}

	IEnumerator win()
    {
        StartCoroutine(panelFadeIn.FadeTo(winText, 0.25f));
        winText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

     private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
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

     public void songPlaying()
    {
        if (isPlay)
        {
            isPlay = false;
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            audio.SetActive(false);
        }
        else
        {
            isPlay = true;
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            audio.SetActive(true);
        }

    }
}