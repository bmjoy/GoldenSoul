using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    Collider2D Col2;
    public bool Damage;
    public bool HeroIsHere = false;
    private void Start()
    {
        Col2 = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            HeroIsHere = true;
            Character1.Alert();
        }

    }
    void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.CompareTag("Player") && HeroIsHere)
        {
            HeroIsHere = false;
            print("dasas");
            Character1.NoAlert();
        }

    }
    private void Update()
    {
        if (HeroIsHere && Damage)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Character1>().Drag(transform.position));
            Character1.MinusHp(15);
        }
    }
}
