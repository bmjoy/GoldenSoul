using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDissapear : MonoBehaviour
{
    public Animator Portal;
    public Animator Cat;
    public GameObject CatObj;
    bool cantp = true;
    bool here = false;
    private void Start()
    {
        CatObj.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cantp && !here)
        {
            cantp = false;
            StartCoroutine(Port());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cantp && here)
        {
            cantp = false;
            StartCoroutine(Port2());
        }
    }
    IEnumerator Port()
    {
        Cat.SetBool("Disappear", false);
        Portal.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        Cat.SetBool("Appear", true);
        CatObj.GetComponent<BoxCollider2D>().enabled = true;
        CatObj.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        Portal.SetBool("Open", false);
        here = true;
        yield return new WaitForSeconds(3f);
        cantp = true;
    }
    IEnumerator Port2()
    {
        Cat.SetBool("Appear", false);
        Portal.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        Cat.SetBool("Disappear", true);
        CatObj.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        CatObj.GetComponent<BoxCollider2D>().enabled = false;
        Portal.SetBool("Open", false);
        here = false;
        yield return new WaitForSeconds(3f);
        cantp = true;
    }
}
