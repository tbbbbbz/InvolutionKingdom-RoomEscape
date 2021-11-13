using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject player;
    public enum BehaviourState
    {
        IDLE,
        WALK,
        ATTACK,
    }

    public BehaviourState behaviourState
    {
        get; set;
    }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        behaviourState = BehaviourState.IDLE;
    }

    private void Update()
    {
        transform.LookAt(player.transform);

        switch (behaviourState)
        {
            case BehaviourState.IDLE:
                animator.SetBool("Walking", false);
                break;

            case BehaviourState.WALK:
                animator.SetBool("Walking", true);
                break;
            case BehaviourState.ATTACK:
                behaviourState = BehaviourState.IDLE;
                break;

        }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            behaviourState = BehaviourState.ATTACK;
            animator.Play("Attack");
        } else if (other.CompareTag("Obstacle"))
        {
            behaviourState = BehaviourState.IDLE;
        }
    }

}
