using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMode : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;
    public int combo = 1;
    public int[] spells = {0,0,0,0};
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Spells.SpellsList[1] = spells[0];
        Spells.SpellsList[2] = spells[1];
        Spells.SpellsList[3] = spells[2];
        Spells.SpellsList[4] = spells[3];
        Character1.HP = 100;
        Player.GetComponent<Spells>().ChangePointer();
        print(EventSavingSystem.ThisLvl);
    }

    private void Update()
    {
        if (win)
        {

        }
        if (lose)
        {

        }
    }
}
