using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
	public CanvasGroup uiElement;
	public GameObject Close;

	public void FadeOut()
	{
		Close.SetActive(false);
		StartCoroutine(FadeGroupe(uiElement, uiElement.alpha, 0));
		GameControl.activeWindow = true;
	}

	public IEnumerator FadeGroupe(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
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
