using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Col)
    {
        bool active = true;
        if (Col.CompareTag("Player") && active )
        {
            active = false;
            StartCoroutine(Level.ThisLevel());
        }
    }
}
