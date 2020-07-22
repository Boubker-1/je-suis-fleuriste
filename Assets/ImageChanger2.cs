using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger2 : MonoBehaviour
{

    public static int SpriteNumber;
    private Image img;
    private Sprite sprite0, sprite1, sprite2, sprite3, sprite4, sprite5;
    private Sprite sprite6, sprite7, sprite8, sprite9, sprite10, sprite11;
    private Sprite sprite12, sprite13, sprite14, sprite15, sprite16, sprite17;

    public void Start()
    {
        img = this.GetComponent<Image>();
        if (Composante1.currentScene == 7) SpriteNumber = Composante1.n1;
        if (Composante1.currentScene == 8) SpriteNumber = Composante1.n4;
        if (Composante1.currentScene == 9) SpriteNumber = Composante1.n7;
        sprite0 = Resources.Load<Sprite>("Pétale1");
        sprite1 = Resources.Load<Sprite>("Étamine1");
        sprite2 = Resources.Load<Sprite>("Stigmate1");
        sprite3 = Resources.Load<Sprite>("Ovaire1");
        sprite4 = Resources.Load<Sprite>("Sépale1");
        sprite5 = Resources.Load<Sprite>("Tige1");
        sprite6 = Resources.Load<Sprite>("Pétale2");
        sprite7 = Resources.Load<Sprite>("Étamine2");
        sprite8 = Resources.Load<Sprite>("Stigmate2");
        sprite9 = Resources.Load<Sprite>("Ovaire2");
        sprite10 = Resources.Load<Sprite>("Sépale2");
        sprite11 = Resources.Load<Sprite>("Tige2");
        sprite12 = Resources.Load<Sprite>("Pétale3");
        sprite13 = Resources.Load<Sprite>("Étamine3");
        sprite14 = Resources.Load<Sprite>("Stigmate3");
        sprite15 = Resources.Load<Sprite>("Ovaire3");
        sprite16 = Resources.Load<Sprite>("Sépale3");
        sprite17 = Resources.Load<Sprite>("Tige3");
        if (SpriteNumber == 0) img.sprite = sprite0;
        if (SpriteNumber == 1) img.sprite = sprite1;
        if (SpriteNumber == 2) img.sprite = sprite2;
        if (SpriteNumber == 3) img.sprite = sprite3;
        if (SpriteNumber == 4) img.sprite = sprite4;
        if (SpriteNumber == 5) img.sprite = sprite5;
        if (SpriteNumber == 6) img.sprite = sprite6;
        if (SpriteNumber == 7) img.sprite = sprite7;
        if (SpriteNumber == 8) img.sprite = sprite8;
        if (SpriteNumber == 9) img.sprite = sprite9;
        if (SpriteNumber == 10) img.sprite = sprite10;
        if (SpriteNumber == 11) img.sprite = sprite11;
        if (SpriteNumber == 12) img.sprite = sprite12;
        if (SpriteNumber == 13) img.sprite = sprite13;
        if (SpriteNumber == 14) img.sprite = sprite14;
        if (SpriteNumber == 15) img.sprite = sprite15;
        if (SpriteNumber == 16) img.sprite = sprite16;
        if (SpriteNumber == 17) img.sprite = sprite17;
    }
}
