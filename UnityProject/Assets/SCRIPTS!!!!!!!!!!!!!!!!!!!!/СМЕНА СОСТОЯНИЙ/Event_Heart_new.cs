using UnityEngine;
using System.Collections;

public class Event_Heart_new : MonoBehaviour
{
    private Animator Heart;
    private Transform playerPos;
    private Transform heartPos;
    void Awake() //Вход в скрипт
    {
        Heart = GetComponent<Animator>();
        heartPos = GetComponent<Transform>(); //Получаем данные о местонахождении Сердца
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
    }
    void Update() //Обновление скрипта
    {
        if (Vector2.Distance(heartPos.position, playerPos.position) < 0.6f &&
            (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Fire1") == 1))
        //если дистанция между игроком и сердцем меньше 0.6 юнита И кнопка "Е" нажат, то
        {
            Heart.SetBool("Heart", false);
            GameObject.FindGameObjectWithTag("Life").GetComponent<Animator>().SetInteger("Stage", 5);
            Destroy(this);
        }
    }
}