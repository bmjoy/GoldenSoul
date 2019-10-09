using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static int counttoop = 0;
    public static int countconst = 123;
    public static Collider2D _Wall1;
    public Animator Anim;
    public static Animator _Anim;
    public Collider2D Wall1;
    public GameObject obj;
    static public GameObject _obj;
    private void Start()
    {
        _Wall1 =Wall1;
        _obj = obj;
        _Anim = Anim;
    }
    public static void Open()
    {
        _Anim.SetBool("Open", true);
        Destroy(_Wall1);
    }
}
