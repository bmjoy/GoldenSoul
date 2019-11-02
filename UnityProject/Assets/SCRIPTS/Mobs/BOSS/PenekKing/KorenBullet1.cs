using System.Collections;
using UnityEngine;

public class KorenBullet1 : MonoBehaviour
{
    //private
    public bool Destr = false;
    bool ignore = false;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !ignore)
        {
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
            Character1.MinusHp();
            ignore = false;
        }
    }
    public void Update()
    {
        if (Destr)
        {
            Destroy(gameObject);
        }
    }

}
