using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestopen : MonoBehaviour
{
    private Animator chest;
    private Transform playerPos;

    void Awake() //Вход в скрипт
    {
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
        chest = GetComponent<Animator>();
    }
    void Update() //Обновление скрипта
    {
        if (Vector2.Distance(transform.position, playerPos.position) < 0.9f && (Input.GetKeyDown(KeyCode.E)))
        {
            chest.SetBool("Open", true);
            Destroy(this);
        }
    }
}
