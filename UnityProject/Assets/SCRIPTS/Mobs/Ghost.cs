using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float Force;
    public bool Attack;
    private int direction;
    private SpriteRenderer Rend;
    private Animator Anim;
    private GameObject Player;
    private Vector2 Vector;
    private Collider2D Col;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Rend = GetComponent<SpriteRenderer>();
        Anim.SetBool("Attack", false);
        StartCoroutine(Direct());
    }
    private void Update()
    {
        switch (direction)
            {
            case 1:
                transform.Translate(-Force,0,0);
                break;
            case 2:
                transform.Translate(0, Force, 0);
                break;
            case 3:
                transform.Translate(Force, 0, 0);
                break;
            case 4:
                transform.Translate(0, -Force, 0);
                break;
        }
            
    }

    IEnumerator Direct()
    {
        yield return new WaitForSeconds(1f);
        direction = Random.Range(1, 5);

        StartCoroutine(Direct());
    }
}
