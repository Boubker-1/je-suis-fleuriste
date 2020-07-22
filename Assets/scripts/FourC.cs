using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class FourC : MonoBehaviour {

	[SerializeField]
	private Transform fourCPlace;

	private Vector2 initialPosition;

	private Vector2 mousePosition;

	private float deltaX, deltaY;

	public static bool locked;

	//methode pour initialiser
	void Start()
	{
		initialPosition = transform.position;
	}

	/*private void Update()
	{
		if(Input.touchCount > 0 && !locked)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			switch(touch.phase)
			{
				case TouchPhase.Began:
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						deltaX = touchPos.x - transform.position.x;
						deltaY = touchPos.y - transform.position.y;
					}
					break;

				case TouchPhase.Moved:
					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
					}
					break;

				case TouchPhase.Ended:
					if(Mathf.Abs(transform.position.x - fourCPlace.position.x) <= 0.5f &&
						Mathf.Abs(transform.position.y - fourCPlace.position.y) <= 0.5f)
					{
						transform.position = new Vector2(fourCPlace.position.x, fourCPlace.position.y);
						locked = true;
					}
					else 
						{
							transform.position = new Vector2(initialPosition.x, initialPosition.y);
						}
					break;
			}
		}
	}*/

	private void OnMouseDown()
	{
		if(!locked)
		{
			deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
			deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
		}
	}

	private void OnMouseDrag()
	{
		if(!locked)
		{
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
		}
	}

	private void OnMouseUp()
	{
		if(Mathf.Abs(transform.position.x - fourCPlace.position.x) <= 0.5f &&
			Mathf.Abs(transform.position.y - fourCPlace.position.y) <= 0.5f)
		{
			transform.position = new Vector2(fourCPlace.position.x, fourCPlace.position.y);
			locked = true;
		}
		else 
		{
			transform.position = new Vector2(initialPosition.x, initialPosition.y);
		}
	}
}