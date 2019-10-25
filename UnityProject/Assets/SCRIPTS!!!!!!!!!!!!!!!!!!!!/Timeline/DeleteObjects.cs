using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    public GameObject[] mas = new GameObject[10];
    private void OnDisable()
    {
        foreach (GameObject i in mas)
            {
            Destroy(i);
        };
    }
}
