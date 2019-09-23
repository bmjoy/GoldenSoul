using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Character1 : MonoBehaviour
{
    public GameObject Life;
    static GameObject _Life;
    public GameObject Lifepoint;
    static GameObject _Lifepoint;
    private GameObject Player;
    public bool Hit;
    static public bool _Hit;

    public static int AttackDirection = 1;
    static int AlertPoints = 0;//Нужно для появления индикатора

    private void Awake()
    {
        try
        {
        if(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl] != 0)
        transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
        }
        catch { }

    }

    private void Start()
    {
        _Life = Life;
        _Lifepoint = Lifepoint;
        _Hit = Hit;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        _Hit = Hit;
        if (Input.GetKeyDown(KeyCode.G)) print("a");
        try
        {
            if (_Life.GetComponent<Animator>().GetInteger("Stage") < 2) //Смерть
            {
            }
        }
        catch { }
        AttackDirection = Player.GetComponent<Animator>().GetInteger("Vector");
    }

    static public void MinusHp()
    {
        if(_Life.GetComponent<Animator>().GetInteger("Stage") > 0)
        {
            _Life.GetComponent<Animator>().SetInteger("Stage", (_Life.GetComponent<Animator>().GetInteger("Stage") - 1));
        }
        
    }

    static public void Alert()
    {
        AlertPoints++;
        _Lifepoint.SetActive(true);
    }
    static public void NoAlert()
    {
        AlertPoints--;
        if (AlertPoints < 1) _Lifepoint.SetActive(false);
    }
}
