using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject[] MainMenuObj;
    public GameObject[] BossesObj;
    public GameObject[] MainMenuScenes;
    public GameObject[] BossesScenes;
    public static int PointerBoss = 1;
    public static int PointerBossMax = 2;
    public int scene;
    public Text[] Texts;

    private void Awake()
    {
        int i = 0;
        foreach (bool Events in EventSavingSystem.UsedEvents)
        {
            EventSavingSystem.UsedEvents[i] = (PlayerPrefs.GetInt("UsedEvents" + i.ToString()) == 1) ? true : false;
            i++;
        }
    }
    private void Start()
    {
        foreach (GameObject i in MainMenuObj)
        {
            i.SetActive(true);
        }
        foreach (GameObject i in BossesObj)
        {
            i.SetActive(false);
        }

        EventSavingSystem.Language = PlayerPrefs.GetInt("Language");
        if (EventSavingSystem.Language == 0)
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
        else
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
        Language();
        Language();
    }

    public void BossFight()
    {
        
    }

    public void BossMenu(bool b)
    {
        if (b)
        {
            foreach (GameObject i in BossesObj)
            {
                i.SetActive(true);
            }
            foreach (GameObject i in MainMenuObj)
            {
                i.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject i in BossesObj)
            {
                i.SetActive(false);
            }
            foreach (GameObject i in MainMenuObj)
            {
                i.SetActive(true);
            }
        }

    }

    public void BossPointerNext()
    {
        PointerBoss += (PointerBoss > PointerBossMax) ? 0 : 1;
    }

    public void BossPointerPrevious()
    {
        PointerBoss -= (PointerBoss < 2) ? 0 : 1;
    }

    public void Load()
    {
       
        if (PlayerPrefs.GetInt("UsedEvents0") == 1)
        {
            EventSavingSystem.LoadAll();
            SceneManager.LoadScene(EventSavingSystem.ThisLvl);
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
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
        {
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
            Texts[0].text = "New Game";
            Texts[3].fontSize = 60;
            Texts[1].text = "Load";
            Texts[3].fontSize = 60;
            Texts[2].text = "Language";
            Texts[3].fontSize = 60;
            Texts[3].text = "Exit";
            Texts[3].fontSize = 60;
            Texts[4].text = "Chapter:";
            Texts[5].text = "Back";
            Texts[5].fontSize = 60;
            Texts[6].text = "Fight";
            Texts[6].fontSize = 60;
            Texts[7].text = "Bosses";
            Texts[7].fontSize = 60;
        }
        else
        {
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
            Texts[0].text = "Новая игра";
            Texts[0].fontSize = 50;
            Texts[1].text = "Загрузить";
            Texts[1].fontSize = 48;
            Texts[2].text = "Язык";
            Texts[2].fontSize = 50;
            Texts[3].text = "Выход";
            Texts[3].fontSize = 50;
            Texts[4].text = "Глава:";
            Texts[5].text = "Назад";
            Texts[5].fontSize = 60;
            Texts[6].text = "Бой";
            Texts[6].fontSize = 60;
            Texts[7].text = "Боссы";
            Texts[7].fontSize = 60;
        }

        PlayerPrefs.SetInt("Language", EventSavingSystem.Language);
        PlayerPrefs.Save();
    }
}
