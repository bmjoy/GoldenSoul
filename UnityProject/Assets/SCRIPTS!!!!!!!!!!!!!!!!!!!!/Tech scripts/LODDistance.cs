using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODDistance : MonoBehaviour
{
    private GameObject[] fovObjects;
    private Transform plr;
    public float Dis = 10f;
    private float timer;
    private void Start()
    {
        fovObjects = GameObject.FindGameObjectsWithTag("fov");
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            for (int i = 0; i < fovObjects.Length; i++)
            {
                if (Vector2.Distance(fovObjects[i].transform.position, transform.position) > Dis)
                    fovObjects[i].SetActive(false);
                else
                    fovObjects[i].SetActive(true);
            }
            timer = 0;
        }
    }
}
