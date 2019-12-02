using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public int scene;
    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
    public void Play() {
        EventSavingSystem.RealHp = 2;
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Language()
    {
        EventSavingSystem.Language = (EventSavingSystem.Language == 0) ? 1 : 0;
        if (EventSavingSystem.Language == 0)
        GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
        else
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
    }
}
