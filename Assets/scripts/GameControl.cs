using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameControl:MonoBehaviour {


	[SerializeField]
	private Transform[] pictures = null;
	public CanvasGroup uiElement;
	public GameObject Feleciter;
//	public GameObject HintImage;
//	public GameObject HintClose;
//	public GameObject TutoImage;
//	public GameObject TutoClose;
	public GameObject Close;

	[SerializeField]
	private GameObject winText = null;

	public static bool youWin;
	public static bool activeWindow;
	public static bool actionOn = false;
	public static int attempt;
	public Text attemptCount;

	public GameObject next;
	public GameObject again;
	public GameObject menu;
	public GameObject Tutorial;
	public GameObject Idea;

	public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject GoHomeAlert;

    public GameObject VerticalLine1;
    public GameObject VerticalLine2;
    public GameObject HorizontalLine;

	public GameObject pic1;
	public GameObject pic2;
	public GameObject pic3;
	public GameObject pic4;
	public GameObject pic5;
	public GameObject pic6;

	private bool isPlay = true;
	private bool confirmed = false;

	private int[] AngleIndex1 = {0, 1, 2, 3, 4, 5};
	private int[] AngleIndex2 = {0, 1, 2, 3, 4, 5};
	private int[] AngleIndex3 = {0, 1, 2, 3, 4, 5};
	private int index;

	//on utilise cette methode pour l'initialisation
	void Start()
	{
		Shuffle(AngleIndex1); Shuffle(AngleIndex2); Shuffle(AngleIndex3);
		if (SceneManager.GetActiveScene().buildIndex == 3) GiveAngle(AngleIndex1);
		if (SceneManager.GetActiveScene().buildIndex == 4) GiveAngle(AngleIndex2);
		if (SceneManager.GetActiveScene().buildIndex == 5) GiveAngle(AngleIndex3);

		attempt = 0;
		winText.SetActive(false);
		youWin = false;
		activeWindow = false;
		Feleciter.SetActive(false);
//		HintClose.SetActive(false);
//		HintImage.SetActive(false);
		Idea.SetActive(false);
		next.SetActive(false);
		again.SetActive(false);

		if (SceneManager.GetActiveScene().buildIndex == 3)
		{
			Tutorial.SetActive(true);
		}
		else
		{
			Tutorial.SetActive(false);
			actionOn = true;
		}
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
		attemptCount.text = attempt.ToString();

		if(Mathf.Round(pictures[0].rotation.z) == 0 &&
			Mathf.Round(pictures[1].rotation.z) == 0 &&
			Mathf.Round(pictures[2].rotation.z) == 0 &&
			Mathf.Round(pictures[3].rotation.z) == 0 &&
			Mathf.Round(pictures[4].rotation.z) == 0 &&
			Mathf.Round(pictures[5].rotation.z) == 0)
		{
			StartCoroutine(FlowerCompleted());
//			Feleciter.SetActive(true);
			youWin = true;
			actionOn = false;
			if (activeWindow)
			{
				next.SetActive(true);
				again.SetActive(true);		
			}
		}
	}

	public void nextLevel()
	{
		FindObjectOfType<SoundManager>().PlaySound("click");
		loadScene(3);
	}

	public void playagain()
	{
		FindObjectOfType<SoundManager>().PlaySound("click");
		loadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("mainMenu");
	}

	IEnumerator win()
    {
        StartCoroutine(panelFadeIn.FadeTo(winText, 3.0f));
        StartCoroutine(wait());
        yield return new WaitForSeconds(1);
        winText.SetActive(true);
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

    public void AudioPause()
    {
	    AudioListener.pause = true; 	
	    MusicOn.SetActive(false);
	    MusicOff.SetActive(true);   
    }

    public void AudioPlay()
    {
	    AudioListener.pause = false; 	
	    MusicOn.SetActive(true);
	    MusicOff.SetActive(false);   
    }

	public IEnumerator FlowerCompleted()
	{
		StartCoroutine(wait());
		yield return new WaitForSeconds(0.5f);
		if (!confirmed)
		{
			FindObjectOfType<SoundManager>().PlaySound("correctanswer");				
			confirmed = true;
		}
		Feleciter.SetActive(true);
	}

	public void FadeOut()
	{
		StartCoroutine(FadeGroup(uiElement, uiElement.alpha, 0));
		actionOn = true;
		Close.SetActive(false);
		Feleciter.SetActive(false);
		VerticalLine1.SetActive(false);
		VerticalLine2.SetActive(false);
		HorizontalLine.SetActive(false);
		activeWindow = true;
	}

	public IEnumerator FadeGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
	{
		float startLerp = Time.time;
		float lerpingLength = Time.time - startLerp;
		float percentComplete = lerpingLength / lerpTime;

		while(true){
			lerpingLength = Time.time - startLerp;
			percentComplete = lerpingLength / lerpTime;
			float currentAlpha = Mathf.Lerp(start, end, percentComplete);
			cg.alpha = currentAlpha;
			if (percentComplete >= 1) break;
			yield return new WaitForEndOfFrame();
		}
	}

     private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    public void ShowHomeAlert()
    {
    	if (actionOn)
    	{
	    	FindObjectOfType<SoundManager>().PlaySound("click");
	        GoHomeAlert.SetActive(true);
	        actionOn = false;
    	}
    }

    public void CloseHomeAlert()
    {
    	FindObjectOfType<SoundManager>().PlaySound("click");
    	GoHomeAlert.SetActive(false);
    	actionOn = true;
    }

    public void ShowTutorial()
    {
        if (actionOn)
        {
	    	FindObjectOfType<SoundManager>().PlaySound("click");
        	Tutorial.SetActive(true);
        	actionOn = false;
        }
    }

    public void CloseTutorial()
    {
    	FindObjectOfType<SoundManager>().PlaySound("click");
        Tutorial.SetActive(false);
        actionOn = true;
    }

    public void ShowIdea()
    {
        if (actionOn)
        {
	    	FindObjectOfType<SoundManager>().PlaySound("idea");
        	Idea.SetActive(true);
        	actionOn = false;
        }
    }

    public void CloseIdea()
    {
    	FindObjectOfType<SoundManager>().PlaySound("click");
        Idea.SetActive(false);
        actionOn = true;
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }

    private void GiveAngle(int [] AngleIndex)
    {
    	for (int index = 0; index < 6; index ++)
		{
			if (AngleIndex[index] == 0) pictures[index].transform.Rotate(0f, 0f, 90f);
			if (AngleIndex[index] == 1) pictures[index].transform.Rotate(0f, 0f, 180f);
			if (AngleIndex[index] == 2) pictures[index].transform.Rotate(0f, 0f, 270f);
			if (AngleIndex[index] == 3) pictures[index].transform.Rotate(0f, 0f, -270f);
			if (AngleIndex[index] == 4) pictures[index].transform.Rotate(0f, 0f, -90f);
			if (AngleIndex[index] == 5) pictures[index].transform.Rotate(0f, 0f, -180f);
		}
    }

/*
    public void Restart()
    {
		if (SceneManager.GetActiveScene().buildIndex == 3) GiveAngle(AngleIndex1);
		if (SceneManager.GetActiveScene().buildIndex == 4) GiveAngle(AngleIndex2);
		if (SceneManager.GetActiveScene().buildIndex == 5) GiveAngle(AngleIndex3);

		VerticalLine1.SetActive(false);
		VerticalLine2.SetActive(false);
		HorizontalLine.SetActive(false);

		attempt = 0;
		youWin = false;
		activeWindow = false;
		Feleciter.SetActive(false);

		next.SetActive(false);
		again.SetActive(false);    	
    }
*/
}