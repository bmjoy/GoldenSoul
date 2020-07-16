using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    GameObject Player;
    public moveScript MS;
    bool Destroyed = false;
    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet") && !Destroyed)
        {
            Break();
            Destroyed = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("PlayerBullet3") && !Destroyed)
        {
            Break();
            Destroyed = true;
        }
        if (collision.CompareTag("PlayerBullet4") && !Destroyed)
        {
            Break();
            Destroyed = true;
        }
        if (collision.CompareTag("enemy") && !Destroyed)
        {
            Break();
            Destroyed = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && !Destroyed)
        {
            Break();
            Destroyed = true;
        }
    }
    void Break()
    {
        GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(5, 0.7f);
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
