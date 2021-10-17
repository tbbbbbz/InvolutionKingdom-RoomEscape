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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("IsWalking", true);
        currWaypoint = -1;
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0 && !agent.pathPending)
        {

            setNextWaypoint();
        }

        animator.SetFloat("IdleWalkRatio", agent.velocity.magnitude / agent.speed);

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
}
