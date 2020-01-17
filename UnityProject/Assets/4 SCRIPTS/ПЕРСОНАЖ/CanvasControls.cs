using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControls : MonoBehaviour
{
    public void Awake()
    {
        GameObject x1 = GameObject.Find("Attack");
        GameObject x2 = GameObject.Find("Action");
        GameObject x3 = GameObject.Find("PhoneControls");
        x1.SetActive(true);
        x2.SetActive(true);
        x3.SetActive(true);
    }
    public void ActiveButt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<moveScript>().ActiveButt();
    }

    public void Aiming()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Aim>().Aiming();
    }

    public void Shooting()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Aim>().Shooting();
    }

    public void Pointr()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().ChangePointer();
    }
}
