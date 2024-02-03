using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent navigator;
    private int destination;
    // Start is called before the first frame update
    void Start()
    {
        navigator = GetComponent<NavMeshAgent>();
        //navigator.isStopped = true;
        destination = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!navigator.pathPending && navigator.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    //Makes the enemy focus on the next WayPoint
    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        navigator.destination = points[destination].position;

        //Reload First WayPoint when the enemy arrives to the last WayPoint.
        if(destination == points.Length-1)
        {
            destination = 0;
        }

        //Next WayPoint
        else
        {
            destination = destination + 1 % points.Length;
        }
    }

    //Gets the navigator property
    public NavMeshAgent getNavigator()
    {
        return navigator;
    }
}
