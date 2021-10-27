using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatAI : InteractableObject
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
    public float fleetTime = 2f;
    private float startFleeTimeStamp;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        currWaypoint = -1;
        behaviourState = BehaviourState.HIDDEN;
        agent.enabled = false;
        isInteractable = false;
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
                animator.SetBool("IsFleeing", false);
                break;

            case BehaviourState.FLEEING:
                animator.SetBool("IsFleeing", true);
                if (Time.realtimeSinceStartup - startFleeTimeStamp >= fleetTime)
                {
                    behaviourState = BehaviourState.WANDERING;
                }
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
        if (playerNearBy && Input.GetKeyDown(KeyCode.C))
        {
            player.startCatching();
        }
        if (playerNearBy && player.IsCatching)
        {
            behaviourState = BehaviourState.FLEEING;
            startFleeTimeStamp = Time.realtimeSinceStartup;
        }
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
        isInteractable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        behaviourState = BehaviourState.WANDERING;
    }

}
