using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnStep1 : MonoBehaviour
{
    public int idmusic;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallMusic(idmusic);
            Destroy(gameObject);
        }
    }
}
