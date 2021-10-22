using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject[] waypoints;
    private int currWaypoint;
    public BehaviourState behaviourState;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        currWaypoint = -1;
        behaviourState = BehaviourState.JUMPING;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (behaviourState)
        {
            case BehaviourState.HIDDEN:
                animator.SetBool("Jumping", false);
                break;

            case BehaviourState.JUMPING:
                animator.SetBool("Jumping", true);
                break;

            case BehaviourState.WANDERING:
                animator.SetBool("IsWalking", true);
                break;

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            agent.enabled = true;
            behaviourState = BehaviourState.WANDERING;
        }

        if (agent.enabled && agent.remainingDistance == 0 && !agent.pathPending)
        {
            setNextWaypoint();
        }
        if (agent.speed != 0)
        {
            animator.SetFloat("IdleWalkRatio", agent.velocity.magnitude / agent.speed);
        }
        

    }

    private void setNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("array of staticWaypoints' length is zero");
        }
        else
        {
                currWaypoint = (currWaypoint + 1)%waypoints.Length;
                agent.SetDestination(waypoints[currWaypoint].transform.position);


        }
    }

    public enum BehaviourState
    {
        HIDDEN,
        JUMPING,
        WANDERING,
    }
}
