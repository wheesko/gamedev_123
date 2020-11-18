using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public NavMeshAgent agent;
    public Animator animator;

    public enum AIState
    {
        isIdle,
        isPatrolling,
        isChasing,
        isAttacking
    };

    public AIState currentState;

    public float waitAtPoint = 20f;
    private float waitCounter;

    public float chaseRange;
    public float attackRange = 5f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;

    public int attackDamage = 25;

    void Start()
    {
        waitCounter = waitAtPoint;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        // Temporarily duplicating this outside of the switch statement as we don't have animations
        if (distanceToPlayer < attackRange && attackCounter < 0)
        {
            PlayerController.instance.TakeDamage(attackDamage);
            attackCounter = timeBetweenAttacks;
        }

        attackCounter -= Time.deltaTime;

        switch (currentState)
        {
            case AIState.isIdle:
                animator.SetBool("IsMoving", false);
                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.isPatrolling;
                    agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }

                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                    animator.SetBool("IsMoving", true);
                }
                break;

            case AIState.isPatrolling:
                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint;
                }

                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                }

                animator.SetBool("IsMoving", true);

                break;

            case AIState.isChasing:
                agent.SetDestination(PlayerController.instance.transform.position);

                if (distanceToPlayer <= attackRange)
                {
                    currentState = AIState.isAttacking;
                    animator.SetTrigger("Attack");
                    animator.SetBool("IsMoving", false);

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;
                    attackCounter = timeBetweenAttacks;
                }
                if (distanceToPlayer > chaseRange)
                {
                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint;
                    agent.velocity = Vector3.zero;
                    agent.SetDestination(transform.position);
                }
                break;
            case AIState.isAttacking:

                transform.LookAt(PlayerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    if (distanceToPlayer < attackRange)
                    {
                        animator.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;
                    }
                    else
                    {
                        currentState = AIState.isIdle;
                        waitCounter = waitAtPoint;
                        agent.isStopped = false;
                    }
                }
                break;
        }
    }
}
