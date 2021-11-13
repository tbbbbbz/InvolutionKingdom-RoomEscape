using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerOpen : MonoBehaviour
{
    public bool hasCat;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void panelButtonOnClick()
    {
        animator.SetBool("Open", true);
    }

    public void onOpen()
    {
        if (hasCat)
        {
            FindObjectOfType<CatAI>().behaviourState = CatAI.BehaviourState.JUMPING;
        } else
        {
            FindObjectOfType<ZombieAI>().behaviourState = ZombieAI.BehaviourState.WALK;
        }
        
    }
}