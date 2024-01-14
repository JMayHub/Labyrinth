using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0f;
    private bool isActive = false;
    private Vector3 initialWallPosition = Vector3.zero;
    GameObject objectWall;

    //Get initial postions of the false wall that hides the enemy to reload his position later if an enemy touched the player.
    private void Start()
    {
        objectWall = GameObject.Find("False Wall");
        initialWallPosition = objectWall.transform.position;
    }

    //Moves the enemy
    void Update()
    {
        if (isActive)
        {
            gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime));
        }
    }

    //Check if an enemy touched the player and reload positions and states of the active enemies.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            objectWall.transform.position = initialWallPosition;
            isActive = false;
        }
    }

    //Set Enemy state to active.
    public void Activate()
    {
        isActive = true;
    }
}
