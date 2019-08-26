using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrder : MonoBehaviour
{
    static public void ChangeLayerOrder(Renderer rend, Transform obj, Transform hero)
    {
        if (obj.position.y > hero.position.y)
        {
            rend.sortingOrder = 3;
        }
        else
        {
            rend.sortingOrder = 8;
        }
    }
}
