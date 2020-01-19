using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public int scene;

    private void Start()
    {
        EventSavingSystem.Language = PlayerPrefs.GetInt("Language");
        if (EventSavingSystem.Language == 0)
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
        else
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
    }
    public void Load()
    {
        EventSavingSystem.LoadAll();
        SceneManager.LoadScene(EventSavingSystem.ThisLvl);
    }
    public void Play() {
        EventSavingSystem.RealHp = 5;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
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
        PlayerPrefs.SetInt("Language", EventSavingSystem.Language);
        PlayerPrefs.Save();
    }
}
