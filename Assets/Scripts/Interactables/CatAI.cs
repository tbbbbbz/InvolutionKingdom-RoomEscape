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
        APPROACHING_FOOD,
        EATING,
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
    public GameObject foodPlate;
    public bool isCatchable;

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
                agent.speed = 1f;

                navToNextPoint();
                setWalkingAnimationSpeed();
                checkPlayersAction();
                if (foodPlate.gameObject.transform.Find("BrownSugar").gameObject.active)
                {
                    behaviourState = BehaviourState.APPROACHING_FOOD;
                }
                break;

            case BehaviourState.FLEEING:
                animator.SetBool("IsFleeing", true);
                agent.speed = 2f;
                if (Time.realtimeSinceStartup - startFleeTimeStamp >= fleetTime)
                {
                    behaviourState = BehaviourState.WANDERING;
                }

                navToNextPoint();
                break;

            case BehaviourState.APPROACHING_FOOD:
                agent.SetDestination(foodPlate.transform.position);
                agent.stoppingDistance = 0.3f;
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    behaviourState = BehaviourState.EATING;
                }
                break;

            case BehaviourState.EATING:
                animator.SetBool("Eating", true);
                if (playerNearBy && Input.GetKeyDown(KeyCode.C))
                {
                    player.startCatching();
                }
                if (playerNearBy && player.IsCatching)
                {
                    Dialog dialog = new Dialog();
                    dialog.sentences = new string[] { "Catched the cat, and got the key hung on its neck" };
                    FindObjectOfType<DialogManager>().StartDialog(dialog);
                    isInteractable = false;
                    player.hasKeyToTheDoor = true;
                    this.gameObject.transform.Find("cat_armature").Find("root")
                        .Find("MCH_back.001")
                        .Find("DEF_back.001")
                        .Find("MCH_back.002")
                        .Find("DEF_back.002")
                        .Find("MCH_back.003")
                        .Find("DEF_back.003")
                        .Find("MCH_back.004")
                        .Find("DEF_back.004")
                        .Find("MCH_neck")
                        .Find("Ring").gameObject.SetActive(false);
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
}
