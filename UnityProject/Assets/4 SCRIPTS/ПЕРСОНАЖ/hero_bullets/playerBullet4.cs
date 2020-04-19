using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet4 : MonoBehaviour
{
    float degree;
    bool destroy = true;

    private void Update()
    {

        if (Aim.PLEE)
        {
            if (destroy)
            {
                StartCoroutine(DestroyBullet());
                destroy = false;
            }
            return;
        }
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

    IEnumerator DestroyBullet()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("Disappear", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
