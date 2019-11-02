using System.Collections; // Librarby
using UnityEngine.UI;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // MONOBEHAVIOUR ATTACK v0.2с
    // буква "с" в версии  обозначает, что скрипт закомментирован 
    // Все неготовые версии начинаются с нуля!

    //static

    static public float BulletSpeed; // Скорость будущей пули
    static public bool startBulling; // переменная для линейной атаки, говорим пулям шо можно лететь // Костыль
    static public GameObject hero; // ГлГерой (!статик)
    static public int AttackType; //Тип атаки, нужен для управления пулей и таймером
    static public bool sAgain; // КОСТЫЛЬ нужен для включения скрипта ещё раз
    static public float x, y; // X Y направления пуль или COS и SIN угла
    static public short damaged;
    static public bool Crutch;
    //private
    private float corner; // Угол 
    private GameObject[] fBull;

    //public
    public int Stage = 0;
    public float Speed = 3f; // Скорость атаки
    public float BSpeed = 2f;
    public GameObject[] bullets; // Массив пулек
    public short EnHp = 100; // ХП врага

    //Взаимодействия между героем и монстром
    public GameObject enemy;
    private static int Iterat;
    public GameObject LifeObject;
    public GameObject Door1;
    public GameObject Door2;

    private void Start() //Вход в скрипт
    {
        hero = GameObject.Find("hero"); //Находим главного нероя
        StopAllCoroutines(); //На всякий случай останавливаем отсчёты, помогает от "двойных" атак 
    }
    private void Update()
    {
        CheckStage(); //Проверяем стадию босса
                      /* if (Cast.Crutch && Crutch)
                       {
                           StopAllCoroutines();
                           StartCoroutine(CircleAttack());
                           Cast.Crutch = false;
                           Crutch = false;
                       }*/
        BulletSpeed = BSpeed; //Скорость пуль

        if (sAgain) //КОСТЫЛЬ нужен для возобновления врага, думаю это временный костыль
        {
            StopAllCoroutines();
            StartCoroutine(CircleAttack()); // Начинаем спамить, опять
            sAgain = false; // Костыль 
        }
        if (AttackType == 0 || AttackType == 2) //Выключаем наш SIN-COS ад если используется атака другого типа
            VectorTimer();
        if (EnHp == 0) //При смерти врага
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullets"); //КОСТЫЛЬ находим все пульки на экране
            foreach (GameObject i in bullets) // Просто удаляем ВСЕ(даже наши) пульки
                Destroy(i.gameObject);
        }
        ChangeOrder.ChangeLayerOrder(enemy.GetComponent<Renderer>(), transform, hero.transform);
    }

    IEnumerator CircleAttack() //Круговая атака
    {
        AttackType = 0;
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                int randomheal = Random.Range(0, 30);
                if (randomheal == 1)
                {
                    Instantiate(bullets[3], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                }
                else
                    Instantiate(bullets[1], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                yield return new WaitForSeconds((Speed * 5) / 100);
            }
        }
        StartCoroutine(directedAttack());
    }

    IEnumerator directedAttack() // Атака направленная на героя
    {
        AttackType = 1;
        for (int j = 0; j < 20; j++)
        {
            Instantiate(bullets[2], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
            StartCoroutine(SlowCircleAttack());
    }

    IEnumerator SlowCircleAttack() //Круговая атака
    {

        AttackType = 2;
        for (int j = 0; j < 100; j++)
        {
            int randomheal = Random.Range(0, 30);
            if (randomheal == 1)
            {
                Instantiate(bullets[3], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            }
            else
                Instantiate(bullets[1], new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            yield return new WaitForSeconds((Speed * 5) / 100);
        }
        StartCoroutine(LineAttack());
    }

    IEnumerator LineAttack() //Линейная атака
    {
        AttackType = 3;
        for (int j = 0; j < 3; j++)
        {
            for (int i = -5; i < 5; i++)
            {
                if (Stage == 3)
                {
                    Instantiate(bullets[2], new Vector2(transform.position.x + i * 1, transform.position.y + 1f), Quaternion.identity);
                }
                Instantiate(bullets[0], new Vector2(transform.position.x + i * 0.5f, transform.position.y - 0.7f), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
            startBulling = true;
            yield return new WaitForSeconds(3f);
            startBulling = false;
            if (Random.Range(0, 5) == 2)
            {
                switch (Stage)
                {
                    case 1:
                        Stage = 2;
                        break;
                    case 3:
                        Stage = 4;
                        break;
                }
            }
        }
        StartCoroutine(CircleAttack());
    }

    void VectorTimer() //Таймер НЕ ЛЕЗЬ ОНО ТЕБЯ УБЬЕТ 
    {
        if (corner < 360) //Счетчик угла(собсна он и крутит тут все)
            corner += Speed;
        else
            corner = 0; //Если угол больше 360град, то он приравнивается у нулю                   
        if(corner >= 0 && corner <= 90)//Математические вычисления Cos и Sin
        {
            float XCorner = corner;
            x = Mathf.Cos((XCorner) * Mathf.PI / 180);
            y = Mathf.Sin((XCorner) * Mathf.PI / 180);
        }
        if (corner >= 90 && corner <= 180)
        {
            float XCorner = corner - 90; 
            x = -Mathf.Sin((XCorner) * Mathf.PI / 180);
            y = Mathf.Cos((XCorner) * Mathf.PI / 180);
        }
        if (corner >= 180 && corner <= 270)
        {
            float XCorner = corner - 180;
            x = -Mathf.Cos((XCorner) * Mathf.PI / 180);
            y = -Mathf.Sin((XCorner) * Mathf.PI / 180);
        }
        if (corner >= 270 && corner <= 360)
        {
            float XCorner = corner - 270;
            x = Mathf.Sin((XCorner) * Mathf.PI / 180);
            y = -Mathf.Cos((XCorner) * Mathf.PI / 180);
        }
    }

    void CheckStage()
    {
        enemy.GetComponent<Animator>().SetInteger("Stage", Stage);
        
        if(Stage == 0)
        {
            if(Vector2.Distance(enemy.transform.position, hero.transform.position) < 3f)
            {
                Stage = 1;
                LifeObject.SetActive(true);
                Door1.SetActive(true);
            }
        }
        if (Stage == 1 && Iterat == 0)
        {
            Speed = 2; 
            BSpeed = 6;
            StartCoroutine(CircleAttack());
            Iterat = 1;
        }
        if (Stage == 2) //спим
        {
            if ((Vector2.Distance(enemy.transform.position, hero.transform.position) < 1f))
            {
                EnHp -= 20;
                if (EnHp < 50) {
                    Stage = 3; 
                }
                else Stage = 1; Iterat = 0;
            }
            StopAllCoroutines();
        }
        if (Stage == 3 && Iterat == 0)
        {
            Speed = 1.9f;
            BSpeed = 8;
            StartCoroutine(LineAttack());
            Iterat = 2;
        }
        if (Stage == 4 && Iterat == 2)//спим
        {
            if ((Vector2.Distance(enemy.transform.position, hero.transform.position) < 1f))
            {
                EnHp -= 20;
                if (EnHp <= 0) Stage = 5;
                else { Stage = 3; Iterat = 0; }
            }
            StopAllCoroutines();
        }
        else if (Stage == 5)
        {
            Door2.SetActive(false);
            LifeObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}