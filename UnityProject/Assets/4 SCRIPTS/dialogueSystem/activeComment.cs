using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeComment : MonoBehaviour
{
    public int[] mas = new int[10]; // нумерация строк из массива в диалоге
    public int[] masav = new int[10];
    public float t; // Время до удаления диалога
    public bool move = false;
    private void OnEnable()
    {
        if(!move) moveScript.moveyes = false;
        moveScript.hero.speed = 0;
        StartCoroutine(Dialog.Dialogue3(Dialog.masDial, masav, mas, 0.05f, t));
    }
}
