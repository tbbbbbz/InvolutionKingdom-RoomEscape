﻿using UnityEngine;
using System.Collections;

public class DoorOpener : SimpleOpener
{

    protected override void playersAction()
    {
        playerInput.startExploring();
    }

    public override void onOpen()
    {
    }
}
