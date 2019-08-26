using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static int counttoop = 0;
    public static int countconst = 123;
    public static Collider2D _Wall1;
    public Collider2D Wall1;
    public GameObject obj;
    static public GameObject _obj;
    private void Start()
    {
        _Wall1 =Wall1;
        _obj = obj;
    }
    public static void Open()
    {
        if (counttoop == countconst)
        {
        _obj.SetActive(false);
        }
    }
}
