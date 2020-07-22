using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartSlot3 : MonoBehaviour, IDropHandler
{
	public static bool empty = true;
	public static bool GoodDrop = false;
	public static int CorrectSprite, DraggedSprite;
    public Text PlaceName3;

	public void Start()
	{
        if (Composante1.currentScene == 7) CorrectSprite = Composante1.c2;
        if (Composante1.currentScene == 8) CorrectSprite = Composante1.c5;
        if (Composante1.currentScene == 9) CorrectSprite = Composante1.c8;
        if (CorrectSprite == 0) PlaceName3.text = "Pétale";
        if (CorrectSprite == 1) PlaceName3.text = "Étamine";
        if (CorrectSprite == 2) PlaceName3.text = "Stigmate";
        if (CorrectSprite == 3) PlaceName3.text = "Ovaire";
        if (CorrectSprite == 4) PlaceName3.text = "Sépale";
        if (CorrectSprite == 5) PlaceName3.text = "Tige";
        if (CorrectSprite == 6) PlaceName3.text = "Pétale";
        if (CorrectSprite == 7) PlaceName3.text = "Étamine";
        if (CorrectSprite == 8) PlaceName3.text = "Stigmate";
        if (CorrectSprite == 9) PlaceName3.text = "Ovaire";
        if (CorrectSprite == 10) PlaceName3.text = "Sépale";
        if (CorrectSprite == 11) PlaceName3.text = "Tige";
        if (CorrectSprite == 12) PlaceName3.text = "Pétale";
        if (CorrectSprite == 13) PlaceName3.text = "Étamine";
        if (CorrectSprite == 14) PlaceName3.text = "Stigmate";
        if (CorrectSprite == 15) PlaceName3.text = "Ovaire";
        if (CorrectSprite == 16) PlaceName3.text = "Sépale";
        if (CorrectSprite == 17) PlaceName3.text = "Tige";
        PlaceName3.text = PlaceName3.text.ToUpper();
	}

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
						DraggedSprite = ImageChanger1.SpriteNumber;
						print(DraggedSprite);
					}
				}
				if (DragDrop2.gotDragged)
				{
					if (!DragDrop2.locked)
					{
						DragDrop2.correctPlace = true;
						DragDrop2.locked = true;				
						DraggedSprite = ImageChanger2.SpriteNumber;
						print(DraggedSprite);
					}
				}
				if (DragDrop3.gotDragged)
				{
					if (!DragDrop3.locked)
					{
						DragDrop3.correctPlace = true;
						DragDrop3.locked = true;				
						DraggedSprite = ImageChanger3.SpriteNumber;
						print(DraggedSprite);
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
			}

		}
		if (DraggedSprite == CorrectSprite) GoodDrop = true;
	}
}
