using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStep : MonoBehaviour
{
    public bool delete = true;
    public int idmusic = 1;
    public string name = "name";
    private bool wasplayed = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !wasplayed && idmusic != AudioSystem.indexMusicNow)
        {
            if(GameObject.Find("AudioSystem").GetComponent<AudioSystem>().CallMusic(idmusic - 1))                 
                StartCoroutine(StartTitreAndDelete());
            wasplayed = true;
        }
    }

    private IEnumerator StartTitreAndDelete()
    {      
        StartCoroutine(Dialog.Titres(name, 0.05f, 2));
        yield return new WaitForSeconds(5f);
        if(delete)
        Destroy(gameObject);
    }
}
