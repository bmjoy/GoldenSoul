﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class PenekKing : MonoBehaviour
{
    public GameObject slider;
    public int Lifes = 5;
    public float Xfast = 1f; // Ускоряем атаки + увеличиваем размер тычек
    public float Xslow = 3f; // Замедляем атаки + Уменьшаем размер тычек
    //---
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
    public GameObject Heart;
    public float posX;
    public float posY;
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
    }

    void Update()
    {
        if (Lifes < 1)
        {
        }
        if (Col.IsTouching(TC1) || Col.IsTouching(TC2) || Col.IsTouching(TC3))
        {
            Col.isTrigger = false;
        }

        if (Active)
        {
            Heart.SetActive(false);
            Active = false;
            Anim.SetBool("Attack", true);
            TypeAttack = Random.Range(1, 7);
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
                        StartCoroutine(Attack3());
                        break;
                    case 5:
                        StartCoroutine(Attack4());
                        break;
                    case 6:
                        StartCoroutine(Attack2());
                        break;
                }
            else if (Lifes == 1)
            {
                StartCoroutine(Attack5());
            }
            else if (Lifes < 1)
            {
                Character1.NoAlert();
                Anim.SetInteger("Stage", 99);
                slider.SetActive(false);
                if (Vector2.Distance(Player.transform.position, transform.position) < 1f && Character1._Hit)
                    {
                    Anim.SetBool("Died", true);
                    Destroy(this);
                }
            }
        }
    }
    IEnumerator SpareMe()//разбег
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 99);
        yield return new WaitForSeconds(0.5f);
        CanDoDamage = true;
        Col.isTrigger = true;
        Rigi.drag = 0;
        Anim.speed = 1;
        Rigi.AddForce((new Vector2(-16f, 1f) - (Vector2)transform.position) * Force, ForceMode2D.Impulse);
        Anim.SetInteger("Stage", 4);
        CanDoDamage = false;
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 1);
        Rigi.drag = 20;
        Anim.SetBool("Attack", false);
        Col.isTrigger = false;
        yield return new WaitForSeconds(1f);
        Rigi.drag = 0;
        Active = true;
    }

    IEnumerator Attack1()//разбег
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 3);
        Character1.Alert();
        yield return new WaitForSeconds(1f);
        CanDoDamage = true;
        Col.isTrigger = true;
        Rigi.drag = 0;
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

    IEnumerator Attack2() //корни преследуют
    {
        Anim.SetBool("Attack", true);
        Anim.SetInteger("Stage", 2);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 7 + Xfast; i++)
        {
            Instantiate(Koren, new Vector2(Player.transform.position.x, Player.transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(0.5f + 1 / Xfast);
        }
        Anim.SetInteger("Stage", 1);
        Heart.SetActive(true);
        yield return new WaitForSeconds(2f);
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
        yield return new WaitForSeconds(2f);
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
            Rigi.drag = 0;
            Anim.speed = 1;
            Rigi.AddForce((Player.transform.position - transform.position) * Force, ForceMode2D.Impulse);
            Anim.SetInteger("Stage", 4);
            yield return new WaitForSeconds(1f);
            Anim.SetInteger("Stage", 1);
            Rigi.drag = 20;
            Anim.SetBool("Attack", false);
            Col.isTrigger = false;
            yield return new WaitForSeconds(1f);
            Character1.NoAlert();
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
            Anim.SetInteger("Stage", 1);
            yield return new WaitForSeconds(1f);
            Anim.SetBool("Attack", true);
            Anim.SetInteger("Stage", 3);
            Character1.Alert();
            yield return new WaitForSeconds(1f);
            CanDoDamage = true;
            Col.isTrigger = true;
            Rigi.drag = 0;
            Anim.speed = 1;
            Rigi.AddForce((Player.transform.position - transform.position) * (Force + 0.5f) , ForceMode2D.Impulse);
            Anim.SetInteger("Stage", 4);
            Character1.NoAlert();
            yield return new WaitForSeconds(1f);
            Anim.SetInteger("Stage", 1);
            Rigi.drag = 20;
            Anim.SetBool("Attack", false);
            Col.isTrigger = false;
            Heart.SetActive(true);
            CanDoDamage = false;
            yield return new WaitForSeconds(3f);
            Heart.SetActive(false);
            Rigi.drag = 0;
        }
        Active = true;
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

    public IEnumerator Drag(Vector2 pos) //Отталкиваем монстра(передаём позицию врага в векторе)
    {
        Lifes--;
        slider.GetComponent<Slider>().value = Lifes;
        Xslow = (Xslow > 1) ? Xslow-1 : Xslow;
        Xfast = (Xfast < 5) ? Xfast+1 : Xfast;
        int X = Player.GetComponent<Animator>().GetInteger("Vector");
        Rigi.drag = 0;
        Rigi.AddForce(((Vector2)transform.position - pos).normalized * 2f, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(0.02f);
        Rigi.drag = 20;
        Heart.SetActive(false);
        Heart.GetComponent<MonsterLife>().HitEnable = true;
        StopAllCoroutines();
        StartCoroutine(SpareMe());
    }
}
