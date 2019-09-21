using UnityEngine;
using UnityEngine.Playables;

public class DirectorCutScene : MonoBehaviour
{
    bool fix = false;
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

    private void Update()
    {
        if (moveScript.activate && Stopable)
        { 
            director.Pause();
            director.Stop();
            playerAnimator.runtimeAnimatorController = playerAnim;
            Dialog.disableImage();
            foreach (activeComment i in Comms)
            {
                i.StopAllCoroutines();
            }
            Dialog.TextArea.text = "";
            moveScript.activate = false;
        }
        if (director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }
}