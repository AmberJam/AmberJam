using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NeedsVisualIndicators : MonoBehaviour
{

    private Dictionary<NeedType, RawImage> indicatorsMap;
    private Character character;
    private float lerpSpeed = 2f;

	// Use this for initialization
	void Start ()
    {
        indicatorsMap = new Dictionary<NeedType, RawImage>();
        indicatorsMap[NeedType.Baie] = transform.FindChild("Paper").GetComponent<RawImage>();
        indicatorsMap[NeedType.Baut] = transform.FindChild("Bottle").GetComponent<RawImage>();
        indicatorsMap[NeedType.Cafea] = transform.FindChild("Coffee").GetComponent<RawImage>();
        indicatorsMap[NeedType.Mancat] = transform.FindChild("Food").GetComponent<RawImage>();
        indicatorsMap[NeedType.Fumat] = transform.FindChild("Cigs").GetComponent<RawImage>();

        character = transform.parent.GetComponent<Character>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach(Need need in character.allNeeds)
        {
            RawImage imageIndicator = indicatorsMap[need.type];
            Color color = imageIndicator.color;

            //color.a = need.wasDepleted ? 1 : 0.25f;
            float alpha = need.wasDepleted ? 1 : 0.25f;
            color = Color.Lerp(color, new Color(color.r, color.g, color.b, alpha), Time.deltaTime * lerpSpeed);
            //color.a = lerpSpeed * Time.deltaTime
            imageIndicator.color = color;
        }	
	}
}
