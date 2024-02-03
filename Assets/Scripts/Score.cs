using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Set de puntuaciones
    public const float Win = 1000;
    public const float Death = -300;
    public const float OpenDoor = 100;
    public const float Injury = -100;
    public const float KillEnemy = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.UpdateScore(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
