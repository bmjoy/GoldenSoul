using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BossMode : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;
    public bool winlose = false; //чтобы фиксировать аин один раз
    static public int combo = 0;

    public Image BlackImage;
    public GameObject Score;

    public int NormaTime = 200;
    public float NormaDmg = -30;
    public float NormaAttacks = 15;

    public static int BossTime;
    public static float BossDmg;
    public static float BossAttacks;
    public static string BossCategory;

    public Animator CategoryImage;
    public Text BossTimeText;
    public Text BossDmgText;
    public Text BossAttacksText;
    public Text BossCategoryText;

    public int[] spells = {0,0,0,0};
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Spells.SpellsList[1] = spells[0];
        Spells.SpellsList[2] = spells[1];
        Spells.SpellsList[3] = spells[2];
        Spells.SpellsList[4] = spells[3];
        Character1.HP = 100;
        Player.GetComponent<Spells>().ChangePointer();
        //CategoryImage = GameObject.Find("CategoryImage").GetComponent<Animation>();

    }

    private void Update()
    {
        switch (combo)
        {
            case 0:
                CategoryImage.SetInteger("Category", 0);
                break;
            case 1:
                CategoryImage.SetInteger("Category", 1);
                break;
            case 2:
                CategoryImage.SetInteger("Category", 2);
                break;
            case 3:
                CategoryImage.SetInteger("Category", 3);
                break;
        }
        if (win && !winlose)
        {           
            StopAllCoroutines();
            StartCoroutine(ScoreAppear());
            winlose = true;
        }
        if (lose)
        {

        }
    }

    public void GoMenu()
    {
        StartCoroutine(ScoreDisappear());
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public static IEnumerator Timer()
    {
        BossTime = 0;
        BossDmg = 0;
        BossAttacks = 0;
        BossCategory = "B";
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            BossTime ++;
        }
    }

    IEnumerator ScoreAppear()
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime * 3)
        {
            BlackImage.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.00001f);
        }
        BlackImage.color = new Color(0, 0, 0, 1f);
       
        BossTimeText.text = BossTimeText.text + BossTime + "s.";
        BossDmgText.text = BossDmgText.text + BossDmg;
        BossAttacksText.text = BossAttacksText.text + BossAttacks;

        if (NormaTime > BossTime)
        {
            combo++;
        }
        if (Mathf.Abs(NormaDmg) > Mathf.Abs(BossDmg))
        {
            combo++;
        }
        if (NormaAttacks >= BossAttacks)
        {
            combo++;
        }
        switch (combo)
        {
            case 0:
                BossCategory = "C";
                break;
            case 1:
                BossCategory = "B";
                break;
            case 2:
                BossCategory = "A";
                break;
            case 3:
                BossCategory = "S";
                break;
        }

        BossCategoryText.text = BossCategoryText.text + BossCategory;
        yield return new WaitForSeconds(0.5f);
        Score.SetActive(true);
    }

    IEnumerator ScoreDisappear()
    {
        Score.GetComponent<Animator>().SetTrigger("ScoreDisappear");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
