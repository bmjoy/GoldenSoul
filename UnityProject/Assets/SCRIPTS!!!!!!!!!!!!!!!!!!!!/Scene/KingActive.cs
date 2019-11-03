using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingActive : MonoBehaviour
{
    public GameObject King;
    private void OnDestroy()
    {
        King.GetComponent<PenekKing>().Active = true;
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            King.GetComponent<PenekKing>().Active = true;
            Destroy(gameObject);
        }
    }
}
