using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet2 : MonoBehaviour
{
    public Vector2 Vector;
    private bool wasForced = false;
    //public
    public float multiplier = 1;
    public float ForceD = 6;
    float degree;
    private Rigidbody2D Rigi;
    // Start is called before the first frame update
    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(WaitPlee());
        StartCoroutine(WaitDelete());
    }

    // Update is called once per frame
    void Update()
    {
        if (Aim.PLEE) return;
        if (!wasForced)
        {

            degree = (moveScript.JoystickDegree < 361) ? moveScript.JoystickDegree - 90 : 666;

            if (degree == 666)
            {
                switch (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetInteger("Vector"))
                {
                    case 1:
                        degree = 90;
                        break;
                    case 2:
                        degree = 0;
                        break;
                    case 3:
                        degree = -90;
                        break;
                    case 4:
                        degree = 180;
                        break;
                    case 5:
                        degree = 45;
                        break;
                    case 6:
                        degree = -45;
                        break;
                    case 7:
                        degree = -135;
                        break;
                    case 8:
                        degree = -225;
                        break;
                }
            }


            gameObject.transform.rotation = Quaternion.Euler(0, 0, degree);
        }
       
        Vector = (moveScript.JStick.Horizontal != 0 || moveScript.JStick.Vertical != 0) ? new Vector2(moveScript.JStick.HorizontalSnap, moveScript.JStick.VerticalSnap) : Vector;

        if (moveScript.JStick.HorizontalSnap == 0  && moveScript.JStick.VerticalSnap == 0)
        {
            int V = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetInteger("Vector");
            switch (V)
            {
                case 1:
                    Vector = new Vector2(-1, 0);
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
    }

    IEnumerator WaitPlee()
    {
        yield return new WaitForSeconds(0.5f);
        wasForced = true;
        gameObject.GetComponent<Animator>().SetBool("Activate", true);
        gameObject.tag = "PlayerBullet";
        Rigi.AddForce(Vector.normalized * ForceD, ForceMode2D.Impulse);
        StartCoroutine(WaitDelete());
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
