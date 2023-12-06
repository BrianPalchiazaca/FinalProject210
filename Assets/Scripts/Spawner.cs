using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private float delay;
    public Transform spawn;
    public float num = 0;
    


    public List<GameObject> EnemyList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            GameObject enemy = Instantiate(Enemy, spawn.position, Quaternion.identity);
            delay = num;
            EnemyList.Add(enemy);

            //ZombieMovement.Speed = 2;
        }


    }
}
