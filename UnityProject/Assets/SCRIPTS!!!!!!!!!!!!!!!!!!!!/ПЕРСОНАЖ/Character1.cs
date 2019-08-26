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

    static int AttackVector = 1;
    static int AlertPoints = 0;//Нужно для появления индикатора

    private void Start()
    {
        _Life = Life;
        _Lifepoint = Lifepoint;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

    if (_Life.GetComponent<Animator>().GetInteger("Stage") < 2)
    {
        Debug.Log("Death");
    }
        AttackVector =(Player.GetComponent<Animator>().GetInteger("vector") != 6) ? Player.GetComponent<Animator>().GetInteger("vector") : AttackVector;
    }

    static public void MinusHp()
    {
        _Life.GetComponent<Animator>().SetInteger("Stage", (_Life.GetComponent<Animator>().GetInteger("Stage") - 1));
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
