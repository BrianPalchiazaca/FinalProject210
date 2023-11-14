using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Camera Camera;
    public float range = 4f;
    public float damage = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log("hit.transform.name");
            Zombie zombie = hit.transform.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.Damaged(damage);
            }

            Enemy2 enemy2 = hit.transform.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                enemy2.Damaged(damage);
            }
        }

    }
}
