using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorController : InteractableObject
{

    public CanvasGroup endingCanvasCanvasGroup;
    public StatueController[] statues;
    private Animator doorAnimator;
    private Animator barrierAnimator;
    private bool hasBarrier;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        doorAnimator = GetComponent<Animator>();
        barrierAnimator = transform.Find("DoorBarriers").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hasBarrier = false;
        foreach (var s in statues)
        {
            if (!s.headingDoor)
            {
                hasBarrier = true;
                break;
            }
        }
        barrierAnimator.SetBool("Unblock", !hasBarrier);

        if (playerInput.hasKey && !hasBarrier)
        {
            dialogTrigger.dialog.sentences = new string[] { "Press 'O' to open the door." };
            if (playerNearBy && Input.GetKey(KeyCode.O))
            {
                playerInput.startExploring();
                dialogTrigger.EndDialog();
            }
        } else
        {
            dialogTrigger.dialog.sentences = new string[] { "I need to find a way to open the door." };
        }
        
        if (playerNearBy && playerInput.InMiddleOfAction && isInteractable)
        {

            doorAnimator.SetBool("Open", true);
            isInteractable = false;
        }
    }

    public void onOpen()
    {
        EventManager.TriggerEvent<VictoryEvent, Vector3>(FindObjectOfType<inputscript>().gameObject.transform.position);
        endingCanvasCanvasGroup.alpha = 1f;
    }
}
