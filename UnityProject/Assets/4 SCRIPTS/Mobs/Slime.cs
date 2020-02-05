using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int HP = 5;
    int Count = 0;
    public GameObject Bullet;
    GameObject Player;
    Animator Anim;
    Collider2D Col;
    Vector2 Vec;
    Rigidbody2D Rigi;
    public GameObject MonsterLife;
    public float Force;
    bool Alive = true;
    bool IsAttacked = false;
    bool alert = true;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Col = gameObject.GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        MonsterLife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Player.transform.position, gameObject.transform.position) < 4 && IsAttacked == false && Alive)
        {
            Character1.Alert();
            StartCoroutine(Jump());
            IsAttacked = true;
            alert = true;
        }
        if (Vector2.Distance(Player.transform.position, gameObject.transform.position) > 5 && Alive)
        {
            MonsterLife.SetActive(false);
            Anim.SetInteger("Vector", 1);
            StopAllCoroutines();
            IsAttacked = false;
            if (alert) {
                Character1.NoAlert();
                alert = false;
            }
        }
        if (MonsterLife.GetComponent<MonsterLife>().Damaged)
        {
            MonsterLife.GetComponent<MonsterLife>().Damaged = false;
            HP--;
            if(HP < 1)
            {
                StopAllCoroutines();
                IsAttacked = true;
                Alive = false;
                StartCoroutine(Die());
                Character1.NoAlert();
                return;
            }
            StartCoroutine(Drag());
        }
    }

    IEnumerator Jump()
    {
        Count++;
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vec = new Vector2(x, y).normalized;
        Anim.SetInteger("Vector", 1);
        yield return new WaitForSeconds(1f);
        MonsterLife.SetActive(false);
        Col.isTrigger = true;
        Anim.SetInteger("Vector", 3);
        yield return new WaitForSeconds(0.2f);
        Rigi.AddForce(Vec * Force);
        yield return new WaitForSeconds(0.5f);
        Anim.SetInteger("Vector", 1);
        for(int i = 0; i < (int)Random.Range(3,6); i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        if(Count >= 2)
        {
            Count = 0;
            MonsterLife.SetActive(true);
        }
        Col.isTrigger = false;
        Rigi.velocity = Vector2.zero;
        yield return new WaitForSeconds(2f);
        IsAttacked = false;
    }

    IEnumerator Die()
    {
        Col.enabled = false;
        MonsterLife.SetActive(false);
        Anim.SetInteger("Vector", 99);
        StartCoroutine(SlimeOnDie());
        Rigi.AddForce(((Vector2)transform.position - (Vector2)Player.transform.position).normalized * Force);
        yield return new WaitForSecondsRealtime(0.1f);
        Rigi.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(2f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        gameObject.GetComponent<ChangeOrderOnly>().enabled = false;
        Destroy(this);
    }

    IEnumerator Drag()
    {
        Rigi.AddForce(((Vector2)transform.position - (Vector2)Player.transform.position).normalized * Force);
        yield return new WaitForSecondsRealtime(0.1f);
        Rigi.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(2f);
    }

    IEnumerator SlimeOnDie()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Rigi.velocity = Vector2.zero;
        }
    }
}
