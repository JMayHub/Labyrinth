using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Vector3 initialPosition = Vector3.zero;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    //Check if any type of trap touched the player and reload positions and states of the active traps.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            Debug.Log("<b><color=purple>YOU ARE DEAD</color>\n<color=yellow>PRESS ENTER TO REVIVE</color></b>");
            other.gameObject.GetComponent<PlayerController>().isAlive = false;
            gameObject.transform.position = initialPosition;
            GameObject.Find("Box").transform.position = Vector3.zero;
        }
    }

    //Check if any type of trap touched the player and reload positions and states of the active traps.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("<b><color=purple>YOU ARE DEAD</color>\n<color=yellow>PRESS ENTER TO REVIVE</color></b>");
            collision.gameObject.GetComponent<PlayerController>().isAlive = false;
            gameObject.transform.position = initialPosition;
            GameObject.Find("Box").transform.position = Vector3.zero;
        }
    }
}