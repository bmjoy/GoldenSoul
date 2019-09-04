using UnityEngine;
using System.Collections;

public class wakeup : MonoBehaviour
{
    public Renderer s1;
    public Renderer s2;
    void Update()
    {
        if (Input.anyKey)
        {
            s1.sortingOrder = 0;
            s2.sortingOrder = 7;
            Destroy(this);
        }
    }
}
