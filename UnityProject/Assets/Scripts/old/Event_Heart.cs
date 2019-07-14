using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Heart : MonoBehaviour
{
    public bool check_enable = true;
    public bool check_col = false;
    public Animator heart;
    public Animator Life;
    void OnTriggerEnter2D(Collider2D col)
        {
        if (col.CompareTag("Player")) {
            check_col = true;
        }
         }
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.E)) && check_col == true && check_enable)
        {
            heart.SetBool("Heart", false);
            check_enable = false;
            if (Life.GetInteger("Stage") < 5) { 
            Life.SetInteger("Stage", 5);
            }
            Life.SetInteger("Stage", Life.GetInteger("Stage") + 1);
            StartCoroutine(Dialog.Dialogue("You restored humanity.",0, 0.05f, 4));
        }
    }
    }
