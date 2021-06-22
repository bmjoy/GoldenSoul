using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterClass : MonoBehaviour
{
    public int damage;
    public int life;
    public float alert_distance = 3f;
    public float die_force;
    public bool active = true;
    public bool died = false;
    private Animator anim;
    private Rigidbody2D rigi;
    private GameObject player;
    public GameObject monster_life;
    private Vector2 vector;
    private Collider2D col;

    void Start()
    {
        monster_life.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        anim.SetBool("Attack", false);
    }

        
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < alert_distance && active && !died)
        {
            Character1.Alert();
            active = false;
            StartCoroutine(Attack1());
        }

        if (Vector2.Distance(player.transform.position, transform.position) > alert_distance+2 && !active)
        {
            active = true;
            monster_life.SetActive(false);
            anim.SetBool("Attack", false);
            Character1.NoAlert();
            if (!died) StopAllCoroutines();
            rigi.velocity = Vector2.zero;
        }
        if (monster_life.GetComponent<MonsterLife>().Damaged)
        {
            monster_life.GetComponent<MonsterLife>().Damaged = false;
            monster_life.SetActive(false);
            StopAllCoroutines();
            died = true;
            StartCoroutine(Die());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Lifepoint"))
        {
            Character1.MinusHp(damage);
            StartCoroutine(player.GetComponent<Character1>().Drag(transform.position));
        }
    }

    

    IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Attack2()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Attack3()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Die()
    {
        rigi.drag = 20;
        col.isTrigger = false;
        rigi.drag = 0;
        rigi.AddForce(-(player.transform.position - transform.position).normalized * die_force, ForceMode2D.Force);
        GetComponent<Animator>().SetBool("Break", true);
        yield return new WaitForSeconds(1f);
        rigi.drag = 20;
        rigi.simulated = false;
        Character1.NoAlert();
        Destroy(this);
    }

}
