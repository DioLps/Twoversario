using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    [SerializeField]
    private Transform playerPosition;

    public bool canFollow = false;

    private Animator animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFollow)
        {
            agent.SetDestination(playerPosition.position);

            if(agent.remainingDistance > agent.stoppingDistance)
            {
                animator.Play("Run");
            } else
            {
                animator.Play("Idle_A");
            }
        }
    }
}
