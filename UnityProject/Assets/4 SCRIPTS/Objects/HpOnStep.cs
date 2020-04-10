using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpOnStep : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lifepoint"))
        {
            Character1.HP += 33;
            if (Character1.HP > 100) Character1.HP = 100;
            Destroy(gameObject);
        }
    }
}
