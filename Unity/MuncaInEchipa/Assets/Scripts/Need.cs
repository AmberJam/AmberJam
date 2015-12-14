using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum NeedType { NoType = 0, Fumat, Mancat, Baut, Cafea, Baie};

[Serializable]
public struct AffectedNeed
{
    public NeedType type;
    public int affectedAmount; //cu cat e afectat need-ul
};
[Serializable]
public class Need
{
    public float defaultCooldown;
    private float currentCooldown;
    public int ratioPerSec = 1;
    public NeedType type = NeedType.NoType;
    public List<AffectedNeed> affectedTypes;
    public DateTime lastTimeDepleted;

    public Need()
    {
        lastTimeDepleted = DateTime.Now;
        currentCooldown = defaultCooldown;
        wasDepleted = false;
    }

    [NonSerialized]
    public bool wasDepleted = false;

    public void decreaseCooldown(float amount)
    {
        currentCooldown -= amount;
    }
	
	// Update is called once per frame
	public int MyUpdate (float dt)
    {
        decreaseCooldown(dt * ratioPerSec);

        if (currentCooldown <= 0f)
        {
            currentCooldown = 0f;
            if(!wasDepleted)
            {
                wasDepleted = true;
                lastTimeDepleted = DateTime.Now;    
            }
        }

        if (wasDepleted)
            return (DateTime.Now - lastTimeDepleted).Seconds;
        return 0;
	}


    public void resetLastTimeDepleted()
    {
        lastTimeDepleted = DateTime.Now;
    }

    public void SatisfyNeed()
    {
        wasDepleted = false;
        currentCooldown = defaultCooldown;
    }
}
