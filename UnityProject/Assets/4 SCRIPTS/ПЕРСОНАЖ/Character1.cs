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
    public static GameObject Indicator;
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


    new Vector2 VecTest;
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
        Indicator = GameObject.Find("Indicator");
    }

    private void Start()
    {
        QuickMenu.can_do_pause = true;
        try
        {
            LifeSlider = GameObject.Find("HeroLife").GetComponent<Slider>();
            _Lifepoint = GameObject.Find("LifePoint");
            DeathText = GameObject.Find("YouDead");
            _Hit = Hit;
            Rigi = GetComponent<Rigidbody2D>();
        }
        catch { }
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Level.ThisLevel());
        try
        {
            Indicator.SetActive(false);
            _Lifepoint.SetActive(false);
            DeathText.SetActive(false);
        }
        catch { }

    }
    void Update()
    {
        try { LifeSlider.value = HP; } catch { }
        if (HitTime == true && !StopHitTime) //Активируем выжидалку от урона(моргание)
        {
            StartCoroutine(WaitForHit());
            StopHitTime = true;
        }

        if (BlackImg && !Death) //Чтобы экран не повторял тускление при смерти
        {
            Death = true;
            try
            {
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().StopMusic();
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallMusic(7, 3f);
            }
            catch { }
            
            AudioSystem.enabled1 = false;
            StartCoroutine(BlackImgFun());
        }

        try
        {
            if (HP < 1) //Смерть
            {
                QuickMenu.can_do_pause = false;
                HitTime = false;
                Player.GetComponent<Animator>().SetBool("Died", true);
                Player.GetComponent<Animator>().speed = 1;
            }
        }
        catch { }
        try{ AttackDirection = Player.GetComponent<Animator>().GetInteger("Vector"); }       catch { }
    }

    static public void MinusHp(int x = 10) //Минус хп если не было получено урона до этого
    {
        if (HP > 1 && !HitTime) 
        {
            try
            {
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(4, 0.8f);
            }
            catch
            {

            }
            //GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(3, 1f);
            HitTime = true;
            HP -= x;
            BossMode.BossDmg -= x; 
        }
        
    }

    static public void Alert() //Как опасность начинается даём очко опасности
    {
            //GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(2,0.8f);
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
        try {
            _Lifepoint.SetActive(true);
            SpriteRenderer Rend = GameObject.Find("LifePoint").GetComponent<SpriteRenderer>(); 
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
            if (AlertPoints < 1)
            {
                _Lifepoint.SetActive(false);
            }
            else
            {
                _Lifepoint.SetActive(true);
            }
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
    public IEnumerator DragBack() //Отталкиваем героя(передаём позицию врага в векторе)
    {
        int X = Player.GetComponent<Animator>().GetInteger("Vector");
        if (!Pushed && CanWalk)
        {
            CanWalk = false;
            Pushed = true;
            Rigi.AddForce((Rigi.GetVector(VecTest)).normalized * 50f, ForceMode2D.Force);
            yield return new WaitForSecondsRealtime(0.01f);
            Rigi.drag = 100;
            CanWalk = true;
        }
    }

    public static void IndicatorOn()
    {
        if (!Indicator.active)
        {
            Indicator.SetActive(true);
            try
            {
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(0);
            }
            catch
            {

            }
            
        }

    }

    public static void IndicatorOff()
    {
        if (Indicator.active)
        {
            Indicator.SetActive(false);
        }
    }
}

