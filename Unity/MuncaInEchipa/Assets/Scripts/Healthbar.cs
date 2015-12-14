using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private Character character;
    private RawImage happyBar;

    private float originalSize;
    private float barSpeed = 1f;

	// Use this for initialization
	void Start () {
        character = transform.parent.GetComponent<Character>();
        happyBar = transform.FindChild("Filled").GetComponent<RawImage>();

        originalSize = happyBar.rectTransform.sizeDelta.y;
        float stepHeight = originalSize / (float)HappinessLevel.NumHappyStates;
        //barSpeed = stepHeight / character.depletedUpdateRate;


    }
	
	// Update is called once per frame
	void Update () {
        float happyLevel = (float)character.Happiness / ((float)HappinessLevel.NumHappyStates - 1);

        happyBar.color = Color.Lerp(Color.red, Color.green, happyLevel);

        //happyBar.rectTransform.sizeDelta = new Vector2(happyBar.rectTransform.sizeDelta.x, originalSize * happyLevel);
        float currentHeight = happyBar.rectTransform.sizeDelta.y;
        happyBar.rectTransform.sizeDelta = Vector2.Lerp(happyBar.rectTransform.sizeDelta, 
            new Vector2(happyBar.rectTransform.sizeDelta.x, originalSize * happyLevel), Time.deltaTime * barSpeed);
        //happyBar.texture.height = (int)(originalSize * happyLevel);
    }
}
