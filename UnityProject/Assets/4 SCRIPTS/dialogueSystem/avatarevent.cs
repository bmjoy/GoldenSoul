using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avatarevent : MonoBehaviour
{   
    private static Animator avatar;
    private static Image ren;
    void Start()
    {
        avatar = GetComponent<Animator>();
        ren = GetComponent<Image>();
        ren.enabled = false;
        avatar.speed = 0;
    }
    public static void avatarchange(int value){
        avatar.Rebind();
        ren.enabled = true;
        avatar.SetInteger("avatar", value);
        avatar.speed = 1;
    }
    public static void avatardisable()
    {
        ren.enabled = false;
    }
    public static void avatarstop()
    {
        avatar.Play(0,0,0.9f);
        avatar.speed = 0;
        
    }
}

/* 0 - пустое пространство
 * 1 - кот в очках
 * 2 - дефолт кот
 * 3 - кот глаз
 * 4 - кот язык
 * 5 - кот пьёт чай
 * 6 - кот тупит
 * 7 - Кинг обычный
 * 8 - Кинг злой
 * 9 - Кинг плачет
 */