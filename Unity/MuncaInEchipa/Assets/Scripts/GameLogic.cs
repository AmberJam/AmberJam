using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameLogic : MonoBehaviour
{
    public float turnDuration = 10f;
    public DateTime lastTurnTime;

    public List<Character> characters;

	void Start ()
    {
        lastTurnTime = DateTime.Now;
        shuffleBoard();

    }
	
	void Update ()
    {
	    if ((DateTime.Now - lastTurnTime).TotalSeconds >= turnDuration)
        {
            lastTurnTime = DateTime.Now;
            foreach (Character character in characters)
            {
                character.decreaseHappiness();
            }
            shuffleBoard();
        }
	}

    void shuffleBoard()
    {
        lastTurnTime = DateTime.Now;
        foreach (Character character in characters)
            character.cleanActiveNeeds();

        NeedType random_type = (NeedType)UnityEngine.Random.Range(0, (float)NeedType.NumTypes - 1);
        List<int> used = new List<int>();
        for (int j = 0; j < 3; j++)
        {
            int rand = UnityEngine.Random.Range(0, characters.Count - 1);
            while (used.Contains(rand))
            {
                rand++;
                if (rand >= characters.Count - 1)
                    rand = 0;
            }
            characters[rand].activateNeed(random_type);
            used.Add(rand);
        }

        // a 2 a formatie
        NeedType random_type2 = (NeedType)UnityEngine.Random.Range(0, (float)NeedType.NumTypes - 1);
        while (random_type2 == random_type)
        {
            random_type2++;
            if (random_type2 >= NeedType.NumTypes)
                random_type2 = 0;
        }
        used.Clear();
        for (int j = 0; j < 3; j++)
        {
            int rand = UnityEngine.Random.Range(0, characters.Count - 1);
            while (used.Contains(rand))
            {
                rand++;
                if (rand >= characters.Count - 1)
                    rand = 0;
            }
            characters[rand].activateNeed(random_type);
            used.Add(rand);
        }

        // a 3 a formatie
        NeedType random_type3 = (NeedType)UnityEngine.Random.Range(0, (float)NeedType.NumTypes - 1);
        while (random_type3 == random_type || random_type3 == random_type2)
        {
            random_type3++;
            if (random_type3 >= NeedType.NumTypes)
                random_type3 = 0;
        }
        int cnt = 0;
        used.Clear();
        for (int i = 0; i < characters.Count; i++)
            if (!characters[i].hasAnyActiveNeed())
            {
                characters[i].activateNeed(random_type3);
                used.Add(i);
                cnt++;
            }

        for (int i = cnt; i < 3; i++)
        {
            int rand = UnityEngine.Random.Range(0, characters.Count - 1);
            while (used.Contains(rand))
            {
                rand++;
                if (rand >= characters.Count - 1)
                    rand = 0;
            }
            characters[rand].activateNeed(random_type);
            used.Add(rand);
        }
    }

    public void choose(NeedType needType)
    {
        foreach(Character character in characters)
        {
            if (character.numActiveNeeds() > 1 && character.hasActiveNeed(needType))
                continue;

            if (character.hasAnyActiveNeed() && !character.hasActiveNeed(needType))
            {
                character.decreaseHappiness();
                continue;
            }

            if (character.numActiveNeeds() == 1 && character.hasActiveNeed(needType))
                character.increaseHappiness();

        }

        shuffleBoard();
    }
}
