using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum NeedType { NoType = 0, Fumat, Mancat, Baut, Cafea, Baie, NumTypes};

[Serializable]
public class Need
{
    public NeedType type = NeedType.NoType;
    public bool isActive;

    public void SatisfyNeed()
    {
        isActive = false;
    }
}
