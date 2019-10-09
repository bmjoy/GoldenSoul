using UnityEngine;
using System.Collections;

public class Lampon : MonoBehaviour
{
    private Animator lamp;
    private Transform playerPos;
    //private Transform lampPos;
    private Renderer lamprend;
    private bool lampEnabled = false;
    void Awake() //Вход в скрипт
    {
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
        lamp = GetComponent<Animator>();
        lamprend = GetComponent<Renderer>();
        lamp.SetBool("on", true);
    }
}