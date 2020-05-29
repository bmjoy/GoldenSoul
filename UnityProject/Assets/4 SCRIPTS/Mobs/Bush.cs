using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
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
    bool alert = false;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Col = gameObject.GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        MonsterLife.SetActive(false);
        Anim.SetInteger("Vector", 0);
        StartCoroutine(Going());
    }

    // Update is called once per frame
    void Update()
    {
        Rigi.velocity = Vec * Force;
        if (Vector2.Distance(Player.transform.position, gameObject.transform.position) < 3 && IsAttacked == false && Alive)
        {
            StopAllCoroutines();
            StartCoroutine(Attack());
            Character1.Alert();
            IsAttacked = true;
            alert = true;
        }
        if (Vector2.Distance(Player.transform.position, gameObject.transform.position) > 3 && Alive)
        {          
            MonsterLife.SetActive(false);
            IsAttacked = false;
            if (alert)
            {
                StopAllCoroutines();
                Character1.NoAlert();
                StartCoroutine(Going());
                alert = false;
                Vec = Vector2.zero;
            }
        }
        if (MonsterLife.GetComponent<MonsterLife>().Damaged)
        {
            MonsterLife.GetComponent<MonsterLife>().Damaged = false;
            HP--;
            if (HP < 1)
            {
                StopAllCoroutines();
                IsAttacked = true;
                Alive = false;
                StartCoroutine(Die());
                Character1.NoAlert();
                gameObject.GetComponent<State>().dead = true;
                return;
            }
            StartCoroutine(Drag());
        }
        
    }

    IEnumerator Drag()
    {
        Rigi.AddForce(((Vector2)transform.position - (Vector2)Player.transform.position).normalized * 120);
        yield return new WaitForSecondsRealtime(0.1f);
        Rigi.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(2f);
    }

    IEnumerator Die()
    {
        Col.enabled = false;
        MonsterLife.SetActive(false);
        Anim.SetInteger("Vector", 99);
        Rigi.AddForce(((Vector2)transform.position - (Vector2)Player.transform.position).normalized * 200);
        yield return new WaitForSecondsRealtime(0.1f);
        Rigi.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(2f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        gameObject.GetComponent<ChangeOrderOnly>().enabled = false;
        Destroy(this);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Lifepoint") && Anim.GetBool("Attack"))
        {
            Character1.MinusHp(20);
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
        }
    }

    IEnumerator Attack()
    {
        Vec = Vector2.zero;
        switch (Random.Range(0, 2))
        {
            case 0:
                for (int i = 0; i < Random.Range(2, 4); i++)
                {
                    Anim.SetInteger("Vector", 3);
                    yield return new WaitForSeconds(0.3f);
                    Instantiate(Bullet, new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.3f, 0.3f)), Quaternion.identity);
                }
            break;

            case 1:
                Anim.SetInteger("Vector", 3);
                Instantiate(Bullet, new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.3f, 0.3f)), Quaternion.identity);
                Instantiate(Bullet, new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.3f, 0.3f)), Quaternion.identity);
                Instantiate(Bullet, new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.3f, 0.3f)), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                break;
        }

        Anim.SetInteger("Vector", 0);
        yield return new WaitForSeconds(1f);
        MonsterLife.SetActive(true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Attack());
        MonsterLife.SetActive(false);
    }

    IEnumerator Going()
    {
        MonsterLife.SetActive(false);
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vec = new Vector2(x, y).normalized;

        if ((transform.position.y - Vec.y)>= transform.position.y)
        {
            Anim.SetInteger("Vector", 1);
        }
        else
        {
            Anim.SetInteger("Vector", 2);
        }
        
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Vector", 0);
        Vec = Vector2.zero;
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        StartCoroutine(Going());
    }
}
