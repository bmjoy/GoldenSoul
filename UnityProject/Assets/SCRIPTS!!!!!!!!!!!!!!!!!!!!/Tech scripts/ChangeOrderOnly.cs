using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrderOnly : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y > GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 7;
        }
    }
}
