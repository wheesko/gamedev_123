using System.Collections.Generic;
using UnityEngine;

public class ShotgunDamage : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private List<ParticleCollisionEvent> collisionEvents;
    public int Damage;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    public void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, collisionEvents);

        int eventCount = particleSystem.GetCollisionEvents(other, collisionEvents);
 
        for (int i = 0; i < eventCount; i++)
        {
            if (collisionEvents[i].colliderComponent.gameObject.tag.Equals("Enemy"))
            {
                other.GetComponent<EnemyHealthController>().DamageEnemy(Damage);
            }
        }    
    }
}
