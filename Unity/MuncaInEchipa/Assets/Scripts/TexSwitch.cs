using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TexSwitch : MonoBehaviour {


    public Texture onTex, offTex;
    bool lastOn = false;

    public void switchTex(bool on)
    {
        if (lastOn == on)
            return;
        lastOn = on;
        if (on)
            GetComponent<RawImage>().texture = onTex;
        else
            GetComponent<RawImage>().texture = offTex;
    }
}
