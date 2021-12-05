using UnityEngine;
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
        if (playerNearBy && playerInput.InMiddleOfAction && isInteractable)
        {
            this.gameObject.transform.Find("BrownSugar").gameObject.SetActive(true);

            if (isInteractable)
            {
                EventManager.TriggerEvent<PotCollidesGroundEvent, Vector3>(transform.position);
            }

            isInteractable = false;
        }
    }
}


