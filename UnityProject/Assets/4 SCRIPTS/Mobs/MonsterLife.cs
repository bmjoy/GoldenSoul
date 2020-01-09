using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public bool Damaged = false;
    public int Hp = 1;
    public int MinusHp = 0;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("PlayerBullet"))
        {  
            MinusHp += 1;
            Damaged = (MinusHp == Hp) ? true : false;
            Destroy(Col.gameObject);
        }
    }
}
