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
        Debug.Log("<b><color=" + GameManager.Instance.doorColor + ">" + GameManager.Instance.doorColor + " Door OPENED</color></b>");
        GameManager.Instance.OpenDoorEvent -= DestroyMe;
    }

    private void DestroyMe()
    {
        string doorName = GameManager.Instance.doorColor + " Door";
        Destroy(GameObject.Find(doorName), 0.5f);
    }
}
