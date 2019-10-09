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
            if (Signature.FromSide(Player,gameObject))
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
        StartCoroutine(BreakWait());
    }
    IEnumerator BreakWait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
