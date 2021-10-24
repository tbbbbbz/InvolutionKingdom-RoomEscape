using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor1 = null;
    [SerializeField] private Animator myDoor2 = null;

    [SerializeField] private bool openTrigger1 = false;
    [SerializeField] private bool openTrigger2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger1)
            {
                myDoor1.Play("OpenDoor1", 0, 0.0f);
                myDoor2.Play("OpenDoor2", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (openTrigger2)
            {
                myDoor1.Play("OpenDoor11", 0, 0.0f);
                myDoor2.Play("OpenDoor22", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
