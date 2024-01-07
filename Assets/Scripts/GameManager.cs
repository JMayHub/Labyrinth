using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public string doorColor = "";
    public static GameManager Instance { get { return instance; } }
    public event Action OpenDoorEvent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenDoor()
    {
        OpenDoorEvent?.Invoke();
    }
}