using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum NeedType { NoType};

[Serializable]
public struct AffectedNeed
{
    public NeedType type;
    public int affectedAmount; //cu cat e afectat need-ul
};

public class Need : MonoBehaviour {
    


    public float defaultCooldown;
    private float currentCooldown;
    public int ratioPerSec = 1;
    public NeedType type = NeedType.NoType;
    public List<AffectedNeed> affectedTypes;
    public DateTime lastTimeDepleted;

    [NonSerialized]
    public bool wasDepleted = false;

    // Use this for initialization
    void Start () {
        lastTimeDepleted = DateTime.Now;
        currentCooldown = defaultCooldown;
        affectedTypes = new List<AffectedNeed>();
        wasDepleted = false;
	}

    public void decreaseCooldown(float amount)
    {
        currentCooldown -= amount;
    }
	
	// Update is called once per frame
	public int MyUpdate (float dt) {

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
