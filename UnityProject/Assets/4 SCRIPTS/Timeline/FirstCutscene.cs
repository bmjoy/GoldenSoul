using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{
    public GameObject DirectorObject;
    public PlayableDirector Director;
    public float X;
    public float Y;
    bool active = true;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (active)
        {
            moveScript.hero.speed = 0;
            moveScript.moveyes = false;
            active = false;
            DirectorObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}
