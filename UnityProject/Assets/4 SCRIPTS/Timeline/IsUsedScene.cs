using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsUsedScene : MonoBehaviour
{
    public int NumScene; // номер катсцены
    public bool DisAppear = true;
    private void Start()
    {
        if (EventSavingSystem.UsedEvents[NumScene] == true && DisAppear == true)
        {
            Destroy(gameObject);
        }

        if (EventSavingSystem.UsedEvents[NumScene] == false && DisAppear == false)
        {
            Destroy(gameObject);
        }
    }
}
