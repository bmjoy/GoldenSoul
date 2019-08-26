using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextboxInv : MonoBehaviour
{
    private Text TextArea;
    public GameObject ImgObj;
    public static GameObject _ImgObj;
    private Animator Img;
    int Seek1 = 1;
    void Start()
    {
        TextArea = GetComponent<Text>();
        InvSys.Invupdate(Seek1);
        _ImgObj = ImgObj;
        Img = _ImgObj.GetComponent<Animator>();
        TextArea.text = InvSys.strings;
        Updateops(1);
    }
    private void Update()
    {
        Changekey();
    }
    private void Changekey()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && (Seek1 == InvSys.UImas.Length - 2) && (InvSys.UImas[Seek1].id == InvSys.Items.Length-1)) return; // Останавливает листание инвентаря в никуда

        if (Input.GetKeyDown(KeyCode.UpArrow) && Seek1 != 1)    // Листает относительно айди вернхей ячейки вниз
        {
            Seek1--;
            Updateops(1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Seek1 != InvSys.UImas.Length-1)  // Листает относительно айди вернхей ячейки вниз
        {
            Seek1++;
            Updateops(1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Seek1 == 1 && InvSys.UImas[1].id != 1) // Обновляет последний элемент смещая вверх
        {
            Seek1++;
            InvSys.Uitrace(InvSys.UImas[1].id - 2);
            InvSys.UImas[Seek1].name = ">" + InvSys.UImas[Seek1].name;
            InvSys.Invupdate(1);
            TextArea.text = InvSys.strings;
            Img.SetInteger("id", InvSys.UImas[Seek1].id);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && (Seek1 == InvSys.UImas.Length - 1) && (InvSys.UImas[Seek1].id < InvSys.Items.Length-1)) // Обновляет последний элемент смещая вниз
        {
            Seek1--;
            InvSys.Uitrace(InvSys.UImas[1].id);
            InvSys.UImas[Seek1].name = ">" + InvSys.UImas[Seek1].name;
            InvSys.Invupdate(1);
            TextArea.text = InvSys.strings;
            Img.SetInteger("id", InvSys.UImas[Seek1].id);
        }
    }
    private void Updateops(int x) //Обновляет последний элемент смещая его
    {
        InvSys.Uitrace(InvSys.UImas[1].id-x); //Помещение во второй массив начиная с верхнего айди
        InvSys.UImas[Seek1].name = ">" + InvSys.UImas[Seek1].name;
        InvSys.Invupdate(1);
        TextArea.text = InvSys.strings;
        Img.SetInteger("id", InvSys.UImas[Seek1].id);
    }
}
