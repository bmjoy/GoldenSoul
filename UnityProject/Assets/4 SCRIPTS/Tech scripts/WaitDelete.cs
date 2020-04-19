using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitDeleteTimer());
    }

    IEnumerator WaitDeleteTimer()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
