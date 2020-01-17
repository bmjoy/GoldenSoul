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
    public int X = 0;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            NewCombo *= 10;
            NewCombo += X;
            Symbol.SetActive(true);
            if (NewCombo == NeedCombo)
            {
                Comm.SetActive(true);
                stains.SetActive(false);
                EventSavingSystem.UsedEvents[Num] = true;
                Destroy(this);
            }
        }
        if (col.CompareTag("Player") && ((NewCombo / 100) != 0 && NewCombo != NeedCombo || NewCombo > 321))
        {
            NewCombo = 0;
            Symbol.SetActive(false);
            foreach (GameObject item in Symbols)
            {
                item.SetActive(false);
            }
        }
        Debug.Log(NewCombo);
    }
}
