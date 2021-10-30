using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookReader : InteractableObject
{
    // Start is called before the first frame update
    public DialogTrigger bookContentTrigger;
    void Start()
    {
        base.Start();
        isInteractable = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && isInteractable)
        {
            playerInput.startExploring();
            dialogTrigger.EndDialog();
            isInteractable = false;
            bookContentTrigger.TriggerDialog();
        }
        
    }
}
