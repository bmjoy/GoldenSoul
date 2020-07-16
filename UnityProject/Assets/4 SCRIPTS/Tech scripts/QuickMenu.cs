using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuickMenu : MonoBehaviour
{
    public static bool can_do_pause = true;
    public GameObject pause_obj;

    public void Menu()
    {
        Time.timeScale = 1;
        AudioSystem.enabled1 = true;
        SceneManager.LoadScene(0);
    }
    public void Load()
    {
        Time.timeScale = 1;
        AudioSystem.enabled1 = true;
        EventSavingSystem.LoadAll();
        SceneManager.LoadScene(EventSavingSystem.ThisLvl);
    }

    public void Pause()
    {
        if (pause_obj.active)
        {
            pause_obj.SetActive(false);
            Time.timeScale = 1;
            return;
        }
        if (can_do_pause)
        {
            Time.timeScale = 0;
            pause_obj.SetActive(true);
        }

    }

    public void Back()
    {
        pause_obj.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadBoss()
    {
        Time.timeScale = 1;
        AudioSystem.enabled1 = true;
        SceneManager.LoadScene(EventSavingSystem.ThisLvl);
    }
}
