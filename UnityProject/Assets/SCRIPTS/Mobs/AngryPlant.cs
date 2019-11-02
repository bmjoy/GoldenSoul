using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPlant : MonoBehaviour
{
    private Animator Anim;
    public bool Attack = true;
    private GameObject Player;
    public GameObject bullet;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player") && Attack == true)
        {
            Anim.SetInteger("Stage", 1);     
            StartCoroutine(WaitAttack());
            Attack = false; 
        }
        
    }
    private void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            Attack = true;
            Anim.SetInteger("Stage", 2);
            StopAllCoroutines();
        }
    }

    IEnumerator WaitAttack(){
        yield return new WaitForSeconds(1.5f);
        Instantiate(bullet, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.7f), Quaternion.identity);
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.6f), Quaternion.identity);
        Instantiate(bullet, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.7f), Quaternion.identity);
        StartCoroutine(WaitAttack());
    }

}
