using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    public Vector3 newPosition;
    public Quaternion newRotation;

    [SerializeField] Vector2 min;
    [SerializeField] Vector2 max;
    [SerializeField] Vector2 yRotationRange;

    [SerializeField] [Range(0.01f, 0.1f)] float lerpSpeed = 0.05f;

    void Awake()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(transform.position, newPosition) < 1f)
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        var xPos = Random.Range(min.x, max.x);
        var zPos = Random.Range(min.y, max.y);

        newPosition = new Vector3(xPos, 0, zPos);
        newRotation = Quaternion.Euler(0, Random.Range(yRotationRange.x, yRotationRange.y), 0);
    }
}
