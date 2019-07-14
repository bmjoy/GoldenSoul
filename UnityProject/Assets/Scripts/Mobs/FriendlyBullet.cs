using System.Collections;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    //private
    private CircleCollider2D col; //коллайдер сердечка
    private GameObject life;
    private Animator lifeAnim;
    //private Transform Enemy;
    private GameObject plr;
    private Transform trsf;
    private int StAttType;
    private float x, y;
    //public
    public float multiplier = 1;
    void Start()
    {
        plr = Attack.hero;
        life = GameObject.FindGameObjectWithTag("Life"); // Ищем обьект лайф
        lifeAnim = life.GetComponent<Animator>();
        StAttType = Attack.AttackType;
        //Enemy = Cast.FocusedEnemy.transform;
        trsf = GetComponent<Transform>();
        x = Attack.x * multiplier;
        y = Attack.y * multiplier;
        if (StAttType == 1)
            transform.right = plr.GetComponent<Transform>().position - transform.position;
        trsf.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        StartCoroutine(move());
    }
    void Update()
    {
        trsf.Translate(x * 1 * Time.deltaTime, y * 1 * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Lifepoint"))
        {
            Destroy(gameObject);
            if (lifeAnim.GetInteger("Stage") != 5) 
            lifeAnim.SetInteger("Stage", lifeAnim.GetInteger("Stage") + 1);
        }
    }
    IEnumerator move()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}