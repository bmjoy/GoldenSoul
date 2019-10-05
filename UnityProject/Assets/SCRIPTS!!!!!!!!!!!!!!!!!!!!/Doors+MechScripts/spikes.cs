using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public bool Damage;
    void OnTriggerStay2D(Collider2D Col)
    {
        if (Col.CompareTag("Player") && Damage)
        {
            Character1.Alert();
            Character1.MinusHp();
        }
    }
}
