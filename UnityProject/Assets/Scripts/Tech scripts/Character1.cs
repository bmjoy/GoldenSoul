using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Character1 : MonoBehaviour
{
    public GameObject Life;
    static GameObject _Life;

    void Update()
    {
        if (_Life.GetComponent<Animator>().GetInteger("Stage") < 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
