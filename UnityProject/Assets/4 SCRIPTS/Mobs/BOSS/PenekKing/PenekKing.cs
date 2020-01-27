using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class PenekKing : MonoBehaviour
{
    private const int V = 50;
    public GameObject slider;
    public int Lifes = 25;
    public float Xfast = 1f; // Ускоряем атаки + увеличиваем размер тычек
    public float Xslow = 3f; // Замедляем атаки + Уменьшаем размер тычек
    //---
    public float Force; //Сила прыжка босса
    public int TypeAttack = 1;
    public bool CanDoDamage = false;
    private Animator Anim;
    private Rigidbody2D Rigi;
    private GameObject Player;
    private Vector2 Vector;
    private Collider2D Col;
    public bool Active = false; //если активен вызывает атаку
    public bool LastStady = false;
    TilemapCollider2D TC1;
    TilemapCollider2D TC2;
    TilemapCollider2D TC3;
    TilemapCollider2D TC4;
    public GameObject Koren;
    public GameObject Heart;
    public float posX;
    public float posY;
    private int bushes = 0;
    public GameObject[] Phrases;
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigi = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Anim.SetBool("Attack", false);
        TC1 = GameObject.Find("solidmiddle").GetComponent<TilemapCollider2D>();
        TC2 = GameObject.Find("solidbottom").GetComponent<TilemapCollider2D>();
        TC3 = GameObject.Find("solidbottom2").GetComponent<TilemapCollider2D>();
        TC4 = GameObject.Find("solidtop").GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        if (Lifes < 1 && LastStady==false) {
            slider.SetActive(false);
            Heart.SetActive(false);
        }
        if (Lifes < 1 && Heart.GetComponent<MonsterLife>().Damaged && LastStady)
        {
            StopAllCoroutines();
            StartCoroutine(Die());
            Anim.SetBool("Died", true);
            Heart.SetActive(false);
            Phrases[3].SetActive(true);
            EventSavingSystem.UsedEvents[8] = true;
            return;
        }
        if (Lifes < 1 && Vector2.Distance(Player.transform.position, transform.position) > 9 && LastStady)
        {
            StopAllCoroutines();
            Heart.SetActive(false);
            Phrases[4].SetActive(true);
            EventSavingSystem.UsedEvents[9] = true;
            Destroy(gameObject);
            return;
        }
        if (Heart.GetComponent<MonsterLife>().Damaged)
        {
            StopAllCoroutines();
            Heart.GetComponent<MonsterLife>().Damaged = false;
            StartCoroutine(Drag(Player.transform.position));
        }
        if (Col.IsTouching(TC1) || Col.IsTouching(TC2) || Col.IsTouching(TC3) || Col.IsTouching(TC4))
        {
            Col.isTrigger = false;
        }

        if (Active)
        {
            Character1.Alert();
            Rigi.drag = 100;
            slider.SetActive(true);
            //Heart.GetComponent<MonsterLife>().HitEnable = true;
            Heart.SetActive(false);
            Active = false;
            Anim.SetBool("Attack", true);
            TypeAttack = (TypeAttack == 0) ? 1 : Random.Range(1, 5);
            if (Lifes > 1)

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
            else if (Lifes < 4 && Lifes>0)
            {
                StartCoroutine(Attack5());
            }

        }
    }
    IEnumerator SpareMe()//отступает
    {
        Heart.SetActive(false);
        Anim.SetBool("Attack", true);
        //Anim.SetInteger("Stage", 99);
        CanDoDamage = true;
        Col.isTrigger = true;
        Rigi.drag = 0;
        Anim.speed = 1;
        Rigi.AddForce((new Vector2(-16f, 1f) - (Vector2)transform.position) * Force, ForceMode2D.Impulse);
        Anim.SetInteger("Stage", 4);
        yield return new WaitForSeconds(0.5f);
        Anim.SetInteger("Stage", 1);
        Rigi.drag = V;
        CanDoDamage = false;
        Anim.SetBool("Attack", false);
        Col.isTrigger = false;
        yield return new WaitForSeconds(1f);
        Rigi.drag = 0;
        Active = true;
    }

    IEnumerator SpareMe2()//отступает
    {
        slider.SetActive(false);
        Heart.SetActive(false);
        Anim.SetBool("Attack", true);
        CanDoDamage = true;
        Col.isTrigger = true;
        Rigi.drag = 0;
        Anim.speed = 1;
        Rigi.AddForce((new Vector2(-16f, 1f) - (Vector2)transform.position) * Force, ForceMode2D.Impulse);
        Anim.SetInteger("Stage", 4);
        yield return new WaitForSeconds(0.5f);
        Anim.SetInteger("Stage", 1);
        Rigi.drag = V;
        CanDoDamage = false;
        Anim.SetBool("Attack", false);
        Col.isTrigger = false;
        Phrases[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 99);
        Rigi.drag = 100;
        LastStady = true;
        Heart.SetActive(true);
        StartCoroutine(Heart.GetComponent<MonsterLife>().DeathWait());
        try { GameObject.Find("DeleteObjects").SetActive(false); } catch { }
        Character1.NoAlert();
    }


    IEnumerator Bushed()//баш
    {
        Active = false;
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 5);
        CanDoDamage = false;
        Col.isTrigger = true;
        Rigi.drag = 100;
        Anim.speed = 1;
        Heart.SetActive(true);
        //Heart.GetComponent<MonsterLife>().HitEnable = true;
        yield return new WaitForSeconds(2f);
        Heart.SetActive(false);
        if (Lifes < 1 && LastStady == false)
        {
            StartCoroutine(SpareMe2());
            yield break;
        }

        StartCoroutine(SpareMe());
    }

    IEnumerator Attack1()//разбег
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 3);
        yield return new WaitForSeconds(1f);
        CanDoDamage = true;
        Col.isTrigger = true;
        Rigi.drag = 0;
        Anim.speed = 1;
        Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
        Anim.SetInteger("Stage", 4);
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 1);
        Rigi.drag = V;
        Anim.SetBool("Attack", false);
        Col.isTrigger = false;
        yield return new WaitForSeconds(1f);
        CanDoDamage = false;
        Rigi.drag = 0;
        Active = true;
    }

    IEnumerator Attack2() //корни преследуют
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 2);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 7 + Xfast; i++)
        {
            Instantiate(Koren, new Vector2(Player.transform.position.x+Random.Range(0f,0.05f), Player.transform.position.y + Random.Range(0f, 0.05f)), Quaternion.identity);
            yield return new WaitForSeconds(0.5f + 1 / Xfast);
        }
        Anim.SetInteger("Stage", 1);
        Heart.SetActive(true);
        yield return new WaitForSeconds(4f);
        Active = true;
    }

    IEnumerator Attack3() //корни Рандом
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 2);
        yield return new WaitForSeconds(1f);
        int X = Random.Range(3, 5);
        for (int j = 0; j < 8 + Xfast; j++)
        {
            for (int i = 0; i < X + Xfast; i++)
            {
                float Xran = Random.Range(Player.transform.position.x - 1f, Player.transform.position.x + 1f);
                float Yran = Random.Range(Player.transform.position.y - 1f, Player.transform.position.y + 1f);
                Instantiate(Koren, new Vector2(Xran, Yran), Quaternion.identity);

            }
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 1);
        Heart.SetActive(true);
        yield return new WaitForSeconds(4f);
        Active = true;
    }

    IEnumerator Attack4() //разбег получше
    {
        for (int i = 0; i < 3; i++)
        {
            Anim.SetBool("Attack", true);
            Anim.SetInteger("Stage", 3);
            yield return new WaitForSeconds(1f);
            CanDoDamage = true;
            Col.isTrigger = true;
            Rigi.drag = 0;
            Anim.speed = 1;
            Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
            Anim.SetInteger("Stage", 4);
            yield return new WaitForSeconds(1f);
            Anim.SetInteger("Stage", 1);
            Rigi.drag = V;
            Anim.SetBool("Attack", false);
            Col.isTrigger = false;
            yield return new WaitForSeconds(1f);
            CanDoDamage = false;
            Rigi.drag = 0;
        }
        Active = true;
    }

    IEnumerator Attack5() //финалочка
    {
        for (int n = 0; n < 3; n++)
        {
            int X = Random.Range(3, 5);
            Anim.SetInteger("Stage", 2);
            for (int j = 0; j < 8 + Xfast; j++)
            {
                for (int i = 0; i < X + Xfast; i++)
                {
                    float Xran = Random.Range(Player.transform.position.x - 1f, Player.transform.position.x + 1f);
                    float Yran = Random.Range(Player.transform.position.y - 1f, Player.transform.position.y + 1f);
                    Instantiate(Koren, new Vector2(Xran, Yran), Quaternion.identity);

                }
                yield return new WaitForSeconds(0.5f);
            }
            for (int m = 0; m < 3; m++)
            {
            Anim.SetInteger("Stage", 1);
            yield return new WaitForSeconds(1f);
            Rigi.drag = 0;
            Anim.SetBool("Attack", true);
            Anim.SetInteger("Stage", 3);
            yield return new WaitForSeconds(1f);
            CanDoDamage = true;
            Col.isTrigger = true;
            Rigi.drag = 0;
            Anim.speed = 1;
            Rigi.AddForce((Player.transform.position - transform.position) * (Force + 0.5f) , ForceMode2D.Impulse);
            Anim.SetInteger("Stage", 4);
            yield return new WaitForSeconds(1f);
            Anim.SetInteger("Stage", 1);
            Rigi.drag = V;
            Anim.SetBool("Attack", false);
            Col.isTrigger = false;
            Heart.SetActive(true);
            CanDoDamage = false;
            Rigi.drag = 100;
            }
            yield return new WaitForSeconds(2f);
            Heart.SetActive(false);

        }
        Active = true;
    }


    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Lifepoint") && CanDoDamage)
        {
            Character1.MinusHp(30);
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
        }
        if (Col.CompareTag("DamageForBoss") && CanDoDamage)
        {
            slider.GetComponent<Slider>().value = Lifes - 3;
            Lifes -= 3;
            //Phrases[bushes++].SetActive(true);
            StopAllCoroutines();
            StartCoroutine(Bushed());
            return;
        }
    }

    IEnumerator Die()
    {
        Rigi.drag = V;
        Col.isTrigger = false;
        Rigi.drag = 0;
        Rigi.AddForce(-(Player.transform.position - transform.position).normalized * Force, ForceMode2D.Force);
        Anim.SetInteger("Stage", 99);
        yield return new WaitForSeconds(1f);
        Rigi.drag = V;
        Rigi.simulated = false;
        yield return new WaitForSeconds(3f);
        Character1.NoAlert();
        Destroy(this);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Drag(Vector2 pos) //Отталкиваем монстра(передаём позицию врага в векторе)
    {
        Anim.SetInteger("Stage", 99);
        Lifes--;
        slider.GetComponent<Slider>().value = Lifes;
        Xslow = (Xslow > 1) ? Xslow-1 : Xslow;
        Xfast = (Xfast < 5) ? Xfast+1 : Xfast;
        int X = Player.GetComponent<Animator>().GetInteger("Vector");
        Rigi.drag = 0;
        Rigi.AddForce(((Vector2)transform.position - pos).normalized * Force, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(0.02f);
        Rigi.drag = V;    
        Rigi.drag = 100;
        //Heart.GetComponent<MonsterLife>().HitEnable = true;
        yield return new WaitForSecondsRealtime(2f);
        if(Lifes < 1)
        {
            StopAllCoroutines();
            StartCoroutine(SpareMe2());
            yield break;
        }
        StopAllCoroutines();
        StartCoroutine(SpareMe());
    }
}
