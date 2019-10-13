using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PenekKing : MonoBehaviour
{
    public float Force; //Сила прыжка босса
    public int TypeAttack = 0;
    public bool CanDoDamage = false;
    private Animator Anim; 
    private Rigidbody2D Rigi;
    private GameObject Player;
    private Vector2 Vector;
    private Collider2D Col;
    public bool Active = false; //если активен вызывает атаку
    TilemapCollider2D TC1;
    TilemapCollider2D TC2;
    TilemapCollider2D TC3;
    public GameObject Koren;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Anim.SetBool("Attack", false);
        TC1 = GameObject.Find("solidmiddle").GetComponent<TilemapCollider2D>();
        TC2 = GameObject.Find("solidbottom").GetComponent<TilemapCollider2D>();
        TC3 = GameObject.Find("solidbottom2").GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        if (Col.IsTouching(TC1) || Col.IsTouching(TC2) || Col.IsTouching(TC3))
        {
            Col.isTrigger = false;
        }

        if (Active)
        {
            Active = false;
            Anim.SetBool("Attack", true);
            TypeAttack = Random.Range(1, 5);
            switch (TypeAttack)
            {
                case 1:
                    StartCoroutine(Attack1());
                    break;
                case 2:
                    StartCoroutine(Attack2());
                    break;
                case 3:
                    StartCoroutine(Attack3());
                    break;
                case 4:
                    StartCoroutine(Attack4());
                    break;
            }
        }

        if (Vector2.Distance(Player.transform.position, transform.position) < 0.9f && Character1._Hit && Anim.GetBool("Attack") == false)
        {
            if (Signature.FromSide(Player, gameObject))
            {
                StartCoroutine(Die());
            }
        }

    }

    IEnumerator Attack1()//разбег
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 3);
        Character1.Alert();
        yield return new WaitForSeconds(1f);
        CanDoDamage = true;
        Col.isTrigger = true;
        Anim.speed = 1;
        Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
        Anim.SetInteger("Stage", 4);
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 1);
        Rigi.drag = 20;
        Anim.SetBool("Attack", false);
        Col.isTrigger = false;
        yield return new WaitForSeconds(1f);
        CanDoDamage = false;
        Rigi.drag = 0;
        Active = true;
        Character1.NoAlert();
    }

    IEnumerator Attack2() //корни Рандом
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 2);
        yield return new WaitForSeconds(1f);
        Character1.Alert();
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Koren, new Vector2(Player.transform.position.x, Player.transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        Anim.SetInteger("Stage", 1);
        yield return new WaitForSeconds(2f);
        Active = true;
    }

    IEnumerator Attack3() //корни преследуют
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 2);
        yield return new WaitForSeconds(1f);
        Character1.Alert();
        int X = Random.Range(3, 5);
        for (int i = 0; i < X; i++)
        {
            float Xran = Random.Range(Player.transform.position.x - 1f, Player.transform.position.x + 1f);
            float Yran = Random.Range(Player.transform.position.y - 1f, Player.transform.position.y + 1f);
            Instantiate(Koren, new Vector2(Xran, Yran), Quaternion.identity);
        }
        Anim.SetInteger("Stage", 1);
        yield return new WaitForSeconds(1f);
        Active = true;
    }

    IEnumerator Attack4() //разбег получше
    {
        for (int i = 0; i < 3; i++)
        {
            Anim.SetBool("Attack", true);
            Anim.SetInteger("Stage", 3);
            Character1.Alert();
            yield return new WaitForSeconds(1f);
            CanDoDamage = true;
            Col.isTrigger = true;
            Anim.speed = 1;
            Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
            Anim.SetInteger("Stage", 4);
            yield return new WaitForSeconds(1f);
            Anim.SetInteger("Stage", 1);
            Rigi.drag = 20;
            Anim.SetBool("Attack", false);
            Col.isTrigger = false;
            yield return new WaitForSeconds(1f);
            CanDoDamage = false;
            Rigi.drag = 0;
        }
        Active = true;
        Character1.NoAlert();
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Lifepoint") && CanDoDamage)
        {
            Character1.MinusHp();
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
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
        yield return new WaitForSeconds(3f);
        Character1.NoAlert();
        Destroy(this);
        yield return new WaitForSeconds(3f);
    }
}
