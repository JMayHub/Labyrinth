using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float movementSpeed = 0f;
    [SerializeField] float rayLenght = 1f;
    [SerializeField] Transform eyes;
    public LayerMask layerToHitRaycast;

    // Update is called once per frame
    void Update()
    {
        Rotate(HorizontalController());
        Move(VerticalController());
        Raycast();
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

    private void Raycast()
    {
        Vector3 direction = eyes.forward;
        Vector3 target = (eyes.position + (direction * rayLenght));
        RaycastHit hit;

        if(Physics.Raycast(eyes.position, direction, out hit, rayLenght, layerToHitRaycast))
        {
            Vector3 directionHitCollider = (hit.collider.transform.position - eyes.position).normalized;
            Debug.DrawRay(eyes.position, directionHitCollider * rayLenght, Color.red);

            string color = hit.rigidbody.name.Split(' ')[0];
            GameManager.Instance.doorColor = color;
            GameManager.Instance.OpenDoor();
        }
        else
        {
            Debug.DrawLine(eyes.position, target, Color.blue);
        }
    }
}
