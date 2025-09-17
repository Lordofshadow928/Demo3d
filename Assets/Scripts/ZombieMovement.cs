using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerFoot.position);
        if (distanceToPlayer > reachingRadius)
        {
            anim.SetBool("isWalk", true);
            agent.isStopped = false;
            agent.SetDestination(playerFoot.position);
        }
        else
        {
            anim.SetBool("isWalk", false);
            agent.isStopped = true;
        }
    }

}
