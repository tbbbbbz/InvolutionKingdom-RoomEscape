using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputscript : MonoBehaviour
{
    private Animator animator;
    private Vector3 direction;
    private Rigidbody rb;
    private float turn;
    public float turnSensitivity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveV = Input.GetAxis("Vertical");

        bool hasMoveV = !Mathf.Approximately(moveV, 0);

        if (!hasMoveV)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("walkingBackward", false);
        } else if (moveV > 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("walkingBackward", false);
        } else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("walkingBackward", true);
        }

        float moveH = Input.GetAxis("Horizontal");
        turn += moveH * turnSensitivity;


        //turn += Input.GetAxis("Mouse X") * turnSensitivity;
        transform.localRotation = Quaternion.Euler(0, turn, 0);
        
    }

}
