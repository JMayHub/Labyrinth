using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float rayLenght = 1f;
    [SerializeField] Transform eyes;
    public LayerMask layerToHitRaycast;

    //Get initial position of the player to use it later to reload his position if he dies.
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    //Shows the raycast and check if it touch any button.
    private void Raycast()
    {
        Vector3 direction = eyes.forward;
        Vector3 target = (eyes.position + (direction * rayLenght));
        RaycastHit hit;

        if (Physics.Raycast(eyes.position, direction, out hit, rayLenght, layerToHitRaycast))
        {
            Debug.DrawLine(eyes.position, target, Color.red);
            Debug.Log("I FOUND YOU!!! >:v");
        }

        //Debug for raycast
        else
        {
            Debug.DrawLine(eyes.position, target, Color.blue);
        }
    }
}
