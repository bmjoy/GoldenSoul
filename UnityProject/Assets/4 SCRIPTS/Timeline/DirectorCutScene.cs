using System.Collections;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;

public class DirectorCutScene : MonoBehaviour
{
    public bool BlackImgOnEnd = true;
    public bool StopMusic = true;
    public int NumScene; // номер катсцены
    bool fix = false;
    public Camera Camera1;
    public GameObject Camera;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    public bool Stopable = true;
    public activeComment[] Comms;

    private GameObject ControlButton;
    private GameObject AttackButton;
    private GameObject ActiveButton;

    void Awake()
    {
        ControlButton = GameObject.Find("PhoneControls");
        ActiveButton = GameObject.Find("Action");
        AttackButton = GameObject.Find("AimJoystick");
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
    }

    private void OnEnable()
    {
        moveScript.moveyes = false;
        if(StopMusic)
            try
            {
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().StopMusic();
            }
            catch
            {

            }
        if (!Stopable)
        {
            ActiveButton.SetActive(false);
        }
        ControlButton.SetActive(false);
        try
        {
            AttackButton.SetActive(false);
        }
        catch { }
        
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

        if (moveScript.activate && Stopable && !fix) // Возможность остановить таймлайн
        {
            StartCoroutine(Cs(true));
        }

        if (director.state != PlayState.Playing && !fix) //Сложно
        {
            try {GameObject.Find("Delete").SetActive(false); }
            catch { }
            StartCoroutine(Cs(BlackImgOnEnd));
        }
    }

    private void OnDestroy()
    {
        //playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
        director.Pause();
        director.Stop();
        playerAnimator.runtimeAnimatorController = playerAnim;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(EventSavingSystem.LevelCoordsX[EventSavingSystem.ThisLvl], EventSavingSystem.LevelCoordsY[EventSavingSystem.ThisLvl]);
        gameObject.GetComponent<Appear>().Appears();
    }

    public IEnumerator Cs(bool BlackImgFlag)
    {
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        try
        {
            EventSavingSystem.UsedEvents[NumScene] = true; // отмечаем что катсцена проиграла
            foreach (activeComment i in Comms)
            {
                i.StopAllCoroutines();
            }
            try
            {
                Dialog.TextArea.text = "";
                Dialog.disableImage();
            }
            catch { }
            if (BlackImgFlag)
                for (float bright = 0; bright < 1; bright += Time.deltaTime)
                {
                    image.color = new Color(0, 0, 0, bright);
                    yield return new WaitForSeconds(0.005f);
                }
            director.Pause();
            director.Stop();
            if (StopMusic)
                try
                {
                    GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallMusic(AudioSystem.PrevMusic);
                }
                catch { }
            playerAnimator.runtimeAnimatorController = playerAnim;
            Camera1.orthographicSize = 3.5f;
            Camera.SetActive(true);
            gameObject.GetComponent<Appear>().Appears();
            try { GameObject.Find("Delete").SetActive(false); }
            catch { }
            fix = true;
            if (BlackImgFlag)
            {
                for (float bright = 1; bright > 0; bright -= Time.deltaTime)
                {
                    image.color = new Color(0, 0, 0, bright);
                    yield return new WaitForSeconds(0.005f);
                }
            }
            try
            {
                ActiveButton.SetActive(true);
                ControlButton.SetActive(true);
                AttackButton.SetActive(true);
                moveScript.FindJoystick();
                moveScript.moveyes = true;
                moveScript.hero.speed = 0;
            }
            catch
            {

            }
        }
        finally
        {


        }
        yield return new WaitForSeconds(1f);
        image.color = new Color(0, 0, 0, 0);
        comment1.IsLock = true;
        moveScript.activate = false;
        gameObject.SetActive(false);
    }
}
