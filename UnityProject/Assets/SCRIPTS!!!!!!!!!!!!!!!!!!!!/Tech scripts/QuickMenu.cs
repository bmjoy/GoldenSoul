using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuickMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Load()
    {
        EventSavingSystem.RealHp = 5;
        SceneManager.LoadScene(EventSavingSystem.ThisLvl);
    }
}
