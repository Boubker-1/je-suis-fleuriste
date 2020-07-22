using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideParts : MonoBehaviour
{
	[SerializeField]
	private Transform PartPlace;
	private Vector2 OriginalPlace;
	private Vector2 mousePosition;
	private float dX, dY;
	public static bool locked;

    void Start()
    {
        OriginalPlace = transform.position;
    }

	private void OnMouseDown()
		{
			if(!locked)
			{
				dX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
				dY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
			}
		}

	private void OnMouseDrag()
		{
			if(!locked)
			{
				mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = new Vector2(mousePosition.x - dX, mousePosition.y - dY);
			}
		}

	private void OnMouseUp()
		{
			transform.position = new Vector2(OriginalPlace.x, OriginalPlace.y);
			/*
			if(Mathf.Abs(transform.position.x - pitalePlace.position.x) <= 0.5f &&
				Mathf.Abs(transform.position.y - pitalePlace.position.y) <= 0.5f)
			{
				transform.position = new Vector2(pitalePlace.position.x, pitalePlace.position.y);
				locked = true;
			}
			else 
			{
				transform.position = new Vector2(OriginalPlace.x, OriginalPlace.y);
			}
			*/
		}
}
