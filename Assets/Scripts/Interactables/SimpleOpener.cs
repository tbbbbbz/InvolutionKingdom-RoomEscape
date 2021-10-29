using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class SimpleOpener : InteractableObject
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

    public abstract void onOpen();
}