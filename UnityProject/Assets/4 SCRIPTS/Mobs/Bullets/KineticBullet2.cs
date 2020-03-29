using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticBullet2 : MonoBehaviour
{
    public bool CanMove = true;
    //private Transform Enemy;
    private GameObject Player;
    private Animator Anim;
    private bool Start_Bullet = false;
    public int Dmg = 25;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 2;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Vec = new Vector2(Random.Range(-1,1) , Random.Range(-1, 1)).normalized;
    }

    private void Update()
    {
        Rigi.velocity = (CanMove) ?  (Vec * ForceD) : Vector2.zero;
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
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2f);
            Vec = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        }
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
