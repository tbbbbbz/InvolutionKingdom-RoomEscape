using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : InteractableObject
{
    public float _rotationSpeed = 5f;
    private Quaternion _targetRot;
    private bool rotating;
    private bool hasCommand;

    private void Awake()
    {
        _targetRot = transform.rotation;
        rotating = false;
        hasCommand = false;
    }
    // Update is called once per frame
    void Update()
    {
        bool turnLeft = Input.GetKeyDown(KeyCode.U);
        bool turnRight = Input.GetKeyDown(KeyCode.I);
        if (playerNearBy && !hasCommand && (turnLeft || turnRight))
        {
            _targetRot *= Quaternion.AngleAxis(turnLeft ? -90:90, transform.up);
            playerInput.startExploring();
            hasCommand = true;
        }

        if (playerInput.InMiddleOfAction)
        {
            rotating = true;
        }
        if (rotating) {
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, _rotationSpeed * Time.deltaTime);
        }
        if (transform.rotation == _targetRot)
        {
            hasCommand = false;
            rotating = false;
        }
    }
}