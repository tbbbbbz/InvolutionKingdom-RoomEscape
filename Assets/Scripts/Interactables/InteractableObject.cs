using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DialogTrigger))]
public abstract class InteractableObject : MonoBehaviour
{
    protected bool playerNearBy;
    protected inputscript playerInput;
    public bool isInteractable;


    protected DialogTrigger dialogTrigger;
    private bool hasTriggerredDialog;

    protected void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
        playerNearBy = false;
        playerInput = FindObjectOfType<inputscript>();
        isInteractable = true;
        hasTriggerredDialog = false;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearBy = true;

            if (isInteractable)
            {
                dialogTrigger.TriggerDialog();

                hasTriggerredDialog = true;
            }
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearBy = false;
            if (hasTriggerredDialog)
            {
                dialogTrigger.EndDialog();
            }
        }
    }

    public void SetInteractive(bool enableInteractive)
    {
        this.isInteractable = enableInteractive;
    }
}