using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public bool HeroWasHere = false;
    public float NextX;
    public float NextY;
    public int NextLvlNum;
    public float bright = 0;
    public Image image;
    public float scale;
    private void Update()
    {
        Time.timeScale = scale;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        
        if (col.CompareTag("Player"))
       {
            moveScript.activate = false;
            if(HeroWasHere)
                EventSavingSystem.HeroWasHere[EventSavingSystem.ThisLvl] = true;
            EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl] = NextX;
            EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl] = NextY;
            EventSavingSystem.ThisLvl = NextLvlNum;
            StartCoroutine(nextLevel());
       }

    }
    
    IEnumerator nextLevel()
    {
        image = GameObject.Find("Imagelvl").GetComponent<Image>();
            for(bright = 0;bright < 1;bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene(NextLvlNum);
    }
}
