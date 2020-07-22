using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
	private int currentWindow = 0;

	private bool ranked = false;

	public GameObject Window1;
	public GameObject Window2;
	public GameObject Window3;
	public GameObject Window4;
	public GameObject Ranking;

	private bool animating = false;

	public Text attempt1;
	public Text attempt2;
	public Text attempt3;

	private int attemptCount1;
	private int attemptCount2;
	private int attemptCount3;

	public Text Composante1Record1;
	public Text Composante1Record2;
	public Text Composante1Record3;

	public Text Composante2Record1;
	public Text Composante2Record2;
	public Text Composante2Record3;

	private float c1time1;
	private float c1time2;
	private float c1time3;

	private float c2time1;
	private float c2time2;
	private float c2time3;

	private int totalAttempt;
	private float totalTime1;
	private float totalTime2;

	public Text totalAttemptString;
	public Text totalTime1String;
	public Text totalTime2String;

	public Text Rank1;
	public Text Rank2;
	public Text Rank3;

	public GameObject totalAttemptWindow;
	public GameObject totalTime1Window;
	public GameObject totalTime2Window;

	public GameObject Rank1Window;
	public GameObject Rank2Window;
	public GameObject Rank3Window;

	public GameObject Puzzle1Attempt;
	public GameObject Puzzle2Attempt;
	public GameObject Puzzle3Attempt;

	public GameObject Composante1Flower1;
	public GameObject Composante1Flower2;
	public GameObject Composante1Flower3;

	public GameObject Composante2Flower1;
	public GameObject Composante2Flower2;
	public GameObject Composante2Flower3;

	public GameObject Next;

	IEnumerator Start()
	{
		Next.GetComponent<CanvasGroup>().alpha = 0f;

		totalAttemptWindow.SetActive(false);
		totalTime1Window.SetActive(false);
		totalTime2Window.SetActive(false);

		Rank1Window.SetActive(false);
		Rank2Window.SetActive(false);
		Rank3Window.SetActive(false);

		Composante1Flower1.SetActive(false);
		Composante1Flower2.SetActive(false);
		Composante1Flower3.SetActive(false);

		Composante2Flower1.SetActive(false);
		Composante2Flower2.SetActive(false);
		Composante2Flower3.SetActive(false);

		Puzzle1Attempt.SetActive(false);
		Puzzle2Attempt.SetActive(false);
		Puzzle3Attempt.SetActive(false);

		c1time1 = PlayerPrefs.GetFloat("Composante1Time1");
		c1time2 = PlayerPrefs.GetFloat("Composante1Time2");
		c1time3 = PlayerPrefs.GetFloat("Composante1Time3");

		c2time1 = PlayerPrefs.GetFloat("Composante2Time1");
		c2time2 = PlayerPrefs.GetFloat("Composante2Time2");
		c2time3 = PlayerPrefs.GetFloat("Composante2Time3");

		attemptCount1 = PlayerPrefs.GetInt("Flower1Attempt1");
		attemptCount2 = PlayerPrefs.GetInt("Flower1Attempt2");
		attemptCount3 = PlayerPrefs.GetInt("Flower1Attempt3");

		totalAttempt = attemptCount1 + attemptCount2 + attemptCount3;
		totalTime1 = Mathf.Round(c1time1) + Mathf.Round(c1time2) + Mathf.Round(c1time3);
		totalTime2 = Mathf.Round(c2time1) + Mathf.Round(c2time2) + Mathf.Round(c2time3);

		Timer.FramesToSeconds(c1time1, Composante1Record1);
		Timer.FramesToSeconds(c1time2, Composante1Record2);
		Timer.FramesToSeconds(c1time3, Composante1Record3);

		Timer.FramesToSeconds(c2time1, Composante2Record1);
		Timer.FramesToSeconds(c2time2, Composante2Record2);
		Timer.FramesToSeconds(c2time3, Composante2Record3);

		if (30 <= totalAttempt &&  totalAttempt <= 38) Rank1.text = "''S''";
		if (39 <= totalAttempt &&  totalAttempt <= 47) Rank1.text = "''A''";
		if (48 <= totalAttempt &&  totalAttempt <= 54) Rank1.text = "''B''";
		if (55 <= totalAttempt &&  totalAttempt <= 63) Rank1.text = "''C''";
		if (64 <= totalAttempt) 					   Rank1.text = "''D''";

		if (1500 <= totalTime1 && totalTime1 <= 3600) Rank2.text = "''S''";
		if (3601 <= totalTime1 && totalTime1 <= 4800) Rank2.text = "''A''";
		if (4801 <= totalTime1 && totalTime1 <= 5400) Rank2.text = "''B''";
		if (5401 <= totalTime1 && totalTime1 <= 6300) Rank2.text = "''C''";
		if (6301 <= totalTime1)						  Rank2.text = "''D''";

		if (1500 <= totalTime1 && totalTime1 <= 3600) Rank3.text = "''S''";
		if (3601 <= totalTime1 && totalTime1 <= 4800) Rank3.text = "''A''";
		if (4801 <= totalTime1 && totalTime1 <= 5400) Rank3.text = "''B''";
		if (5401 <= totalTime1 && totalTime1 <= 6300) Rank3.text = "''C''";
		if (6301 <= totalTime1) 					  Rank3.text = "''D''";

		Next.SetActive(false);

		Puzzle1Attempt.SetActive(true);
    	yield return StartCoroutine(CalculateTotalAttempt(Puzzle1Attempt, attempt1, attemptCount1));
		Puzzle2Attempt.SetActive(true);
		yield return StartCoroutine(CalculateTotalAttempt(Puzzle2Attempt, attempt2, attemptCount2));
		Puzzle3Attempt.SetActive(true);
		yield return StartCoroutine(CalculateTotalAttempt(Puzzle3Attempt, attempt3, attemptCount3));

		Next.SetActive(true);
		if (!animating) yield return StartCoroutine(FadeInOut(Next, 0.75f));
	}

    void Update()
    {
        if (currentWindow == 0)
        {
        	Window1.SetActive(true);
        	Window2.SetActive(false);
        	Window3.SetActive(false);
        	Window4.SetActive(false);
        	Ranking.SetActive(false);
        }
        if (currentWindow == 1)
        {
        	Window1.SetActive(false);
        	Window2.SetActive(true);
        	Window3.SetActive(false);
        	Window4.SetActive(false);
        	Ranking.SetActive(false);
        }
        if (currentWindow == 2)
        {
        	Window1.SetActive(false);
        	Window2.SetActive(false);
        	Window3.SetActive(true);
        	Window4.SetActive(false);
        	Ranking.SetActive(false);
        }
        if (currentWindow == 3)
        {
        	Window1.SetActive(false);
        	Window2.SetActive(false);
        	Window3.SetActive(false);
        	Window4.SetActive(true);
        	Ranking.SetActive(false);
        }
        if (currentWindow == 4)
        {
        	Window1.SetActive(false);
        	Window2.SetActive(false);
        	Window3.SetActive(false);
        	Window4.SetActive(false);
        	Ranking.SetActive(true);
        }
    }

    public void NextWindow()
    {
    	FindObjectOfType<SoundManager>().PlaySound("click");
    	StartCoroutine(NextCountResult());
    }

	public IEnumerator NextCountResult()
	{
		if (!animating) yield return StartCoroutine(FadeInOut(Next, 0.75f));
		Next.SetActive(false);
		if (currentWindow < 4) currentWindow++;

		if (currentWindow == 1)
		{

			Composante1Flower1.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(Composante1Flower1, c1time1, Composante1Record1));
			Composante1Flower2.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(Composante1Flower2, c1time2, Composante1Record2));
			Composante1Flower3.SetActive(true);			
			yield return StartCoroutine(CalculateTotalTime(Composante1Flower3, c1time3, Composante1Record3));

			Next.SetActive(true);
			if (!animating) yield return StartCoroutine(FadeInOut(Next, 0.75f));
		}

		if (currentWindow == 2)
		{

			Composante2Flower1.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(Composante2Flower1, c2time1, Composante2Record1));
			Composante2Flower2.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(Composante2Flower2, c2time2, Composante2Record2));
			Composante2Flower3.SetActive(true);			
			yield return StartCoroutine(CalculateTotalTime(Composante2Flower3, c2time3, Composante2Record3));

			Next.SetActive(true);			
			if (!animating) yield return StartCoroutine(FadeInOut(Next, 0.75f));
		}

		if (currentWindow == 3)
		{

			totalAttemptString.text = "0"; totalTime1String.text = "00:00"; totalTime2String.text = "00:00";
			totalAttemptWindow.SetActive(true);
			yield return StartCoroutine(CalculateTotalAttempt(totalAttemptWindow, totalAttemptString, totalAttempt));
			totalTime1Window.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(totalTime1Window, totalTime1, totalTime1String));
			totalTime2Window.SetActive(true);
			yield return StartCoroutine(CalculateTotalTime(totalTime2Window, totalTime2, totalTime2String));

			Next.SetActive(true);
			if (!animating) yield return StartCoroutine(FadeInOut(Next, 0.75f));
		}

		if (currentWindow == 4)
		{

			Rank1Window.SetActive(true);
			if (!animating) yield return StartCoroutine(FadeZoom(Rank1Window, new Vector3(1, 1, 1), 0.75f));

			Rank2Window.SetActive(true);
			if (!animating) yield return StartCoroutine(FadeZoom(Rank2Window, new Vector3(1, 1, 1), 0.75f));

			Rank3Window.SetActive(true);
			if (!animating) yield return StartCoroutine(FadeZoom(Rank3Window, new Vector3(1, 1, 1), 0.75f));
			FindObjectOfType<SoundManager>().PlaySound("win");
		}
	}

	public IEnumerator CalculateTotalAttempt(GameObject obj, Text attemptString, int attempt)
	{
		float step = attempt / 60f;
		float counting = 0;
		int tempAttempt;

		CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
    	float start = canvasGroup.alpha;
    	float end = (canvasGroup.alpha == 1) ? 0 : 1;
    	float duration = 0.75f;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			counting += step;
			tempAttempt = (int)counting;
			if (tempAttempt <= attempt) attemptString.text = tempAttempt.ToString();
			//FindObjectOfType<SoundManager>().PlaySound("scorecount");
    		canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
			yield return new WaitForSeconds(Time.deltaTime / 60f);
		}
		attemptString.text = attempt.ToString();
    	canvasGroup.alpha = end;
	}

	public IEnumerator CalculateTotalTime(GameObject obj, float time, Text timeString)
	{
		float step = time / 60f;
		float counting = 0;

		CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
    	float start = canvasGroup.alpha;
    	float end = 1;//(canvasGroup.alpha == 1) ? 0 : 1;
    	float duration = 0.75f;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			counting += step;
			if(counting <= time) Timer.FramesToSeconds(counting, timeString);
			//FindObjectOfType<SoundManager>().PlaySound("scorecount");
    		canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
			yield return new WaitForSeconds(Time.deltaTime / 60f);
		}
		Timer.FramesToSeconds(time, timeString);
    	canvasGroup.alpha = end;
	}

	private IEnumerator FadeZoom(GameObject obj, Vector3 TargetScale, float duration)
    {
    	animating = true;
    	Vector3 OriginalScale = obj.transform.localScale;
    	CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
    	float start = canvasGroup.alpha;
    	float end = (canvasGroup.alpha == 1) ? 0 : 1; 
    	for (float t = 0; t < duration; t += Time.deltaTime)
    	{
    		canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
    		obj.transform.localScale = Vector3.Lerp(OriginalScale, TargetScale, t / duration);
    		yield return null;
    	}
    	canvasGroup.alpha = end;
    	animating = false;
    }

    private IEnumerator FadeInOut(GameObject obj, float duration)
    {
    	animating = true;
    	CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
    	float start = canvasGroup.alpha;
    	float end = (canvasGroup.alpha == 1) ? 0 : 1;
    	for (float t = 0; t < duration; t += Time.deltaTime)
    	{
    		canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
    		yield return null;
    	}
    	canvasGroup.alpha = end;
    	animating = false;
    }
}
