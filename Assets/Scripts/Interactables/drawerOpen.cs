using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : InteractableObject
{
    private Animator animator;


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
            dialogTrigger.EndDialog();
        }
        if (playerNearBy && playerInput.InMiddleOfExploring && isInteractable)
        {
            
            animator.SetBool("Open", true);
            isInteractable = false;
        }
    }

    public void onOpen()
    {
        FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
    }
}
