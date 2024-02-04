using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float movementSpeed = 0f;
    [SerializeField] float rayLenght = 1f;
    [SerializeField] Transform eyes;
    private Vector3 initialPosition = Vector3.zero;
    private Quaternion initialRotation = Quaternion.identity;
    public LayerMask layerToHitRaycast;
    public bool isAlive = true;

    //Get initial position of the player to use it later to reload his position if he dies.
    private void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.life <= 0)
        {

            isAlive = false;

        }


        if (isAlive)
        {
            Rotate(HorizontalController());
            Move(VerticalController());
            Raycast();
        }

        //Comes back to the initial position and rotation.

        //Also, his life becomes to the max value.
        else
        {
            Dead();

        }

        //Push key to revive
        if (Input.GetKey("return"))
        {
            isAlive = true;
        }
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

    //Shows the raycast and check if it touch any button.
    private void Raycast()
    {
        Vector3 direction = eyes.forward;
        Vector3 target = (eyes.position + (direction * rayLenght));
        RaycastHit hit;

        if(Physics.Raycast(eyes.position, direction, out hit, rayLenght, layerToHitRaycast))
        {
            //Activate a trap to move a wall that hides an enemy to a random position and let the enemy pass to catch the player.
            if(hit.rigidbody.name == "FalseButton")
            {
                Debug.DrawLine(eyes.position, target, Color.red);
                Debug.Log("THIS BUTTON DOESN'T WORK\nIT'S A TRAP!!!");
                //GameObject objectWall = GameObject.Find("FalseWall");
                //GameObject enemy = GameObject.Find("Enemy");
                //Vector3 initialWallPosition = objectWall.transform.position;

                //objectWall.transform.position = new Vector3(initialWallPosition.x, initialWallPosition.y-10, initialWallPosition.z);
                //enemy.GetComponent<EnemyTrap>().Activate();
            }

            //Activate buttons to open doors by color. (Blue button for blue door, green button for green door, red button for red door)
            else
            {
                Vector3 directionHitCollider = (hit.collider.transform.position - eyes.position).normalized;
                Debug.DrawRay(eyes.position, directionHitCollider * rayLenght, Color.red);

                string color = hit.rigidbody.name.Split(' ')[0];
                GameManager.Instance.doorColor = color;
                GameManager.Instance.OpenDoor();
            }
        }

        //Debug for raycast
        else
        {
            Debug.DrawLine(eyes.position, target, Color.blue);
        }
    }

    //Reload the player to the initial position and rotation when he dies.

    //Also, his life becomes to the max value.
    void Dead()
    {
        gameObject.GetComponent<CharacterController>().transform.position = initialPosition;
        gameObject.GetComponent<CharacterController>().transform.rotation = initialRotation;

        GameManager.Instance.life = GameManager.Instance.initialLife;

    }
}
