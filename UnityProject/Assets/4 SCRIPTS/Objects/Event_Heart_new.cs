using UnityEngine;
using System.Collections;

public class Event_Heart_new : MonoBehaviour
{
    private Animator Heart;
    private Transform playerPos;
    bool IsPlayerExited = true;
    private Transform heartPos;
    void Awake() //Вход в скрипт
    {
        Heart = GetComponent<Animator>();
        heartPos = GetComponent<Transform>(); //Получаем данные о местонахождении Сердца
        playerPos = GameObject.Find("hero").GetComponent<Transform>(); //Получаем данные о местонахождении Игрока
    }
    void Update() //Обновление скрипта
    {
        if ((Vector2.Distance(heartPos.position, playerPos.position) < 1f))
        {
            IsPlayerExited = false;
            Character1.IndicatorOn();
            if(Input.GetKeyDown(KeyCode.E) || moveScript.activate){
                {
                    Heart.SetBool("Heart", false);
                    Character1.HP = 100;
                    Character1.IndicatorOff();
                    Destroy(this);
                }
            }

        }else if (!IsPlayerExited)
        {
            IsPlayerExited = true;
            Character1.IndicatorOff();
        }
        
        //если дистанция между игроком и сердцем меньше 0.6 юнита И кнопка "Е" нажат, то
    }
}