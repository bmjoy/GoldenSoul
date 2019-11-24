using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public bool HitEnable = true;
    GameObject Player;
    public GameObject Monster;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, Monster.transform.position) < 2f && Character1._Hit && HitEnable)
        {
            if (Signature.FromSide(Player, gameObject))
            {
                HitEnable = false;
                StartCoroutine(Monster.GetComponent<PenekKing>().Drag(Player.transform.position));
            }
        }
    }
}
