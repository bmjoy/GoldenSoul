using System;
using UnityEngine;
using System.Collections;

public class comment1 : MonoBehaviour
{
    public bool Stay = false; //стоять во время диалога.
    public static bool IsLock = true;
    public string tagg = "Player";
    public int type; // ТИП Диалога
    public int[] mas = new int[10]; // нумерация строк из массива в диалоге
    public int[] masav = new int[10];
    public int[] masvoice = new int[0];
    public  bool checkcomm = true; // Проверка для одноразовости диалога
    public float t; // Время до удаления диалога
    public float await; // Время до удаления диалога
    private Transform playerPos;
    private Collider2D col;

    void Awake() //Вход в скрипт
    {
        col = GetComponent<Collider2D>();
        masvoice = (masvoice.Length <= 0) ? new int[masav.Length] : masvoice;
    }

    void OnTriggerStay2D(Collider2D col)
    {    
        if (!IsLock) {
            if (moveScript.activate && Stay)
            {
                StopAllCoroutines();
                moveScript.activate = false;
                Dialog.disableImage();
                IsLock = true;
                checkcomm = false;
                Dialog.TextArea.text = "";
                return;
            }
            return;
        }
        if((type == 2 || type == 5 || type == 6) && col.CompareTag(tagg))
        {
            Character1.IndicatorOn();
        }
        switch (type)
        {
            case 1: //простой комментарий или неактиваруемый диалог
                if (col.CompareTag(tagg) && checkcomm == true)
                {
                    if (Stay && checkcomm == true)
                    {
                        moveScript.moveyes = false;
                        moveScript.hero.speed = 0;
                    }
                    moveScript.activate = false;
                    StartCoroutine(Dialog.Dialogue(Dialog.masDial[mas[0]], masvoice, masav[0], 0.05f, t)); 
                    checkcomm = false;
                }
            break;
            case 2: //вечный комментарий активируемый
                if (col.CompareTag(tagg) && (Input.GetKeyDown(KeyCode.E) || moveScript.activate))
                {
                    if (Stay && checkcomm == true)
                    {
                        moveScript.moveyes = false;
                        moveScript.hero.speed = 0;
                    }
                    moveScript.activate = false;
                    StartCoroutine(Dialog.Dialogue(Dialog.masDial[mas[0]], masvoice, masav[0], 0.05f, t)); 
                }
                break;
            case 3: //Диалог наступательный удаляется
                if (col.CompareTag(tagg) && checkcomm == true)
                {
                    if (Stay && checkcomm == true)
                    {
                        moveScript.moveyes = false;
                        moveScript.hero.speed = 0;
                    }
                    moveScript.activate = false;
                    StartCoroutine(Dialog.Dialogue3(Dialog.masDial, masvoice, masav, mas,0.05f,t));
                    checkcomm = false;
                }
            break;

            case 4: //Титры
                if (col.CompareTag(tagg) && checkcomm == true)
                {
                    StartCoroutine(Dialog.Titres(Dialog.masDial[mas[0]], 0.05f, t));
                    checkcomm = false;
                    moveScript.activate = false;
                }
            break;

            case 5: //Диалог активируемый удаляется
                if ((moveScript.activate || Input.GetKeyDown(KeyCode.E)) && col.CompareTag(tagg) && checkcomm == true)
                {
                    if (Stay && checkcomm == true)
                    {
                        moveScript.moveyes = false;
                        moveScript.hero.speed = 0;
                    }
                    moveScript.activate = false;
                    StartCoroutine(Dialog.Dialogue3(Dialog.masDial, masvoice, masav, mas, 0.05f, t));
                    checkcomm = false;
                }
            break;
            case 6: //Диалог активируемый НЕ удаляется
                if ((moveScript.activate || Input.GetKeyDown(KeyCode.E)) && col.CompareTag(tagg) && checkcomm == true)
                {
                    if (Stay && checkcomm == true)
                    {
                        moveScript.moveyes = false;
                        moveScript.hero.speed = 0;
                    }
                    moveScript.activate = false;
                    StartCoroutine(Dialog.Dialogue3(Dialog.masDial, masvoice, masav, mas, 0.05f, t));
                }
                    checkcomm = true;
                break;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if ((type == 2 || type == 5 || type == 6) && col.CompareTag(tagg))
        {
            Character1.IndicatorOff();
        }
    }

}

