using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Penek : MonoBehaviour
{
    bool Died = false;
    public float Force;
    private Animator Anim;
    private Rigidbody2D Rigi;
    private GameObject Player;
    public GameObject MonsterLife;
    private Vector2 Vector;
    private Collider2D Col;
    private bool Active = true;
    void Start()
    {
        MonsterLife.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Anim.SetBool("Attack", false);
    }

    void Update()
    {
        if(Vector2.Distance(Player.transform.position, transform.position) < 3f && Active && !Died)
        {
            Character1.Alert();
            Active = false;
            StartCoroutine(Attack());
        }

        if (Vector2.Distance(Player.transform.position, transform.position) > 5f && !Active)
        {
            Active = true;
            MonsterLife.SetActive(false);
            Anim.SetBool("Attack", false);
            Character1.NoAlert();
            if(!Died) StopAllCoroutines();
            Rigi.velocity = Vector2.zero;
        }
        if (MonsterLife.GetComponent<MonsterLife>().Damaged)
        {
            MonsterLife.GetComponent<MonsterLife>().Damaged = false;
            MonsterLife.SetActive(false);
            StopAllCoroutines();
            Died = true;
            StartCoroutine(Die());
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Lifepoint") && Anim.GetBool("Attack"))
        {
            Character1.MinusHp(25);
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
        }
    }


    IEnumerator Attack()
    {
        Rigi.drag = 0;
        Anim.SetBool("Attack", true);
        MonsterLife.SetActive(false);
        Anim.speed = 0;
        yield return new WaitForSeconds(1f);
        Anim.speed = 1;
        Rigi.AddForce((Player.transform.position - transform.position).normalized * Force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        Rigi.drag = 20;
        Rigi.velocity = Vector2.zero;
        Anim.SetBool("Attack", false);
        MonsterLife.SetActive(true);
        yield return new WaitForSeconds(3f);
        Rigi.drag = 0;
        if (!Died) StartCoroutine(Attack());
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "solidmiddle" && collision.gameObject.name != "solidbottom1" && collision.gameObject.name != "solidbottom2")
        {
            Col.isTrigger = true;
        }
        if (collision.gameObject.name == "solidmiddle" || collision.gameObject.name == "solidbottom1" || collision.gameObject.name == "solidbottom2"){
            Col.isTrigger = false;
            Rigi.velocity = Vector2.zero;
        }
    }

    IEnumerator Die()
    {
        Rigi.drag = 20;
        Col.isTrigger = false;
        Rigi.drag = 0;
        Rigi.AddForce(-(Player.transform.position - transform.position).normalized * Force, ForceMode2D.Force);
        GetComponent<Animator>().SetBool("Break", true);
        yield return new WaitForSeconds(1f);
        Rigi.drag = 20;
        Rigi.simulated = false;
        Character1.NoAlert();
        Destroy(this);
    }
}
