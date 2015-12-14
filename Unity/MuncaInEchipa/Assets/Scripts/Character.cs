using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public enum HappinessLevel { Mort, Suparat, Meh, Woohoo};

public class Character : MonoBehaviour {

    public List<Need> allNeeds;
    private string charName;
    private List<Text> displayNeeds;
    public HappinessLevel Happiness;

    public int depletedUpdateRate = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAllNeeds(Time.deltaTime);
	}

    void SatisfyNeed(NeedType type)
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
        foreach (Need need in allNeeds)
        {
            if(need.MyUpdate(dt) >= depletedUpdateRate)
            {
                need.resetLastTimeDepleted();
                if(Happiness > HappinessLevel.Mort)
                    Happiness--;
            }
        }
    }
}
