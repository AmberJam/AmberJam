﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public enum HappinessLevel { Mort, Suparat, Meh, Woohoo, NumHappyStates};

public class Character : MonoBehaviour {

    public List<Need> allNeeds;
    private string charName;
    private List<Text> displayNeeds;
    public HappinessLevel Happiness;

    private DateTime lastTimeWasNotFine;
    private bool wasFineLastTime = true;

    public int depletedUpdateRate = 10;

	// Use this for initialization
	void Start () {
        lastTimeWasNotFine = DateTime.Now;

        foreach (Need need in allNeeds)
            need.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Dani Happiness: " + Happiness);
        UpdateAllNeeds(Time.deltaTime);
	}

    public void SatisfyNeed(NeedType type)
    {
        foreach(Need need in allNeeds)
        {
            if(need.type == type)
            {
                need.SatisfyNeed();

                affectNeedsBySatisfying(need.affectedTypes);
            }
        }
    }

    void affectNeedsBySatisfying(List<AffectedNeed> affectedNeeds)
    {
        foreach(AffectedNeed affNeed in affectedNeeds)
        {
            foreach(Need need in allNeeds)
            {
                if(need.type == affNeed.type)
                {
                    need.decreaseCooldown(affNeed.affectedAmount);
                }
            }
        }
    }

    //vede daca pierzi happiness
    void UpdateAllNeeds(float dt)
    {
        bool isFine = true;

        foreach (Need need in allNeeds)
        {
            if(need.MyUpdate(dt) >= depletedUpdateRate)
            {
                need.resetLastTimeDepleted();
                if(Happiness > HappinessLevel.Mort)
                    Happiness--;
            }
            if(need.wasDepleted)
            {

                Debug.Log("I have this need: " + need.type);
                isFine = false;
            }
        }

        if(isFine)
        {
            if ((DateTime.Now - lastTimeWasNotFine).Seconds >= depletedUpdateRate)
            {
                if(Happiness < HappinessLevel.NumHappyStates - 1)
                    Happiness++;
                lastTimeWasNotFine = DateTime.Now;
            }
        }
        else
        {
            lastTimeWasNotFine = DateTime.Now;
        }
    }
    
    public bool hasAnyDepletedNeed()
    {
        foreach(Need need in allNeeds)
        {
            if (need.wasDepleted)
                return true;
        }

        return false;
    }
}
