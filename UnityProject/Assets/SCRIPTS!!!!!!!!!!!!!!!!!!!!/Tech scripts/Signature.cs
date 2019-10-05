using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signature : MonoBehaviour
{
    public static bool FromSide(GameObject X, GameObject Y)
    {
        if (X.transform.position.x > Y.transform.position.x && Character1.AttackDirection == 1 ||
                X.transform.position.x > Y.transform.position.x && Character1.AttackDirection == 5 && X.transform.position.y < Y.transform.position.y ||
                X.transform.position.x > Y.transform.position.x && Character1.AttackDirection == 8 && X.transform.position.y > Y.transform.position.y ||

                X.transform.position.y < Y.transform.position.y && Character1.AttackDirection == 2 ||
                X.transform.position.y < Y.transform.position.y && Character1.AttackDirection == 7 && X.transform.position.x < Y.transform.position.x ||
                X.transform.position.y > Y.transform.position.y && Character1.AttackDirection == 8 && X.transform.position.x > Y.transform.position.x ||

                X.transform.position.x < Y.transform.position.x && Character1.AttackDirection == 3 ||
                X.transform.position.x < Y.transform.position.x && Character1.AttackDirection == 6 && X.transform.position.y < Y.transform.position.y ||
                X.transform.position.x < Y.transform.position.x && Character1.AttackDirection == 7 && X.transform.position.y > Y.transform.position.y ||

                X.transform.position.y > Y.transform.position.y && Character1.AttackDirection == 4 ||
                X.transform.position.y < Y.transform.position.y && Character1.AttackDirection == 5 && X.transform.position.x > Y.transform.position.x ||
                X.transform.position.y < Y.transform.position.y && Character1.AttackDirection == 6 && X.transform.position.x < Y.transform.position.x)
        {
            return(true);
        }else
            return (false);
    }
}
