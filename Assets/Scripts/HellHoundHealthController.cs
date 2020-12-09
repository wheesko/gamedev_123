using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HellHoundHealthController : EnemyHealthController
{
    public Animator animator;
    public void Update()
    {
        if(currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<EnemyController>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(gameObject, 3.533f);
        }
    }
}
