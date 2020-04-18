using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Job Summary - determine when any object hits any other item in the room that could affect score
public class ObjectHasHitV2 : MonoBehaviour
{
    //get the two pieces of data necessary to inform EventBus - TODO - make these private?
    public GameObject objectHit;
    public GameObject objectHitter;

    //get the EventBus to register this as a Publisher
    public EventBusScorer eventBusScorer;

    public void Start()
    {
        //get current object values
        eventBusScorer = GameObject.Find("EventBusScorer").GetComponent<EventBusScorer>();
        objectHit = this.gameObject;
    }

    //will be used for changing scores that hit players
    public void OnTriggerEnter(Collider other)
    {
            //stores the object using that objects collider
            objectHitter = other.gameObject;

            //only call script if appropriate score based objects
            if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
            {
                //Call Event Bus Score Compiler/Processor with parameters
                eventBusScorer.AssessScoreChange(objectHit, objectHitter);
            }
    }
}
