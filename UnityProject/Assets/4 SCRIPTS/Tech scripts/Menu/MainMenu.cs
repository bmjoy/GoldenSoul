using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public string[] TitlesRus;
    public string[] TitlesEng;

    public GameObject[] MainMenuObj;
    public GameObject[] BossesObj;

    public GameObject[] MainMenuScenes;
    public GameObject[] BossesScenes;

    public GameObject[] PartsScenes;
    public GameObject[] PartsObj;

    public Image MenuBlack;
    public static int PointerScene = 0;
    public static int PointerSceneMax = 1;

    public static int PointerBoss = 0;
    public static int PointerBossMax = 1;

    public static int PointerPart = 0;
    public static int PointerPartMax = 1;
    public int scene;
    public Text[] Texts;
    public static int category = 1;
    public int[] scenes = {0};

    public GameObject BossButtonLeft;
    public GameObject BossButtonRight;

    public GameObject PartButtonLeft;
    public GameObject PartButtonRight;

    public int part;

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
        Texts[0].text = "История";
        Texts[0].fontSize = 50;
        Texts[1].text = "Загрузить";
        Texts[1].fontSize = 48;
        Texts[2].text = "Язык";
        Texts[2].fontSize = 50;
        Texts[3].text = "Выход";
        Texts[3].fontSize = 50;
        //Texts[4].text = "1. Верни \n нас назад [PILOT]";
        Texts[5].text = "Назад";
        Texts[5].fontSize = 60;
        Texts[6].text = "Бой";
        Texts[6].fontSize = 60;
        Texts[7].text = "Боссы";
        Texts[7].fontSize = 60;
        Texts[8].text = "Начать";
        Texts[8].fontSize = 60;
        Texts[9].text = "Назад";
        Texts[9].fontSize = 60;
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
        foreach (GameObject i in PartsObj)
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
            BossMenu("menu");
        }
        if (category == 2)
        {
            BossMenu("bosses");
        }
        if (category == 3)
        {
            BossMenu("parts");
        }
        //Language();
    }

    public void BossFight()
    {
        EventSavingSystem.ThisLvl = scenes[PointerBoss];
        print(EventSavingSystem.ThisLvl);
        StartCoroutine(DisappearanceLvl(scenes[PointerBoss]));  
    }

    public void BossMenu(string b)
    {
        StartCoroutine(AppearanceImg(b));
    }

    public void BossPointerNext()
    {
        PointerBoss += (PointerBoss < PointerBossMax) ? 1 : 0;

        StartCoroutine(AppearanceImg("bosses"));
    }

    public void PartPointerPrevious()
    {
        PointerPart -= (PointerPart < 1) ? 0 : 1;
        StartCoroutine(AppearanceImg("parts"));
    }

    public void PartPointerNext()
    {

        PointerPart += (PointerPart < PointerPartMax) ? 1 : 0;
        StartCoroutine(AppearanceImg("parts"));
    }

    public void BossPointerPrevious()
    {

        PointerBoss -= (PointerBoss < 1) ? 0 : 1;

        StartCoroutine(AppearanceImg("bosses"));
    }

    public void Load()
    {
        if (EventSavingSystem.ThisLvl != 0)
        {
            EventSavingSystem.LoadAll();
            StartCoroutine(DisappearanceLvl(EventSavingSystem.ThisLvl));
        }
    }
    public void Play() {
        PlayerPrefs.DeleteAll();
        EventSavingSystem.RealHp = 5;
        Spells.SpellsList[1] = 0;
        Spells.SpellsList[2] = 0;
        Spells.SpellsList[3] = 0;
        Spells.SpellsList[4] = 0;
        switch (PointerPart)
        {
            case 0:
                StartCoroutine(DisappearanceLvl(1));
                break;
            case 1:
                StartCoroutine(DisappearanceLvl(27));
                break;
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator AppearanceImg(string b)
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime * 3)
        {
            MenuBlack.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.00001f);
        }

        switch (b)
        {
            case "bosses":

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
                foreach (GameObject i in PartsObj)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in MainMenuObj)
                {
                    i.SetActive(false);
                }
                StartCoroutine(DisappearanceImg("bosses"));
                break;

            case "menu":
                {
                    foreach (GameObject i in PartsScenes)
                    {
                        i.SetActive(false);
                    }
                    category = 1;
                    BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 1);
                    foreach (GameObject i in BossesObj)
                    {
                        i.SetActive(false);
                    }
                    foreach (GameObject i in PartsObj)
                    {
                        i.SetActive(false);
                    }
                    foreach (GameObject i in MainMenuObj)
                    {
                        i.SetActive(true);
                    }
                    StartCoroutine(DisappearanceImg("menu"));
                }
            break;

            case "parts":
                {
                    category = 3;
                    foreach (GameObject i in PartsScenes)
                    {
                        i.SetActive(false);
                    }

                    PartsScenes[PointerPart].SetActive(true);
                    PartsScenes[PointerPart].GetComponent<Animator>().SetInteger("Slide", 1);

                    foreach (GameObject i in BossesObj)
                    {
                        i.SetActive(false);
                    }
                    foreach (GameObject i in PartsObj)
                    {
                        i.SetActive(true);
                    }
                    foreach (GameObject i in MainMenuObj)
                    {
                        i.SetActive(false);
                    }
                    StartCoroutine(DisappearanceImg("parts"));
                    break;
                }

        }
        
    }
        
        

         

    IEnumerator DisappearanceImg(string b)
    {
        switch (b)
        {
            case "bosses":
                MainMenuScenes[PointerScene].GetComponent<Animator>().SetInteger("Slide", 2);
                MainMenuScenes[PointerScene].SetActive(false);
                BossesScenes[PointerBoss].SetActive(true);
                BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 1);
                foreach (GameObject i in BossesObj)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in PartsObj)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in MainMenuObj)
                {
                    i.SetActive(false);
                }
            break;

            case "menu":
                BossesScenes[PointerBoss].GetComponent<Animator>().SetInteger("Slide", 2);
                BossesScenes[PointerBoss].SetActive(false);
                MainMenuScenes[0].SetActive(true);
                MainMenuScenes[0].GetComponent<Animator>().SetInteger("Slide", 1);
                foreach (GameObject i in BossesObj)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in PartsObj)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in MainMenuObj)
                {
                    i.SetActive(true);
                }
                PointerBoss = 0;
                break;

            case "parts":
                MainMenuScenes[PointerScene].GetComponent<Animator>().SetInteger("Slide", 2);
                MainMenuScenes[PointerScene].SetActive(false);
                PartsScenes[PointerPart].SetActive(true);
                PartsScenes[PointerPart].GetComponent<Animator>().SetInteger("Slide", 1);
                foreach (GameObject i in BossesObj)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in PartsObj)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in MainMenuObj)
                {
                    i.SetActive(false);
                }
                break;
        }
        if (PointerBoss < 1)
        {
            BossButtonLeft.SetActive(false);
        }
        else
        if (PointerBoss == PointerBossMax)
        {
            BossButtonRight.SetActive(false);
        }
        else
        {
            BossButtonLeft.SetActive(true);
            BossButtonRight.SetActive(true);
        }

        if (PointerPart < 1)
        {
            PartButtonLeft.SetActive(false);
        }
        else
        if (PointerPart == PointerPartMax)
        {
            PartButtonRight.SetActive(false);
        }
        else
        {
            PartButtonLeft.SetActive(true);
            PartButtonRight.SetActive(true);
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
        print(EventSavingSystem.Language);
        if (EventSavingSystem.Language == 0)
        {
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", true);
            Texts[0].text = "Story";
            Texts[3].fontSize = 60;
            Texts[1].text = "Load";
            Texts[3].fontSize = 60;
            Texts[2].text = "Language";
            Texts[3].fontSize = 60;
            Texts[3].text = "Exit";
            Texts[3].fontSize = 60;
            Texts[4].text = TitlesEng[0];
            Texts[5].text = "Back";
            Texts[5].fontSize = 60;
            Texts[6].text = "Fight";
            Texts[6].fontSize = 60;
            Texts[7].text = "Bosses";
            Texts[7].fontSize = 60;
            Texts[8].text = "Start";
            Texts[8].fontSize = 60;
            Texts[9].text = "Back";
            Texts[9].fontSize = 60;
        }
        else
        {
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().SetBool("Eng", false);
            Texts[0].text = "История";
            Texts[0].fontSize = 50;
            Texts[1].text = "Загрузить";
            Texts[1].fontSize = 48;
            Texts[2].text = "Язык";
            Texts[2].fontSize = 50;
            Texts[3].text = "Выход";
            Texts[3].fontSize = 50;
            Texts[4].text = TitlesRus[0];
            Texts[5].text = "Назад";
            Texts[5].fontSize = 60;
            Texts[6].text = "Бой";
            Texts[6].fontSize = 60;
            Texts[7].text = "Боссы";
            Texts[7].fontSize = 60;
            Texts[8].text = "Начать";
            Texts[8].fontSize = 60;
            Texts[9].text = "Назад";
            Texts[9].fontSize = 60;
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
