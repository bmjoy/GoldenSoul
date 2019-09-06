using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    GameObject hero;
    // Update is called once per frame
    private void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(Vector2.Distance(hero.transform.position, transform.position) < 1f && moveScript._IsAttack)
        {
            if (hero.transform.position.x < transform.position.x && Character1.AttackDirection == 3)
            {
                GetComponent<Animator>().SetBool("Break", true);
                }
            if (hero.transform.position.x > transform.position.x && Character1.AttackDirection == 1)
            {
                GetComponent<Animator>().SetBool("Break", true);
            }
            if (hero.transform.position.y > transform.position.y && Character1.AttackDirection == 4)
            {
                GetComponent<Animator>().SetBool("Break", true);
            }
            if (hero.transform.position.y < transform.position.y && Character1.AttackDirection == 2)
            {
                GetComponent<Animator>().SetBool("Break", true);
            }
        }


    }
}
