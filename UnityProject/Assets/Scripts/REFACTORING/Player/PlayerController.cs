using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameStorage storage;

    private Rigidbody2D rb2d;
    private Animator anim;
    
    private Vector2 move;

    private void Start() {
        Cursor.visible = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        anim.SetInteger("vector",5);

        if (move.x > 0)
        {
            anim.SetInteger("vector", 3);
        }
        else if (move.x < 0)
        {
            anim.SetInteger("vector", 1);
        }
        else if (move.y > 0)
        {
            anim.SetInteger("vector", 2);
        }
        else if (move.y < 0)
        {
            anim.SetInteger("vector", 4);
        }
    }

    void FixedUpdate() //Physics code
    {
        rb2d.velocity = transform.TransformDirection(move.normalized * storage.Speed);
    }
}
