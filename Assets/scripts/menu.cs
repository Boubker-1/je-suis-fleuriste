using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Net;
using System.IO;

public class menu : MonoBehaviour {

	public GameObject setting;
	public GameObject click;

	public Slider volumeSlider;

	private bool isOpen=false;

	void Start()
	{
		setting.SetActive(false);
		volumeSlider.value = PlayerPrefs.HasKey ("volumeLevel") ? PlayerPrefs.GetFloat ("volumeLevel") : 0.5f;
		//StartCoroutine (panelFadeIn.FadeOut (click, .25f));
	}

    void Update()
    {
             
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

	public void quit() {
			Application.Quit();

	}

	public void options() {

		if (isOpen) {
			StartCoroutine (panelFadeIn.FadeOut (setting, .25f));
			setting.SetActive (false);
			isOpen = false;
		} else {
			isOpen = true;
			StartCoroutine (panelFadeIn.FadeTo (setting, .25f));
			setting.SetActive (true);
		}

	}

	public void setVolume(float volume)
	{
		//audioMixer.SetFloat ("volume",volume);
		AudioListener.volume = volume;
		PlayerPrefs.SetFloat ("volumeLevel",AudioListener.volume);
	}

}
