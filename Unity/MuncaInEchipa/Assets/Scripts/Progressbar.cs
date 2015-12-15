using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    public List<Character> characters;
    public int maxProgress = 20;
    public int currentProgress = 0;
    private DateTime lastUpdateTime;
    private RawImage fullProgressBar;
    private Vector2 initialSize;
    private Vector2 initialSizeDelta;

    // Use this for initialization
    void Start () {
        currentProgress = 0;
        lastUpdateTime = DateTime.Now;
        fullProgressBar = GetComponent<RawImage>();
        //initialSize = fullProgressBar.rectTransform.sizeDelta;
        initialSize = fullProgressBar.uvRect.size;
        initialSizeDelta = fullProgressBar.rectTransform.sizeDelta;


        //fullProgressBar.rectTransform.sizeDelta = new Vector2(0, initialSize.y);
    }

    // Update is called once per frame
    void Update() {

        recalculateBounds();
    }

    public void myUpdate()
    {
        lastUpdateTime = DateTime.Now;
        int happinessSum = 0;
	    foreach(Character character in characters)
        {
            happinessSum += (int)character.Happiness;
        }
        

        currentProgress += happinessSum;


	}

    void recalculateBounds()
    {
        Vector2 newSize = Vector2.Lerp(new Vector2(fullProgressBar.uvRect.size.x, initialSize.y), 
            new Vector2(initialSize.x * currentProgress / maxProgress, initialSize.y), 
            (float)(DateTime.Now - lastUpdateTime).TotalSeconds);
        //Vector2 newSize = fullProgressBar.uvRect.size;
        fullProgressBar.uvRect = new Rect(fullProgressBar.uvRect.position, newSize);
        fullProgressBar.rectTransform.sizeDelta = Vector2.Lerp(new Vector2(fullProgressBar.rectTransform.sizeDelta.x, initialSizeDelta.y), new Vector2(initialSizeDelta.x * currentProgress / maxProgress , initialSizeDelta.y), (float)(DateTime.Now - lastUpdateTime).TotalSeconds);
    }
}
