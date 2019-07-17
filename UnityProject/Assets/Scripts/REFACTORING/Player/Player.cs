using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameStorage storage;

    // Start is called before the first frame update
    void Start() {
        storage.setLife(4);
    }

    // Update is called once per frame
    void Update() {
        if(storage.Life == 0) {
            // menuDied.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // todo: this
    }
}
