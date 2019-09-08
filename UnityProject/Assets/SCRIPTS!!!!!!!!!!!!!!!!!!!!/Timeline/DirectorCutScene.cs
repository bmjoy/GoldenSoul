using UnityEngine;
using UnityEngine.Playables;

public class DirectorCutScene : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject Obj;
    void Update()
    {
        if(director.time == director.duration)
        {
            director.Stop();
        }

    }
}