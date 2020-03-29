using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetail : MonoBehaviour
{
    public int Dmg;
    GameObject Player;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Lifepoint"))
        {
            Character1.MinusHp(Dmg);
            Player.GetComponent<Character1>().DragStart(transform.position);
        }
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(5f);
        Anim.SetBool("Disappear", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
