﻿using UnityEngine;
using UnityEngine.Playables;

public class DirectorCutScene : MonoBehaviour
{
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
       if (EventSavingSystem.HeroWasHere[EventSavingSystem.ThisLvl] == true) // Если игрок был на этой карте, его возвращает туда куда надо
        {
            director.Pause();
            director.Stop();
            playerAnimator.runtimeAnimatorController = playerAnim;
            fix = true;
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
            Destroy(gameObject);
        }

        if (moveScript.activate && Stopable) // Возможность остановить таймлайн
        { 
            director.Pause();
            director.Stop();
            playerAnimator.runtimeAnimatorController = playerAnim;
            Dialog.disableImage();
            Camera1.orthographicSize = 3.5f;
            fix = true;
            foreach (activeComment i in Comms)
            {
                i.StopAllCoroutines();
            }
            Dialog.TextArea.text = "";
            moveScript.activate = false;
        }

        if (director.state != PlayState.Playing && !fix) //Сложно
        {
            fix = true;
            Camera1.orthographicSize = 3.5f;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }
}