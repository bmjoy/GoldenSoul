using UnityEngine;
using UnityEngine.UI;
using System;
public class FPS : MonoBehaviour
{
    public Text text;
    private float latency;
    private int timer;
    void Update()
    {
        if(latency >= 1f)
        {
            latency = 0;
            text.text = Convert.ToString(timer );
            timer = 0;
        }
        else
        {
            timer++;
            latency += Time.deltaTime;
        }
    }
}
