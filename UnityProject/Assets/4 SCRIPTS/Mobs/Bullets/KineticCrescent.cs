using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticCrescent : MonoBehaviour
{
    public bool CanMove = false;
    //private Transform Enemy;
    private GameObject Player;
    private Animator Anim;
    public int Dmg = 20;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 3;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Vec = Vector2.zero;
    }

    private void Update()
    {
        Rigi.velocity = (Vec * ForceD);

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
        Vec = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        Anim.speed = 1;
        //Anim.SetBool("Rotate", true);
        yield return new WaitForSeconds(0.5f);
        Anim.speed = 2;
        Vec = (Player.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(3f);
        Vec = -Vec;
        yield return new WaitForSeconds(3f);
        //Anim.SetBool("Rotate", false);
        Vec = Vector2.zero;
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}