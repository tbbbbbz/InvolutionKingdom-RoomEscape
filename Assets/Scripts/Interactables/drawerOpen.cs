using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] private bool openTrigger = false;

    private DialogManager dm;
    private bool playerNearBy;
    private GameObject player;
    private inputscript playerInput;

    private void Start()
    {
        dm = FindObjectOfType<DialogManager>();
        playerNearBy = false;
        animator = GetComponent<Animator>();
        playerInput = FindObjectOfType<inputscript>();
    }

    private void Update()
    {
        if (playerNearBy && Input.GetKeyDown(KeyCode.O) && !openTrigger)
        {
            playerInput.startExploring();
            openTrigger = true;
        }
        if (!playerInput.IsExploring && openTrigger)
        {
            
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!openTrigger && other.CompareTag("Player"))
        {
            Dialog dialog = new Dialog();
            dialog.sentences = new string[] {"press 'O' to open drawer"};
            dm.StartDialog(dialog);
            playerNearBy = true;
            player = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearBy = false;
            dm.clearAndEndDialog();
        }
    }

    public void onOpen()
    {
        FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
    }
}
