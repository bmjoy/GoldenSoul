using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeTitre : MonoBehaviour
{
    public int[] mas = new int[10]; // нумерация строк из массива в диалоге
    public int[] masav = new int[10];
    public float t; // Время до удаления диалога
    private void OnEnable()
    {
        StartCoroutine(Dialog.Titres(Dialog.masDial[mas[0]], 0.05f, t));
    }
}
