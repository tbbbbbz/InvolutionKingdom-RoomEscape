using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : SimpleOpener
{
    protected override void playersAction()
    {
        playerInput.startExploring();
    }

    public override void onOpen()
    {
        FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
    }
}
