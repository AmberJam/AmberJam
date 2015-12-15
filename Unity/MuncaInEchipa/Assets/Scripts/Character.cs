using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public enum HappinessLevel { Mort, Suparat, Meh, Woohoo, NumHappyStates};

public class Character : MonoBehaviour {

    public List<Need> allNeeds;
    public HappinessLevel Happiness;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SatisfyNeed(NeedType type)
    {
        foreach(Need need in allNeeds)
        {
            if(need.type == type)
            {
                need.SatisfyNeed();

            }
        }
    }

    public bool hasAnyActiveNeed()
    {
        foreach(Need need in allNeeds)
        {
            if (need.isActive)
                return true;
        }

        return false;
    }

    public bool hasActiveNeed(NeedType needType)
    {
        foreach (Need need in allNeeds)
        {
            if (need.isActive && need.type == needType)
                return true;
        }

        return false;
    }

    public void cleanActiveNeeds()
    {
        foreach (Need need in allNeeds)
            need.SatisfyNeed();
    }

    public void decreaseHappiness(int amount = 1)
    {
        if (Happiness - amount >= 0)
            Happiness -= amount;
        else
            Happiness = 0;
    }

    public void increaseHappiness(int amount = 1)
    {
        if (Happiness + amount < HappinessLevel.NumHappyStates)
            Happiness += amount;
        else
            Happiness = HappinessLevel.NumHappyStates - 1;
    }

    public void activateNeed(NeedType needType)
    {
        foreach (Need need in allNeeds)
            if (need.type == needType)
            {
                need.isActive = true;
                return;
            }
    }

    public int numActiveNeeds()
    {
        int cnt = 0;
        foreach (Need need in allNeeds)
            if (need.isActive)
                cnt++;
        return cnt;
    }
}
