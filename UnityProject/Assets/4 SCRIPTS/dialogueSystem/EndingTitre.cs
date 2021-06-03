using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class EndingTitre : MonoBehaviour
{
    public string russian;
    public string english;
    private string message;
    private Text Text1;
    void Start()
    {
        try
        {
            message = (Convert.ToInt32(EventSavingSystem.Language) == 1) ? russian : english; //поменять
            print(EventSavingSystem.Language);
        }
        catch
        {
            message = russian;
        }
        Text1 = gameObject.GetComponent<Text>();
        Text1.text = message;
    }

}
