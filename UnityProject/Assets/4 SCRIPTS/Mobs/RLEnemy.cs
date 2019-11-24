using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RLEnemy : MonoBehaviour
{
    BoxCollider2D bc;
    TilemapCollider2D TC;
    float x = 0.01f,y = 0.01f;
    SpriteRenderer SR;
    public bool isTopDown;
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        TC = GameObject.Find("solidmiddle").GetComponent<TilemapCollider2D>();
    }
    void Update()
    {
        if (bc.IsTouching(TC))
        {
            if (!isTopDown) SR.flipX = !SR.flipX;
            x = -x;
            y = -y;
        }
        if (!isTopDown)
        {
            transform.Translate(new Vector3(x, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, y, 0));
        }
        
    }
}
