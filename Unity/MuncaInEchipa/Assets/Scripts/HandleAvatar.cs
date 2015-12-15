using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandleAvatar : MonoBehaviour {

    public List<Texture> avatars;

    Character associatedChar;
    UnityEngine.UI.RawImage rawImg;

    void Start()
    {
        rawImg = transform.FindChild("Fata").GetComponent<UnityEngine.UI.RawImage>();
        associatedChar = GetComponent<Character>();
    }

	// Update is called once per frame
	void Update () {
        if (associatedChar.Happiness == HappinessLevel.Mort)
            rawImg.texture = avatars[0];
        else if (associatedChar.Happiness == HappinessLevel.Suparat)
            rawImg.texture = avatars[1];
        else if (associatedChar.Happiness == HappinessLevel.Meh)
            rawImg.texture = avatars[2];
        else if (associatedChar.Happiness == HappinessLevel.Woohoo)
            rawImg.texture = avatars[3];
	}
}
