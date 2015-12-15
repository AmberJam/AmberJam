using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FinalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int reached = PlayerPrefs.GetInt("Reached");
        int goal = PlayerPrefs.GetInt("Goal");

        Text txt = GetComponent<Text>();

        if(reached >= goal)
        {
            txt.text = "Ai castigat\n" + reached + "/" + goal;
        }
        else
        {
            txt.text = "Ai pierdut\n" + reached +  "/" + goal;
        }
	}

}
