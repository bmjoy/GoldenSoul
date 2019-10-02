using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    GameObject Player;
    public moveScript MS;
    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(Vector2.Distance(Player.transform.position, transform.position) < 1f && Character1._Hit)
        {
            if (Player.transform.position.x > transform.position.x && Character1.AttackDirection == 1 ||
                Player.transform.position.x > transform.position.x && Character1.AttackDirection == 5 && Player.transform.position.y < transform.position.y ||
                Player.transform.position.x > transform.position.x && Character1.AttackDirection == 8 && Player.transform.position.y > transform.position.y ||

                Player.transform.position.y < transform.position.y && Character1.AttackDirection == 2 ||
                Player.transform.position.y < transform.position.y && Character1.AttackDirection == 7 && Player.transform.position.x < transform.position.x ||
                Player.transform.position.y > transform.position.y && Character1.AttackDirection == 8 && Player.transform.position.x > transform.position.x ||

                Player.transform.position.x < transform.position.x && Character1.AttackDirection == 3 ||
                Player.transform.position.x < transform.position.x && Character1.AttackDirection == 6 && Player.transform.position.y < transform.position.y ||
                Player.transform.position.x < transform.position.x && Character1.AttackDirection == 7 && Player.transform.position.y > transform.position.y ||

                Player.transform.position.y > transform.position.y && Character1.AttackDirection == 4 ||
                Player.transform.position.y < transform.position.y && Character1.AttackDirection == 5 && Player.transform.position.x > transform.position.x ||
                Player.transform.position.y < transform.position.y && Character1.AttackDirection == 6 && Player.transform.position.x < transform.position.x
                )
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
