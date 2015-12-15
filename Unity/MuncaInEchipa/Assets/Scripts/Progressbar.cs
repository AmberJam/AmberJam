using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    public List<Character> characters;
    public int maxProgress = 1000;
    public float updateOnceEveryXSeconds = 1f;
    private int currentProgress = 0;
    private DateTime lastUpdateTime;
    private RawImage fullProgressBar;
    private Vector2 initialSize;

	// Use this for initialization
	void Start () {
        currentProgress = 0;
        lastUpdateTime = DateTime.Now;
        fullProgressBar = GetComponent<RawImage>();
        initialSize = fullProgressBar.rectTransform.sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {

        recalculateBounds();

        if ((DateTime.Now - lastUpdateTime).Seconds < updateOnceEveryXSeconds)
            return;

        lastUpdateTime = DateTime.Now;

        int happinessSum = 0;
        bool wasDepleted = false;
	    foreach(Character character in characters)
        {
            happinessSum += (int)character.Happiness;
            if (character.Happiness == HappinessLevel.Mort)
                wasDepleted = true;
        }

        if (wasDepleted)
            return;

        currentProgress += happinessSum;


	}

    void recalculateBounds()
    {
        fullProgressBar.rectTransform.sizeDelta = Vector2.Lerp(new Vector2(fullProgressBar.rectTransform.sizeDelta.x, initialSize.y), new Vector2(initialSize.x * currentProgress / maxProgress , initialSize.y), (float)(DateTime.Now - lastUpdateTime).TotalSeconds);
    }
}
