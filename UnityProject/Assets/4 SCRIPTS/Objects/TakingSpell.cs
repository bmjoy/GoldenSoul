using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingSpell : MonoBehaviour
{
    public int type = 1;
    public int SpellMagic = 1;
    bool CanDo = false;
    public GameObject enableObj;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CanDo = true;
            Character1.IndicatorOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CanDo = false;
            Character1.IndicatorOff();
        }
    }

    private void Update()
    {
        if (CanDo && moveScript.activate)
        {
            moveScript.activate = false;

            if (Spells.SpellsList[SpellMagic] == type)
            {
                return;
            }
            Spells.SpellsList[SpellMagic] = type;
            GameObject.Find("hero").GetComponent<Spells>().ChangePointer();
            Destroy(gameObject);
        }
        
    }
}
