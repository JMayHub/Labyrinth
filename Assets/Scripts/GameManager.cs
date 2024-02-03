using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public string doorColor = "";
    public static GameManager Instance { get { return instance; } }
    public event Action OpenDoorEvent;
    //ASL puntuación del jugador
    public float score = 0f;
    public TextMeshProUGUI scoreObject;
    
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

    //Check if the player arrived to the end and shows a win message for feedback.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            UpdateScore(Score.Win);
            Debug.Log("<b><color=yellow>CONGRATULATIONS!!!\nYOU WIN!!!</color></b>");
        }
    }

    // Updates score for the player and changes it on screen
    public void UpdateScore(float number)
    {
        // Avoiding negative score
        Debug.Log(score + number);
        if (score + number < 0)
        {
            score = 0;
        }
        else 
        {
            score += number;
        }

        scoreObject.SetText(score + "");
    }
}