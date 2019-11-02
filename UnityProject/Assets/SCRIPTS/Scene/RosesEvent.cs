using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosesEvent : MonoBehaviour
{
    public int Num;
    public GameObject stains;
    public GameObject Comm;
    public static int NeedCombo = 123;
    public static int NewCombo = 0;
    public int X = 0;
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if ((NeedCombo != NewCombo && NeedCombo / 10 != NewCombo && NeedCombo / 100 != NewCombo) && NewCombo != 0)
        {
            NewCombo = 0;
        }
        if (col.CompareTag("Player"))
        {
            NewCombo *= 10;
            NewCombo += X;
            if (NewCombo == NeedCombo)
            {
                Comm.SetActive(true);
                stains.SetActive(false);
                EventSavingSystem.UsedEvents[Num] = true;
            }
        }
        Debug.Log(NewCombo);
    }
}
