using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Character1 : MonoBehaviour
{
    public GameObject DeathObj;
    public bool BlackImg = false;
    public bool Death = false;
    public GameObject Life;
    static GameObject _Life;
    public GameObject Lifepoint;
    static GameObject _Lifepoint;
    private GameObject Player;
    public bool Hit;
    public bool StopHitTime = false;
    static public bool _Hit;
    public static bool HitTime = false;
    public static int AttackDirection = 1;
    static int AlertPoints = 0;//Нужно для появления индикатора

    private void Awake()
    {
        try //Сверяем уровни и координаты
        {
        if(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl] != 0)
        transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
        }
        catch { }

    }

    private void Start()
    {
        _Life = Life;
        _Lifepoint = Lifepoint;
        _Hit = Hit;
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Level.ThisLevel());
    }
    void Update()
    {
        if(HitTime == true && !StopHitTime && EventSavingSystem.RealHp > 1) //Активируем выжидалку от урона(моргание)
        {
            StartCoroutine(WaitForHit());
            StopHitTime = true;
        }
        try { _Life.GetComponent<Animator>().SetInteger("Stage", EventSavingSystem.RealHp); } catch { } //Синхронизируем ХП и эвент сейвинг систем
        _Hit = Hit;

        if (BlackImg && !Death) //Чтобы экран не повторял тускление при смерти
        {
            Death = true;
            StartCoroutine(BlackImgFun());
        }

        try
        {
            if (EventSavingSystem.RealHp < 2) //Смерть
            {
                HitTime = false;
                Player.GetComponent<Animator>().SetBool("Died", true);
                Player.GetComponent<Animator>().speed = 1;
            }
        }
        catch { }
        AttackDirection = Player.GetComponent<Animator>().GetInteger("Vector");
    }

    static public void MinusHp() //Минус хп если не было получено урона до этого
    {
        if (EventSavingSystem.RealHp > 0 && !HitTime) 
        {
            HitTime = true;
            EventSavingSystem.RealHp--;
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
        if (AlertPoints < 1) _Lifepoint.SetActive(false);
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
        DeathObj.SetActive(true);
    }

    IEnumerator WaitForHit() //Моргаем персонажем и не позволяем получить урон за это время
    {
        SpriteRenderer Rend = GameObject.Find("HearthLife").GetComponent<SpriteRenderer>();
        SpriteRenderer Rend2 = GameObject.Find("hero").GetComponent<SpriteRenderer>();
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
        Rend2.color = new Color(1, 1, 1, 1f).linear; ;
        StopHitTime = false;
        HitTime = false;
    }
}
