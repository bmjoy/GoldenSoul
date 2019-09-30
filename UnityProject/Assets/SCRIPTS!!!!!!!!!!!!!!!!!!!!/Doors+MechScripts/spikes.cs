using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public bool Damage;
    void OnTriggerExit2D(Collider2D Col)
    {
        if (!Col.CompareTag("Player"))
        {
            Character1.NoAlert();
        }
    }
    void OnTriggerStay2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            Character1.Alert();
        }
        if (Col.CompareTag("Lifepoint") && Damage)
        {
            Character1.MinusHp();
        }
    }
}
