using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatAI : MonoBehaviour
{
    
    public enum BehaviourState
    {
        HIDDEN,
        JUMPING,
        WANDERING,
        FLEEING,
    }


    private NavMeshAgent agent;
    private Animator animator;
    public GameObject[] waypoints;
    private int currWaypoint;
    public BehaviourState behaviourState;
    private Rigidbody rb;
    public inputscript player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        currWaypoint = -1;
        behaviourState = BehaviourState.HIDDEN;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switchBehaviourStates();
        navToNextPoint();
        setWalkingAnimationSpeed();
        checkPlayersAction();
    }

    private void switchBehaviourStates()
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

            case BehaviourState.FLEEING:
                animator.SetBool("IsFleeing", true);
                break;

        }
    }

    private void navToNextPoint()
    {
        if (agent.enabled && agent.remainingDistance == 0 && !agent.pathPending)
        {
            setNextWaypoint();
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

    private void setWalkingAnimationSpeed()
    {
        if (agent.speed != 0)
        {
            animator.SetFloat("IdleWalkRatio", agent.velocity.magnitude / agent.speed);
        }
    }


    private void checkPlayersAction ()
    {
        Vector3 playerPosition = player.gameObject.transform.position;
    }

    public void startJumping ()
    {
        behaviourState = BehaviourState.JUMPING;
    }

    public void afterJumping()
    {
        agent.enabled = true;
        behaviourState = BehaviourState.WANDERING;
        rb.isKinematic = false;
    }

}
