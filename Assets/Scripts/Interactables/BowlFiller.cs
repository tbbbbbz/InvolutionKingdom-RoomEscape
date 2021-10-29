﻿using UnityEngine;
using System.Collections;

public class BowlFiller : InteractableObject
{

    private void Start()
    {
        base.Start();
        isInteractable = false;
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
            this.gameObject.transform.Find("BrownSugar").gameObject.SetActive(true);
            isInteractable = false;
        }
    }
}
