using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : SimpleOpener
{
    void Start()
    {
        base.Start();
        isInteractable = false;
    }

    public override void onOpen()
    {
        playerInput.HasCatFood = true;
        Dialog dialog = new Dialog();
        dialog.sentences = new string[] {"found cat food!"};
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        FindObjectOfType<BowlFiller>().isInteractable = true;
    }

    protected override void playersAction()
    {
        playerInput.startExploring();
    }
}