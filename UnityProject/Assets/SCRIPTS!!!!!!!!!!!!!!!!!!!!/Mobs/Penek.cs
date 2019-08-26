using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penek : MonoBehaviour
{
    public float Force;
    private Animator Anim;
    private Rigidbody2D Rigi;
    private GameObject Player;
    private Vector2 Vector;
    private Collider2D Col;
    private bool Active = true;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Anim.SetBool("Attack", false);
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, Player.transform.position) < 2f && Active)
        {
            Active = false;
            Anim.SetBool("Attack", true);
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        Character1.Alert();
        Anim.speed = 0;
        yield return new WaitForSeconds(0.5f);
        Col.isTrigger = true;
        Anim.speed = 1;
        Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        Rigi.drag = 20;
        Anim.SetBool("Attack", false);
        yield return new WaitForSeconds(1f);
        Col.isTrigger = false;
        Rigi.drag = 0;
        Active = true;
        Character1.NoAlert();
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Lifepoint"))
        {
            Character1.MinusHp();
        }
    }
}
