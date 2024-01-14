using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0f;

    // Simple action to make rotation effect for the mills.
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed);
    }
}
