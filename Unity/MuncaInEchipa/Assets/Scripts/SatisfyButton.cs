using UnityEngine;
using System.Collections.Generic;
using System;

public class SatisfyButton : MonoBehaviour {

    public NeedType type;
    
    private List<Character> characters;

    private GameLogic gameLogic;

    void Start()
    {
        characters = transform.parent.GetComponent<PlayerContainer>().characters;
        gameLogic = GameObject.Find("Canvas").GetComponent<GameLogic>();
    }

	public void OnClick()
    {
        gameLogic.choose(type);
        /*
        foreach(Character ch in characters)
        {
            ch.SatisfyNeed(type);
        }
        */
    }
}
