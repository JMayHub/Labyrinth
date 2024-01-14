using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OpenDoorEvent += DestroyMe;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        GameManager.Instance.OpenDoorEvent -= DestroyMe;
        Debug.Log("<b><color=" + GameManager.Instance.doorColor + ">" + GameManager.Instance.doorColor + " DOOR OPENED</color></b>");
    }

    //Destroy doors when the player push the buttons and activate the trap when blue button is pushed.
    private void DestroyMe()
    {
        //Destroy door by color button pushed.
        string doorName = GameManager.Instance.doorColor + " Door";
        Destroy(GameObject.Find(doorName), 0.5f);

        //Activate Sphere trap if the blue button is pushed. (Sphere trap is active when the box disappear and the sphere falls to crash with the player)
        if(GameManager.Instance.doorColor == "Blue")
        {
            //Moves box to another random position to make fall the sphere.
            GameObject.Find("Box").transform.position = new Vector3(100, 100, 100);
        }
    }
}
