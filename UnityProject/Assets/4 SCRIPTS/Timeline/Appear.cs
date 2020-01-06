using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject[] obj;
    
    public void Appears()
    {
        try
        {
            foreach (GameObject item in obj)
            {
                item.SetActive(true);
            }
        }
        catch
        {

        }
    }
}
