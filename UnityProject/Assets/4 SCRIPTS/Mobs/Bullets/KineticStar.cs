using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticStar : MonoBehaviour
{
    private GameObject Player;
    private Animator Anim;
    public int Dmg = 10;
    Vector2 Vec;
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
        yield return new WaitForSeconds(10f);
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
