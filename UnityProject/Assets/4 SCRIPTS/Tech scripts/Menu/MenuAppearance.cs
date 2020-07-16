using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAppearance : MonoBehaviour
{
    private Image Img;
    public Image Logo;
    //public Image Mw;
    public Image Ll;
    public Image Gs;
    void Start()
    {
        Img = GetComponent<Image>();
        Img.color = new Color(0, 0, 0, 1);
        if (MainMenu.category == 2)
        {
            StartCoroutine(Appearance2());
        }
        else
        {
            StartCoroutine(Appearance());
        }
        
        Logo.color = new Color(255, 255, 255, 0);
        //Mw.color = new Color(255, 165, 246, 0);
        Ll.color = new Color(255, 165, 246, 0);
        Gs.color = new Color(255, 255, 255, 0);
    }
    IEnumerator Appearance()
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            Logo.color = new Color(255, 255, 255, bright);
            //Mw.color = new Color(255, 165, 246, bright);
            Ll.color = new Color(255, 165, 246, bright);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(2f);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Logo.color = new Color(255, 255, 255, bright);
            //Mw.color = new Color(255, 165, 246, bright);
            Ll.color = new Color(255, 165, 246, bright);
            yield return new WaitForSeconds(0.002f);
        }
        Logo.color = new Color(255, 255, 255, 0);
        //Mw.color = new Color(255, 165, 246, 0);
        Ll.color = new Color(255, 165, 246, 0);
        yield return new WaitForSeconds(1f);
        for (float bright = 0; bright < 1; bright += Time.deltaTime * 2)
        {
            Gs.color = new Color(255, 255, 255, bright);
            yield return new WaitForSeconds(0.002f);
        }
        yield return new WaitForSeconds(2f);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Gs.color = new Color(255, 255, 255, bright);
            yield return new WaitForSeconds(0.002f);
        }

        Gs.color = new Color(255, 255, 255,0);
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Img.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(gameObject);
    }

    IEnumerator Appearance2()
    {
        for (float bright = 1; bright > 0; bright -= Time.deltaTime * 2)
        {
            Img.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(gameObject);
    }

    IEnumerator Disappearance()
    {
        for (float bright = 0; bright < 1; bright += Time.deltaTime)
        {
            Img.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
