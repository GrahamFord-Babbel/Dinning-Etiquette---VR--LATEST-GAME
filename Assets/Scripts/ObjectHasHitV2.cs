using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHasHitV2 : MonoBehaviour
{
    //get the two pieces of data necessary to inform EventBus
    public GameObject objectHit;
    public GameObject objectHitter;

    //get the EventBus to register this as a Publisher
    public EventBusScorer eventBusScorer;

    //NOTE: THESE ARE SUPER REPEATATIVE CODE PIECES, CAN WE COMBINE THEM INTO 1?

    public void Start()
    {
        eventBusScorer = GameObject.Find("EventBusScorer").GetComponent<EventBusScorer>();
        objectHit = this.gameObject;
    }

    //will be used for changing scores that hit players
    public void OnTriggerEnter(Collider other)
    {
        if (objectHit.name != "EnvironmentTrigger")
        {
            //stores the object using that objects collider
            objectHitter = other.gameObject;

            //only call script if appropriate score based objects
            if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
            {
                //Call Event Bus Score Compiler/Processor with parameters
                eventBusScorer.AssessScoreChange(objectHit, objectHitter);

                //calling Destroy Object here had issues
            }
        }
    }

    //will be used for changing scores that hit environment
    public void OnTriggerExit(Collider other)
    {
        //stores the object using that objects collider
        objectHitter = other.gameObject;

        //only call script if appropriate score based objects
        if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
        {
            //Call Event Bus Score Compiler/Processor with parameters
            eventBusScorer.AssessScoreChange(objectHit,objectHitter);
        }

            //calling Destroy Object here had issues
    }
}
