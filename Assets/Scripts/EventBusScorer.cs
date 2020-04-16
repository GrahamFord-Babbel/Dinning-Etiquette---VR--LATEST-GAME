﻿using System.Collections;
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

    //because parents are adults and it wouldnt be fair for the baby, so parent needs a handicap 
    //potentially add more OoI (Objects of Interest) to instead give the baby an advantage to make even gameplay
    //for gameplay designer to manipulate
    public int dadPoints = 1;
    public int babyPoints = 2;
    public int thrownOoIPoints = 3; //Object of Interest - fork, car, anything non-standard

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
                    movementAI.PickUpObject(-dadPoints, objectHitter);

                    //trying adding the below conditional if breaks again 3.23
                    //RACE Conflict - object getting delete before removed from list if player fast
                    //if (movementAI.listOfThrownObjects.Contains(objectHitter)) //MAY NOT WORK BECAUSE NEED OBJECT, not object transform
                    //{
                    //DOES NOT WORK, because race condition with pickup removing it


                    //remove obj - RESET LIVE
                    //objectHitter.SetActive(false);
                    //}
                }
                //RACE Conflict - object getting delete before removed from list if player fast
                else if (movementAI.enabled == false)
                {
                    //remove obj - RESET LIVE
                    //objectHitter.SetActive(false);
                }
                //SCORING ACTIONS
                if (objectHitter.tag == "BabyCollectible")
                {
                    pointsChanged = -dadPoints;
                }
                else if (objectHitter.tag == "BabyWeapon")
                {
                    pointsChanged = thrownOoIPoints;
                }

                Debug.Log("Points changed by " + pointsChanged + "because " + objectHitter + "hit " + objectHit);
            }

            //nearly a redundancy, is there any way to resolve NORMCORE multiplayer and return to only calling this once?
            scoreKeeper.Scored(pointsChanged);
        }

        //disabling for time being, possibly use in future
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
        //disabling for time being, possibly use in future
        ////based on if object hit baby
        //else if (objectHit == babyPlayer)
        //{
        //    print("Who would hit a baby!");
        //}

        //once points to change score have been calculated, change the score
        //TODO- once ScoreKeeper fully updated, remove Scored Function from here and change this to:
        //scoreKeeper.Scored(pointsChanged);

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
    
