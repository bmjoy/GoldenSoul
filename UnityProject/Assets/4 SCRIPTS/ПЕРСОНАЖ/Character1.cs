using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Character1 : MonoBehaviour
{
    //Статы
    public static int HP = 10;
    public static int MP = 100;
    public static int LVL = 1;
    //
    Rigidbody2D Rigi;
    public GameObject DeathText;
    public static Slider LifeSlider;
    public bool BlackImg = false;
    public bool Death = false;
    static GameObject _Lifepoint;
    private GameObject Player;
    public bool Hit;
    public bool StopHitTime = false;
    static public bool _Hit;
    public static bool HitTime = false;
    public static int AttackDirection = 1;
    static int AlertPoints = 0;//Нужно для появления индикатора
    public static bool Pushed = false; //для толканий персонажа
    public static bool CanWalk = true; //для толканий персонажа

    private void Awake()
    {
        AlertPoints = 0;
        try //Сверяем уровни и координаты
        {
        if(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl] != 0)
        transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
        }
        catch { }
        if(EventSavingSystem.x != 0 && EventSavingSystem.y != 0)
        {
            gameObject.transform.position = new Vector2(EventSavingSystem.x, EventSavingSystem.y);
            EventSavingSystem.y = EventSavingSystem.x = 0;
        }

    }

    private void Start()
    {
        LifeSlider = GameObject.Find("HeroLife").GetComponent<Slider>();
        _Lifepoint = GameObject.Find("LifePoint");
        DeathText = GameObject.Find("YouDead");
        _Hit = Hit;
        Rigi = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Level.ThisLevel());
        _Lifepoint.SetActive(false);
        DeathText.SetActive(false);
    }
    void Update()
    {
        LifeSlider.value = HP;
        if (HitTime == true && !StopHitTime) //Активируем выжидалку от урона(моргание)
        {
            StartCoroutine(WaitForHit());
            StopHitTime = true;
        }

        if (BlackImg && !Death) //Чтобы экран не повторял тускление при смерти
        {
            Death = true;
            StartCoroutine(BlackImgFun());
        }

        try
        {
            if (HP < 1) //Смерть
            {
                HitTime = false;
                Player.GetComponent<Animator>().SetBool("Died", true);
                Player.GetComponent<Animator>().speed = 1;
            }
        }
        catch { }
        AttackDirection = Player.GetComponent<Animator>().GetInteger("Vector");
    }

    static public void MinusHp(int x = 10) //Минус хп если не было получено урона до этого
    {
        if (HP > 1 && !HitTime) 
        {
            HitTime = true;
            HP -= x;

        }
        
    }

    static public void Alert() //Как опасность начинается даём очко опасности
    {
        AlertPoints++;
        _Lifepoint.SetActive(true);
    }

    static public void NoAlert() //Как опасность проходит снимаем очко опасности
    {
        AlertPoints--;
        if (AlertPoints < 1) {
            _Lifepoint.SetActive(false);
            AlertPoints = 0;
        }
    }

    IEnumerator BlackImgFun() //Затемняем экран
    {
        Image image = GameObject.Find("DeathImage").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        AlertPoints = 10;
        DeathText.SetActive(true);
    }

    IEnumerator WaitForHit() //Моргаем персонажем и не позволяем получить урон за это время
    {
        try { SpriteRenderer Rend = GameObject.Find("LifePoint").GetComponent<SpriteRenderer>(); 
        SpriteRenderer Rend2 = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        Rend2.color = new Color(1, 1, 1, 0.4f).linear; ;
        Rend.color = new Color(0, 0, 0, 1f).linear;
        yield return new WaitForSecondsRealtime(0.5f);
        Rend.color = new Color(1, 1, 1, 1).linear;
        yield return new WaitForSecondsRealtime(0.5f);
        Rend.color = new Color(0, 0, 0, 1f).linear;
        yield return new WaitForSecondsRealtime(0.5f);
        Rend.color = new Color(1, 1, 1, 1f).linear;
        yield return new WaitForSecondsRealtime(0.5f);
        Rend.color = new Color(0, 0, 0, 1f).linear;
        yield return new WaitForSecondsRealtime(0.5f);
        Rend.color = new Color(1, 1, 1, 1f).linear;
        Rend2.color = new Color(1, 1, 1, 1f).linear;
        }
        finally
        {
            StopHitTime = false;
            HitTime = false;
            Pushed = false;
        }
    }

    public void DragStart(Vector2 pos)
    {
        StartCoroutine(Drag(pos));
    }

    public IEnumerator Drag(Vector2 pos) //Отталкиваем героя(передаём позицию врага в векторе)
    {
        int X = Player.GetComponent<Animator>().GetInteger("Vector");
        if (!Pushed && CanWalk)
        {
        CanWalk = false;
        Pushed = true;
        Rigi.AddForce(((Vector2)transform.position - pos).normalized * 50f, ForceMode2D.Force);
        yield return new WaitForSecondsRealtime(0.01f);
        Rigi.drag = 100;
        CanWalk = true;
        }
    }
}
