using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public new Rigidbody rigidbody;
    public GameObject impactEffect;
    public int damage = 1;

    public bool damageEnemy;
    public bool damagePlayer;

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
            Destroy(this.gameObject);
        }

        if (other.tag == "Headshot" && damageEnemy)
        {
            other.transform.parent.GetComponent<EnemyHealthController>().DamageEnemy(damage * 2);
            Debug.Log("HEADSHOT");
            Destroy(this.gameObject);
        }

        if(impactEffect != null)
        {
            Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed) * Time.deltaTime), transform.rotation);
        }
    }
}
