using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
	public CanvasGroup uiElement;
	public GameObject HintClose;
	public GameObject HintImage;

	public void FadeIn()
	{
		if (GameControl.actionOn)
		{
			GameControl.actionOn = false;
			HintClose.SetActive(true);
			HintImage.SetActive(true);
			StartCoroutine(FadeGroup(uiElement, uiElement.alpha, 1));			
		}
	}

	public void FadeOut()
	{
		HintClose.SetActive(false);
		HintImage.SetActive(false);
		StartCoroutine(FadeGroup(uiElement, uiElement.alpha, 0));
		GameControl.actionOn = true;
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
}
