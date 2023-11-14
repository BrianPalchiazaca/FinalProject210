using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private float delay;
    public Transform spawn;

    public List<GameObject> Enemies;

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
            Instantiate(Enemy, spawn.position, Quaternion.identity);
            delay = 3;

            //ZombieMovement.Speed = 2;
        }
    }
}
