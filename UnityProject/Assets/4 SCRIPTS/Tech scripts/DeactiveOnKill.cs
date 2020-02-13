using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOnKill : MonoBehaviour
{
    public State[] States;
    public GameObject ObjectDeactive;
    // Update is called once per frame
    void Update()
    {
        foreach (State S in States)
        {
            if (S.dead == false) return;
        }
        ObjectDeactive.SetActive(false);
    }
}
