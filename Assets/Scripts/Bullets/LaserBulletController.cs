using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBulletController : MonoBehaviour
{
    public float Speed = 35;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * Speed;
    }
}
