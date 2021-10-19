using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class RootMotionScript : MonoBehaviour
{

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            Vector3 newPosition = transform.position;
            Vector3 diff = transform.forward * animator.GetFloat("WalkSpeed") * Time.deltaTime;
            if (animator.GetBool("IsForward"))
            {
                transform.position = newPosition + diff;
            } else
            {
                transform.position = newPosition - diff * animator.GetFloat("BackSpeed");
            }
            
        }
    }
}
