using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnStep : MonoBehaviour
{
    bool Trigger = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Character1>().DragBack());
            Character1.Alert();
            Character1.MinusHp(15);
        }
    }
}
