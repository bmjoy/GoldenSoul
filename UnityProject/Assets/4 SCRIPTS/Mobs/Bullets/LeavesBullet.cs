using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesBullet : MonoBehaviour
{
    //private Transform Enemy;
    private GameObject Player;
    private bool Chase = true;
    public int Dmg = 10;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 2;
    private Rigidbody2D Rigi;
    float Deg;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Vec = (Player.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        if (Chase)
        {
            Vec = (Player.transform.position - transform.position).normalized;
            Deg = Degree.GetDegree(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        }

        Rigi.velocity = Vec * ForceD;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Deg + 90);
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
        yield return new WaitForSeconds(1f);
        Chase = false;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
