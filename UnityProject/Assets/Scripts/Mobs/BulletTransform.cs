using System.Collections;
using UnityEngine;

public class BulletTransform : MonoBehaviour
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
        if(StAttType == 1)
            transform.right = plr.GetComponent<Transform>().position - transform.position;
            trsf.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        StartCoroutine(move());
    }
    void Update()   
    {
        switch (StAttType)
        {
            case 0:
                trsf.Translate(x * Attack.BulletSpeed * Time.deltaTime, y * Attack.BulletSpeed *Time.deltaTime, 0);
                break;
            case 1:
                trsf.Translate(Time.deltaTime * Attack.BulletSpeed * multiplier, 0, 0); 
                break;
            case 2:
                trsf.Translate(x * Attack.BulletSpeed * Time.deltaTime, y * Attack.BulletSpeed * Time.deltaTime, 0);
                break;
            case 3:
                if (!Attack.startBulling)
                {
                    transform.right = plr.GetComponent<Transform>().position - transform.position;
                    trsf.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
                }
                else
                    trsf.Translate(Attack.BulletSpeed * Time.deltaTime * 1.1f, 0 , 0);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Lifepoint"))
        {
            Destroy(gameObject);
            lifeAnim.SetInteger("Stage",lifeAnim.GetInteger("Stage")-1);
        }
    }
    IEnumerator move()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
   /* void FireBall()
    {
        transform.right = Enemy.position - transform.position;
        transform.Translate(0.05f,0,0);
        if (Vector2.Distance(Enemy.position, transform.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }*/
}
