using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStep : MonoBehaviour
{
    public GameObject Obj;
    private void Start()
    {
        Obj.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Obj.SetActive(true);
    }
}
