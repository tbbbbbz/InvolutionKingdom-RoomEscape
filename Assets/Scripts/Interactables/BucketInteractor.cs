using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketInteractor : InteractableObject
{
    // Start is called before the first frame update
    public DialogTrigger paperConerContent;
    public SimpleOpener drawer;

    void Start()
    {
        base.Start();
        isInteractable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && isInteractable)
        {
            playerInput.startExploring();
            dialogTrigger.EndDialog();
            paperConerContent.TriggerDialog();
            drawer.SetInteractive(true);
        }
    }
}