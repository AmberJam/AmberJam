using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeBar : MonoBehaviour {

    public int numSeconds = 300;
    private int currentProgress = 0;
    private RawImage fullProgressBar;
    private Vector2 initialSize;
    private DateTime startTime;

    // Use this for initialization
    void Start()
    {
        startTime = DateTime.Now;
        fullProgressBar = GetComponent<RawImage>();
        initialSize = fullProgressBar.rectTransform.sizeDelta;
    }

    void Update()
    {

        fullProgressBar.rectTransform.sizeDelta = Vector2.Lerp(new Vector2(0, initialSize.y), initialSize, (float)(DateTime.Now - startTime).TotalSeconds / numSeconds);
        

    }

}
