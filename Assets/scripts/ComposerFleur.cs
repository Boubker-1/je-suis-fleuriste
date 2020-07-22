using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ComposerFleur : MonoBehaviour {

	[SerializeField]
	private GameObject correct1;
	[SerializeField]
	private GameObject correct2;
	[SerializeField]
	private GameObject correct3;
	[SerializeField]
	private GameObject correct4;
	[SerializeField]
	private GameObject correct5;
	[SerializeField]
	private GameObject correct6;
	[SerializeField]
	private GameObject win;
	//[SerializeField]
	//private GameObject close;
	[SerializeField]
	private GameObject aide;

	//public GameObject repeter;

	public GameObject MusicOn;
    public GameObject MusicOff;

    public GameObject audio;

	private bool isPlay = true;


	//methode pour initialiser
	void Start()
	{
		correct1.SetActive(false);
		correct2.SetActive(false);
		correct3.SetActive(false);
		correct4.SetActive(false);
		correct5.SetActive(false);
		correct6.SetActive(false);

		win.SetActive(false);

		//again.SetActive(false);
		//repeter.SetActive(false);	
		aide.SetActive(false);
	}

	// &&  &&  && 

	void Update()
	{
		if(SixC.locked)
		{
			correct3.SetActive(true);
		}

		if(TwoC.locked)
		{
			correct1.SetActive(true);
		}

		if(SevenC.locked)
		{
			correct5.SetActive(true);
		}

		if(FiveC.locked)
		{
			correct6.SetActive(true);
		}

		if(FourC.locked)
		{
			correct4.SetActive(true);
		}

		if(ThreeC.locked)
		{
			correct2.SetActive(true);
		}

		if(SixC.locked && TwoC.locked && SevenC.locked && FiveC.locked && FourC.locked && ThreeC.locked &&
			TigeName.locked && RacineName.locked && StigmateName.locked && FeuillesName.locked && OvaireName.locked && PitaleName.locked)
		{
			win.SetActive(true);
			//repeter.SetActive(true);
			//next.SetActive(true);
			//again.SetActive(true);
		}
	}

	public void playagain()
	{
		loadScene(10);
	}

	public void mainMenu()
	{
		loadScene(0);
	}

	public void closeAide()
	{
		aide.SetActive(false);
	}

	public void aide_moi()
	{
		aide.SetActive(true);
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