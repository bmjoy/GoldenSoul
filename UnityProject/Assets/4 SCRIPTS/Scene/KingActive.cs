using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingActive : MonoBehaviour
{
    public GameObject[] King;
    private void OnDestroy()
    {
        King[0].GetComponent<PenekKing>().Active = true;
        for (int i=1; i < King.Length; i++)
        {
        King[i].SetActive(true);
        }
    }
}
