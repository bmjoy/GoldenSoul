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
    public Image MenuBlack;
    public static int PointerScene = 0;
    public static int PointerSceneMax = 1;
    public static int PointerBoss = 0;
    public static int PointerBossMax = 1;
    public int scene;
    public Text[] Texts;
    public static int category = 1;
    public int[] scenes = {0};

    public GameObject ButtonLeft;
    public GameObject ButtonRight;

    private void Awake()
    {
        int i = 0;
        foreach (bool Events in EventSavingSystem.UsedEvents)
        {
            EventSavingSystem.UsedEvents[i] = (PlayerPrefs.GetInt("UsedEvents" + i.ToString()) == 1) ? true : false;
            i++;
        }
        EventSavingSystem.Language = 1;//Убрать
        print(EventSavingSystem.Language);
        GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
        Texts[0].text = "Новая игра";
        Texts[0].fontSize = 50;
        Texts[1].text = "Загрузить";
        Texts[1].fontSize = 48;
        Texts[2].text = "Язык";
        Texts[2].fontSize = 50;
        Texts[3].text = "Выход";
        Texts[3].fontSize = 50;
        Texts[4].text = "1. Верни \n нас назад [PILOT]";
        Texts[5].text = "Назад";
        Texts[5].fontSize = 60;
        Texts[6].text = "Бой";
        Texts[6].fontSize = 60;
        Texts[7].text = "Боссы";
        Texts[7].fontSize = 60;
    }
    private void Start()
    {
        GameObject.Find("AudioSystem").GetComponent<AudioSystem>().StopMusic();
        foreach (GameObject i in MainMenuObj)
        {
            i.SetActive(true);
        }
        foreach (GameObject i in BossesObj)
        {
            i.SetActive(false);
        }

        //EventSavingSystem.Language = PlayerPrefs.GetInt("Language");
        if (EventSavingSystem.Language == 0)
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
        else
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
        if (category == 1)
        {
            BossMenu(false);
        }
        else
        {
            BossMenu(true);
        }
        //Language();
    }

    public void BossFight()
    {
        EventSavingSystem.ThisLvl = scenes[PointerBoss];
        print(EventSavingSystem.ThisLvl);
        StartCoroutine(DisappearanceLvl(scenes[PointerBoss]));  
    }

    public void BossMenu(bool b)
    {
        StartCoroutine(AppearanceImg(b));

    }

    public void BossPointerNext()
    {
        PointerBoss += (PointerBoss < PointerBossMax) ? 1 : 0;

        StartCoroutine(AppearanceImg(true));
    }

    public void BossPointerPrevious()
    {
        PointerBoss -= (PointerBoss < 1) ? 0 : 1;

        StartCoroutine(AppearanceImg(true));
    }

    public void Load()
    {
       
        if (PlayerPrefs.GetInt("UsedEvents0") == 1)
        {
            EventSavingSystem.LoadAll();
            StartCoroutine(DisappearanceLvl(EventSavingSystem.ThisLvl));
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Play() {
        EventSavingSystem.RealHp = 5;
        PlayerPrefs.DeleteAll();
        StartCoroutine(DisappearanceLvl(1));
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator AppearanceImg(bool b)
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime*3)
        {
            MenuBlack.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.00001f);
        }

        if (b)
        {
            category = 2;
            foreach (GameObject i in BossesScenes)
            {
                i.SetActive(false);
            }

            BossesScenes[PointerBoss].SetActive(true);
            MainMenuScenes[PointerScene].GetComponent<Animator>().SetInteger("Slide", 1);
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
            category = 1;
            BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 1);
            foreach (GameObject i in BossesObj)
            {
                i.SetActive(false);
            }
            foreach (GameObject i in MainMenuObj)
            {
                i.SetActive(true);
            }
        }

         StartCoroutine(DisappearanceImg(b));
    }

    IEnumerator DisappearanceImg(bool b)
    {
        if (b)
        {
            MainMenuScenes[PointerScene].GetComponent<Animator>().SetInteger("Slide", 2);
            MainMenuScenes[PointerScene].SetActive(false);
            BossesScenes[PointerBoss].SetActive(true);
            BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 1);
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
            BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 2);
            BossesScenes[PointerBoss].SetActive(false);
            MainMenuScenes[0].SetActive(true);
            MainMenuScenes[0].GetComponent<Animator>().SetInteger("Slide", 1);
            foreach (GameObject i in BossesObj)
            {
                i.SetActive(false);
            }
            foreach (GameObject i in MainMenuObj)
            {
                i.SetActive(true);
            }
            PointerBoss = 0;
        }
        if (PointerBoss < 1)
        {
            ButtonLeft.SetActive(false);
        }
        else
        if (PointerBoss == PointerBossMax)
        {
            ButtonRight.SetActive(false);
        }
        else
        {
            ButtonLeft.SetActive(true);
            ButtonRight.SetActive(true);
        }
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 3)
        {
            MenuBlack.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.00001f);
        }
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
            Texts[4].text = "1. Bring \n     us back";
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
            Texts[4].text = "1. Верни \n     нас назад";
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
    IEnumerator DisappearanceLvl(int lvl)
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime * 3)
        {
            MenuBlack.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.00001f);
        }
        MenuBlack.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene(lvl);
    }
}
