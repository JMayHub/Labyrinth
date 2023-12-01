using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float movementSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        Rotate(HorizontalController());
        Move(VerticalController());
    }

    void Rotate(float rotation)
    {
        transform.Rotate(new Vector3(0, rotation, 0) * rotationSpeed);
    }

    float HorizontalController()
    {
        return Input.GetAxis("Horizontal");
    }

    void Move(float movement)
    {
        gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(new Vector3(0, 0, movement) * movementSpeed * Time.deltaTime));
    }

    float VerticalController()
    {
        return Input.GetAxis("Vertical");
    }
}
