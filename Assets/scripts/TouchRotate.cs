using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TouchRotate:MonoBehaviour {
	public GameObject objectToRotate;
	private bool rotating;
 
	private IEnumerator Rotate( Vector3 angles, float duration )
	{
	     rotating = true ;
	     Quaternion startRotation = objectToRotate.transform.rotation ;
	     Quaternion endRotation = Quaternion.Euler(angles) * startRotation ;
	     for( float t = 0 ; t < duration ; t += Time.deltaTime*3)
	     {
	         objectToRotate.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration );
	         yield return null;
	     }
	     objectToRotate.transform.rotation = endRotation  ;
	     rotating = false;
	}
	 
	 public void OnMouseDown()
	 {
		if(!GameControl.youWin && GameControl.actionOn)
		{
	     	if(!rotating){
	     		GameControl.attempt++;
	     		StartCoroutine(Rotate(new Vector3(0, 0, 90), 1));
	     		if (Mathf.Round(objectToRotate.transform.rotation.eulerAngles.z) == 270) FindObjectOfType<SoundManager>().PlaySound("success3half");
	     		else FindObjectOfType<SoundManager>().PlaySound("click2");
	     	}
		}
	 }
}