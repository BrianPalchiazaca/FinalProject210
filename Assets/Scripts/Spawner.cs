using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private float delay;
    public Transform spawn;
    public float num = 0;
    

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            GameObject enemy = Instantiate(Enemy, spawn.position, Quaternion.identity);
            delay = num;
        }


    }
}
