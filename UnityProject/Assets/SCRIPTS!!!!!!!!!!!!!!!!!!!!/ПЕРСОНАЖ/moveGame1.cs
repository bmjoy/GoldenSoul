using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGame1 : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    float speedY;
    Rigidbody2D rb;
    public Animator hero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (true)
        {
            hero.enabled = true;
            speedY = verticalSpeed;
            hero.SetInteger("vector", 2);
        }
        transform.Translate(0, speedY, 0);
        speedY = 0;
    }
}