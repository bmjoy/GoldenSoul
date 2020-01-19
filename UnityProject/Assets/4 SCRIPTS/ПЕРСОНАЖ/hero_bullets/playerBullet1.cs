using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet1 : MonoBehaviour
{
    public Vector2 Vector;
    private bool wasForced = false;
    //public
    public float multiplier = 1;
    public float ForceD = 4;
    private Rigidbody2D Rigi;
    // Start is called before the first frame update
    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector = (moveScript.JStick.Horizontal != 0 || moveScript.JStick.Vertical != 0) ? new Vector2(moveScript.JStick.HorizontalSnap, moveScript.JStick.VerticalSnap) : Vector;

        if(Vector.x == 0 && Vector.y == 0)
        {
            int V = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetInteger("Vector");
            switch (V)
            {
                case 1:
                    Vector = new Vector2(-1,0);
                    break;
                case 2:
                    Vector = new Vector2(0, 1);
                    break;
                case 3:
                    Vector = new Vector2(1, 0);
                    break;
                case 4:
                    Vector = new Vector2(0, -1);
                    break;
                case 5:
                    Vector = new Vector2(-1, 1);
                    break;
                case 6:
                    Vector = new Vector2(1, 1);
                    break;
                case 7:
                    Vector = new Vector2(1, -1);
                    break;
                case 8:
                    Vector = new Vector2(-1, -1);
                    break;
            }

        }

        if (!wasForced && Aim.PLEE)
        {
            gameObject.tag = "PlayerBullet";
            Rigi.AddForce(Vector.normalized * ForceD, ForceMode2D.Impulse);
            StartCoroutine(WaitDelete());
            wasForced = true;
        }
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
