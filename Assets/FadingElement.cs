using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingElement : MonoBehaviour
{
	public CanvasGroup uiElement;
	public GameObject TutoClose;
	public GameObject TutoImage;

	public void FadeIn()
	{
		if (GameControl.actionOn)
		{
			TutoClose.SetActive(true);
			StartCoroutine(FadeGroup(uiElement, uiElement.alpha, 1));
			TutoImage.SetActive(true);
		}
	}

	public void FadeOut()
	{
		TutoClose.SetActive(false);
		StartCoroutine(FadeGroup(uiElement, uiElement.alpha, 0));
		TutoImage.SetActive(false);
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
