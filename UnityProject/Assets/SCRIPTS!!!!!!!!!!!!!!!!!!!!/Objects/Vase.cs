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
                Break();
            }
            if (hero.transform.position.x > transform.position.x && Character1.AttackDirection == 1)
            {
                Break();
            }
            if (hero.transform.position.y > transform.position.y && Character1.AttackDirection == 4)
            {
                Break();
            }
            if (hero.transform.position.y < transform.position.y && Character1.AttackDirection == 2)
            {
                Break();
            }
        }


    }
    void Break()
    {
        GetComponent<Animator>().SetBool("Break", true);
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<ChangeOrderOnly>().enabled = false;
        GetComponent<SpriteRenderer>().sortingOrder = 3;
    }
}
