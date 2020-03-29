using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticWall : MonoBehaviour
{
    public float x, y;
    public bool CanMove = false;
    //private Transform Enemy;
    private GameObject Player;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 2;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Vec = new Vector2(x, y).normalized;
    }

    private void Update()
    {
        Rigi.velocity = (CanMove) ? (Vec * ForceD) : Vector2.zero;
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
