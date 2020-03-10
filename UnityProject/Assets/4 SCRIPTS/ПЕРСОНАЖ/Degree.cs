using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degree : MonoBehaviour
{
    static Animator Anim;
    //DEBUG закончился, при полной работоспособности кода, можно удалить
    void Start()
    {
        Anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //Здесь сделай инициализацию геймпада и получение значений с него
    }

    public static float GetDegree(float gamePadH, float gamePadV)
    {
        float cos; //Косинус (удобен для расчётов)
        float sin;
        float degree = 0; //Градус оч показателен
        float dis; //расстояние от центра до положения стика
                   //а ща будет матан 7 класса
                   //Для начала нужно посчитать косинус нужного угла
                   // Mathf - библиотека встроенная в UnityEngine
        if ((gamePadH == 0 && gamePadV == 0))
        { //Прекращаем безобразие, если геймпад отдаёт значение 0;0 +- мёртвая зона
            cos = 0;
            sin = 0;
            dis = 0;
        }

        //Подсчёт гипотенузы (она равна радиусу)

        cos = gamePadH / Mathf.Sqrt((Mathf.Pow(Mathf.Abs(gamePadH), 2) + Mathf.Pow(Mathf.Abs(gamePadV), 2)));
        sin = gamePadV / Mathf.Sqrt((Mathf.Pow(Mathf.Abs(gamePadH), 2) + Mathf.Pow(Mathf.Abs(gamePadV), 2)));

        if (gamePadH >= 0 && gamePadV >= 0 || gamePadH < 0 && gamePadV >= 0)
            degree = Mathf.Acos(cos) * 180 / Mathf.PI;
        else if (gamePadH <= 0 && gamePadV <= 0)
            degree = Mathf.Acos(Mathf.Abs(cos)) * 180 / Mathf.PI + 180;
        else if (gamePadH >= 0 && gamePadV <= 0)
            degree = 360 - Mathf.Acos(Mathf.Abs(cos)) * 180 / Mathf.PI;
        dis = Mathf.Sqrt(Mathf.Pow(gamePadH, 2) + Mathf.Pow(gamePadV, 2));

        //Character1.ThrowVector = new Vector2(gamePadH, gamePadV).normalized;

        return (degree);
        //Применение DEBUG переменных, нужны только для проверки работоспособности
    }
}
