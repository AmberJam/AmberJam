using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private Character character;
    private RawImage happyBar;

    private float originalSize;

	// Use this for initialization
	void Start () {
        character = transform.parent.GetComponent<Character>();
        happyBar = transform.FindChild("Filled").GetComponent<RawImage>();

        originalSize = happyBar.rectTransform.sizeDelta.y;
	}
	
	// Update is called once per frame
	void Update () {
        float happyLevel = (float)character.Happiness / ((float)HappinessLevel.NumHappyStates - 1);

        happyBar.color = Color.Lerp(Color.red, Color.green, happyLevel);

        happyBar.rectTransform.sizeDelta = new Vector2(happyBar.rectTransform.sizeDelta.x, originalSize * happyLevel);
        //happyBar.texture.height = (int)(originalSize * happyLevel);
	}
}
