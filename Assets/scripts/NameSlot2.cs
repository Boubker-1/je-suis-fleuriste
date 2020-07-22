using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NameSlot2 : MonoBehaviour, IDropHandler
{
	public static bool empty = true;
	public static bool GoodDrop = false;
	public static int CorrectName = 1, DraggedName;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			if (empty)
			{
				FindObjectOfType<SoundManager>().PlaySound("completehalf");
				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
				empty = false;
				if (DragDrop1.gotDragged)
				{
					if (!DragDrop1.locked)
					{
						DragDrop1.correctPlace = true;
						DragDrop1.locked = true;
						DraggedName = NameChanger1.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 1;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}
				if (DragDrop2.gotDragged)
				{
					if (!DragDrop2.locked)
					{
						DragDrop2.correctPlace = true;
						DragDrop2.locked = true;				
						DraggedName = NameChanger2.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 2;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}
				if (DragDrop3.gotDragged)
				{
					if (!DragDrop3.locked)
					{
						DragDrop3.correctPlace = true;
						DragDrop3.locked = true;				
						DraggedName = NameChanger3.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 3;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}

				if (DragDrop4.gotDragged)
				{
					if (!DragDrop4.locked)
					{
						DragDrop4.correctPlace = true;
						DragDrop4.locked = true;
						DraggedName = NameChanger4.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 4;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}
				if (DragDrop5.gotDragged)
				{
					if (!DragDrop5.locked)
					{
						DragDrop5.correctPlace = true;
						DragDrop5.locked = true;				
						DraggedName = NameChanger5.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 5;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}
				if (DragDrop6.gotDragged)
				{
					if (!DragDrop6.locked)
					{
						DragDrop6.correctPlace = true;
						DragDrop6.locked = true;				
						DraggedName = NameChanger6.NameNumber;
//						nameComposantes.FromClass[nameComposantes.index] = 6;
//						if (nameComposantes.index < 5) nameComposantes.index++;
						print(DraggedName);
					}
				}
			}
			else
			{
				if (DragDrop1.gotDragged)
				{
					DragDrop1.slotIsFull = true;			
				}				
				if (DragDrop2.gotDragged)
				{
					DragDrop2.slotIsFull = true;			
				}				
				if (DragDrop3.gotDragged)
				{
					DragDrop3.slotIsFull = true;			
				}				
				if (DragDrop4.gotDragged)
				{
					DragDrop4.slotIsFull = true;			
				}				
				if (DragDrop5.gotDragged)
				{
					DragDrop5.slotIsFull = true;			
				}				
				if (DragDrop6.gotDragged)
				{
					DragDrop6.slotIsFull = true;			
				}				
			}

		}
		if (DraggedName == CorrectName) GoodDrop = true;
	}
}
