using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimLevel : MonoBehaviour
{
    public Image image;
    void Start()
    {
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, 1 - bright);
            yield return new WaitForSeconds(0.0005f);
        }
        Destroy(this);
    }
}
