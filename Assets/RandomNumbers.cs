using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{
    public static int[] intArray = new int[5];

    void Start()
    {
        RandomUnique(intArray);
    }

 
    private void RandomUnique(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i] = i;
        }
        Shuffle(obj);
    }
 
    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }
}
