using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate5:MonoBehaviour {

	private void OnMouseDown()
	{
		if(!RotateGame5.youWin)
		{
			transform.Rotate(0f, 0f, 90f);
		}
	}
}