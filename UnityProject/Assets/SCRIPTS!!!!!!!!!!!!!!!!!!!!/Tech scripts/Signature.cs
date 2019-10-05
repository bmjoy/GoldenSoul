using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signature : MonoBehaviour {

    public enum Direction { Left = 1, Up, Right, Down, UpLeft, UpRight, DownRight, DownLeft }

    public static bool FromSide(GameObject player, GameObject subject) {
        Ptp = player.transform.position;
        Stp = subject.transform.position;
        CAD = Character1.AttackDirection
        
        if (
            (Ptp.y < tp.y && (
                (CAD == Direction.UpLeft  && Ptp.x > tp.x)   ||
                 CAD == Direction.Up                         ||
                (CAD == Direction.UpRight && Ptp.x < tp.x))
            )                                        ||
            (CAD == Direction.Left  && Ptp.x > tp.x) ||
            (CAD == Direction.Right && Ptp.x < tp.x) ||
            (Ptp.y > tp.y && (
                (CAD == Direction.DownLeft && Ptp.x > tp.x)  ||
                 CAD == Direction.Down                       ||
                (CAD == Direction.DownRight && Ptp.x < tp.x))
            )
        ) {
            return true;
        } else 
            return false;
    }
}
