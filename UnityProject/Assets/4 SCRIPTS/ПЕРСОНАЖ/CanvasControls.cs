using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControls : MonoBehaviour
{
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
}
