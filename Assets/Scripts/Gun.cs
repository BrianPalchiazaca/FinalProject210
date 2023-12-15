using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera Camera;
    public float range = 20f;
    public float damage = 1f;
    public float FireRate = 1f;
    private float NextTimeShot = 0f;

    public AudioSource GunShot;
    public Animator GunRecoil;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= NextTimeShot)
        {
            NextTimeShot = Time.time + 1f / FireRate;
            Shoot();
            GunShot.Play();
            GunRecoil.Play("GunRecoil");
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            //Debug.Log("hit.transform.name");
            Zombie zombie = hit.transform.GetComponent<Zombie>();
            if (zombie != null)
            {
                Debug.Log("ZomHit");
                zombie.Damaged(damage);
            }

            Enemy2 enemy2 = hit.transform.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                Debug.Log("Enemy2Hit");
                enemy2.Damaged(damage);
            }
        }
    }
}
