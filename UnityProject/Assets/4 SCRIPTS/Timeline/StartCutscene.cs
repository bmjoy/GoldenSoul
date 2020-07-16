using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject DirectorObject;
    public PlayableDirector Director;
    public float X;
    public float Y ;
    bool active = true;
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player") && active)
        {
            active = false;
            StartCoroutine(StartCS());
        }
    }
    public IEnumerator StartCS()
    {
        moveScript.hero.speed = 0;
        moveScript.moveyes = false;
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        if (X != 0 && Y != 0){
        GameObject.Find("hero").transform.position = new Vector2(X, Y);
        }

        DirectorObject.SetActive(true);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        moveScript.moveyes = true;
        Destroy(gameObject);
    }
}
