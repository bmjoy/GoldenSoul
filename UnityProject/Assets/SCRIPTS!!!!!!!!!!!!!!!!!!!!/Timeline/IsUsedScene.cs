using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsUsedScene : MonoBehaviour
{
    public int NumScene; // номер катсцены
    private void Awake()
    {
        if (EventSavingSystem.UsedCutscenes[NumScene] == true)
        {
            Destroy(gameObject);
        }
    }
}
