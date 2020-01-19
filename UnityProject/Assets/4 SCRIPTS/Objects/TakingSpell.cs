using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingSpell : MonoBehaviour
{
    public int type = 1;
    bool CanDo = false;
    public GameObject enableObj;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CanDo = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CanDo = false;
        }
    }

    private void Update()
    {

        if (CanDo && moveScript.activate)
        {
            moveScript.activate = false;

            if (Spells.SpellsList[0] == type || Spells.SpellsList[1] == type || Spells.SpellsList[2] == type)
            {
                return;
            }

            if (Spells.SpellsList[0] == 0 && Spells.SpellsList[1] == 0 && Spells.SpellsList[2] == 0)
            {
                Spells.SpellsList[0] = type;
                try { enableObj.SetActive(true); } catch { }
                GameObject.Find("hero").GetComponent<Spells>().ChangePointer();
                Destroy(gameObject);
                return;
            }
            if (Spells.SpellsList[1] == 0) {
                Spells.SpellsList[1] = type;
                Spells.Pointer = 0;
                GameObject.Find("hero").GetComponent<Spells>().ChangePointer();
                Destroy(gameObject);
                return;
            }
            if (Spells.SpellsList[2] == 0) {
                Spells.SpellsList[2] = type;
                Spells.Pointer = 1;
                GameObject.Find("hero").GetComponent<Spells>().ChangePointer();
                Destroy(gameObject);
                return;
            }
            

            if (Spells.SpellsList[0] != type && Spells.SpellsList[1] != type && Spells.SpellsList[2] != type)
            {

                Spells.SpellsList[Spells.Pointer] = type;
                Destroy(gameObject);

            }
            
        }
    }
}
