using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticBullet1 : MonoBehaviour
{
    //private Transform Enemy;
    private GameObject Player;
    private bool Start_Bullet = false;
    public int Dmg = 10;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 6;
    private Rigidbody2D Rigi;
    float Deg;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        StartCoroutine(WaitPlee());
        Vec = (Player.transform.position - transform.position).normalized;
        Deg = Degree.GetDegree(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Deg - 90);
    }

    private void Update()
    {
        if (Start_Bullet == false) return;
        Rigi.velocity = Vec * ForceD;
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
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator WaitPlee()
    {
        yield return new WaitForSeconds(1f);
        Start_Bullet = true;
    }
}