using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Store", menuName = "Scriptable Object/New Store")] // выпадающее меню редактора "Create"
public class GameStorage : ScriptableObject
{
    [SerializeField]
    public bool Alive { get; private set; } = true;

    public float Life { get; private set; }
    public float Speed = 1.5f;
    public float Acceleration = 100;

    public void setAlive(bool value = true) {
        // some mutations
        this.Alive = value;
    }

    public void setLife(int value) {
        // some mutations
        this.Life = value;
    }
}
