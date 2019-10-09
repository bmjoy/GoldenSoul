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
            HeroIsHere = true;
        }
    void OnTriggerExit2D(Collider2D Col)
        {
        if (Col.CompareTag("Player"))
            HeroIsHere = false;
        }
    private void Update()
    {
        if (HeroIsHere && Damage)
        {
            Character1.Alert();
            Character1.MinusHp();
        }
    }
}
