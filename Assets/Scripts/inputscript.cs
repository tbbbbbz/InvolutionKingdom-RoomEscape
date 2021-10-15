using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputscript : MonoBehaviour
{
    private Animator animator;
    private Vector3 direction;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        bool hasMoveH = !Mathf.Approximately(moveH, 0);
        bool hasMoveV = !Mathf.Approximately(moveV, 0);

        bool isWalking = hasMoveH || hasMoveV;
        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            direction = new Vector3(moveH, 0, moveV);
            direction.Normalize();
        }
    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(rotation);
    }
}
