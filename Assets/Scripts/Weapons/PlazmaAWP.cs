using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazmaAWP : MonoBehaviour, IRangedWeapon
{
    public Transform FirePoint;
    public AudioClip hitEnemyClip;
    public AudioClip notHitAudioClip;
    public GameObject Bullet;
    public GameObject ColissionEffect;
    public int Damage;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;

    void Start()
    {
        nextFire = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if(nextFire <= Time.time && Input.GetButton("Fire1"))
        {
            CollisionDetection();
            var bullet = Instantiate(Bullet, FirePoint.position, PlayerViewRotation);
            Destroy(bullet, 3);
            nextFire = Time.time + fireRate;
        }

    }

    private void CollisionDetection()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.tag.Equals("Enemy"))
            {
                var hitPos = hit.transform.position;
                hitPos.y = hit.collider.bounds.center.y;
                var explosion = Instantiate(ColissionEffect, hitPos, Quaternion.identity);
                Destroy(explosion, 3);
                hit.collider.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(Damage);
            }
            PlayClip(hitEnemyClip);
        }
        else
        {
            PlayClip(notHitAudioClip);
        }
    }

    private Quaternion PlayerViewRotation => Camera.main.transform.rotation;

    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    } 
}
