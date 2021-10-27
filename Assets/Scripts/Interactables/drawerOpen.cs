using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : InteractableObject
{
    [SerializeField] private Animator animator = null;

    private DialogTrigger dialogTrigger;


    private void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && isInteractable)
        {
            playerInput.startExploring();
            isInteractable = true;
        }
        if (playerNearBy && playerInput.InMiddleOfExploring && isInteractable)
        {
            
            animator.SetBool("Open", true);
        }
    }

    public void onOpen()
    {
        FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
    }
}
