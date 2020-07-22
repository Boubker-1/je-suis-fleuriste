using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	[SerializeField] private Canvas canvas;

	public static CanvasGroup canvasGroup;
	public static RectTransform rectTransform;
	public static bool gotDragged;
	public static bool slotIsFull;
	public static bool correctPlace;
	public static bool locked;
	public static Vector2 originalPosition3;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		originalPosition3 = rectTransform.anchoredPosition;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			canvasGroup.alpha = .5f;
			canvasGroup.blocksRaycasts = false;
			gotDragged = true;	
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;
			if (!correctPlace || slotIsFull)
			{
				FindObjectOfType<SoundManager>().PlaySound("backtoplace");
				rectTransform.anchoredPosition = originalPosition3;
				gotDragged = false;
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			FindObjectOfType<SoundManager>().PlaySound("click2");
			canvasGroup.alpha = .5f;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			canvasGroup.alpha = 1f;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (!locked && !Timer.pausedGame)
		{
			throw new System.NotImplementedException();
		}
	}
}
