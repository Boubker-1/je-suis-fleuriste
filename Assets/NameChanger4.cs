using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger4 : MonoBehaviour
{
    public static int NameNumber;
    public Text name;

    public void Start()
    {
        NameNumber = nameComposantes.n3;
        if (NameNumber == 0) name.text = "Tige";
        if (NameNumber == 1) name.text = "Étamine";
        if (NameNumber == 2) name.text = "Sépale";
        if (NameNumber == 3) name.text = "Pétale";
        if (NameNumber == 4) name.text = "Ovaire";
        if (NameNumber == 5) name.text = "Stigmate";
        name.text = name.text.ToUpper();
    }
}
