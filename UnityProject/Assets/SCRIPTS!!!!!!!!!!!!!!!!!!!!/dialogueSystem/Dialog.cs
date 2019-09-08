using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Dialog : MonoBehaviour
{
    public int localLang = 1;
    public Image DialogImage;
    public static Image _DialogImage;
    static public Text TextArea;
    public Text Titre;
    static public Text _Titre;
    //Dialogue list
    static public int langflagl;
    static public readonly string[] masDialRus = DialogueMass.Rus;
    static public readonly string[] masDialEng = DialogueMass.Eng;
    static public string[] masDial;
    private static bool flag = true; 

    void Awake()
    {
        TextArea = GetComponent<Text>();
        _DialogImage = DialogImage;
        _DialogImage.enabled = false;
        _Titre = Titre;
    }
    private void Start()
    {
        try
        {
            masDial = (Convert.ToInt32(EventSavingSystem.Language) == 1) ? masDialRus : masDialEng;
        }
        catch
        {
            masDial = (localLang == 1) ? masDialRus : masDialEng;
        }
    }
    public static IEnumerator Dialogue(string inputText, int massav = 0, float latency = 0.05f,float timeDestroy = 5f)
    {
        comment1.IsLock = false;
        _DialogImage.enabled = true;
        avatarevent.avatarchange(massav);
        char[] a = inputText.ToCharArray();
        for(int i = 0; i < inputText.Length;i++)
        {
            TextArea.text = TextArea.text + a[i];
            yield return new WaitForSeconds(latency);
        }
        yield return new WaitForSeconds(timeDestroy);
        TextArea.text = "";
        comment1.IsLock = true;
        disableImage();
        moveScript.enable(true);
    }
    public static IEnumerator Dialogue3(string[] mass,int[] masav,int[] numbers,float latency = 0.05f, float timeDestroy = 5f)
    {
        comment1.IsLock = false;
        _DialogImage.enabled = true;
        for (int j = 0; j < numbers.Length; j++)
        {
            avatarevent.avatarchange(masav[j]);
            char[] a = mass[numbers[j]].ToCharArray();
            for (int i = 0; i < mass[numbers[j]].Length; i++)
            {
                TextArea.text = TextArea.text + a[i];
                yield return new WaitForSeconds(latency);
            }
            avatarevent.avatarstop();
            yield return new WaitForSeconds(timeDestroy);            
            TextArea.text = "";
        }
        comment1.IsLock = true;
        disableImage();
        moveScript.enable(true);
    }
    public static IEnumerator Titres(string inputText, float latency = 0.05f, float timeDestroy = 5f)
    {
        char[] a = inputText.ToCharArray();
        for (int i = 0; i < inputText.Length; i++)
        {
            _Titre.text = _Titre.text + a[i];
            yield return new WaitForSeconds(latency);
        }
        yield return new WaitForSeconds(timeDestroy);
        _Titre.text = "";
        moveScript.enable(true);
    }
    public static void disableImage() {
        avatarevent.avatardisable();
        _DialogImage.enabled = false;
    } 
}
