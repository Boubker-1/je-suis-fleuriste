using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInZoomText : MonoBehaviour
{

	public CanvasGroup canvasGroup;
	public float alpha;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
