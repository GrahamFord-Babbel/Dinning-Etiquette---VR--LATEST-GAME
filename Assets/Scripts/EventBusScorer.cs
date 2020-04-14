using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBusScorer : MonoBehaviour
{

    //get scoreKeeper
    public ScoreKeeper scoreKeeper;

    //get player objects that can be Hit
    public GameObject dadPlayer;
    //a SHITTY way to hack both players not scoring to the NORMCORE server
    public GameObject babyPlayer;
    public GameObject enVironment;
    public GameObject forkZone;

    //provide a value to control Score change
    private int pointsChanged;

    //get the MovementAI - to log positions of thrown objects for collection
    public MovementAI movementAI;


    //determine what value pointsChange should be based on data from collision events
    public void AssessScoreChange(GameObject objectHit, GameObject objectHitter)
    {
        //added so Desktop version only keeps track of dad score - TODO: FIX THIS - need bettter solution
        if (!babyPlayer.activeSelf)
        {
            //based on if object hit Dad
            if (objectHit == dadPlayer)
            {
                //STARTING AI ACTIONS HERE - potentially move to seperate script/rename this script:
                if (movementAI.enabled)
                {
                    Debug.Log("DAT SHIT REMOVED BABY!");
                    //calls the pickup script
                    movementAI.PickUpObject(-1, objectHitter);

                    //trying adding the below conditional if breaks again 3.23
                    //RACE Conflict - object getting delete before removed from list if player fast
                    //if (movementAI.listOfThrownObjects.Contains(objectHitter)) //MAY NOT WORK BECAUSE NEED OBJECT, not object transform
                    //{
                    //DOES NOT WORK, because race condition with pickup removing it
                    //destroy obj
                    Destroy(objectHitter);
                    //}
                }
                //RACE Conflict - object getting delete before removed from list if player fast
                else if (movementAI.enabled == false)
                {
                    //destroy obj
                    Destroy(objectHitter);
                }
                //SCORING ACTIONS
                if (objectHitter.tag == "BabyCollectible")
                {
                    pointsChanged = -1;
                }
                else if (objectHitter.tag == "BabyWeapon")
                {
                    pointsChanged = 2;
                }

                Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
            }
        }

        //based on if object hit forkzone
        else if (objectHit == forkZone)
        {
            if (objectHitter.tag == "BabyCollectible")
            {
                pointsChanged = 1;
            }
            else if (objectHitter.tag == "BabyWeapon")
            {
                pointsChanged = -1;
            }
            //destroy obj
            Destroy(objectHitter);

            Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);
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
                    movementAI.PickUpObject(1, objectHitter);
                }

                //SCORING ACTIONS
                if (objectHitter.tag == "BabyCollectible" || objectHitter.tag == "BabyWeapon")
                {
                    pointsChanged = 1;
                }

                Debug.Log("Points changed because " + objectHitter + "hit " + objectHit);

            }
        }

        //based on if object hit baby
        else if (objectHit == babyPlayer)
        {
            print("Who would hit a baby!");
        }

        //once points to change score have been calculated, change the score
        //TODO- once ScoreKeeper fully updated, remove Scored Function from here and change this to:
        scoreKeeper.Scored(pointsChanged);

        //TODO- delete this if ^ works
        //Scored(pointsChanged);
    }

    ////TODO- delete this if ^ works
    ////FIGURE OUT HOW TO MAKE THIS CONDENSED VERSION OF THE TWO WORK:
    //public void Scored(int points)
    //{
    //    scoreKeeper.gameScore += points;
    //}
}
    
