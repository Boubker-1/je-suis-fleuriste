using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate2:MonoBehaviour {

	private void OnMouseDown()
	{
		if(!RotateGame2.youWin)
		{
			transform.Rotate(0f, 0f, 90f);
		}
	}
}