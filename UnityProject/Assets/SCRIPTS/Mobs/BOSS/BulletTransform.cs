using System.Collections;
using UnityEngine;

public class BulletTransform : MonoBehaviour
{
    //private
    private CircleCollider2D col;
    //private Transform Enemy;
    private GameObject Player;
    private Transform trsf;
    private int StAttType;
    private float x, y;
    //public
    public float multiplier = 1;
    public float ForceD = 2;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StAttType = Attack.AttackType;
            x = Attack.x * multiplier;
            y = Attack.y * multiplier; 
        StartCoroutine(WaitDelete());
        Character1.Alert();
        Rigi.AddForce((Player.transform.position - transform.position).normalized * ForceD, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Lifepoint"))
        {
            Character1.MinusHp();
            StartCoroutine(Player.GetComponent<Character1>().Drag(transform.position));
        } 
    }
    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
        Character1.NoAlert();
    }

}
