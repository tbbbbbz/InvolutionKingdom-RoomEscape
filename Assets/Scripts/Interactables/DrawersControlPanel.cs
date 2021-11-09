using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersControlPanel : InteractableObject
{
    private GameObject canvas;

    protected void Start()
    {
        base.Start();
        canvas = this.gameObject.transform.Find("Canvas").gameObject;
    }

    private void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O))
        {
            canvas.SetActive(true);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        canvas.SetActive(false);
    }
}
