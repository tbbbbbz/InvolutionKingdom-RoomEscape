﻿using UnityEngine;
using System.Collections;

public class DoorOpener : SimpleOpener
{
    public CanvasGroup endingCanvasCanvasGroup = null;

    private void Start()
    {
        base.Start();
        if (gameObject.tag.Equals("Exit"))
        {
            isInteractable = false;
        }
    }

    protected override void playersAction()
    {
        playerInput.startExploring();
    }

    public override void onOpen()
    {
        if (gameObject.tag.Equals("Exit"))
        {
            EventManager.TriggerEvent<VictoryEvent, Vector3>(FindObjectOfType<inputscript>().gameObject.transform.position);
            endingCanvasCanvasGroup.alpha = 1f;
        }
    }
}