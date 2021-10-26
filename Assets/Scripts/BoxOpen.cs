using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : MonoBehaviour
{
    [SerializeField] private Animator box = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                box.Play("OpenBox", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
