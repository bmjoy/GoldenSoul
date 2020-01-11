using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public bool Damaged = false;


    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("PlayerBullet"))
        {
            Damaged = true;
            Destroy(Col.gameObject);
        }
    }
}
