using UnityEngine;
using System;
using System.Globalization;
using System.Collections;

public class Totemon : MonoBehaviour
{
    public int key; //каждый тотем хранит конкретное значение для составления кода 
    public bool ison;
    public int num;
    private Animator totem;
    private Transform playerPos;
    //private Transform lampPos;
    private Renderer rend;
    private bool Enabled = false;
    void Awake() //Вход в скрипт
    {
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
        totem = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }
    void Update() //Обновление скрипта
    {
        if (Vector2.Distance(transform.position, playerPos.position) < 0.9f && (Input.GetKeyDown(KeyCode.E) ||  moveScript.activate && !Enabled))
        {
            totem.SetBool("fired", true);
            Enabled = true;
            Wall.counttoop = Wall.counttoop * 10 + key;
            if(Wall.countconst == Wall.counttoop)
            {
                Wall.Open();
            }
            moveScript.activate = false;
            return;
        }
        if (Vector2.Distance(transform.position, playerPos.position) < 0.9f && (Input.GetKeyDown(KeyCode.E) || moveScript.activate && Enabled))
        {
            totem.SetBool("fired", false);
            Wall.counttoop = Wall.counttoop / 10;
            Enabled = false;
            moveScript.activate = false;
            return;
        }
            ChangeOrder.ChangeLayerOrder(rend, transform, playerPos);
    }
}