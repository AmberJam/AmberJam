using UnityEngine;
using System.Collections.Generic;

public class SatisfyButton : MonoBehaviour {

    public NeedType type;

    private List<Character> characters;

    void Start()
    {
        characters = transform.parent.GetComponent<PlayerContainer>().characters;
    }

	public void OnClick()
    {
        foreach(Character ch in characters)
        {
            ch.SatisfyNeed(type);
        }
    }
}
