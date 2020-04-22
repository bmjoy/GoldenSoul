using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject HpHeal;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Instantiate(HpHeal, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}
