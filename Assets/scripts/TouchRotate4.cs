using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate4:MonoBehaviour {

	private void OnMouseDown()
	{
		if(!RotateGame4.youWin)
		{
			transform.Rotate(0f, 0f, 90f);
		}
	}
}