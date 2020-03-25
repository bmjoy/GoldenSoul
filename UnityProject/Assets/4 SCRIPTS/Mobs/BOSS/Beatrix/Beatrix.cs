using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Beatrix : MonoBehaviour
{
    public GameObject slider;
    public int Lifes = 25;
    public int TypeAttack = 1;
    public bool CanDoDamage = false;
    private Animator Anim;
    private Rigidbody2D Rigi;
    private GameObject Heart;
    private GameObject Player;
    private Collider2D Col;
    public bool Active = false; //если активен вызывает атаку
    public bool LastStady = false;
    public Tilemap TC1;
    public Tilemap TC2;
    public Tilemap TC3;
    public float[] posX;
    public float[] posY;
    public GameObject[] Phrases;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
