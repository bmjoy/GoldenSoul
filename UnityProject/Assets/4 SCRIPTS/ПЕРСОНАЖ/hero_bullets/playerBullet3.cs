using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet3 : MonoBehaviour
{
    Rigidbody2D Rigi;
    public float Force;
    Vector2 Vec;
    // Start is called before the first frame update
    void Start()
    {
        Vec = Vector2.zero;
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(WaitDelete());
        if (moveScript.JStick.HorizontalSnap == 0 && moveScript.JStick.VerticalSnap == 0)
        {
            int V = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetInteger("Vector");
            switch (V)
            {
                case 1:
                    Vec = new Vector2(-1, 0);
                    break;
                case 2:
                    Vec = new Vector2(0, 1);
                    break;
                case 3:
                    Vec = new Vector2(1, 0);
                    break;
                case 4:
                    Vec = new Vector2(0, -1);
                    break;
                case 5:
                    Vec = new Vector2(-1, 1);
                    break;
                case 6:
                    Vec = new Vector2(1, 1);
                    break;
                case 7:
                    Vec = new Vector2(1, -1);
                    break;
                case 8:
                    Vec = new Vector2(-1, -1);
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigi.AddForce(Vec * Force * 11, ForceMode2D.Force);
        Rigi.velocity = Vector2.zero;
        if (Character1.MP < 16)
        {
            StartCoroutine(Delete());
            gameObject.tag = "Untagged";
            return;
        }
        if (Aim.PLEE)
        {
            StartCoroutine(Delete());
            return;
        }
        Vec = new Vector2(moveScript.JStick.Horizontal, moveScript.JStick.Vertical);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullets"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator WaitDelete()
    {
        yield return new WaitForSeconds(10f);
        Rigi.velocity = Vector2.zero;
        gameObject.GetComponent<Animator>().SetBool("Destroy", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator Delete()
    {
        Rigi.velocity = Vector2.zero;
        gameObject.GetComponent<Animator>().SetBool("Destroy", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
