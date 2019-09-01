using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class moveScript : MonoBehaviour
{
    //public
    public bool IsAttack = false;
    public float Speed = 0.03f;
    public bool tw, th, _tw, _th;//Для тачей
    //private 
    float horizontalSpeed,verticalSpeed; // Скорость движения
    float speedX; // актуальная скорость игрока
    float speedY;
    //static
    static public bool _IsAttack;
    public static bool moveyes;
    public static Animator hero; 
    public static bool attack;
  
    // Старт!
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //Фиксируем курсор
        //Cursor.visible = false; //Делаем его невидимым
        hero = GetComponent<Animator>();
        moveyes = true;
        attack = false;
    }

    // FixedUpdate потому что Костя захотел
    void Update()
    {
        _IsAttack = IsAttack; //Сверяем тайминг атаки с этой переменной и всё гуд

        if (Input.GetKey(KeyCode.Q))
        {
            //SceneManager.LoadScene();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            attack = true;
            hero.SetInteger("vector",5);
            hero.speed = 1;
            return;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && moveyes == true)
        { //Вертикальное передвижение
            if (Input.GetKey(KeyCode.W)) // Проверяем условие нажатия кнопки W
            {
                hero.speed = 1;
                speedY = verticalSpeed; //Изменение скорости игрока и анимация
               hero.SetInteger("vector", 2);
            }
            if (Input.GetKey(KeyCode.S)) // Проверяем условие нажатия кнопки S
            {
                hero.speed = 1;
                speedY = -verticalSpeed;
                hero.SetInteger("vector", 4);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                hero.speed = 0;
                speedY = 0;
            }
        }

        /*else*/ //закомментировал потому что это не нужно
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && moveyes == true)
        {
            if (Input.GetKey(KeyCode.D)) // Проверяем условие нажатия кнопки D
            {
                hero.speed = 1;
                hero.SetInteger("vector", 3);
                speedX = horizontalSpeed;
            }
            if (Input.GetKey(KeyCode.A)) // Проверяем условие нажатия кнопки A
            {
                hero.speed = 1;
                speedX = -horizontalSpeed;
                hero.SetInteger("vector", 1);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) //Костыль от Кости
            {
                hero.speed = 0;
                speedX = 0;
            }
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            || (tw || _tw && th || _th))
        {
            horizontalSpeed = Mathf.Sqrt(Mathf.Pow(Speed / 2, 2) * 2); //Скорость вертикальной ходьбы
            verticalSpeed = Mathf.Sqrt(Mathf.Pow(Speed / 2, 2) * 2);
        }
        else
        {
            horizontalSpeed = Speed; //Скорость движения
            verticalSpeed = Speed;
        }

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && moveyes == true
            && Input.touchCount == 0 && !Input.GetKey(KeyCode.Space))
        {
            hero.speed = 0; //Остановить анимацию если не идём
        }
        if (!Input.GetKey(KeyCode.Space)&&!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            hero.SetInteger("vector", 6);
        }
        transform.Translate(speedX, speedY, 0); //Применение передвижения
        speedX = 0;
        speedY = 0;
    }
    
    public static void enable(bool x)
    {
        hero.enabled = x;
    }
}