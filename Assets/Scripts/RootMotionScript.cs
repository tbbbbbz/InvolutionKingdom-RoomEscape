using UnityEngine;
using System.Collections;

using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class RootMotionScript : MonoBehaviour
{

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            //transform.position = new Vector3(0, 0, animator.GetFloat("WalkSpeed") * 0.01f);
        }
    }
}
