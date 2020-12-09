using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenWeapon : MonoBehaviour, IRangedWeapon
{
    public Transform FirePoint;
    public GameObject Bullet;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        nextFire = Time.time;
    }

    public void Shoot()
    {
        if (nextFire <= Time.time && Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50f))
            {
                if (Vector3.Distance(Camera.main.transform.position, hit.point) > 2f)
                {
                    FirePoint.LookAt(hit.point);
                }
            }
            else
            {
                FirePoint.LookAt(Camera.main.transform.position + (Camera.main.transform.forward * 50f));
            }

            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
