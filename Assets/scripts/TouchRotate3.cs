using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate3:MonoBehaviour {

	private void OnMouseDown()
	{
		if(!RotateGame3.youWin)
		{
			transform.Rotate(0f, 0f, 90f);
		}
	}
}