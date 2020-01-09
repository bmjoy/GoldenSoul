using System.Collections;
using UnityEngine;

public class BulletTransform : MonoBehaviour
{
    //private Transform Enemy;
    private GameObject Player;
    private Transform trsf;
    private int StAttType;
    private float x, y;
    Vector2 Vec;
    //public
    public float multiplier = 1f;
    public float ForceD = 2;
    private Rigidbody2D Rigi;

    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(WaitDelete());
        Vec = (Player.transform.position - transform.position).normalized;
        Rigi.AddForce(Vec * ForceD, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.CompareTag("Lifepoint"))
        {
            Character1.MinusHp(20);
            Player.GetComponent<Character1>().DragStart(transform.position);
        } 
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

}
