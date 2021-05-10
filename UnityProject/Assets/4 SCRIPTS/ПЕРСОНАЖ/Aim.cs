using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public static bool PLEE = false;
    GameObject Aim1;
    private float degree;


    private void Start()
    {
        Aim1 = GameObject.FindGameObjectWithTag("Aim");
        Aim1.SetActive(false);
    }

    private void Update()
    {
        degree = (moveScript.AimDegree < 361) ? moveScript.AimDegree - 90 : 666;
        print(moveScript.AimDegree);
        if (degree == 666)
        {
            switch (gameObject.GetComponent<Animator>().GetInteger("Vector"))
            {
                case 1:
                    degree = 90;
                    break;
                case 2:
                    degree = 0;
                    break;
                case 3:
                    degree = -90;
                    break;
                case 4:
                    degree = 180;
                    break;
                case 5:
                    degree = 45;
                    break;
                case 6:
                    degree = -45;
                    break;
                case 7:
                    degree = -135;
                    break;
                case 8:
                    degree = -225;
                    break;
            }
        }

        Aim1.transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    public void Aiming()
    {
        print("Aiming");
        if (Spells.Pointer < 0) return;
        Aim1.SetActive(true);
        PLEE = false;
        gameObject.GetComponent<Spells>().Spawn();
       // moveScript.NoShooting = false;
       // gameObject.GetComponent<Animator>().SetBool("Spell", true);
        gameObject.GetComponent<Spells>().Regen = false;
    }

    public void Shooting()
    {
        print("Shooting");
        if (Spells.Pointer < 0) return;
        Aim1.SetActive(false);
        PLEE = true;
        //moveScript.NoShooting = true;
        // gameObject.GetComponent<Animator>().SetBool("Spell", false);
        gameObject.GetComponent<Spells>().Regen = true;
    }
}
