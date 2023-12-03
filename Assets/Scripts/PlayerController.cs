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

    //Player rotation with the specified direction and rotation speed.
    void Rotate(float rotation)
    {
        transform.Rotate(new Vector3(0, rotation, 0) * rotationSpeed);
    }

    //Get Axis from the horizontal player control.  
    float HorizontalController()
    {
        return Input.GetAxis("Horizontal");
    }

    //Set a new movement for the player specified by the controller and movement speed.
    void Move(float movement)
    {
        gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(new Vector3(0, 0, movement) * movementSpeed * Time.deltaTime));
    }

    //Get Axis from the vertical player control. 
    float VerticalController()
    {
        return Input.GetAxis("Vertical");
    }
}
