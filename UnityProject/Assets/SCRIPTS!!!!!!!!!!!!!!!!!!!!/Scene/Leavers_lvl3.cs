using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leavers_lvl3 : MonoBehaviour
{
    public Leaver Obj1;
    public Leaver Obj2;
    public GameObject Tile;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (!Obj1.On && Obj2.On)
        {
            Tile.SetActive(false);
        }
    }
}
