using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{
    //private Transform Enemy;
    private GameObject Player;
    private Transform trsf;
    private int StAttType;
    public int Dmg = 20;
    private float x, y;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 2;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Vec = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Rigi.AddForce(Vec * ForceD, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Lifepoint"))
        {
            Character1.MinusHp(Dmg);
            Player.GetComponent<Character1>().DragStart(transform.position);
        }
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
