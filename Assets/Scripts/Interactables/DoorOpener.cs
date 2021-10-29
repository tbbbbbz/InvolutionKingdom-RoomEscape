using UnityEngine;
using System.Collections;

public class DoorOpener : SimpleOpener
{

    protected override void playersAction()
    {
        playerInput.startExploring();
    }

    public override void onOpen()
    {
        if (this.CompareTag("Exit"))
        {
            EventManager.TriggerEvent<VictoryEvent, Vector3>(FindObjectOfType<inputscript>().gameObject.transform.position);

        }
    }
}
