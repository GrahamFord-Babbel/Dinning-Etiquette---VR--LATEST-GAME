using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHasHitV2 : MonoBehaviour
{
    //get the two pieces of data necessary to inform EventBus - make these private?
    public GameObject objectHit;
    public GameObject objectHitter;

    //get the EventBus to register this as a Publisher
    public EventBusScorer eventBusScorer;

    //REMOVING ALONG WITH EXIT
    //get the MovementAI - to log positions of thrown objects for collection
    //public MovementAI movementAI;

    //NOTE: THESE ARE REPEATATIVE CODE PIECES, CAN WE COMBINE THEM INTO 1?

    public void Start()
    {
        eventBusScorer = GameObject.Find("EventBusScorer").GetComponent<EventBusScorer>();
        objectHit = this.gameObject;
    }

    //will be used for changing scores that hit players
    public void OnTriggerEnter(Collider other)
    {
        //REMOVING ALONG WITH EXIT
        //only progress if Dad character is objectHit
        //if (objectHit.name != "EnvironmentTrigger")
        //{
            //stores the object using that objects collider
            objectHitter = other.gameObject;

            //only call script if appropriate score based objects
            if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
            {
            //IF MOVING TO EventBusScorer works, DELETE THIS SECTION
            //STARTING AI ACTIONS HERE:
            //if (movementAI.enabled)
            //{
            //    //removes the objectHitter from AIMovement List
            //    movementAI.listOfThrownObjects.Remove(objectHitter.transform);
            //    //calls the pickup script
            //    if (movementAI.listOfThrownObjects.Count != 0)
            //    {
            //        movementAI.PickUpObject();
            //    }
            //}
                //Call Event Bus Score Compiler/Processor with parameters
                eventBusScorer.AssessScoreChange(objectHit, objectHitter);
            }
        //}
    }

    //REMOVED BECAUSE BABY HANDS VR WERE TRIGGERING EXIT EVERY TIME AN OBJET WAS PICTED UP
    ////will be used for changing scores that hit environment
    //public void OnTriggerExit(Collider other)
    //{
    //    //stores the object using that objects collider
    //    objectHitter = other.gameObject;

    //    //only call script if appropriate score based objects
    //    if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
    //    {
    //        //IF MOVING TO EventBusScorer works, DELETE THIS SECTION
    //        //STARTING AI ACTIONS HERE:
    //        //if (movementAI.enabled)
    //        //{
    //        //    Debug.Log("How MANY TIMES is this printed");
    //        //    //adds the objectHitter to AIMovement List
    //        //    movementAI.listOfThrownObjects.Add(objectHitter.transform);
    //        //    //calls the pickup script
    //        //    movementAI.PickUpObject();
    //        //}
    //        //Call Event Bus Score Compiler/Processor with parameters
    //        eventBusScorer.AssessScoreChange(objectHit,objectHitter);
    //    }
    //}
}
