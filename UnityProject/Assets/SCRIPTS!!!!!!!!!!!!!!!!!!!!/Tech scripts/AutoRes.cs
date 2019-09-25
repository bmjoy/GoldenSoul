using UnityEngine;
using System;

public class AutoRes : MonoBehaviour
{
    void Start()
    {
        int x = Screen.width;
        int y = Screen.height;
        if(Application.isMobilePlatform == true)
        {
            if(x > 1366)
                Screen.SetResolution(Convert.ToInt32(x/1.5f), Convert.ToInt32(y/1.5f),true);
            Application.targetFrameRate = 30;
            QualitySettings.vSyncCount = 2;
        }
    }
}
