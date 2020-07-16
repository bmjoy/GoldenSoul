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
    bool IsPlayerExited = true;
    //private Transform lampPos;
    private Renderer rend;
    private bool Enabled = false;
    void Awake() //Вход в скрипт
    {
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
        totem = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        Wall.counttoop = 0;
    }
    void Update() //Обновление скрипта
    {
        if (Vector2.Distance(transform.position, playerPos.position) < 0.9f)
        {
            Character1.IndicatorOn();
            IsPlayerExited = false;
            if ((Input.GetKeyDown(KeyCode.E) || moveScript.activate && !Enabled))
            {
                totem.SetBool("fired", true);
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(7, 0.8f);
                Enabled = true;
                Wall.counttoop = Wall.counttoop * 10 + key;
                if(Wall.countconst == Wall.counttoop)
                {
                    GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(10, 0.8f);
                    Wall.Open();
                }
                moveScript.activate = false;
                return;
            }

        }
        else if (!IsPlayerExited)
        {
            IsPlayerExited = true;
            Character1.IndicatorOff();
        }
        if (Vector2.Distance(transform.position, playerPos.position) < 0.9f)
        {
            Character1.IndicatorOn();
            IsPlayerExited = false;
            if ((Input.GetKeyDown(KeyCode.E) || moveScript.activate && Enabled))
            {
                totem.SetBool("fired", false);
                Wall.counttoop = Wall.counttoop / 10;
                Enabled = false;
                moveScript.activate = false;
                return;
            }

        }
        else if (!IsPlayerExited)
        {
            IsPlayerExited = true;
            Character1.IndicatorOff();
        }
        ChangeOrder.ChangeLayerOrder(rend, transform, playerPos);
    }
}