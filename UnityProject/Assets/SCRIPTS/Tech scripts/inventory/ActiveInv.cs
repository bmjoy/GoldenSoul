using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInv : MonoBehaviour
{
    public GameObject InventoryObject;
    private bool Check = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !Check)
        {
            InventoryObject.SetActive(true);
            Check = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && Check)
        {
            InventoryObject.SetActive(false);
            Check = false;
        }
    }
}
