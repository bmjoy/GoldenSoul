using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeComment : MonoBehaviour
{
    public int[] mas = new int[10]; // нумерация строк из массива в диалоге
    public int[] masav = new int[10];
    public int[] masvoice = new int[0];
    public float t; // Время до удаления диалога
    public bool move = false;
    void Awake() //Вход в скрипт
    {
        masvoice = (masvoice.Length <= 0) ? new int[masav.Length] : masvoice;
    }
    private void OnEnable()
    {
        if(!move) moveScript.moveyes = false;
        try
        {
            moveScript.hero.speed = 0;
        }
        catch { }
        
        StartCoroutine(Dialog.Dialogue3(Dialog.masDial, masvoice, masav, mas, 0.05f, t));
    }
}
