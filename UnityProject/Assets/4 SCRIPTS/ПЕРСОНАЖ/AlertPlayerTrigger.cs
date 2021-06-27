using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPlayerTrigger : MonoBehaviour
{
    public bool on = true;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            switch (on){
                case true:
                Character1.Alert();
                    break;
                case false:
                    Character1.NoAlert();
                    break;
            }
            
        }
    }
}
