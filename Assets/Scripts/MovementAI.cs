using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementAI : MonoBehaviour
{
    //get dad AI player
    public NavMeshAgent agent;

    //list of current and future objects AI will go to (pick up)
    public List<Transform> listOfThrownObjects = new List<Transform>();

    //need to start here - 1) how to initiate the first pickup (decoupled), 2) how to initiate going to next pick up (on dad destroy)
    void Update()
    {

        //do some kind of loop to rotate through the list once a item has been added/removed from List

        //MOVING THESE TO THE OBJECT HIT SCRIPT TO MAKE SURE HAPPENS ONLY ONCE

    //    //for picking up the first object
    //    if(listOfThrownObjects.Count == 1)
    //    {
    //        PickUpObject();

    //        //since it is calling repeatedly
    //    }

    //    if (hasPickedUpPrevious)
    //    {
    //        PickUpObject();
    //        hasPickedUpPrevious = false;
    //    }
    }

    //a script that calls set destination?
    public void PickUpObject()
    {
            agent.SetDestination(listOfThrownObjects[0].position);
    }
}
