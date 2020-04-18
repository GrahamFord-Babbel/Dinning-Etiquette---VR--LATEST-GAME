using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Job Summary - An Event Bus (one singular hub) that collects input from multiple players and objects to guide increment or decrement of the score 
public class EventBusScorer : MonoBehaviour
{

    //the RealtimeComponent we will use to collect changes in score and send to the Network
    public ScoreKeeper scoreKeeper;

    //get items that can be Hit by thrown objects - to determine scoring value
    public GameObject dadPlayer;
    public GameObject babyPlayer;
    public GameObject enVironment;
    public GameObject forkZone;

    //for gameplay designer to manipulate - uneven points as if it were even, would 1:1 cancel out the baby's score, never allowing the VR headset to get to 50 and win
    public int dadPoints = 1;
    public int babyPoints = 2;
    public int thrownOoIPoints = 3; //Object of Interest - fork, car, anything non-standard (bonus points)

    //provide a value to control how much the score changes
    private int pointsChanged;

    //get the MovementAI - to log positions of thrown objects for collection in here
    public MovementAI movementAI;

    //determine what value pointsChange should be based on data from collision events
    public void AssessScoreChange(GameObject objectHit, GameObject objectHitter)
    {
        //added so Desktop version only keeps track of dad score - TODO: FIX THIS - need more modular & flexible solution
        if (!babyPlayer.activeSelf)
        {
            //based on if object hit Dad
            if (objectHit == dadPlayer)
            {
                //only control dad location via AI if AI is active
                //TODO 1 - potentially move to seperate script/rename this script
                //TODO 2 - add a UI toggle for the player to turn this ON/OFF in Start Screen
                if (movementAI.enabled)
                {
                    //moves dad AI to object to pickup
                    movementAI.PickUpObject(-dadPoints, objectHitter);
                }
                //if AI not enabled - use this to deactivate the object 
                else if (movementAI.enabled == false)
                {
                    //remove obj
                    objectHitter.SetActive(false);
                }
                //based on what object his dad, set the amount of points assigned
                if (objectHitter.tag == "BabyCollectible")
                {
                    pointsChanged = -dadPoints;
                }
                else if (objectHitter.tag == "BabyWeapon")
                {
                    pointsChanged = thrownOoIPoints;
                }

                //log all the details of the above actions in the Console
                Debug.Log("Points changed by " + pointsChanged + "because " + objectHitter + "hit " + objectHit);
            }

            //send the collected values to ScoreKeeper to adjust the score - score value is private on ScoreKeeper, so allows us to modify that value
            //nearly a redundancy, is there any way to resolve NORMCORE multiplayer and return to only calling this once?
            scoreKeeper.Scored(pointsChanged);
        }

        //added so VR version only keeps track of dad score - TODO: FIX THIS - need bettter solution
        else if (babyPlayer.activeSelf)
        {
            //based on if object hit environment
            if (objectHit == enVironment)
                {
                    //STARTING AI ACTIONS HERE - potentially move to seperate script/rename this script:
                    if (movementAI.enabled)
                    {
                        Debug.Log("DAT SHIT ADDED BABY!");
                        //calls the pickup script
                        movementAI.PickUpObject(babyPoints, objectHitter);
                    }

                    //SCORING ACTIONS
                    if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
                    {
                        pointsChanged = babyPoints;
                    }

                Debug.Log("Points changed by " + pointsChanged + "because " + objectHitter + "hit " + objectHit);

            }
            //nearly a redundancy, is there any way to resolve NORMCORE multiplayer and return to only calling this once?
            scoreKeeper.Scored(pointsChanged);
        }

        //CLEAR VALUE - doing this to eliminate the value being maintained and then being called unintentionally (aka dad not calls baby 2pt value)
        pointsChanged = 0;

        if (objectHit == dadPlayer)
        {
            //remove obj 
            objectHitter.SetActive(false);
        }
    }
}

//TODO - renable for future USE - when more OoI are utilized
////based on if object hit forkzone
//if (objectHit == forkZone)
//{
//    if (objectHitter.tag == "BabyCollectible")
//    {
//        pointsChanged = babyPoints;
//    }
//    else if (objectHitter.tag == "BabyWeapon")
//    {
//        pointsChanged = -dadPoints;
//    }
//    //remove obj
//    objectHitter.SetActive(false);

//    Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
//}

//TODO - renable for future USE - intereacting with Baby player is a component
////based on if object hit baby
//else if (objectHit == babyPlayer)
//{
//    print("Who would hit a baby!");
//}