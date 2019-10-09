using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signature : MonoBehaviour {

    public enum Direction { Left = 1, Up, Right, Down, UpLeft, UpRight, DownRight, DownLeft }

    public static bool FromSide(GameObject player, GameObject subject) {
        Vector2 Ptp = player.transform.position;
        Vector2 Stp = subject.transform.position;
        int CAD = Character1.AttackDirection;
        
        if (
            (Ptp.y < Stp.y && (
                (CAD == (int)Direction.UpLeft  && Ptp.x > Stp.x)    ||
                 CAD == (int)Direction.Up                           ||
                (CAD == (int)Direction.UpRight && Ptp.x < Stp.x))
            )                                              ||
            (CAD == (int)Direction.Left  && Ptp.x > Stp.x) ||
            (CAD == (int)Direction.Right && Ptp.x < Stp.x) ||
            (Ptp.y > Stp.y && (
                (CAD == (int)Direction.DownLeft && Ptp.x > Stp.x)   ||
                 CAD == (int)Direction.Down                         ||
                (CAD == (int)Direction.DownRight && Ptp.x < Stp.x))
            )
        ) {
            return true;
        } else 
            return false;
    }
}
