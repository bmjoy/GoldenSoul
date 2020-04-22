using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStep : MonoBehaviour
{
    public GameObject Obj;
    public bool Active;
    bool wasActive = false;
    private void Start()
    {
        Active = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !wasActive)
        {
            Obj.SetActive(true);
            Active = true;
            wasActive = true;
        }
            
    }
}
