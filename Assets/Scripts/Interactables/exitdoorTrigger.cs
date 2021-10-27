using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitdoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor1 = null;
    [SerializeField] private Animator myDoor2 = null;

    [SerializeField] private bool openTrigger1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger1)
            {
                myDoor1.Play("ExitdoorOpen", 0, 0.0f);
                myDoor2.Play("Exitdoor2Open", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
