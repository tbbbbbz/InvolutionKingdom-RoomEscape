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

    protected abstract void playersAction();

    private void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && isInteractable)
        {
            playersAction();
            dialogTrigger.EndDialog();
        }
        if (playerNearBy && playerInput.InMiddleOfAction && isInteractable)
        {

            animator.SetBool("Open", true);
            isInteractable = false;
        }
    }

    public abstract void onOpen();
}