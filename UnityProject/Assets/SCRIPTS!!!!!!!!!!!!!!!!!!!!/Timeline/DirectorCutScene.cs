using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorCutScene : MonoBehaviour
{
    public int NumScene; // номер катсцены
    bool fix = false;
    public Camera Camera1;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    public bool Stopable = true;
    public activeComment[] Comms;
    private void OnEnable()
    {
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;

    }

    private void FixedUpdate()
    {
        try
        {
            if (EventSavingSystem.HeroWasHere[EventSavingSystem.ThisLvl] == true) // Если игрок был на этой карте, его возвращает туда куда надо
            {
                director.Pause();
                director.Stop();
                playerAnimator.runtimeAnimatorController = playerAnim;
                fix = true;
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
                Destroy(gameObject);
            }
        }
        catch { }

        if (moveScript.activate && Stopable) // Возможность остановить таймлайн
        {
            StartCoroutine(Cs());
        }

        if (director.state != PlayState.Playing && !fix) //Сложно
        {
            try {GameObject.Find("Delete").SetActive(false); }
            catch { }
            StartCoroutine(Cs());
        }
    }
    public IEnumerator Cs()
    {
        EventSavingSystem.UsedCutscenes[NumScene] = true; // отмечаем что катсцена проиграла
        foreach (activeComment i in Comms)
        {
            i.StopAllCoroutines();
        }
        Dialog.TextArea.text = "";
        Dialog.disableImage();
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        director.Pause();
        director.Stop();
        playerAnimator.runtimeAnimatorController = playerAnim;
        Camera1.orthographicSize = 3.5f;
        try { GameObject.Find("Delete").SetActive(false); }
        catch { }
        fix = true;
        for (float bright = 1; bright > 0; bright -= Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(1f);
        image.color = new Color(0, 0, 0, 0);
        moveScript.moveyes = true;
        moveScript.hero.speed = 0;
        comment1.IsLock = true;
        moveScript.activate = false;
        gameObject.SetActive(false);
    }
}
