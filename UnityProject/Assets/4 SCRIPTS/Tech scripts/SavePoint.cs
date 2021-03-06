using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject titre;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character1.IndicatorOn();
            if (moveScript.activate)
            {
                moveScript.activate = false;
                EventSavingSystem.SaveAll(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
                GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallSound(2, 0.8f);
                gameObject.GetComponent<Animator>().SetBool("Saved", true);
                titre.SetActive(true);
                Character1.IndicatorOff();
                Destroy(this);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character1.IndicatorOff();
        }
    }

}
