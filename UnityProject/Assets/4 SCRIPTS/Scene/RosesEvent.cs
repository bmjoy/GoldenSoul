using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosesEvent : MonoBehaviour
{
    public int Num;
    public GameObject stains;
    public GameObject Comm;
    public GameObject Symbol;
    public GameObject[] Symbols;
    public static int NeedCombo = 123;
    public static int NewCombo = 0;
    public static int count = 0;
    public int X = 0;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(6, 0.8f);
            NewCombo *= 10;
            NewCombo += X;
            count++;
            if(NewCombo == NeedCombo / 100 && count == 1 )
            {
                Symbol.SetActive(true);
                return;
            }

            if (NewCombo == NeedCombo / 10 && count == 2 )
            {
                Symbol.SetActive(true);
                return;
            }

            if (NewCombo == NeedCombo && count == 3)
            {
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(10, 0.8f);
                Symbol.SetActive(true);
                Comm.SetActive(true);
                stains.SetActive(false);
                EventSavingSystem.UsedEvents[Num] = true;
                Destroy(this);
            }
            else
            {
                count--;
                NewCombo = NewCombo / 10;
            }



        }
        Debug.Log(NewCombo);
    }
}
