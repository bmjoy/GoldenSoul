using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DynamicRess : MonoBehaviour
{
    public float scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform == true)
        {
            int h = Screen.height;
            int w = Screen.width;
            Screen.SetResolution(Convert.ToInt32(w / 1.5f), Convert.ToInt32(h / 1.5f), true);
        }
    }
}
