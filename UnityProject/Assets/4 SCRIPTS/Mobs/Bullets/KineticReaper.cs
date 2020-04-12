using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticReaper : MonoBehaviour
{
    public bool CanMove = false;
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
        Vec = (Player.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        Rigi.velocity = (CanMove) ? (Vec * ForceD) : Vector2.zero;

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
        for (int i = 0; i < 3; i++)
        {
            Anim.SetBool("Rotate", true);
            Anim.speed = 1;
            yield return new WaitForSeconds(1f);
            Vec = (Player.transform.position - transform.position).normalized;
            CanMove = true;
            Anim.speed = 2;
            yield return new WaitForSeconds(1f);
            CanMove = false;
            Anim.speed = 1;
            yield return new WaitForSeconds(0.5f);
            Anim.speed = 0;
            if(i == 2) Anim.speed = 1; 
            yield return new WaitForSeconds(0.2f);

        }
        Anim.speed = 2;
        Anim.SetBool("Rotate", false);
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
