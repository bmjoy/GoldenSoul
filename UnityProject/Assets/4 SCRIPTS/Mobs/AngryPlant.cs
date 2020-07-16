using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPlant : MonoBehaviour
{
    private Animator Anim;
    public bool Attack = true;
    private GameObject Player;
    public GameObject bullet;
    public GameObject MonsterLife;
    void Start()
    {
        MonsterLife.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        
        if (Col.CompareTag("Player") && Attack == true)
        {
            Character1.Alert();
            Anim.SetInteger("Stage", 1);     
            StartCoroutine(WaitAttack());
            StartCoroutine(EnableLife());
            Attack = false; 
        }
        
    }
    private void OnTriggerExit2D(Collider2D Col)
    {
        
        if (Col.CompareTag("Player"))
        {
            Character1.NoAlert();
            Attack = true;
            Anim.SetInteger("Stage", 2);
            MonsterLife.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void Update()
    {
        if (MonsterLife.GetComponent<MonsterLife>().Damaged)
        {
            StopAllCoroutines();
            Anim.SetInteger("Stage", 5);
            Anim.speed = 2;
            Destroy(MonsterLife);
            Destroy(this);
        }
    }

    IEnumerator EnableLife()
    {
        yield return new WaitForSeconds(1.5f);
        MonsterLife.SetActive(true);
    }
    IEnumerator WaitAttack(){
        yield return new WaitForSeconds(1.5f);

        if (Anim.GetInteger("Stage") == 1)
        {
            GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(11, 0.8f);
            Instantiate(bullet, new Vector2(transform.position.x - 0.3f, transform.position.y + 1f), Quaternion.identity);
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
            Instantiate(bullet, new Vector2(transform.position.x + 0.3f, transform.position.y + 1f), Quaternion.identity);
        }

        StartCoroutine(WaitAttack());
    }

}
