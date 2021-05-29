using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticRapier : MonoBehaviour
{
    public bool CanMove = false;
    //private Transform Enemy;
    private GameObject Player;
    private Animator Anim;
    public int Dmg = 25;
    Vector2 Vec;
    float Deg;
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
    }

    private void Update()
    {
        Deg = Degree.GetDegree(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        gameObject.transform.rotation = (!CanMove) ? Quaternion.Euler(0, 0, Deg - 90) : gameObject.transform.rotation;
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
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Vec = -(Player.transform.position - transform.position).normalized;
            CanMove = true;
            yield return new WaitForSeconds(0.1f);
            CanMove = false;
            yield return new WaitForSeconds(0.5f);
            CanMove = true;
            Vec = (Player.transform.position - transform.position).normalized;
            yield return new WaitForSeconds(1f);

            CanMove = false;
        }
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
