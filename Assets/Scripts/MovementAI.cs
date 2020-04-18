using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Job Summary - creates a list of the objects thrown so AI knows where to go next to pick up objects (and score)
public class MovementAI : MonoBehaviour
{
    //get dad AI player - to tell him where to go
    public NavMeshAgent agent;

    //list of current and future objects AI will go to (pick up)
    public List<GameObject> listOfThrownObjects = new List<GameObject>();

    //uses Unity's NavMesh system to direct the AI to the thrown object location, and add or subtract from the existing object list
    public void PickUpObject(int incrementAmount, GameObject thrownObject)
    {
        //if object hit floor, add
        if(incrementAmount > 0)
        {
            listOfThrownObjects.Add(thrownObject);

        }
        //if object hit dad, remove
        if(incrementAmount < 0)
        {
            listOfThrownObjects.Remove(thrownObject);
        }
        //only set a destination if there is still an object in the LIST
        if(listOfThrownObjects.Count != 0)
        {
            agent.SetDestination(listOfThrownObjects[0].transform.position);
        }
    }
}
