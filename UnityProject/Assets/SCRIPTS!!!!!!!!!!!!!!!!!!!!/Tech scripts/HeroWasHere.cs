using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWasHere : MonoBehaviour
{
    public bool Destroy  = true;
    private void Awake()
    {
        if(EventSavingSystem.HeroWasHere[EventSavingSystem.ThisLvl] == true)
        if (Destroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
