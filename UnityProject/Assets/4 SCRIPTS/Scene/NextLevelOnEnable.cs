using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOnEnable : MonoBehaviour
{
    public int lvl = 0;

    private void OnEnable()
    {
        SceneManager.LoadScene(lvl);
    }
}
