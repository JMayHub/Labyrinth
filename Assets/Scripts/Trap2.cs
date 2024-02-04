using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
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

            GameManager.Instance.DamagePlayer();

            if(GameManager.Instance.life <= 0)
            {

                DeadTrap2();
                other.gameObject.GetComponent<PlayerController>().isAlive = false;

            }


        }
    }

    //Check if any type of trap touched the player and reload positions and states of the active traps.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {

            GameManager.Instance.DamagePlayer();

            if (GameManager.Instance.life <= 0)
            {

                DeadTrap2();
                collision.gameObject.GetComponent<PlayerController>().isAlive = false;

            }


        }
    }


    //Is dead when life reaches to zero.
    public void DeadTrap2()
    {

        Debug.Log("<b><color=purple>YOU ARE DEAD</color>\n<color=yellow>PRESS ENTER TO REVIVE</color></b>");
        GameManager.Instance.UpdateScore(Score.Death);
        gameObject.transform.position = initialPosition;
        GameObject.Find("Box").transform.position = Vector3.zero;

    }

}
