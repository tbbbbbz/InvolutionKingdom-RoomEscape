using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureItemTrigger : InteractableObject
{
    public DialogTrigger tipContent;

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && isInteractable)
        {
            playerInput.startExploring();
            dialogTrigger.EndDialog();
        }
    }
}
