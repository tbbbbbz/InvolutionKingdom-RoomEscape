using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : SimpleOpener
{
    public DialogTrigger onOpenInfo;
    public SimpleOpener boxOpener;

    void Start()
    {
        base.Start();
        isInteractable = false;
    }

    protected override void playersAction()
    {
        playerInput.startExploring();
    }

    public override void onOpen()
    {
        FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
        onOpenInfo.TriggerDialog();
        boxOpener.SetInteractive(true);
    }
}