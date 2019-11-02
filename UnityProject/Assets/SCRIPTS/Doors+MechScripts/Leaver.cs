using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaver : MonoBehaviour
{
    public bool On = false;
    Animator Anim;
    GameObject Player;
    // Update is called once per frame
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < 0.7f && moveScript.activate)
        {
            moveScript.activate = false;
            if (On == false)
            {
                Anim.SetBool("On", true);
                On = true;
            }
            else
            {
                Anim.SetBool("On", false);
                On = false;
            }
        }
    }
}
