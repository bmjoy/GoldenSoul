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
        avatar.Play(0,0,0f);
        avatar.speed = 0;
        
    }
}
